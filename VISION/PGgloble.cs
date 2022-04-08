using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION
{
    public class PGgloble
    {
        #region "DO NOT TOUCH"
        private static PGgloble instance = null;
        private static readonly object Lock = new object();

        private PGgloble()
        {

        }

        public static PGgloble getInstance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new PGgloble();
                    }
                    return instance;
                }
            }
        }
        #endregion
        public readonly string PROGRAMROOT = Application.StartupPath;

        public readonly string MODELROOT = Application.StartupPath + "\\Models"; //모델저장경로.
        public readonly string MODELLIST = Application.StartupPath + "\\ModelList.ini"; //모델리스트 ini파일

        public readonly string MODELCONFIGFILE = "\\Modelcfg.ini"; //모델 사용유무 저장.

        public readonly string CONFIGFILE = Application.StartupPath + "\\config.ini";
        public readonly string SETTING = Application.StartupPath + "\\setting.ini"; //setting값 저장
        //C:\Users\MB990VF\Desktop\GENTEX_HEATSINK_20210719\VISION\bin\x64\Debug\Models\354-0024\MasterImage
        public readonly string MasterImageFilePath = Application.StartupPath + "\\Models";
        public readonly string PROGRAM_VERSION = "1.0.0"; //Program Version
        #region "버전 관리 및 업데이트 내용"
        //1.0.0 - 현장투입 후 완성된 최종버전(주요기능 및 프로그램 구성 완료) - 날짜 / 이름
        #endregion

        // 시스템
        public Cogs.Model RunnModel = null;

        public string CurruntModelName;
        public string ImageSaveRoot; // 이미지 저장 경로
        public string DataSaveRoot; // 검사 결과 저장 경로
        public string LineName; // 프로그램 메인 화면 중앙 상단에 적힐 무언가.

        public string Camera_SerialNumber; //카메라 시리얼번호.
        public CamSets[] CameraOption = new CamSets[3]; //카메라 옵션 클래스

        // Light controller
        public int LightControlNumber;
        public string PortName; // 포트 번호
        public string Parity; // 패리티 비트
        public string StopBits; // 스톱비트
        public string DataBit; // 데이터 비트
        public string BaudRate; // 보오 레이트
        public int[] LightCH = new int[4]; //조명컨트롤러 채널(컨트롤번호, 채널번호) 조명값

        public string ImageFilePath; //이미지파일경로.
        public int CamNumber; //사용카메라번호

        public double[] CAM_PixValue = new double[3];
        public double[] CAM_CalValue = new double[3];
        public double[] CAM_CalValue2 = new double[3];
        public double[] CAM_Point208Value = new double[3];
        public double[] CAM_Point500Value = new double[3];
        public double[] CAM_Point500Value2 = new double[3];
        public double[] CAM_Point501Value = new double[3];
        public double[] CAM_Point502Value = new double[3];
        public double[] CAM_Point409Value = new double[3];
        public double[] CAM_Point405Value = new double[3];

        public bool CAM1_Inspect = false;
        public bool CAM2_Inspect = false;
        public bool CAM3_Inspect = false;

        //검사 방식 설정
        public bool InspectType = true; //true : 모든불량 NG 배출 , false : 너트 미조립 NG 배출

        //CAMERA별 PIXEL 값
        public bool OKImageSave = true;
        public bool NGImageSave = true;

        public double[,] MultiInsPat_Result = new double[3, 30];
        public double[,] MultiPatternResultData = new double[3, 30];
        public bool[,] b_MultiInspat_Result = new bool[3, 30];

        public int SelectPCNumber;

        public bool[] PatternResult = new bool[3];
        public bool[] BlobResult = new bool[3];
        public bool[] MeasureResult = new bool[3];

        public double Point208_Min;
        public double Point208_Stand;
        public double Point208_Max;
        public double Point500_Min;
        public double Point500_Stand;
        public double Point500_Max;
        public double Point501_Min;
        public double Point501_Stand;
        public double Point501_Max;
        public double Point502_Min;
        public double Point502_Stand;
        public double Point502_Max;
        public double Point409_Min;
        public double Point409_Stand;
        public double Point409_Max;
        public double Point405_Min;
        public double Point405_Stand;
        public double Point405_Max;
    }
    public struct CamSets
    {
        public double Exposure; //조리개값
        public double Gain;
        public int DelayTime; //지연시간
    }
}
