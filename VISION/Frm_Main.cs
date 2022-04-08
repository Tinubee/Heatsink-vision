using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Cognex.VisionPro;
using System.Runtime.InteropServices;
using Cognex.VisionPro.Display;
using System.IO.Ports;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using System.Drawing.Imaging;
using System.Reflection;
using KimLib;

namespace VISION
{
    public delegate void EventCallBack(Bitmap bmp);
    public partial class Frm_Main : Form
    {
        Log log = new Log();
        public List<Basler.Pylon.ICameraInfo> AllCams;// 컴퓨터에 접근 된 카메라 리스트
        public Basler.Pylon.Camera[] Cam = new Basler.Pylon.Camera[3];// 프로그램에서 제어 할 카메라.
        public bool[] CameraStats = new bool[3]; //카메라 상태 체크
        private Basler.Pylon.PixelDataConverter ImageConverter = new Basler.Pylon.PixelDataConverter(); // 이미지 컨버터
        private Basler.Pylon.IEnumParameter PixelParameter = null; // 픽셀 컨트롤 파라미터
        private Basler.Pylon.IFloatParameter ExposureParameter = null; // 노출 컨트롤 파라미터
        private bool isFirst = true;
        private bool AcqEnable = false;
        private int FreamCount = 0;
        private string[] CameraSerialNumber = new string[3]; //카메라 시리얼번호
        private int CameraNumber; //카메라 번호
        public Stopwatch[] InspectTime = new Stopwatch[3]; //검사시간
        Frm_Loading frm_loading; //로딩화면 
        private Class_Common cm { get { return Program.cm; } } //에러 메세지 보여주기.
        public CogImage8Grey[] Monoimage = new CogImage8Grey[3]; //흑백이미지
        internal Frm_ToolSetUp frm_toolsetup; //툴셋업창 화면
        //public SerialPort LightControl; //조명컨트롤러

        private CogImage8Grey Fiximage; //PMAlign툴의 결과이미지(픽스쳐이미지)
        private string FimageSpace; //PMAlign툴 SpaceName(보정하기위해)

        private Cogs.Model TempModel; //모델
        private Cogs.Blob[,] TempBlobs; //블롭툴
        private Cogs.Line[,] TempLines; //라인툴
        private Cogs.Circle[,] TempCircles; //써클툴
        private Cogs.MultiPMAlign[,] TempMulti; //멀티패턴툴
        private Cogs.Caliper[,] TempCalipers; //캘리퍼툴

        private bool[,] TempLineEnable; //라인툴 사용여부
        private bool[,] TempBlobEnable;//블롭툴 사용여부
        private bool[,] TempCircleEnable; //써클툴 사용여부
        private bool[,] TempMultiEnable; //멀티패턴툴 사용여부
        private int[,] TempBlobOKCount;//블롭툴 설정갯수
        private int[,] TempBlobFixPatternNumber;
        private int[,] TempLineFixPatternNumber;
        private bool[,] TempCaliperEnable; //캘리퍼툴 사용여부

        private PGgloble Glob; //전역변수 - CLASS "PGgloble" 참고.
        public bool AutoRun = false; //오토런 상태
        public bool LightStats = false; //조명 상태
        public bool[] InspectResult = new bool[3]; //검사결과.
        public bool[] PatternInspectResult = new bool[3];
        public bool[] BlobInspectResult = new bool[3];
        public bool Modelchange = false; //모델체인지
        //public Stopwatch[] InspectTime = new Stopwatch[5]; //검사시간
        public double[] OK_Count = new double[3]; //양품개수
        public double[] NG_Count = new double[3]; //NG품개수
        public double[] TOTAL_Count = new double[3]; //총개수
        public double[] NG_Rate = new double[3]; //총개수
        public bool[] InspectFlag = new bool[3]; //검사 플래그.

        private int LabelPointX = 600;
        private int LabelPointY = 100;

        Button[] btn_Input; //Input버튼
        Button[] btn_Output; //Output버튼

        Thread snap1; //CAM1 Shot 쓰레드
        Thread snap2; //CAM2 Shot 쓰레드
        Thread snap3; //CAM3 Shot 쓰레드
      

        Label[] OK_Label; //수량 OK 라벨
        Label[] NG_Label; //수량 NG 라벨
        Label[] TOTAL_Label; //총수량 라벨
        Label[] NGRATE_Label; //불량률 라벨
        Label[] CameraStats_Label; //카메라 상태 체크 라벨
        CogDisplay[] MainCogDisplay; //메인폼 디스플레이 

        #region ADLINK DIO
        //PLC <-> PC 통신 시 I/O 확인하는 변수들
        public short m_dev;
        bool[] gbool_di = new bool[16];
        bool[] re_gbool_di = new bool[16];
        bool[] gbool_do = new bool[16];
        ushort[] didata = new ushort[16];
        #endregion 

        public Frm_Main(Frm_Loading f)
        {
            frm_loading = f; //처음시작 Loading Form
            InitializeComponent();
            MainCogDisplay = new CogDisplay[3] { cdyDisplay, cdyDisplay2, cdyDisplay3};
            Glob = PGgloble.getInstance; //전역변수 사용
            btn_Input = new Button[15] { btn_INPUT0, btn_INPUT1, btn_INPUT2, btn_INPUT3, btn_INPUT4, btn_INPUT5, btn_INPUT6, btn_INPUT7, btn_INPUT8, btn_INPUT9, btn_INPUT10, btn_INPUT11, btn_INPUT12, btn_INPUT13, btn_INPUT14 };
            btn_Output = new Button[15] { btn_Output0, btn_Output1, btn_Output2, btn_Output3, btn_Output4, btn_Output5, btn_Output6, btn_Output7, btn_Output8, btn_Output9, btn_Output10, btn_Output11, btn_Output12, btn_Output13, btn_Output14 };
            StandFirst(); //처음 Setting해줘야 하는 부분.
            Glob.RunnModel = new Cogs.Model(); //코그넥스 모델 확인.
        }
        private void Log_OnLogEvent(object sender, LogItem e)
        {
            logControl1.ManageLog(e);
        }
        public void StandFirst()
        {
            Directory.CreateDirectory(Glob.MODELROOT); // 프로그램 모델 루트 디렉토리 작성

            INIControl Config = new INIControl(Glob.CONFIGFILE);
            INIControl Modellist = new INIControl(Glob.MODELLIST);
            INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);
            INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로

            for (int i = 0; i < Program.CameraList.Count(); i++) //카메라에서 찍은 이미지 변수 초기화 과정.
            {
                Monoimage[i] = new CogImage8Grey();
            }
            for (int i = 0; i < Program.CameraList.Count(); i++)
            {
                CameraSerialNumber[i] = Program.CameraList[i].SerialNum;
            }

