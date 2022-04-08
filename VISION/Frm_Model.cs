using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION
{
    public partial class Frm_Model : Form
    {
        private Class_Common cm { get { return Program.cm; } }
        PGgloble Glob; //글로벌함수
        private string SelectedModel = "";
        private string NowModel;
        Frm_Main Main;

        public Frm_Model(string NowModelName, Frm_Main main)
        {
            InitializeComponent();
            NowModel = NowModelName;
            Main = main;
            Glob = PGgloble.getInstance;
        }

        private void btn_NewModel_Click(object sender, EventArgs e)
        {
            Frm_NewModel Create = new Frm_NewModel();
            if (Create.ShowDialog() == DialogResult.OK)
            {
                RefreashList();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_LoadModel_Click(object sender, EventArgs e)
        {
            PGgloble gls = PGgloble.getInstance;
            if (SelectedModel == "")
            {
                return;
            }
            for (int i = 0; i < 7; i++)
            {
                if (gls.RunnModel.Loadmodel(SelectedModel, gls.MODELROOT, i) == true)
                {
                    if (i == 6)
                    {
                        MessageBox.Show("모델 전환 성공", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            tb_CurruntModel.Text = gls.RunnModel.Modelname();
            NowModel = gls.RunnModel.Modelname();
            ChangeSpecValue(NowModel); //0024 스펙이 달라 스펙변경하는 함수 추가 20210603 김형민
            CameraSpecChange(NowModel); //모델별 Camera Exposure값이 다르기때문에 각 모델별로 설정된 값으로 변경하는 함수 추가 20210603 김형민
            //Main.CameraSettingCheck();
        }
        private void CameraSpecChange(string ModelName)
        {
            //INIControl CFGFILE = new INIControl(Glob.CONFIGFILE);  // ini파일 경로
            //string LastModel = CFGFILE.ReadData("LASTMODEL", "NAME"); //마지막 사용모델 확인.
            INIControl CamSet = new INIControl($"{Glob.MODELROOT}\\{ModelName}\\CamSet.ini");
            for (int i = 0; i < 7; i++)
            {
                Main.ExposureSet(i, Convert.ToDouble(CamSet.ReadData($"Camera{i}", "Exposure"))); //노출값 설정
            }
        }
        private void ChangeSpecValue(string ModelName)
        {
         
            INIControl CalibrationValue = new INIControl($"{Glob.MODELROOT}\\{ModelName}\\CalibrationValue.ini");
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

        private void Frm_Model_Load(object sender, EventArgs e)
        {
            tb_CurruntModel.Text = NowModel;
            tb_SelectModel.Text = SelectedModel;
            RefreashList();
        }
        private void RefreashList()
        {
            PGgloble gls = PGgloble.getInstance;
            INIControl List = new INIControl(gls.MODELLIST);
            if (System.IO.File.Exists(gls.MODELLIST) == false)
            {
                cm.info("모델 파일을 찾을 수 없습니다.");
                this.Dispose();
                this.Close();
                return;
            }

            System.IO.DirectoryInfo Directorys = new System.IO.DirectoryInfo(gls.MODELROOT);
            System.IO.DirectoryInfo[] dir = Directorys.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly);

            dgvModelList.RowCount = dir.Length;

            for (int lop = 0; lop <= dir.Length - 1; lop++)
            {
                dgvModelList[cName.Index, lop].Value = dir[lop].Name;
                dgvModelList[cNumber.Index, lop].Value = List.ReadData("NAME", dir[lop].Name, true);
            }
        }

        private void btn_DeleteModel_Click(object sender, EventArgs e)
        {
            PGgloble gls = PGgloble.getInstance;
            INIControl List = new INIControl(gls.MODELLIST);
            if (MessageBox.Show("선택한 모델을 삭제 하시겠습니까?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            if (SelectedModel == "")
            {
                return;
            }

            if (SelectedModel == NowModel)
            {
                cm.info("현재 사용중인 모델은 삭제 할 수 없습니다.");
                return;
            }

            try
            {
                System.IO.Directory.Delete(gls.MODELROOT + "\\" + SelectedModel, true);
            }
            catch (Exception ee)
            {
                cm.info(ee.Message);
            }

            if (System.IO.Directory.Exists(gls.MODELROOT + "\\" + SelectedModel) == false)
            {
                string Modelnumber = List.ReadData("NAME", SelectedModel, true);
                List.DeleteKey("NAME", SelectedModel);
                List.DeleteKey("NUMBER", Modelnumber);
                List.WriteData("COUNT", "count", (int.Parse(List.ReadData("COUNT", "count")) - 1).ToString());
                MessageBox.Show("Deleted Complete", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cm.info("모델 삭제에 실패 하였습니다.");
            }
            SelectedModel = "";
            tb_SelectModel.Text = SelectedModel;
            RefreashList();
        }

        private void dgvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedModel = dgvModelList[cName.Index, dgvModelList.SelectedRows[0].Index].Value.ToString();
            tb_SelectModel.Text = SelectedModel;
        }
    }
}