            Glob.ImageSaveRoot = setting.ReadData("SYSTEM", "Image Save Root"); //이미지 저장 경로
            Glob.DataSaveRoot = setting.ReadData("SYSTEM", "Data Save Root"); //데이터 저장 경로
            log.InitializeLog($"{Glob.DataSaveRoot}\\Log");
            log.OnLogEvent += Log_OnLogEvent;
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            lb_Ver.Text = $"Ver. {Glob.PROGRAM_VERSION}"; //프로그램버전표시.
            Initialize_CamvalueInit(); //카메라 초기화
            LoadSetup(); //프로그램 셋팅 로드.
            Initialize_LightControl(); //조명컨트롤러 연결.
            InitializeDIO();
            CalibrationDataLoad();
            Initialize_CameraInit(); //카메라 초기화 및 연결 - 카메라연결을 제일 마지막에 해줘야한다.
            CameraExposureSet();
            timer_Setting.Start(); //타이머에서 계속해서 확인하는 것들
            log.AddLogMessage(LogType.Infomation, 0, "Vision Program Start");
        }
        private void CameraExposureSet()
        {
            INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);  // ini파일 경로
            string LastModel = CFGFILE.ReadData("LASTMODEL", "NAME"); //마지막 사용모델 확인.
            INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{LastModel}\\CamSet.ini");
            for (int i = 0; i < 3; i++)
            {
                ExposureSet(i, Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"))); //노출값 설정
            }
        }
        private void InitializeDIO()
        {
            try
            {
                //카드번호 입력.
                m_dev = DASK.Register_Card(DASK.PCI_7230, 0);
                if (m_dev < 0)
                {
                    log.AddLogMessage(LogType.Error, 0, "Register_Card error!");
                }
                else
                {
                    ushort i;
                    short result;
                    for (i = 0; i < 16; i++)
                    {
                        result = DASK.DI_ReadLine((ushort)m_dev, 0, i, out didata[i]); //InPut 읽음 (카드넘버,포트0번,In단자번호,버퍼메모리(In단자1일때 1,In단자0일때 0) 
                        if (didata[i] == 1)
                        {
                            gbool_di[i] = true;
                        }
                        else
                        {
                            gbool_di[i] = false;
                        }
                    }
                    bk_IO.RunWorkerAsync(); // IO 백그라운드 스타트
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{ee.Message}");
            }
        }
        public void SnapShot1()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[0].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[0].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot2()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[1].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[1].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        public void SnapShot3()
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[2].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[2].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
       
        public void SnapShot(int CamNumber)
        {
            try
            {
                //StatsCheck($"CAM{CamNumber + 1} SnapShot Start", false);
                Cam[CamNumber].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.SingleFrame);
                Cam[CamNumber].StreamGrabber.Start(1, Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        public void StartLive(int CamNumber)
        {
            FreamCount = 0;
            AcqEnable = true;
            Cam[CamNumber].Parameters[Basler.Pylon.PLCamera.AcquisitionMode].SetValue(Basler.Pylon.PLCamera.AcquisitionMode.Continuous);
            Cam[CamNumber].StreamGrabber.Start(Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByStreamGrabber);
        }

        public void StopLive(int CamNumber)
        {
            Cam[CamNumber].StreamGrabber.Stop();
        }

        private void UpDateCams()
        { // 연결 가능한 카메라 리스트 갱신하기
            try
            {
                AllCams = Basler.Pylon.CameraFinder.Enumerate(); // 카메라 리스트 초기화

                if (AllCams.Count < 1)
                { // 카메라가 없으면 나가기
                    return;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        private void DistoryCamera()
        {
            try
            {             // 예제소스 앞단은 화면상 파라미터값 해제
                for (int i = 0; i < 3; i++)
                {
                    if (Cam[i] != null)
                    {
                        Cam[i].Close();
                        Cam[i].Dispose();
                        Cam[i] = null;
                    }
                    CameraStats[i] = false;
                    MainCogDisplay[i].Image = null;
                    MainCogDisplay[i].InteractiveGraphics.Clear();
                    MainCogDisplay[i].StaticGraphics.Clear();
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }

        public void GainSet(int CamNum, double Value)
        {
            if (Cam[CamNum] == null) return;
            try
            {
                Cam[CamNum].Parameters[Basler.Pylon.PLCamera.GainAbs].SetValue(Value);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        public void ExposureSet(int CamNum, double Value)
        {
            if (Cam[CamNum] == null) return;
            try
            {
                Cam[CamNum].Parameters[Basler.Pylon.PLCamera.ExposureTimeAbs].SetValue(Value);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }

        #region InnerClass
        private class EnumValue
        {
            public EnumValue(Basler.Pylon.IEnumParameter parameter)
            {
                ValueName = parameter.GetValue();
                ValueDisplayName = parameter.GetAdvancedValueProperties(ValueName).GetPropertyOrDefault(Basler.Pylon.AdvancedParameterAccessKey.DisplayName, ValueName);
            }

            public EnumValue(Basler.Pylon.IEnumParameter parameter, string valueName)
            {
                ValueName = valueName;
                ValueDisplayName = parameter.GetAdvancedValueProperties(valueName).GetPropertyOrDefault(Basler.Pylon.AdvancedParameterAccessKey.DisplayName, valueName);
            }

            public override string ToString()
            {
                return ValueDisplayName;
            }

            public string ValueName;
            public string ValueDisplayName;
        };
        #endregion

        private void Initialize_LightControl()
        {
            try
            {
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CamSet.ini");
                INIControl setting = new INIControl(Glob.SETTING);
                if (LightControl1.IsOpen == true)
                {
                    LightControl1.Close();
                }
                LightControl1.BaudRate = Convert.ToInt32(setting.ReadData("COMMUNICATION", $"Baud Rate"));
                LightControl1.Parity = Parity.None;
                LightControl1.DataBits = Convert.ToInt32(setting.ReadData("COMMUNICATION", $"Data Bits"));
                LightControl1.StopBits = StopBits.One;
                LightControl1.PortName = setting.ReadData("COMMUNICATION", $"Port number");
                LightControl1.Open();
                for (int j = 0; j < 4; j++)
                {
                    Glob.LightCH[j] = Convert.ToInt32(CamSet.ReadData($"LightControl", $"CH{j + 1}")); //저장된 조명값 불러오기.
                }
                LightOFF(); // 처음 실행했을때는 조명을 꺼주자. (AUTO모드로 변경됐을때, 조명 켜주자)
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        public bool CameraSerialNumberCheck(int CameraNumber, string CameraIP, string serialnumber)
        {
            string[] EachIP = CameraIP.Split('.');
            switch (EachIP[2])
            {
                case "1":
                    if (serialnumber == CameraSerialNumber[0])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM1 not Connect - SerialNumber Error");
                        return false;
                    }
                case "2":
                    if (serialnumber == CameraSerialNumber[1])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM2 not Connect - SerialNumber Error");
                        return false;
                    }
                case "3":
                    if (serialnumber == CameraSerialNumber[2])
                        return true;
                    else
                    {
                        log.AddLogMessage(LogType.Error, 0, "CAM3 not Connect - SerialNumber Error");
                        return false;
                    }
                    //case "4":
                    //    if (serialnumber == CameraSerialNumber[3])
                    //        return true;
                    //    else
                    //    {
                    //        log.AddLogMessage(LogType.Error, 0, "CAM4 not Connect - SerialNumber Error");
                    //        return false;
                    //    }
                    //case "5":
                    //    if (serialnumber == CameraSerialNumber[4])
                    //        return true;
                    //    else
                    //    {
                    //        log.AddLogMessage(LogType.Error, 0, "CAM5 not Connect - SerialNumber Error");
                    //        return false;
                    //    }
                    //case "6":
                    //    if (serialnumber == CameraSerialNumber[5])
                    //        return true;
                    //    else
                    //    {
                    //        log.AddLogMessage(LogType.Error, 0, "CAM6 not Connect - SerialNumber Error");
                    //        return false;
                    //    }
                    //case "7":
                    //    if (serialnumber == CameraSerialNumber[6])
                    //        return true;
                    //    else
                    //    {
                    //        log.AddLogMessage(LogType.Error, 0, "CAM7 not Connect - SerialNumber Error");
                    //        return false;
                    //    }
            }
            return false;
        }
        private void Initialize_CameraInit()
        {
            try
            {
                //int CameraNumber = 0;
                for (int i = 0; i < AllCams.Count; i++)
                {
                    CameraNumber = 0;
                    Basler.Pylon.ICameraInfo EachCam = AllCams[i]; //불러온 카메라 각각 차례대로 불러오기.
                    string SerialNumber = EachCam[Basler.Pylon.CameraInfoKey.SerialNumber]; //불러온 카메라 시리얼번호확인.
                    //카메라 시리얼번호 맞추기
                    for (int y = 0; y < 3; y++)
                    {
                        if (CameraSerialNumber[y] == SerialNumber) //설정된 시리얼번호와 불러온 시리얼번호 일치여부 확인.
                        {
                            Cam[y] = new Basler.Pylon.Camera(EachCam);
                            CameraNumber = y;
                        }
                    }
                    /*
                     * 불러온 시리얼번호가 카메라 번호가 맞는지 확인.(IP 3번째 숫자를 이용하여 확인)
                     * 시리얼번호가 일치 하는데, 실제 연결되어야될 카메라가 아닌 다른 카메라가 연결되는것을 방지하기 위하여, 확인해주는 작업
                     *  ex) Program상 CAM2에서 2번카메라가 나와야되는데 3번카메라가 나오는 현상이 생겨 추가해놈
                     */
                    if (!CameraSerialNumberCheck(CameraNumber, Cam[CameraNumber].CameraInfo["Address"], SerialNumber))
                    {
                        continue;
                    }

                    Cam[CameraNumber].CameraOpened += Basler.Pylon.Configuration.AcquireSingleFrame;
                    if (Cam[CameraNumber].IsOpen == true)
                    {
                        //연결되어있으면 해제 시켜주기.
                        Cam[CameraNumber].Close();
                        Cam[CameraNumber].Dispose();
                    }
                    /*카메라 이벤트 생성*/
                    switch (CameraNumber)
                    {
                        case 0:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost;
                            Cam[CameraNumber].CameraOpened += onCameraOpened;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped;
                            break;
                        case 1:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost2;
                            Cam[CameraNumber].CameraOpened += onCameraOpened2;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed2;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted2;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed2;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped2;
                            break;
                        case 2:
                            Cam[CameraNumber].ConnectionLost += onConnectionLost3;
                            Cam[CameraNumber].CameraOpened += onCameraOpened3;
                            Cam[CameraNumber].CameraClosed += onCameraCloseed3;
                            Cam[CameraNumber].StreamGrabber.GrabStarted += onGrabStarted3;
                            Cam[CameraNumber].StreamGrabber.ImageGrabbed += onImageGrabbed3;
                            Cam[CameraNumber].StreamGrabber.GrabStopped += onGrabStopped3;
                            break;
                    }
                    Cam[CameraNumber].Open(); //카메라 오픈
                    CameraStats[CameraNumber] = true; //카메라 연결상태 
                    log.AddLogMessage(LogType.Result, 0, $"CAM{CameraNumber + 1} 연결 성공");
                    PixelParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.PixelFormat]; // 카메라 픽셀 설정

                    /* 카메라 프레임 올려주기 위한 설정추가 - 김형민 2021-03-19 */
                    Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.GevSCPSPacketSize].SetValue(9000);

                    // 노출 설정 (카메라 허용 값대로 가져오기.
                    if (Cam[CameraNumber].Parameters.Contains(Basler.Pylon.PLCamera.ExposureTimeAbs))
                    {
                        ExposureParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.ExposureTimeAbs];
                    }
                    else
                    {
                        ExposureParameter = Cam[CameraNumber].Parameters[Basler.Pylon.PLCamera.ExposureTime];
                    }

                    // 카메라 픽셀 설정 먼저.
                    if (PixelParameter.IsWritable && PixelParameter.IsReadable)
                    {
                        string Selected = PixelParameter.GetValue();

                        foreach (string values in PixelParameter)
                        {
                            EnumValue item = new EnumValue(this.PixelParameter, values); // EnumValue : 아래 추가 선언 되어 있다.

                            if (Selected == values)
                            {

                            }
                        }
                    }
                    else if (PixelParameter.IsReadable)
                    {
                        EnumValue item = new EnumValue(PixelParameter);
                    }
                    else
                    {

                    }

                    if (ExposureParameter.IsReadable)
                    {
                        //this.nudExposure.Minimum = (decimal)this.ExposureParameter.GetMinimum();
                        //this.nudExposure.Maximum = (decimal)this.ExposureParameter.GetMaximum();
                        //this.nudExposure.Value = (decimal)this.ExposureParameter.GetValue();
                        //this.nudExposure.Enabled = true;
                    }
                    this.isFirst = false;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - CAM{CameraNumber + 1} {ee.Message}");
            }
        }
        private void Initialize_CamvalueInit()
        {
            try
            {
                for (int i = 0; i < CameraStats.Count(); i++)
                {
                    CameraStats[i] = false; //카메라 상태 전체 False
                }
                AllCams = Basler.Pylon.CameraFinder.Enumerate(); //PC와 연결되어있는 카메라 전체불러오기
                if (AllCams.Count < 1)
                {
                    log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - 연결된 카메라가 없습니다");
                    return;
                }
                if (AllCams.Count != 3) //7개가 연결되어있지않으면.
                {
                    log.AddLogMessage(LogType.Warning, 0, $"{3 - AllCams.Count}개의 카메라가 접근하지 못하였습니다. ※카메라 전원 및 IP Adress 확인※");
                }
                else //정상적으로 전체카메라 불러오기 성공.
                {
                    log.AddLogMessage(LogType.Result, 0, $"{AllCams.Count}개의 카메라 접근 성공.");
                }
                //for (int lop = 0; lop < AllCams.Count; lop++)
                //{
                //    Basler.Pylon.ICameraInfo EachCam = AllCams[lop];
                //}
                //DestoryCamera();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        private void CalibrationDataLoad()
        {
            try
            {
                INIControl CalibrationValue = new INIControl($"{Glob.MODELROOT}\\{Glob.RunnModel.Modelname()}\\CalibrationValue.ini");
                for (int i = 0; i < Glob.CAM_CalValue.Count(); i++)
                {
                    Glob.CAM_CalValue[i] = Convert.ToDouble(CalibrationValue.ReadData("Calibration Value", $"CAM{i}"));
                    Glob.CAM_CalValue2[i] = Convert.ToDouble(CalibrationValue.ReadData("Calibration Value2", $"CAM{i}"));
                }
                Glob.Point208_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "208Point_Min"));
                Glob.Point208_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "208Point_Stand"));
                Glob.Point208_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "208Point_Max"));
                Glob.Point500_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "500Point_Min"));
                Glob.Point500_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "500Point_Stand"));
                Glob.Point500_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "500Point_Max"));
                Glob.Point501_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "501Point_Min"));
                Glob.Point501_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "501Point_Stand"));
                Glob.Point501_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "501Point_Max"));
                Glob.Point502_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "502Point_Min"));
                Glob.Point502_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "502Point_Stand"));
                Glob.Point502_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "502Point_Max"));
                Glob.Point409_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "409Point_Min"));
                Glob.Point409_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "409Point_Stand"));
                Glob.Point409_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "409Point_Max"));
                Glob.Point405_Min = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "405Point_Min"));
                Glob.Point405_Stand = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "405Point_Stand"));
                Glob.Point405_Max = Convert.ToDouble(CalibrationValue.ReadData("Spec Value", "405Point_Max"));
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{ee.Message}");
            }
        }
        private void DataReset(int CamNumber)
        {
            Glob.CAM_Point208Value[CamNumber] = 0;
            Glob.CAM_Point500Value[CamNumber] = 0;
            Glob.CAM_Point501Value[CamNumber] = 0;
            Glob.CAM_Point502Value[CamNumber] = 0;
            Glob.CAM_Point409Value[CamNumber] = 0;
            Glob.CAM_Point405Value[CamNumber] = 0;
        }
        private void LoadSetup()
        {
            try
            {
                OK_Label = new Label[3] { lb_CAM1_OK, lb_CAM2_OK, lb_CAM3_OK };
                NG_Label = new Label[3] { lb_CAM1_NG, lb_CAM2_NG, lb_CAM3_NG };
                TOTAL_Label = new Label[3] { lb_CAM1_TOTAL, lb_CAM2_TOTAL, lb_CAM3_TOTAL};
                NGRATE_Label = new Label[3] { lb_CAM1_NGRATE, lb_CAM2_NGRATE, lb_CAM3_NGRATE };
                CameraStats_Label = new Label[3] { lb_Cam1Stats, lb_Cam2Stats, lb_Cam3Stats };
                INIControl Modellist = new INIControl(Glob.MODELLIST); // ini파일 경로
                INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);  // ini파일 경로
                INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로

                string LastModel = CFGFILE.ReadData("LASTMODEL", "NAME"); //마지막 사용모델 확인.
                INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{LastModel}\\CamSet.ini");
                for (int i = 0; i < 3; i++)
                {
                    Glob.RunnModel.Loadmodel(LastModel, Glob.MODELROOT, i); //VISION TOOL LOAD
                }
                //****************************스펙 값****************************//
                for (int i = 0; i < 3; i++)
                {
                    ExposureSet(i, Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"))); //노출값 설정
                }
                //****************************COMPORT 연결관련****************************//
                Glob.PortName = setting.ReadData("COMMUNICATION", $"Port number");
                Glob.Parity = setting.ReadData("COMMUNICATION", $"Parity Check");
                Glob.StopBits = setting.ReadData("COMMUNICATION", $"Stop bits");
                Glob.DataBit = setting.ReadData("COMMUNICATION", $"Data Bits");
                Glob.BaudRate = setting.ReadData("COMMUNICATION", $"Baud Rate");

                if (setting.ReadData("SYSTEM", "OK IMAGE SAVE", true) == "1")
                    Glob.OKImageSave = true;
                else
                    Glob.OKImageSave = false;

                if (setting.ReadData("SYSTEM", "NG IMAGE SAVE", true) == "1")
                    Glob.NGImageSave = true;
                else
                    Glob.NGImageSave = false;

                if (setting.ReadData("SYSTEM", "InspectType", true) == "true")
                    Glob.InspectType = true;
                else
                    Glob.InspectType = false;
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
            }
        }
        public void OutPutSignal_On(int jobNo)
        {
            short ret;
            ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 1);
        }

        public void OutPutSignal_Off(int jobNo)
        {
            short ret;
            ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 0);
        }

        #region CAM1 Events
        private void onConnectionLost(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM1 Connection Lost");
        }
        private void onCameraOpened(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM1 Close");
            //StatsCheck("CAM1 Close", true);
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 GrabStart");
        }

        private void onImageGrabbed(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            int CameraNumber = 1;
            DataReset(CameraNumber - 1);
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.

            try
            {
                InspectTime[CameraNumber - 1] = new Stopwatch();
                InspectTime[CameraNumber - 1].Reset();
                InspectTime[CameraNumber - 1].Start();

                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    string Result = "";
                    //if (!Stopwatch.IsRunning || Stopwatch.ElapsedMilliseconds > 33)
                    //{
                    //Stopwatch.Restart();
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);

                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    Monoimage[CameraNumber - 1] = new CogImage8Grey(Image);

                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        frm_toolsetup.cdyDisplay.Image = Monoimage[CameraNumber - 1];
                        //StopLive(0);
                    }
                    else
                    {
                        Image = null;
                        cdyDisplay.Image = Monoimage[CameraNumber - 1];

                        if (Inspect_Cam0(cdyDisplay) == true)
                        {
                            //btn_Output[4].PerformClick();
                            OutPutSignal_On(6);
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam1_Result.BackColor = Color.Lime;
                                lb_Cam1_Result.Text = "O K";
                                OK_Count[CameraNumber - 1]++;
                                if (Glob.OKImageSave)
                                    ImageSave1(Result, CameraNumber, cdyDisplay);
                            });
                            Glob.CAM1_Inspect = true;
                        }
                        else
                        {
                            Result = "NG";
                            if (Glob.InspectType)
                            {
                                OutPutSignal_On(7);
                            }
                            else
                            {
                                if (Glob.b_MultiInspat_Result[CameraNumber - 1, 6] == false || Glob.b_MultiInspat_Result[CameraNumber - 1, 7] == false)
                                {
                                    OutPutSignal_On(7);
                                }
                                else
                                {
                                    OutPutSignal_On(6);
                                }
                            }
                           
                            //btn_Output[5].PerformClick();
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam1_Result.BackColor = Color.Red;
                                lb_Cam1_Result.Text = "N G";
                                NG_Count[CameraNumber - 1]++;
                                if (Glob.NGImageSave)
                                    ImageSave1(Result, CameraNumber, cdyDisplay);
                            });
                            Glob.CAM1_Inspect = false;
                        }
                        DataSave1(Result, CameraNumber);
                        //ImageSave1(Result, 3, cdyDisplay);
                        InspectTime[CameraNumber - 1].Stop();
                        BeginInvoke((Action)delegate { lb_Cam1_InsTime.Text = InspectTime[CameraNumber - 1].ElapsedMilliseconds.ToString() + "msec"; });
                        //DataSave();
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} : {ee.Message}");
            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM1 GrabStop");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM2 Events
        private void onConnectionLost2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost2), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 Connection Lost");
        }

        private void onCameraOpened2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM2 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted2(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed2(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            int CameraNumber = 2;
            DataReset(CameraNumber - 1);
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed2), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            //StatsCheck("CAM2 Inspect Start", false);
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.

            try
            {
                InspectTime[CameraNumber - 1] = new Stopwatch();
                InspectTime[CameraNumber - 1].Reset();
                InspectTime[CameraNumber - 1].Start();

                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    //Image Type Check
                    Monoimage[CameraNumber - 1] = new CogImage8Grey(Image);
                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        frm_toolsetup.cdyDisplay.Image = Monoimage[CameraNumber - 1];
                        //StopLive(1);
                    }
                    else
                    {
                        Image = null;
                        cdyDisplay2.Image = Monoimage[CameraNumber - 1];
                        if (Inspect_Cam1(cdyDisplay2) == true)
                        {
                            //1번 Vision 검사결과 OK
                            //btn_Output[6].PerformClick();
                            OutPutSignal_On(8);
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam2_Result.BackColor = Color.Lime;
                                lb_Cam2_Result.Text = "O K";
                                OK_Count[CameraNumber - 1]++;
                                if (Glob.OKImageSave)
                                    ImageSave2(Result, CameraNumber, cdyDisplay2);
                            });
                        }
                        else
                        {
                            //1번 Vision 검사결과 NG
                            if (Glob.InspectType)
                            {
                                OutPutSignal_On(9);
                            }
                            else
                            {
                                if (Glob.b_MultiInspat_Result[CameraNumber - 1, 10] == false)
                                {
                                    OutPutSignal_On(9);
                                }
                                else
                                {
                                    OutPutSignal_On(8);
                                }
                            }
                           
                            //OutPutSignal_On(9);
                            //btn_Output[7].PerformClick();
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam2_Result.BackColor = Color.Red;
                                lb_Cam2_Result.Text = "N G";
                                NG_Count[CameraNumber - 1]++;
                                if (Glob.NGImageSave)
                                    ImageSave2(Result, CameraNumber, cdyDisplay2);
                            });
                        }
                        DataSave2(Result, CameraNumber);
                        //ImageSave2(Result, 4, cdyDisplay2);
                        InspectTime[CameraNumber - 1].Stop();
                        BeginInvoke((Action)delegate { lb_Cam2_InsTime.Text = InspectTime[CameraNumber - 1].ElapsedMilliseconds.ToString() + "msec"; });
                        //Glob.CAM2_Inspect = false;
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped2(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped2), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM2 GrabStop");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        #region CAM3 Events
        private void onConnectionLost3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onConnectionLost3), sender, e);
                return;
            }
            DistoryCamera();
            UpDateCams();
            log.AddLogMessage(LogType.Error, 0, "CAM3 Connection Lost");
        }

        private void onCameraOpened3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraOpened3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 Open");
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }

        private void onCameraCloseed3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onCameraCloseed3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Error, 0, "CAM3 Close");
            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = false;
        }

        private void onGrabStarted3(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<EventArgs>(onGrabStarted3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 GrabStart");
            //this.Stopwatch.Reset();

            //this.btnAcqire.Enabled = false;
            //this.btnLive.Enabled = false;
            //this.button1.Enabled = true;
        }

        private void onImageGrabbed3(object sender, Basler.Pylon.ImageGrabbedEventArgs e)
        { // 이미지를 처리하는 곳이기 때문에, 이미지 그랩 이벤트가 걸려있다.
            int CameraNumber = 3;
            DataReset(CameraNumber - 1);
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.ImageGrabbedEventArgs>(onImageGrabbed3), sender, e.Clone()); // 이게 중요. e.Clone()
                GC.Collect();
                return;
            }
            Basler.Pylon.IGrabResult ImageResult = e.GrabResult; // 이미지를 찍었다.
            try
            {
                InspectTime[CameraNumber - 1] = new Stopwatch();
                InspectTime[CameraNumber - 1].Reset();
                InspectTime[CameraNumber - 1].Start();

                string Result = "";
                // 이미지를 사용할 수 있도록 비트맵 타입으로 수정.
                if (ImageResult.IsValid)
                {
                    Bitmap Image = new Bitmap(ImageResult.Width, ImageResult.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    BitmapData Imagedata = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, Image.PixelFormat);
                    // 이미지 색상 형식 지정
                    ImageConverter.OutputPixelFormat = Basler.Pylon.PixelType.BGRA8packed;
                    IntPtr ptrbmp = Imagedata.Scan0;
                    ImageConverter.Convert(ptrbmp, Imagedata.Stride * Image.Height, ImageResult);
                    Image.UnlockBits(Imagedata);
                    Monoimage[CameraNumber - 1] = new CogImage8Grey(Image);
                    if (frm_toolsetup != null)
                    {
                        Image = null;
                        frm_toolsetup.cdyDisplay.Image = Monoimage[CameraNumber - 1];
                        //StopLive(2);
                    }
                    else
                    {
                        Image = null;
                        cdyDisplay3.Image = Monoimage[CameraNumber - 1];
                        if (Inspect_Cam2(cdyDisplay3) == true)
                        {
                            //btn_Output[8].PerformClick();
                            OutPutSignal_On(10);
                            Result = "OK";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam3_Result.BackColor = Color.Lime;
                                lb_Cam3_Result.Text = "O K";
                                OK_Count[CameraNumber - 1]++;
                                if (Glob.OKImageSave)
                                    ImageSave3(Result, CameraNumber, cdyDisplay3);
                            });
                        }
                        else
                        {
                            if (Glob.InspectType)
                            {
                                OutPutSignal_On(11);
                            }
                            else
                            {
                                if (Glob.b_MultiInspat_Result[CameraNumber - 1, 5] == false || Glob.b_MultiInspat_Result[CameraNumber - 1, 6] == false)
                                {
                                    OutPutSignal_On(11);
                                }
                                else
                                {
                                    OutPutSignal_On(10);
                                }
                            }
                            //btn_Output[9].PerformClick();
                            //OutPutSignal_On(11);
                            Result = "NG";
                            BeginInvoke((Action)delegate
                            {
                                lb_Cam3_Result.BackColor = Color.Red;
                                lb_Cam3_Result.Text = "N G";
                                NG_Count[CameraNumber - 1]++;
                                if (Glob.NGImageSave)
                                    ImageSave3(Result, CameraNumber, cdyDisplay3);
                            });
                        }
                        DataSave3(Result, CameraNumber);
                        LightOFF();
                        //ImageSave3(Result, 5, cdyDisplay3);
                        InspectTime[CameraNumber - 1].Stop();
                        BeginInvoke((Action)delegate { lb_Cam3_InsTime.Text = InspectTime[CameraNumber - 1].ElapsedMilliseconds.ToString() + "msec"; });
                        //Glob.CAM3_Inspect = false;
                    }
                }
                if (AcqEnable)
                {
                    FreamCount++;
                }
            }
            catch
            {

            }
            finally
            {
                e.DisposeGrabResultIfClone(); // 중요한건 이부분. 없으면 라이브가 연속 촬영 불가
                GC.Collect();
            }
            return;
        }

        private void onGrabStopped3(object sender, Basler.Pylon.GrabStopEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<Basler.Pylon.GrabStopEventArgs>(onGrabStopped3), sender, e);
                return;
            }
            log.AddLogMessage(LogType.Infomation, 0, "CAM3 Stop");
            //this.Stopwatch.Reset();
            //this.btnAcqire.Enabled = true;
            //this.btnLive.Enabled = true;
            //this.button1.Enabled = false;
        }
        #endregion

        private void btn_ToolSetUp_Click(object sender, EventArgs e)
        {
            frm_toolsetup = new Frm_ToolSetUp(this);
            frm_toolsetup.Show();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "EXIT", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            INIControl setting = new INIControl(Glob.SETTING);
            DateTime dt = DateTime.Now;
            setting.WriteData("Exit Date", "Date", dt.ToString("yyyyMMdd"));
            Application.Exit();
        }

        private void btn_SystemSetup_Click(object sender, EventArgs e)
        {
            Frm_SystemSetUp FrmSystemSetUp = new Frm_SystemSetUp(this);
            FrmSystemSetUp.Show();
        }

        private void timer_Setting_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lb_Time.Text = dt.ToString("yyyy년 MM월 dd일 HH:mm:ss"); //현재날짜
            lb_CurruntModelName.Text = Glob.RunnModel.Modelname(); //현재사용중인 모델명 체크
            Glob.CurruntModelName = Glob.RunnModel.Modelname();
            lb_Mode.Text = AutoRun == true ? "AUTO RUN" : "MANUAL";
            lb_Mode.BackColor = AutoRun == true ? Color.Lime : Color.Red;
            btn_Light.BackColor = LightStats == true ? Color.Lime : Color.Red;

            cb_AllNG.BackColor = Glob.InspectType == true ? Color.Lime : Color.Red;
            cb_AllNG.Checked = Glob.InspectType == true ? true : false;
            cb_NutNG.BackColor = Glob.InspectType == false ? Color.Lime : Color.Red;
            cb_NutNG.Checked = Glob.InspectType == false ? true : false;

            for (int i = 0; i < Program.CameraList.Count(); i++)
            {
                OK_Label[i].Text = OK_Count[i].ToString();
                NG_Label[i].Text = NG_Count[i].ToString();
                TOTAL_Count[i] = OK_Count[i] + NG_Count[i];
                TOTAL_Label[i].Text = (OK_Count[i] + NG_Count[i]).ToString();

                if (NG_Count[i] != 0)
                {
                    NG_Rate[i] = (NG_Count[i] / TOTAL_Count[i]) * 100;
                    NGRATE_Label[i].Text = NG_Rate[i].ToString("F1") + "%";
                }
            }
            for (int i = 0; i < Program.CameraList.Count(); i++)
            {
                CameraStats_Label[i].BackColor = CameraStats[i] == true ? Color.Lime : Color.Red;
            }
        }

        private void btn_Status_Click(object sender, EventArgs e)
        {

            log.AddLogMessage(LogType.Infomation, 0, "AUTO MODE START");
            AutoRun = true;
            btn_Status.Enabled = false;
            btn_ToolSetUp.Enabled = false;
            btn_Model.Enabled = false;
            btn_SystemSetup.Enabled = false;
            btn_Stop.Enabled = true;
            VisionReddyOn();
            //OutPutSignal_On(2);
            //OutPutSignal_On(4);
            //OutPutSignal_On(12);
            //OutPutSignal_On(14);
            //LightON(LightControl[0]);
            //LightON(LightControl[1]);
        }
        public void Line_Train1(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.LINE_FixtureImage1((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Line_Train2(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.LINE_FixtureImage2((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Line_Train3(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.LINE_FixtureImage3((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
      

        public void Bolb_Train1(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage1((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train2(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage2((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }
        public void Bolb_Train3(CogDisplay cdy, int CameraNumber, int toolnumber)
        {
            if (TempMulti[CameraNumber, toolnumber].Run((CogImage8Grey)cdy.Image) == true)
            {
                Fiximage = TempModel.Blob_FixtureImage3((CogImage8Grey)cdy.Image, TempMulti[CameraNumber, toolnumber].ResultPoint(TempMulti[CameraNumber, toolnumber].HighestResultToolNumber()), TempMulti[CameraNumber, toolnumber].ToolName(), CameraNumber, toolnumber, out FimageSpace, TempMulti[CameraNumber, toolnumber].HighestResultToolNumber());
                //cdyDisplay.Image = Fiximage;
            }
        }

        public void CognexModelLoad()
        {
            Glob = PGgloble.getInstance;
            TempModel = Glob.RunnModel;
            TempLines = TempModel.Line();
            TempLineEnable = TempModel.LineEnables();
            TempLineFixPatternNumber = TempModel.LineFixPatternNumbers();
            TempBlobs = TempModel.Blob();
            TempBlobEnable = TempModel.BlobEnables();
            TempBlobOKCount = TempModel.BlobOKCounts();
            TempBlobFixPatternNumber = TempModel.BlobFixPatternNumbers();
            TempCircles = TempModel.Circle();
            TempCircleEnable = TempModel.CircleEnables();
            TempMulti = TempModel.MultiPatterns();
            TempMultiEnable = TempModel.MultiPatternEnables();
            TempCalipers = TempModel.Caliper();
            TempCaliperEnable = TempModel.CaliperEnables();
        }

        #region Inpection CAM0 
        public bool Inspect_Cam0(CogDisplay cog)
        {
            int CameraNumber = 0;
            Glob.PatternResult[CameraNumber] = true;
            Glob.BlobResult[CameraNumber] = true;
            Glob.MeasureResult[CameraNumber] = true;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            CogGraphicCollection Collection = new CogGraphicCollection();
            CogGraphicCollection Collection2 = new CogGraphicCollection(); // 패턴
            CogGraphicCollection Collection3 = new CogGraphicCollection(); // 블롭
            CogGraphicCollection Collection4 = new CogGraphicCollection(); // 치수
            CognexModelLoad(); //VISION TOOL LOAD
            string[] temp = new string[30];
            if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image)) //기본패턴 등록해두기.
            {
                Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
            }
            //*******************************MultiPattern Tool Run******************************//
            if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
            {
                //너트 패턴 6,7
                for (int lop = 0; lop < 30; lop++)
                {
                    if (TempMultiEnable[CameraNumber, lop] == true)
                    {
                        Glob.b_MultiInspat_Result[CameraNumber, lop] = true;
                        if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                        {
                            Glob.b_MultiInspat_Result[CameraNumber, lop] = false;
                            InspectResult[CameraNumber] = false;
                            Glob.PatternResult[CameraNumber] = false;
                        }
                    }
                }
            }
            else
            {
                InspectResult[CameraNumber] = false;
                Glob.PatternResult[CameraNumber] = false;
            }

            //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
            for (int toolnum = 0; toolnum < 29; toolnum++)
            {
                if (TempBlobEnable[CameraNumber, toolnum])
                {
                    Bolb_Train1(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                    TempBlobs[CameraNumber, toolnum].Area_Affine_Main1(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                }
            }

            if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
            {

            }
            else
            {
                //BLOB 검사 FAIL
                InspectResult[CameraNumber] = false;
                Glob.BlobResult[CameraNumber] = false;
            }

            //Glob.RunnModel.Modelname() == "354-0024"
            //if ( Glob.RunnModel.Modelname() == "354-0024")
            //{
            //    //라인툴 넘버와 패턴툴넘버 맞추는 작업.
            //    for (int toolnum = 0; toolnum < 29; toolnum++)
            //    {
            //        if (TempLineEnable[CameraNumber, toolnum])
            //        {
            //            Line_Train1(cog, CameraNumber, TempLineFixPatternNumber[CameraNumber, toolnum]);
            //            //TempLines[CameraNumber, toolnum].Area1(ref cog, (CogImage8Grey)cog.Image, TempLineFixPatternNumber[CameraNumber, toolnum].ToString());
            //        }
            //    }

            //    if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
            //    {

            //    }
            //    else
            //    {
            //        //LINE 검사 FAIL
            //        InspectResult[CameraNumber] = false;
            //        Glob.MeasureResult[CameraNumber] = false;
            //    }

            //    if (PointLineDistance((CogImage8Grey)cog.Image, CameraNumber, cog))
            //    {
            //        CogCreateGraphicLabelTool Point1_Label = new CogCreateGraphicLabelTool();
            //        Point1_Label.InputImage = cog.Image;
            //        Point1_Label.InputGraphicLabel.X = TempLines[CameraNumber, 3].Average_PointX();
            //        Point1_Label.InputGraphicLabel.Y = TempLines[CameraNumber, 3].Average_PointY();
            //        Point1_Label.InputGraphicLabel.Text = Glob.CAM_Point208Value[CameraNumber].ToString("F3");

            //        if (frm_toolsetup == null)
            //        {
            //            if (Glob.Point208_Min <= Glob.CAM_Point208Value[CameraNumber] && Glob.Point208_Max >= Glob.CAM_Point208Value[CameraNumber])
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Green;
            //            }
            //            else
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Red;
            //                InspectResult[CameraNumber] = false;
            //                Glob.MeasureResult[CameraNumber] = false;
            //            }
            //        }
            //        else
            //        {
            //            if (Glob.Point208_Min <= Glob.CAM_Point208Value[CameraNumber] && Glob.Point208_Max >= Glob.CAM_Point208Value[CameraNumber])
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Green;
            //            }
            //            else
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Red;
            //                InspectResult[CameraNumber] = false;
            //                Glob.MeasureResult[CameraNumber] = false;
            //            }
            //        }
            //        Point1_Label.Run();
            //        cog.StaticGraphics.Add(Point1_Label.GetOutputGraphicLabel(), "");
            //    }
            //    else
            //    {
            //        InspectResult[CameraNumber] = false;
            //        Glob.MeasureResult[CameraNumber] = false;
            //    }
            //}
          

            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }

            if (Glob.PatternResult[CameraNumber]) { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN OK"); }
            else { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN NG"); };

            if (Glob.BlobResult[CameraNumber]) { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB OK"); }
            else { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB NG"); };
          

            for (int i = 0; i < Collection2.Count; i++)
                Collection2[i].Color = Glob.PatternResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;
            for (int i = 0; i < Collection3.Count; i++)
                Collection3[i].Color = Glob.BlobResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;

            cog.StaticGraphics.AddList(Collection, "");
            cog.StaticGraphics.AddList(Collection2, "");
            cog.StaticGraphics.AddList(Collection3, "");

            //if (Glob.RunnModel.Modelname() == "354-0024")
            //{
            //    if (Glob.MeasureResult[CameraNumber]) { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE OK : {Glob.CAM_Point208Value[CameraNumber].ToString("F3")}"); }
            //    else { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE NG : {Glob.CAM_Point208Value[CameraNumber].ToString("F3")}"); };

            //    for (int i = 0; i < Collection4.Count; i++)
            //        Collection4[i].Color = Glob.MeasureResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;

            //    cog.StaticGraphics.AddList(Collection4, "");
            //}

            return InspectResult[CameraNumber];
        }
        #endregion 

        #region Inpection CAM1 
        public bool Inspect_Cam1(CogDisplay cog)
        {
            int CameraNumber = 1;
            Glob.PatternResult[CameraNumber] = true;
            Glob.BlobResult[CameraNumber] = true;
            //Glob.MeasureResult[CameraNumber] = true;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            CogGraphicCollection Collection = new CogGraphicCollection();
            CogGraphicCollection Collection2 = new CogGraphicCollection(); // 패턴
            CogGraphicCollection Collection3 = new CogGraphicCollection(); // 블롭
            CogGraphicCollection Collection4 = new CogGraphicCollection(); // 치수
            CognexModelLoad();
            string[] temp = new string[30];

            if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
            {
                Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
            }
            //*******************************MultiPattern Tool Run******************************//
            if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
            {
                for (int lop = 0; lop < 30; lop++)
                {
                    if (TempMultiEnable[CameraNumber, lop] == true)
                    {
                        Glob.b_MultiInspat_Result[CameraNumber, lop] = true;
                        if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                        {
                            Glob.b_MultiInspat_Result[CameraNumber, lop] = false;
                            InspectResult[CameraNumber] = false;
                            Glob.PatternResult[CameraNumber] = false;
                        }
                    }
                }
            }
            else
            {
                InspectResult[CameraNumber] = false;
                Glob.PatternResult[CameraNumber] = false;
            }
            //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
            for (int toolnum = 0; toolnum < 29; toolnum++)
            {
                if (TempBlobEnable[CameraNumber, toolnum])
                {
                    Bolb_Train2(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                    TempBlobs[CameraNumber, toolnum].Area_Affine_Main2(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                }
            }
            if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
            {

            }
            else
            {
                //BLOB 검사 FAIL
                InspectResult[CameraNumber] = false;
                Glob.BlobResult[CameraNumber] = false;
            }

            //for (int toolnum = 0; toolnum < 29; toolnum++)
            //{
            //    if (TempLineEnable[CameraNumber, toolnum])
            //    {
            //        Line_Train2(cog, CameraNumber, TempLineFixPatternNumber[CameraNumber, toolnum]);
            //        //TempLines[CameraNumber, toolnum].Area2(ref cog, (CogImage8Grey)cog.Image, TempLineFixPatternNumber[CameraNumber, toolnum].ToString());
            //    }
            //}

            //if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
            //{

            //}
            //else
            //{
            //    //LINE 검사 FAIL
            //    InspectResult[CameraNumber] = false;
            //    Glob.MeasureResult[CameraNumber] = false;
            //}
            //if (PointLineDistance((CogImage8Grey)cog.Image, CameraNumber, cog))
            //{
            //    CogCreateGraphicLabelTool Point1_Label = new CogCreateGraphicLabelTool();
            //    Point1_Label.InputImage = cog.Image;
            //    Point1_Label.InputGraphicLabel.X = TempLines[CameraNumber, 3].Average_PointX();
            //    Point1_Label.InputGraphicLabel.Y = TempLines[CameraNumber, 3].Average_PointY();
            //    Point1_Label.InputGraphicLabel.Text = Glob.CAM_Point501Value[CameraNumber].ToString("F3");

            //    if (frm_toolsetup == null)
            //    {
            //        //BeginInvoke((Action)delegate
            //        //{
            //        //    lb_CAM1_Point1.Text = Glob.CAM_Point1Value[CameraNumber].ToString("F3");
            //        //});
            //        //if (Glob.Point24_Min <= Glob.CAM_Point1Value[CameraNumber] && Glob.Point24_Max >= Glob.CAM_Point1Value[CameraNumber])
            //        //{
            //        //    Point1_Label.OutputColor = CogColorConstants.Green;
            //        //    lb_CAM1_Point1.BackColor = Color.Lime;
            //        //}
            //        //else
            //        //{
            //        //    Point1_Label.OutputColor = CogColorConstants.Red;
            //        //    lb_CAM1_Point1.BackColor = Color.Red;
            //        //    InspectResult[CameraNumber] = false;
            //        //    Glob.MeasureResult[CameraNumber] = false;
            //        //}
            //    }
            //    else
            //    {
            //        if (Glob.Point501_Min <= Glob.CAM_Point501Value[CameraNumber] && Glob.Point501_Max >= Glob.CAM_Point501Value[CameraNumber])
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Green;
            //        }
            //        else
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Red;
            //            InspectResult[CameraNumber] = false;
            //            Glob.MeasureResult[CameraNumber] = false;
            //        }
            //    }
            //    Point1_Label.Run();
            //    cog.StaticGraphics.Add(Point1_Label.GetOutputGraphicLabel(), "");
            //}

            //if (PointLineDistance2((CogImage8Grey)cog.Image, CameraNumber, cog))
            //{
            //    CogCreateGraphicLabelTool Point1_Label = new CogCreateGraphicLabelTool();
            //    Point1_Label.InputImage = cog.Image;
            //    Point1_Label.InputGraphicLabel.X = TempLines[CameraNumber, 4].Average_PointX();
            //    Point1_Label.InputGraphicLabel.Y = TempLines[CameraNumber, 4].Average_PointY();
            //    Point1_Label.InputGraphicLabel.Text = Glob.CAM_Point409Value[CameraNumber].ToString("F3");

            //    if (frm_toolsetup == null)
            //    {
            //        if (Glob.Point409_Min <= Glob.CAM_Point409Value[CameraNumber] && Glob.Point409_Max >= Glob.CAM_Point409Value[CameraNumber])
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Green;
            //        }
            //        else
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Red;
            //            InspectResult[CameraNumber] = false;
            //            Glob.MeasureResult[CameraNumber] = false;
            //        }
            //    }
            //    else
            //    {
            //        if (Glob.Point409_Min <= Glob.CAM_Point409Value[CameraNumber] && Glob.Point409_Max >= Glob.CAM_Point409Value[CameraNumber])
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Green;
            //        }
            //        else
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Red;
            //            InspectResult[CameraNumber] = false;
            //            Glob.MeasureResult[CameraNumber] = false;
            //        }
            //    }
            //    Point1_Label.Run();
            //    cog.StaticGraphics.Add(Point1_Label.GetOutputGraphicLabel(), "");
            //}

            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }
            if (Glob.PatternResult[CameraNumber]) { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN OK"); }
            else { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN NG"); };

            if (Glob.BlobResult[CameraNumber]) { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB OK"); }
            else { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB NG"); };

            //if (Glob.MeasureResult[CameraNumber]) { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE OK : {Glob.CAM_Point501Value[CameraNumber].ToString("F3")}, {Glob.CAM_Point409Value[CameraNumber].ToString("F3")}"); }
            //else { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE NG : {Glob.CAM_Point501Value[CameraNumber].ToString("F3")}, {Glob.CAM_Point409Value[CameraNumber].ToString("F3")}"); };

            for (int i = 0; i < Collection2.Count; i++)
                Collection2[i].Color = Glob.PatternResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;
            for (int i = 0; i < Collection3.Count; i++)
                Collection3[i].Color = Glob.BlobResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;
            //for (int i = 0; i < Collection4.Count; i++)
            //    Collection4[i].Color = Glob.MeasureResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;

            cog.StaticGraphics.AddList(Collection, "");
            cog.StaticGraphics.AddList(Collection2, "");
            cog.StaticGraphics.AddList(Collection3, "");
            //cog.StaticGraphics.AddList(Collection4, "");

            return InspectResult[CameraNumber];
        }
        #endregion 

        #region Inpection CAM2 
        public bool Inspect_Cam2(CogDisplay cog)
        {
            int CameraNumber = 2;
            Glob.PatternResult[CameraNumber] = true;
            Glob.BlobResult[CameraNumber] = true;
            Glob.MeasureResult[CameraNumber] = true;
            InspectResult[CameraNumber] = true; //검사 결과는 초기에 무조건 true로 되어있다.
            CogGraphicCollection Collection = new CogGraphicCollection();
            CogGraphicCollection Collection2 = new CogGraphicCollection(); // 패턴
            CogGraphicCollection Collection3 = new CogGraphicCollection(); // 블롭
            CogGraphicCollection Collection4 = new CogGraphicCollection(); // 치수
            CognexModelLoad();
            string[] temp = new string[30];
            if (TempMulti[CameraNumber, 0].Run((CogImage8Grey)cog.Image))
            {
                Fiximage = TempModel.FixtureImage((CogImage8Grey)cog.Image, TempMulti[CameraNumber, 0].ResultPoint(TempMulti[CameraNumber, 0].HighestResultToolNumber()), TempMulti[CameraNumber, 0].ToolName(), CameraNumber, out FimageSpace, TempMulti[CameraNumber, 0].HighestResultToolNumber());
            }
            //*******************************MultiPattern Tool Run******************************//
            if (TempModel.MultiPattern_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection)) //검사결과가 true 일때
            {
                for (int lop = 0; lop < 30; lop++)
                {
                    Glob.b_MultiInspat_Result[CameraNumber, lop] = true;
                    if (TempMultiEnable[CameraNumber, lop] == true)
                    {
                        if (TempMulti[CameraNumber, lop].Threshold() * 100 > Glob.MultiInsPat_Result[CameraNumber, lop])
                        {
                            Glob.b_MultiInspat_Result[CameraNumber, lop] = false;
                            InspectResult[CameraNumber] = false;
                            Glob.PatternResult[CameraNumber] = false;
                        }
                    }
                }
            }
            else
            {
                InspectResult[CameraNumber] = false;
                Glob.PatternResult[CameraNumber] = false;
            }
            //블롭툴 넘버와 패턴툴넘버 맞추는 작업.
            for (int toolnum = 0; toolnum < 29; toolnum++)
            {
                if (TempBlobEnable[CameraNumber, toolnum])
                {
                    Bolb_Train3(cog, CameraNumber, TempBlobFixPatternNumber[CameraNumber, toolnum]);
                    TempBlobs[CameraNumber, toolnum].Area_Affine_Main3(ref cog, (CogImage8Grey)cog.Image, TempBlobFixPatternNumber[CameraNumber, toolnum].ToString());
                }
            }
            //******************************Blob Tool Run******************************//
            if (TempModel.Blob_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
            {

            }
            else
            {
                //BLOB 검사 FAIL
                InspectResult[CameraNumber] = false;
                Glob.BlobResult[CameraNumber] = false;
            }

            //if (TempModel.Circle_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))
            //{

            //}
            //else
            //{
            //    InspectResult[CameraNumber] = false;
            //}

            //if (Glob.RunnModel.Modelname() == "354-0024")
            //{
            //    for (int toolnum = 0; toolnum < 29; toolnum++)
            //    {
            //        if (TempLineEnable[CameraNumber, toolnum])
            //        {
            //            Line_Train3(cog, CameraNumber, TempLineFixPatternNumber[CameraNumber, toolnum]);
            //            //TempLines[CameraNumber, toolnum].Area3(ref cog, (CogImage8Grey)cog.Image, TempLineFixPatternNumber[CameraNumber, toolnum].ToString());
            //        }
            //    }
            //    if (TempModel.Line_Inspection(ref cog, (CogImage8Grey)cog.Image, ref temp, CameraNumber, Collection))// (CogImage8Grey)cog.Image, ref temp)) //검사툴 정상적으로 작동하였을때.
            //    {

            //    }
            //    else
            //    {
            //        //LINE 검사 FAIL
            //        InspectResult[CameraNumber] = false;
            //        Glob.MeasureResult[CameraNumber] = false;
            //    }

            //    if (PointLineDistance((CogImage8Grey)cog.Image, CameraNumber, cog))
            //    {
            //        CogCreateGraphicLabelTool Point1_Label = new CogCreateGraphicLabelTool();
            //        Point1_Label.InputImage = cog.Image;
            //        Point1_Label.InputGraphicLabel.X = TempLines[CameraNumber, 3].Average_PointX();
            //        Point1_Label.InputGraphicLabel.Y = TempLines[CameraNumber, 3].Average_PointY();
            //        Point1_Label.InputGraphicLabel.Text = Glob.CAM_Point208Value[CameraNumber].ToString("F3");

            //        if (frm_toolsetup == null)
            //        {
            //            if (Glob.Point208_Min <= Glob.CAM_Point208Value[CameraNumber] && Glob.Point208_Max >= Glob.CAM_Point208Value[CameraNumber])
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Green;
            //            }
            //            else
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Red;
            //                InspectResult[CameraNumber] = false;
            //                Glob.MeasureResult[CameraNumber] = false;
            //            }
            //        }
            //        else
            //        {
            //            if (Glob.Point208_Min <= Glob.CAM_Point208Value[CameraNumber] && Glob.Point208_Max >= Glob.CAM_Point208Value[CameraNumber])
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Green;
            //            }
            //            else
            //            {
            //                Point1_Label.OutputColor = CogColorConstants.Red;
            //                InspectResult[CameraNumber] = false;
            //                Glob.MeasureResult[CameraNumber] = false;
            //            }
            //        }
            //        Point1_Label.Run();
            //        cog.StaticGraphics.Add(Point1_Label.GetOutputGraphicLabel(), "");
            //    }
            //    else
            //    {
            //        InspectResult[CameraNumber] = false;
            //        Glob.MeasureResult[CameraNumber] = false;
            //    }
            //}

           

            //if (PointLineDistance2((CogImage8Grey)cog.Image, CameraNumber, cog))
            //{
            //    CogCreateGraphicLabelTool Point1_Label = new CogCreateGraphicLabelTool();
            //    Point1_Label.InputImage = cog.Image;
            //    Point1_Label.InputGraphicLabel.X = TempLines[CameraNumber, 4].Average_PointX();
            //    Point1_Label.InputGraphicLabel.Y = TempLines[CameraNumber, 4].Average_PointY();
            //    Point1_Label.InputGraphicLabel.Text = Glob.CAM_Point405Value[CameraNumber].ToString("F3");

            //    if (frm_toolsetup == null)
            //    {
            //        //BeginInvoke((Action)delegate
            //        //{
            //        //    lb_CAM1_Point1.Text = Glob.CAM_Point1Value[CameraNumber].ToString("F3");
            //        //});
            //        //if (Glob.Point24_Min <= Glob.CAM_Point1Value[CameraNumber] && Glob.Point24_Max >= Glob.CAM_Point1Value[CameraNumber])
            //        //{
            //        //    Point1_Label.OutputColor = CogColorConstants.Green;
            //        //    lb_CAM1_Point1.BackColor = Color.Lime;
            //        //}
            //        //else
            //        //{
            //        //    Point1_Label.OutputColor = CogColorConstants.Red;
            //        //    lb_CAM1_Point1.BackColor = Color.Red;
            //        //    InspectResult[CameraNumber] = false;
            //        //    Glob.MeasureResult[CameraNumber] = false;
            //        //}
            //    }
            //    else
            //    {
            //        if (Glob.Point405_Min <= Glob.CAM_Point405Value[CameraNumber] && Glob.Point405_Max >= Glob.CAM_Point405Value[CameraNumber])
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Green;
            //        }
            //        else
            //        {
            //            Point1_Label.OutputColor = CogColorConstants.Red;
            //            InspectResult[CameraNumber] = false;
            //            Glob.MeasureResult[CameraNumber] = false;
            //        }
            //    }
            //    Point1_Label.Run();
            //    cog.StaticGraphics.Add(Point1_Label.GetOutputGraphicLabel(), "");
            //}
            //else
            //{
            //    InspectResult[CameraNumber] = false;
            //    Glob.MeasureResult[CameraNumber] = false;
            //}

            for (int i = 0; i < Collection.Count; i++)
            {
                if (Collection[i].ToString() == "null")
                {

                }
                if (Collection[i].ToString() == "Cognex.VisionPro.CogGraphicLabel")
                    Collection[i].Color = CogColorConstants.Blue;
            }

            if (Glob.PatternResult[CameraNumber]) { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN OK"); }
            else { DisplayLabelShow(Collection2, cog, LabelPointX, LabelPointY, "PATTERN NG"); };

            if (Glob.BlobResult[CameraNumber]) { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB OK"); }
            else { DisplayLabelShow(Collection3, cog, LabelPointX, LabelPointY + 70, "BLOB NG"); };

           
            for (int i = 0; i < Collection2.Count; i++)
                Collection2[i].Color = Glob.PatternResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;
            for (int i = 0; i < Collection3.Count; i++)
                Collection3[i].Color = Glob.BlobResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;
           

            cog.StaticGraphics.AddList(Collection, "");
            cog.StaticGraphics.AddList(Collection2, "");
            cog.StaticGraphics.AddList(Collection3, "");
           

            //if (Glob.RunnModel.Modelname() == "354-0024")
            //{
            //    if (Glob.MeasureResult[CameraNumber]) { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE OK : {Glob.CAM_Point208Value[CameraNumber].ToString("F3")}"); }
            //    else { DisplayLabelShow(Collection4, cog, LabelPointX, LabelPointY + 150, $"LINE NG : {Glob.CAM_Point208Value[CameraNumber].ToString("F3")}"); };

            //    for (int i = 0; i < Collection4.Count; i++)
            //        Collection4[i].Color = Glob.MeasureResult[CameraNumber] == true ? CogColorConstants.Green : CogColorConstants.Red;

            //    cog.StaticGraphics.AddList(Collection4, "");

            //}

            return InspectResult[CameraNumber];
        }
        #endregion

       
        public bool LineLineDistance(CogImage8Grey img, int CamNumber, CogDisplay cog)
        {
            bool rs = true;
            CogLineSegment segment;
            CogDistancePointLineTool Point1 = new CogDistancePointLineTool();
            Point1.InputImage = img;


            if (TempLines[CamNumber, 2].GetLine() == null)
            {
                return false;
            }
            Point1.X = TempLines[CamNumber, 2].Average_PointX();
            Point1.Y = TempLines[CamNumber, 2].Average_PointY();

            if (TempLines[CamNumber, 1].GetLine() == null)
            {
                return false;
            }

            Point1.Line = TempLines[CamNumber, 1].GetLine();
            Point1.Run();
            segment = (CogLineSegment)Point1.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Arrow"].Content;
            cog.StaticGraphics.Add(segment, "");
            if (CamNumber == 0 || CamNumber == 2)
            {
                Glob.CAM_Point208Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue[CamNumber];
            }
            else if (CamNumber == 1)
            {
                Glob.CAM_Point501Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue[CamNumber];
            }
            return rs;
        }

        public bool PointLineDistance(CogImage8Grey img, int CamNumber, CogDisplay cog)
        {
            bool rs = true;
            CogLineSegment segment;
            CogDistancePointLineTool Point1 = new CogDistancePointLineTool();
            CogIntersectLineLineTool IntersectPoint = new CogIntersectLineLineTool();

            IntersectPoint.InputImage = img;
            Point1.InputImage = img;
           
            if (Glob.CurruntModelName == "354-0024")
            {
                if (CamNumber == 0 || CamNumber == 2)
                {
                    if (TempLines[CamNumber, 3].GetLine() == null || TempLines[CamNumber, 4].GetLine() == null)
                    {
                        return false;
                    }

                    IntersectPoint.LineA = TempLines[CamNumber, 3].GetLine();
                    IntersectPoint.LineB = TempLines[CamNumber, 4].GetLine();
                    IntersectPoint.Run();

                    Point1.X = IntersectPoint.X;
                    Point1.Y = IntersectPoint.Y;
                }
                else if (CamNumber == 1 || CamNumber == 3 || CamNumber == 5)
                {
                    if (TempLines[CamNumber, 3].GetLine() == null)
                    {
                        return false;
                    }
                    Point1.X = TempLines[CamNumber, 3].Average_PointX();
                    Point1.Y = TempLines[CamNumber, 3].Average_PointY();
                }

            }
            else
            {
                if (TempLines[CamNumber, 3].GetLine() == null)
                {
                    return false;
                }
                Point1.X = TempLines[CamNumber, 3].Average_PointX();
                Point1.Y = TempLines[CamNumber, 3].Average_PointY();
            }

            Point1.Line = TempLines[CamNumber, 1].GetLine();
            Point1.Run();

            segment = (CogLineSegment)Point1.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Arrow"].Content;
            cog.StaticGraphics.Add(segment, "");

            if (CamNumber == 0 || CamNumber == 2)
            {
                Glob.CAM_Point208Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue[CamNumber];
            }
            else if (CamNumber == 1)
            {
                Glob.CAM_Point501Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue[CamNumber];
            }
            else if (CamNumber == 3 || CamNumber == 5)
            {
                Glob.CAM_Point502Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue[CamNumber];
            }
            return rs;
        }
        public bool PointLineDistance2(CogImage8Grey img, int CamNumber, CogDisplay cog)
        {
            bool rs = true;
            CogLineSegment segment;
            CogCreateSegmentTool AverageLine = new CogCreateSegmentTool();
            CogDistancePointLineTool Point1 = new CogDistancePointLineTool();
            CogIntersectLineLineTool IntersectPoint = new CogIntersectLineLineTool();

            AverageLine.InputImage = img;
            IntersectPoint.InputImage = img;
            Point1.InputImage = img;
            if (TempLines[CamNumber, 1].GetLine() == null || TempLines[CamNumber, 2].GetLine() == null)
            {
                return false;
            }
            AverageLine.Segment.StartX = TempLines[CamNumber, 1].Average_PointX();
            AverageLine.Segment.StartY = TempLines[CamNumber, 1].Average_PointY();
            AverageLine.Segment.EndX = TempLines[CamNumber, 2].Average_PointX();
            AverageLine.Segment.EndY = TempLines[CamNumber, 2].Average_PointY();

            AverageLine.Run();
            cog.StaticGraphics.Add(AverageLine.GetOutputSegment().CreateLine(), "");

            if (TempLines[CamNumber, 4].GetLine() == null)
            {
                return false;
            }

            Point1.X = TempLines[CamNumber, 4].Average_PointX();
            Point1.Y = TempLines[CamNumber, 4].Average_PointY();

            Point1.Line = AverageLine.GetOutputSegment().CreateLine();
            Point1.Run();

            segment = (CogLineSegment)Point1.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Arrow"].Content;
            cog.StaticGraphics.Add(segment, "");
            if (CamNumber == 1)
            {
                Glob.CAM_Point409Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue2[CamNumber];
            }
            else
            {
                Glob.CAM_Point405Value[CamNumber] = Point1.Distance * Glob.CAM_CalValue2[CamNumber];
            }
            return rs;
        }
        public bool LineLineAngle(CogImage8Grey img, int CamNumber, CogDisplay cog)
        {
            bool rs = true;
            double anglevalue = 0;
            double anglevalue2 = 0;
            CogCircularArc segment;
            CogCircularArc segment2;
            CogCreateSegmentTool AverageLine = new CogCreateSegmentTool();
            CogAngleLineLineTool PointAngle = new CogAngleLineLineTool();
            CogAngleLineLineTool PointAngle2 = new CogAngleLineLineTool();

            AverageLine.InputImage = img;
            PointAngle.InputImage = img;
            PointAngle2.InputImage = img;

            if (TempLines[CamNumber, 2].GetLine() == null || TempLines[CamNumber, 1].GetLine() == null)
            {
                return false;
            }

            PointAngle.LineA = TempLines[CamNumber, 4].GetLine();
            PointAngle.LineB = TempLines[CamNumber, 1].GetLine();
            PointAngle.Run();

            PointAngle2.LineA = TempLines[CamNumber, 4].GetLine();
            PointAngle2.LineB = TempLines[CamNumber, 2].GetLine();
            PointAngle2.Run();

            anglevalue = (PointAngle.Angle * 180) / Math.PI;
            anglevalue2 = (PointAngle2.Angle * 180) / Math.PI;
            if (anglevalue < 0)
            {
                anglevalue = anglevalue * -1;
            }
            if (anglevalue2 < 0)
            {
                anglevalue2 = anglevalue2 * -1;
            }
            
            Glob.CAM_Point500Value[CamNumber] = anglevalue;
            Glob.CAM_Point500Value2[CamNumber] = anglevalue2;
            segment = (CogCircularArc)PointAngle.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Angle"].Content;
            segment2 = (CogCircularArc)PointAngle2.CreateLastRunRecord().SubRecords["InputImage"].SubRecords["Angle"].Content;
            cog.StaticGraphics.Add(segment, "");
            cog.StaticGraphics.Add(segment2, "");

            return rs;
        }
        public void DgvResult(DataGridView dgv, int camnumber, int cellnumber)
        {
            if (frm_toolsetup != null)
            {
                for (int i = 0; i < 30; i++)
                {
                    if (TempBlobEnable[camnumber, i] == true)
                    {
                        if (TempBlobs[camnumber, i].ResultBlobCount() != TempBlobOKCount[camnumber, i]) // - 검사결과 NG
                        {
                            dgv.Rows[i].Cells[3].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[3].Style.BackColor = Color.Red;
                        }
                        else // - 검사결과 OK
                        {
                            dgv.Rows[i].Cells[3].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[3].Style.BackColor = Color.Lime;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[3].Value = "NOT USED";
                        dgv.Rows[i].Cells[3].Style.BackColor = SystemColors.Control;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    if (TempBlobEnable[camnumber, i] == true)
                    {
                        if (TempBlobs[camnumber, i].ResultBlobCount() != TempBlobOKCount[camnumber, i]) // - 검사결과 NG
                        {
                            dgv.Rows[i].Cells[cellnumber + 1].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = Color.Red;
                        }
                        else // - 검사결과 OK
                        {
                            dgv.Rows[i].Cells[cellnumber + 1].Value = $"{TempBlobs[camnumber, i].ResultBlobCount()}-({TempBlobOKCount[camnumber, i]})";
                            dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = Color.Lime;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[cellnumber + 1].Value = "NOT USED";
                        dgv.Rows[i].Cells[cellnumber + 1].Style.BackColor = SystemColors.Control;
                    }
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (TempMultiEnable[camnumber, i] == true)
                {
                    if (TempMulti[camnumber, i].ResultPoint(TempMulti[camnumber, i].HighestResultToolNumber()) != null)
                    {
                        if (Glob.MultiInsPat_Result[camnumber, i] > TempMulti[camnumber, i].Threshold() * 100)
                        {
                            dgv.Rows[i].Cells[cellnumber].Value = Glob.MultiInsPat_Result[camnumber, i].ToString("F2");
                            dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Lime;
                        }
                        else
                        {
                            dgv.Rows[i].Cells[cellnumber].Value = Glob.MultiInsPat_Result[camnumber, i].ToString("F2");
                            dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Red;
                            InspectResult[camnumber] = false;
                        }
                    }
                    else
                    {
                        dgv.Rows[i].Cells[cellnumber].Value = "NG";
                        dgv.Rows[i].Cells[cellnumber].Style.BackColor = Color.Red;
                        InspectResult[camnumber] = false;
                    }
                }
                else
                {
                    dgv.Rows[i].Cells[cellnumber].Value = "NOT USED";
                    dgv.Rows[i].Cells[cellnumber].Style.BackColor = SystemColors.Control;
                }
            }
        }
        public void DisplayLabelShow(CogGraphicCollection Collection, CogDisplay cog, int X, int Y, string Text)
        {
            CogCreateGraphicLabelTool Label = new CogCreateGraphicLabelTool();
            Label.InputGraphicLabel.Color = Cognex.VisionPro.CogColorConstants.Green;
            Label.InputImage = cog.Image;
            Label.InputGraphicLabel.X = X;
            Label.InputGraphicLabel.Y = Y;
            Label.InputGraphicLabel.Text = Text;
            Label.Run();
            Collection.Add(Label.GetOutputGraphicLabel());
        }
        public void ImageSave1(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\{dt.ToString("yyyyMMdd")}\CAM{CamNumber}\{Result}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //log.AddLogFileList(ee.Message);
            }
        }
        public void ImageSave2(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\{dt.ToString("yyyyMMdd")}\CAM{CamNumber}\{Result}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }
        public void ImageSave3(string Result, int CamNumber, CogDisplay cog)
        {
            //NG 이미지와 OK 이미지 구별이 필요할 것 같음 - 따로 요청이 없어서 구별해놓진 않음
            try
            {
                CogImageFileJPEG ImageSave = new CogImageFileJPEG();
                DateTime dt = DateTime.Now;
                string Root = Glob.ImageSaveRoot + $@"\{Glob.CurruntModelName}\{dt.ToString("yyyyMMdd")}\CAM{CamNumber}\{Result}";

                if (!Directory.Exists(Root))
                {
                    Directory.CreateDirectory(Root);
                }
                //cog.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom).Save(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}_All" + ".jpg", ImageFormat.Jpeg);
                ImageSave.Open(Root + $@"\{dt.ToString("HH mm ss")}" + $"_{Result}" + ".jpg", CogImageFileModeConstants.Write);
                ImageSave.Append(cog.Image);
                ImageSave.Close();
            }
            catch (Exception ee)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - {ee.Message}");
                //cm.info(ee.Message);
            }
        }
       
        public void DataSave1(string Result, int CamNumber)
        {
            //DATA 저장부분 TEST 후 적용 시키기.
            DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            //1.시간,2.결과값,3.불량위치// 
            Root += $@"\Data_{dt.ToString("yyyyMMdd")}.csv";
            Writer = new StreamWriter(Root, true);
            Writer.WriteLine($"Time,{dt.ToString("yyyyMMdd_HH mm ss")},Result,{Result}");
            Writer.Close();
        }
        public void DataSave2(string Result, int CamNumber)
        {
            //DATA 저장부분 TEST 후 적용 시키기.
            DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            //1.시간,2.결과값,3.불량위치// 
            Root += $@"\Data_{dt.ToString("yyyyMMdd")}.csv";
            Writer = new StreamWriter(Root, true);
            Writer.WriteLine($"Time,{dt.ToString("yyyyMMdd_HH mm ss")},Result,{Result}");
            Writer.Close();
        }
        public void DataSave3(string Result, int CamNumber)
        {
            //DATA 저장부분 TEST 후 적용 시키기.
            DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot + $@"\{Glob.CurruntModelName}\CAM{CamNumber}\{dt.ToString("yyyyMMdd")}";
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            //1.시간,2.결과값,3.불량위치// 
            Root += $@"\Data_{dt.ToString("yyyyMMdd")}.csv";
            Writer = new StreamWriter(Root, true);
            Writer.WriteLine($"Time,{dt.ToString("yyyyMMdd_HH mm ss")},Result,{Result}");
            Writer.Close();
        }
       
        public void ErrorLogSave()
        {
            DateTime dt = DateTime.Now;
            string Root = Glob.DataSaveRoot;
            StreamWriter Writer;
            if (!Directory.Exists(Root))
            {
                Directory.CreateDirectory(Root);
            }
            Root += $@"\ErrorLog_{dt.ToString("yyyyMMdd-HH")}.csv";
            Writer = new StreamWriter(Root, true);
            Writer.WriteLine($"Time,{dt.ToString("yyyyMMdd_HH mm ss")}");
            Writer.Close();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            log.AddLogMessage(LogType.Infomation, 0, "AUTO MODE STOP");
            AutoRun = false;
            btn_Stop.Enabled = false;
            btn_ToolSetUp.Enabled = true;
            btn_Model.Enabled = true;
            btn_SystemSetup.Enabled = true;
            btn_Status.Enabled = true;
            VisionReddyOff();
            for (int k = 2; k < 15; k++)
            {
                OutPutSignal_Off(k);
            }
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
            //MODEL FORM 열기.
            Frm_Model frm_model = new Frm_Model(Glob.RunnModel.Modelname(), this);
            frm_model.Show();
        }

        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            //****************************단축키 모음****************************//
            if (e.Control && e.KeyCode == Keys.T) //ctrl + t : 툴셋팅창 열기
                btn_ToolSetUp.PerformClick();
            if (e.Control && e.KeyCode == Keys.M) //ctrl + m : 모델창 열기
                btn_Model.PerformClick();
            if (e.Control && e.KeyCode == Keys.C) //ctrl + c : 카메라 셋팅창 열기.
                btn_CamList_Click(sender, e);
            if (e.KeyCode == Keys.Escape) // esc : 프로그램 종료
                btn_Exit.PerformClick();
        }

        private void btn_CamList_Click(object sender, EventArgs e)
        {
            Frm_CamSet frm_camset = new Frm_CamSet(this);
            if (frm_camset.ShowDialog() == DialogResult.OK)
            {
                //Camera Serial Number Setting 이후 프로그램 재시작하여, Camera 연결.
                Application.Restart(); //프로그램 재시작
            }
            else
            {

            }
        }
        private void VisionReddyOn()
        {
            short ret;
            int jobNo = 0;
            ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 1);
        }
        private void VisionReddyOff()
        {
            short ret;
            int jobNo = 0;
            ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 0);
        }
        private void OUTPUT_Click(object sender, EventArgs e)
        {
            try
            {
                short ret;
                int jobNo = Convert.ToInt16((sender as Button).Tag);
                ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 1);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        private void OUTPUTOFF_Click(object sender, EventArgs e)
        {
            try
            {
                short ret;
                int jobNo = Convert.ToInt16((sender as Button).Tag);
                ret = DASK.DO_WriteLine((ushort)m_dev, 0, (ushort)jobNo, 0);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }
        }
        private void Frm_Main_Paint(object sender, PaintEventArgs e)
        {
            if (frm_loading != null)
            {
                frm_loading.Close();
                frm_loading.Dispose();
                frm_loading = null;
            }
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            int jobNo = Convert.ToInt16((sender as Button).Tag);
            Main_TabControl.SelectedIndex = jobNo;
        }
        public void LightCondition_1()
        {
            if (LightControl1.IsOpen == false)
            {
                return;
            }
            LightStats = true;
            string LightValue = string.Format("{0:D3}", 0);
            string LightValue2 = string.Format("{0:D3}", 255);
            string LightValue3 = string.Format("{0:D3}", 0);
            string LightValue4 = string.Format("{0:D3}", 0);
            LightValue = ":L" + 1 + LightValue + "\r\n";
            LightValue2 = ":L" + 2 + LightValue2 + "\r\n";
            LightValue3 = ":L" + 3 + LightValue3 + "\r\n";
            LightValue4 = ":L" + 4 + LightValue4 + "\r\n";
            LightControl1.Write(LightValue.ToCharArray(), 0, LightValue.ToCharArray().Length);
            LightControl1.Write(LightValue2.ToCharArray(), 0, LightValue2.ToCharArray().Length);
            LightControl1.Write(LightValue3.ToCharArray(), 0, LightValue3.ToCharArray().Length);
            LightControl1.Write(LightValue4.ToCharArray(), 0, LightValue4.ToCharArray().Length);
        }
        public void LightCondition_2()
        {
            if (LightControl1.IsOpen == false)
            {
                return;
            }
            LightStats = true;
            string LightValue = string.Format("{0:D3}", 255);
            string LightValue2 = string.Format("{0:D3}", 255);
            string LightValue3 = string.Format("{0:D3}", 0);
            string LightValue4 = string.Format("{0:D3}", 0);
            LightValue = ":L" + 1 + LightValue + "\r\n";
            LightValue2 = ":L" + 2 + LightValue2 + "\r\n";
            LightValue3 = ":L" + 3 + LightValue3 + "\r\n";
            LightValue4 = ":L" + 4 + LightValue4 + "\r\n";
            LightControl1.Write(LightValue.ToCharArray(), 0, LightValue.ToCharArray().Length);
            LightControl1.Write(LightValue2.ToCharArray(), 0, LightValue2.ToCharArray().Length);
            LightControl1.Write(LightValue3.ToCharArray(), 0, LightValue3.ToCharArray().Length);
            LightControl1.Write(LightValue4.ToCharArray(), 0, LightValue4.ToCharArray().Length);
        }
        public void LightCondition_3()
        {
            if (LightControl1.IsOpen == false)
            {
                return;
            }
            LightStats = true;
            string LightValue = string.Format("{0:D3}", 0);
            string LightValue2 = string.Format("{0:D3}", 255);
            string LightValue3 = string.Format("{0:D3}", 255);
            string LightValue4 = string.Format("{0:D3}", 0);
            LightValue = ":L" + 1 + LightValue + "\r\n";
            LightValue2 = ":L" + 2 + LightValue2 + "\r\n";
            LightValue3 = ":L" + 3 + LightValue3 + "\r\n";
            LightValue4 = ":L" + 4 + LightValue4 + "\r\n";
            LightControl1.Write(LightValue.ToCharArray(), 0, LightValue.ToCharArray().Length);
            LightControl1.Write(LightValue2.ToCharArray(), 0, LightValue2.ToCharArray().Length);
            LightControl1.Write(LightValue3.ToCharArray(), 0, LightValue3.ToCharArray().Length);
            LightControl1.Write(LightValue4.ToCharArray(), 0, LightValue4.ToCharArray().Length);
        }
        public void LightON()
        {
            if (LightControl1.IsOpen == false)
            {
                return;
            }
            LightStats = true;
            string LightValue = string.Format("{0:D3}", 255);
            string LightValue2 = string.Format("{0:D3}", 255);
            string LightValue3 = string.Format("{0:D3}", 255);
            string LightValue4 = string.Format("{0:D3}", 255);
            LightValue = ":L" + 1 + LightValue + "\r\n";
            LightValue2 = ":L" + 2 + LightValue2 + "\r\n";
            LightValue3 = ":L" + 3 + LightValue3 + "\r\n";
            LightValue4 = ":L" + 4 + LightValue4 + "\r\n";
            LightControl1.Write(LightValue.ToCharArray(), 0, LightValue.ToCharArray().Length);
            LightControl1.Write(LightValue2.ToCharArray(), 0, LightValue2.ToCharArray().Length);
            LightControl1.Write(LightValue3.ToCharArray(), 0, LightValue3.ToCharArray().Length);
            LightControl1.Write(LightValue4.ToCharArray(), 0, LightValue4.ToCharArray().Length);
        }
        public void LightOFF()
        {
            if (LightControl1.IsOpen == false)
            {
                return;
            }
            LightStats = false;
            string LightValue = string.Format("{0:D3}", 0);
            string LightValue2 = string.Format("{0:D3}", 0);
            string LightValue3 = string.Format("{0:D3}", 0);
            string LightValue4 = string.Format("{0:D3}", 0);
            LightValue = ":L" + 1 + LightValue + "\r\n";
            LightValue2 = ":L" + 2 + LightValue2 + "\r\n";
            LightValue3 = ":L" + 3 + LightValue3 + "\r\n";
            LightValue4 = ":L" + 4 + LightValue4 + "\r\n";
            LightControl1.Write(LightValue.ToCharArray(), 0, LightValue.ToCharArray().Length);
            LightControl1.Write(LightValue2.ToCharArray(), 0, LightValue2.ToCharArray().Length);
            LightControl1.Write(LightValue3.ToCharArray(), 0, LightValue3.ToCharArray().Length);
            LightControl1.Write(LightValue4.ToCharArray(), 0, LightValue4.ToCharArray().Length);
        }

        private void btn_Light_Click(object sender, EventArgs e)
        {
            if (LightControl1.IsOpen == false)
            {
                log.AddLogMessage(LogType.Error, 0, $"{MethodBase.GetCurrentMethod().Name} - LightControl Not Connected");
                return;
            }
            //if (LightStats == false)
            //{
            //    LightON();
            //}
            //else
            //{
            LightOFF();
            //}
        }

        private void btn_ReconnectCam_Click(object sender, EventArgs e)
        {
            DistoryCamera();
            Thread.Sleep(50);
            Initialize_CamvalueInit();
            Initialize_CameraInit();
        }
        private void IOCHECK()
        {
            btn_INPUT0.BackColor = gbool_di[0] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT1.BackColor = gbool_di[1] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT2.BackColor = gbool_di[2] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT3.BackColor = gbool_di[3] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT4.BackColor = gbool_di[4] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT5.BackColor = gbool_di[5] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT6.BackColor = gbool_di[6] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT7.BackColor = gbool_di[7] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT8.BackColor = gbool_di[8] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT9.BackColor = gbool_di[9] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT10.BackColor = gbool_di[10] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT11.BackColor = gbool_di[11] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT12.BackColor = gbool_di[12] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT13.BackColor = gbool_di[13] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT14.BackColor = gbool_di[14] == true ? Color.Lime : SystemColors.Control;
            btn_INPUT15.BackColor = gbool_di[15] == true ? Color.Lime : SystemColors.Control;
        }
        private void bk_IO_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(200);
                if (bk_IO.CancellationPending == true) //취소요청이 들어오면 return
                {
                    return;
                }
                ushort i;
                short result;

                for (i = 0; i < 16; i++)
                {
                    re_gbool_di[i] = gbool_di[i];
                }

                for (i = 0; i < 16; i++)
                {
                    result = DASK.DI_ReadLine((ushort)m_dev, 0, i, out didata[i]); //InPut 읽음 (카드넘버,포트0번,In단자번호,버퍼메모리(In단자1일때 1,In단자0일때 0) 
                    if (didata[i] == 1)
                    {
                        gbool_di[i] = true;
                    }
                    else
                    {
                        gbool_di[i] = false;
                    }
                }
                //IO CHECK - DISPLAY 표시 부분
                BeginInvoke((Action)delegate { IOCHECK(); });
                for (i = 0; i < 16; i++)
                {
                    if (gbool_di[i] != re_gbool_di[i] && gbool_di[i] == true)
                    {
                        switch (i)
                        {
                            case 0: //트리거 신호 확인.
                                for (int k = 2; k < 15; k++)
                                {
                                    OutPutSignal_Off(k);
                                }

                                LightCondition_1();
                                cdyDisplay.Image = null;
                                cdyDisplay.InteractiveGraphics.Clear();
                                cdyDisplay.StaticGraphics.Clear();
                                cdyDisplay2.Image = null;
                                cdyDisplay2.InteractiveGraphics.Clear();
                                cdyDisplay2.StaticGraphics.Clear();
                                cdyDisplay3.Image = null;
                                cdyDisplay3.InteractiveGraphics.Clear();
                                cdyDisplay3.StaticGraphics.Clear();

                                BeginInvoke((Action)delegate
                                {
                                    lb_Cam1_Result.Text = "Result";
                                    lb_Cam1_Result.BackColor = SystemColors.Control;
                                    lb_Cam2_Result.Text = "Result";
                                    lb_Cam2_Result.BackColor = SystemColors.Control;
                                    lb_Cam3_Result.Text = "Result";
                                    lb_Cam3_Result.BackColor = SystemColors.Control;
                                });

                                snap1 = new Thread(new ThreadStart(SnapShot1));
                                snap1.Priority = ThreadPriority.Highest;
                                snap1.Start();

                                snap2 = new Thread(new ThreadStart(SnapShot2));
                                snap2.Priority = ThreadPriority.Highest;
                                snap2.Start();

                                snap3 = new Thread(new ThreadStart(SnapShot3));
                                snap3.Priority = ThreadPriority.Highest;
                                snap3.Start();
                                break;
                            case 1: //트리거 신호 확인.

                                //OutPutSignal_Off(2);
                                //Thread.Sleep(100);
                                //OutPutSignal_Off(4);
                                //Thread.Sleep(100);
                                Thread.Sleep(500);
                                OutPutSignal_On(2);
                                Thread.Sleep(500);
                                OutPutSignal_On(4);
                                
                                
                                break;
                            case 2: //트리거 신호 확인.

                                //OutPutSignal_Off(12);
                                //Thread.Sleep(100);
                                //OutPutSignal_Off(14);
                                //Thread.Sleep(100);
                                Thread.Sleep(500);
                                OutPutSignal_On(12);
                                Thread.Sleep(500);
                                OutPutSignal_On(14);
                                break;
                        }
                    }
                }
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bk_IO.IsBusy == true)
            {
                bk_IO.CancelAsync();
            }
            DistoryCamera();
        }

        private void lb_Cam1Stats_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            CogImage8Grey Monoimage = new CogImage8Grey();
            /*mageDelete = false;*/
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Glob.ImageFilePath = ofd.FileName;
                string type = Path.GetExtension(ofd.FileName);
                string[] ImageFileName = ofd.FileNames;

                CogImageFileBMP Imageopen2 = new CogImageFileBMP();
                Imageopen2.Open(ofd.FileName, CogImageFileModeConstants.Read);
                Monoimage = (CogImage8Grey)Imageopen2[0];
                Imageopen2.Close();

                cdyDisplay.Image = Monoimage;
                cdyDisplay.InteractiveGraphics.Clear();
                cdyDisplay.StaticGraphics.Clear();
            }
        }

        private void btn_inspectUp_Click(object sender, EventArgs e)
        {
            LightCondition_1();
            Thread.Sleep(50);
            cdyDisplay.Image = null;
            cdyDisplay.InteractiveGraphics.Clear();
            cdyDisplay.StaticGraphics.Clear();
            cdyDisplay2.Image = null;
            cdyDisplay2.InteractiveGraphics.Clear();
            cdyDisplay2.StaticGraphics.Clear();
            cdyDisplay3.Image = null;
            cdyDisplay3.InteractiveGraphics.Clear();
            cdyDisplay3.StaticGraphics.Clear();
            BeginInvoke((Action)delegate
            {
                lb_Cam1_Result.Text = "Result";
                lb_Cam1_Result.BackColor = SystemColors.Control;
                lb_Cam2_Result.Text = "Result";
                lb_Cam2_Result.BackColor = SystemColors.Control;
                lb_Cam3_Result.Text = "Result";
                lb_Cam3_Result.BackColor = SystemColors.Control;
            });

            snap1 = new Thread(new ThreadStart(SnapShot1));
            snap1.Priority = ThreadPriority.Highest;
            snap1.Start();

            snap2 = new Thread(new ThreadStart(SnapShot2));
            snap2.Priority = ThreadPriority.Highest;
            snap2.Start();

            snap3 = new Thread(new ThreadStart(SnapShot3));
            snap3.Priority = ThreadPriority.Highest;
            snap3.Start();
        }

        private void cb_AllNG_CheckedChanged(object sender, EventArgs e)
        {
            INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로
            if (cb_AllNG.Checked == true)
            {
                Glob.InspectType = true;
            }
            else
            {
                Glob.InspectType = false;
            }
            setting.WriteData("SYSTEM", "InspectType", Glob.InspectType.ToString());
        }

        private void cb_NutNG_CheckedChanged(object sender, EventArgs e)
        {
            INIControl setting = new INIControl(Glob.SETTING); // ini파일 경로
            if (cb_NutNG.Checked == true)
            {
                Glob.InspectType = false;
            }
            else
            {
                Glob.InspectType = true;
            }
            setting.WriteData("SYSTEM", "InspectType", Glob.InspectType.ToString());
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvtype = dgv.GetType();
            PropertyInfo pi = dgvtype.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
