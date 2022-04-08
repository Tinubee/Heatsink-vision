namespace VISION
{
    partial class Frm_Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.tlpUnder = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SystemSetup = new System.Windows.Forms.Button();
            this.btn_ToolSetUp = new System.Windows.Forms.Button();
            this.btn_Model = new System.Windows.Forms.Button();
            this.btn_CamSet = new System.Windows.Forms.Button();
            this.tlpTopSide = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Mode = new System.Windows.Forms.Label();
            this.lb_CurruntModelName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Time = new System.Windows.Forms.Label();
            this.lb_Ver = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Status = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_PLCStats = new System.Windows.Forms.Label();
            this.timer_Setting = new System.Windows.Forms.Timer(this.components);
            this.LightControl1 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay3 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam3_Result = new System.Windows.Forms.Label();
            this.lb_Cam3Stats = new System.Windows.Forms.Label();
            this.lb_Cam3_InsTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay2 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam2_Result = new System.Windows.Forms.Label();
            this.lb_Cam2Stats = new System.Windows.Forms.Label();
            this.lb_Cam2_InsTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cdyDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Cam1Stats = new System.Windows.Forms.Label();
            this.lb_Cam1_Result = new System.Windows.Forms.Label();
            this.lb_Cam1_InsTime = new System.Windows.Forms.Label();
            this.logControl1 = new KimLib.LogControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel43 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Output14 = new System.Windows.Forms.Button();
            this.btn_Output13 = new System.Windows.Forms.Button();
            this.tableLayoutPanel42 = new System.Windows.Forms.TableLayoutPanel();
            this.button25 = new System.Windows.Forms.Button();
            this.btn_Output12 = new System.Windows.Forms.Button();
            this.tableLayoutPanel41 = new System.Windows.Forms.TableLayoutPanel();
            this.button23 = new System.Windows.Forms.Button();
            this.btn_Output11 = new System.Windows.Forms.Button();
            this.tableLayoutPanel40 = new System.Windows.Forms.TableLayoutPanel();
            this.button21 = new System.Windows.Forms.Button();
            this.btn_Output10 = new System.Windows.Forms.Button();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.button19 = new System.Windows.Forms.Button();
            this.btn_Output9 = new System.Windows.Forms.Button();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.button17 = new System.Windows.Forms.Button();
            this.btn_Output8 = new System.Windows.Forms.Button();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.button15 = new System.Windows.Forms.Button();
            this.btn_Output7 = new System.Windows.Forms.Button();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.button13 = new System.Windows.Forms.Button();
            this.btn_Output6 = new System.Windows.Forms.Button();
            this.tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.button11 = new System.Windows.Forms.Button();
            this.btn_Output5 = new System.Windows.Forms.Button();
            this.tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.btn_Output4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_Output3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_Output2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_Output1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_Output0 = new System.Windows.Forms.Button();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_INPUT15 = new System.Windows.Forms.Button();
            this.btn_INPUT14 = new System.Windows.Forms.Button();
            this.btn_INPUT13 = new System.Windows.Forms.Button();
            this.btn_INPUT12 = new System.Windows.Forms.Button();
            this.btn_INPUT11 = new System.Windows.Forms.Button();
            this.btn_INPUT10 = new System.Windows.Forms.Button();
            this.btn_INPUT9 = new System.Windows.Forms.Button();
            this.btn_INPUT0 = new System.Windows.Forms.Button();
            this.btn_INPUT1 = new System.Windows.Forms.Button();
            this.btn_INPUT2 = new System.Windows.Forms.Button();
            this.btn_INPUT3 = new System.Windows.Forms.Button();
            this.btn_INPUT4 = new System.Windows.Forms.Button();
            this.btn_INPUT5 = new System.Windows.Forms.Button();
            this.btn_INPUT6 = new System.Windows.Forms.Button();
            this.btn_INPUT8 = new System.Windows.Forms.Button();
            this.btn_INPUT7 = new System.Windows.Forms.Button();
            this.Main_TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM3_NGRATE = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lb_CAM3_TOTAL = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lb_CAM3_NG = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lb_CAM3_OK = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM2_NGRATE = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lb_CAM2_TOTAL = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lb_CAM2_NG = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lb_CAM2_OK = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_CAM1_NGRATE = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lb_CAM1_TOTAL = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lb_CAM1_NG = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lb_CAM1_OK = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_IO = new System.Windows.Forms.Button();
            this.btn_Count = new System.Windows.Forms.Button();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Log = new System.Windows.Forms.Button();
            this.btn_Light = new System.Windows.Forms.Button();
            this.btn_ReconnectCam = new System.Windows.Forms.Button();
            this.bk_IO = new System.ComponentModel.BackgroundWorker();
            this.btn_inspectUp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_NutNG = new System.Windows.Forms.CheckBox();
            this.cb_AllNG = new System.Windows.Forms.CheckBox();
            this.tlpUnder.SuspendLayout();
            this.tlpTopSide.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay3)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay2)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel43.SuspendLayout();
            this.tableLayoutPanel42.SuspendLayout();
            this.tableLayoutPanel41.SuspendLayout();
            this.tableLayoutPanel40.SuspendLayout();
            this.tableLayoutPanel39.SuspendLayout();
            this.tableLayoutPanel38.SuspendLayout();
            this.tableLayoutPanel37.SuspendLayout();
            this.tableLayoutPanel36.SuspendLayout();
            this.tableLayoutPanel35.SuspendLayout();
            this.tableLayoutPanel34.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.Main_TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpUnder
            // 
            this.tlpUnder.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpUnder.ColumnCount = 13;
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.959229F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.959229F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.280139F));
            this.tlpUnder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpUnder.Controls.Add(this.btn_SystemSetup, 12, 0);
            this.tlpUnder.Controls.Add(this.btn_ToolSetUp, 4, 0);
            this.tlpUnder.Controls.Add(this.btn_Model, 9, 0);
            this.tlpUnder.Controls.Add(this.btn_CamSet, 8, 0);
            this.tlpUnder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpUnder.Location = new System.Drawing.Point(0, 994);
            this.tlpUnder.Name = "tlpUnder";
            this.tlpUnder.RowCount = 1;
            this.tlpUnder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnder.Size = new System.Drawing.Size(1920, 86);
            this.tlpUnder.TabIndex = 1;
            // 
            // btn_SystemSetup
            // 
            this.btn_SystemSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SystemSetup.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SystemSetup.Image = global::VISION.Properties.Resources.Setting;
            this.btn_SystemSetup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SystemSetup.Location = new System.Drawing.Point(1774, 4);
            this.btn_SystemSetup.Name = "btn_SystemSetup";
            this.btn_SystemSetup.Size = new System.Drawing.Size(142, 78);
            this.btn_SystemSetup.TabIndex = 0;
            this.btn_SystemSetup.Text = "System Setting";
            this.btn_SystemSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SystemSetup.UseVisualStyleBackColor = true;
            this.btn_SystemSetup.Click += new System.EventHandler(this.btn_SystemSetup_Click);
            // 
            // btn_ToolSetUp
            // 
            this.btn_ToolSetUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ToolSetUp.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ToolSetUp.Image = global::VISION.Properties.Resources.Setup;
            this.btn_ToolSetUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ToolSetUp.Location = new System.Drawing.Point(560, 4);
            this.btn_ToolSetUp.Name = "btn_ToolSetUp";
            this.btn_ToolSetUp.Size = new System.Drawing.Size(183, 78);
            this.btn_ToolSetUp.TabIndex = 0;
            this.btn_ToolSetUp.Tag = "Front";
            this.btn_ToolSetUp.Text = "Tool Setting";
            this.btn_ToolSetUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ToolSetUp.UseVisualStyleBackColor = true;
            this.btn_ToolSetUp.Click += new System.EventHandler(this.btn_ToolSetUp_Click);
            // 
            // btn_Model
            // 
            this.btn_Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Model.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Model.Image = global::VISION.Properties.Resources.JobOpen;
            this.btn_Model.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Model.Location = new System.Drawing.Point(1357, 4);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(132, 78);
            this.btn_Model.TabIndex = 2;
            this.btn_Model.Tag = "";
            this.btn_Model.Text = "Model";
            this.btn_Model.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Model.UseVisualStyleBackColor = true;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // btn_CamSet
            // 
            this.btn_CamSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_CamSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_CamSet.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CamSet.Image = global::VISION.Properties.Resources.OneShot;
            this.btn_CamSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_CamSet.Location = new System.Drawing.Point(1218, 4);
            this.btn_CamSet.Name = "btn_CamSet";
            this.btn_CamSet.Size = new System.Drawing.Size(132, 78);
            this.btn_CamSet.TabIndex = 51;
            this.btn_CamSet.Tag = "";
            this.btn_CamSet.Text = "Camera Setting";
            this.btn_CamSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_CamSet.UseVisualStyleBackColor = true;
            this.btn_CamSet.Click += new System.EventHandler(this.btn_CamList_Click);
            // 
            // tlpTopSide
            // 
            this.tlpTopSide.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpTopSide.ColumnCount = 9;
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.08826F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.77986F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.21735F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.561666F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.557187F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.554338F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.414443F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.414443F));
            this.tlpTopSide.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.412449F));
            this.tlpTopSide.Controls.Add(this.lb_Mode, 4, 0);
            this.tlpTopSide.Controls.Add(this.lb_CurruntModelName, 5, 0);
            this.tlpTopSide.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpTopSide.Controls.Add(this.btn_Exit, 8, 0);
            this.tlpTopSide.Controls.Add(this.btn_Stop, 7, 0);
            this.tlpTopSide.Controls.Add(this.btn_Status, 6, 0);
            this.tlpTopSide.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpTopSide.Controls.Add(this.label1, 2, 0);
            this.tlpTopSide.Controls.Add(this.lb_PLCStats, 3, 0);
            this.tlpTopSide.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTopSide.Location = new System.Drawing.Point(0, 0);
            this.tlpTopSide.Name = "tlpTopSide";
            this.tlpTopSide.RowCount = 1;
            this.tlpTopSide.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopSide.Size = new System.Drawing.Size(1920, 77);
            this.tlpTopSide.TabIndex = 2;
            // 
            // lb_Mode
            // 
            this.lb_Mode.AutoSize = true;
            this.lb_Mode.BackColor = System.Drawing.Color.Lime;
            this.lb_Mode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Mode.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_Mode.Location = new System.Drawing.Point(1279, 1);
            this.lb_Mode.Name = "lb_Mode";
            this.lb_Mode.Size = new System.Drawing.Size(157, 75);
            this.lb_Mode.TabIndex = 31;
            this.lb_Mode.Text = "AUTORUN";
            this.lb_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CurruntModelName
            // 
            this.lb_CurruntModelName.AutoSize = true;
            this.lb_CurruntModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lb_CurruntModelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CurruntModelName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CurruntModelName.Location = new System.Drawing.Point(1443, 1);
            this.lb_CurruntModelName.Name = "lb_CurruntModelName";
            this.lb_CurruntModelName.Size = new System.Drawing.Size(157, 75);
            this.lb_CurruntModelName.TabIndex = 1;
            this.lb_CurruntModelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lb_Time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_Ver, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(216, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(238, 69);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.BackColor = System.Drawing.Color.Black;
            this.lb_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Time.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Time.ForeColor = System.Drawing.Color.White;
            this.lb_Time.Location = new System.Drawing.Point(4, 1);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(230, 33);
            this.lb_Time.TabIndex = 0;
            this.lb_Time.Text = "0000-00-00 오전 00:00:00";
            this.lb_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Ver
            // 
            this.lb_Ver.AutoSize = true;
            this.lb_Ver.BackColor = System.Drawing.Color.Black;
            this.lb_Ver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Ver.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Ver.ForeColor = System.Drawing.Color.White;
            this.lb_Ver.Location = new System.Drawing.Point(4, 35);
            this.lb_Ver.Name = "lb_Ver";
            this.lb_Ver.Size = new System.Drawing.Size(230, 33);
            this.lb_Ver.TabIndex = 4;
            this.lb_Ver.Text = "Ver. 1.0.0";
            this.lb_Ver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Exit.Image = global::VISION.Properties.Resources.Close;
            this.btn_Exit.Location = new System.Drawing.Point(1815, 4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(101, 69);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Stop.Image = global::VISION.Properties.Resources.Stop;
            this.btn_Stop.Location = new System.Drawing.Point(1711, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(97, 69);
            this.btn_Stop.TabIndex = 9;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Status
            // 
            this.btn_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Status.Image = global::VISION.Properties.Resources.Run;
            this.btn_Status.Location = new System.Drawing.Point(1607, 4);
            this.btn_Status.Name = "btn_Status";
            this.btn_Status.Size = new System.Drawing.Size(97, 69);
            this.btn_Status.TabIndex = 5;
            this.btn_Status.UseVisualStyleBackColor = true;
            this.btn_Status.Click += new System.EventHandler(this.btn_Status_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = global::VISION.Properties.Resources.logo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 69);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(461, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 75);
            this.label1.TabIndex = 11;
            this.label1.Text = "GENTEX HEATSINK VISION PROGRAM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_PLCStats
            // 
            this.lb_PLCStats.AutoSize = true;
            this.lb_PLCStats.BackColor = System.Drawing.Color.Lime;
            this.lb_PLCStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_PLCStats.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_PLCStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lb_PLCStats.Location = new System.Drawing.Point(1115, 1);
            this.lb_PLCStats.Name = "lb_PLCStats";
            this.lb_PLCStats.Size = new System.Drawing.Size(157, 75);
            this.lb_PLCStats.TabIndex = 38;
            this.lb_PLCStats.Text = "PLC";
            this.lb_PLCStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_Setting
            // 
            this.timer_Setting.Tick += new System.EventHandler(this.timer_Setting_Tick);
            // 
            // LightControl1
            // 
            this.LightControl1.BaudRate = 19200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1916, 573);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.cdyDisplay3, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(1280, 4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(632, 565);
            this.tableLayoutPanel8.TabIndex = 20;
            // 
            // cdyDisplay3
            // 
            this.cdyDisplay3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay3.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay3.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay3.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay3.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay3.Location = new System.Drawing.Point(4, 78);
            this.cdyDisplay3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay3.MouseWheelSensitivity = 1D;
            this.cdyDisplay3.Name = "cdyDisplay3";
            this.cdyDisplay3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay3.OcxState")));
            this.cdyDisplay3.Size = new System.Drawing.Size(624, 483);
            this.cdyDisplay3.TabIndex = 8;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3_Result, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3Stats, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.lb_Cam3_InsTime, 2, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(624, 67);
            this.tableLayoutPanel13.TabIndex = 9;
            // 
            // lb_Cam3_Result
            // 
            this.lb_Cam3_Result.AutoSize = true;
            this.lb_Cam3_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3_Result.Location = new System.Drawing.Point(129, 1);
            this.lb_Cam3_Result.Name = "lb_Cam3_Result";
            this.lb_Cam3_Result.Size = new System.Drawing.Size(304, 65);
            this.lb_Cam3_Result.TabIndex = 1;
            this.lb_Cam3_Result.Text = "Result";
            this.lb_Cam3_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam3Stats
            // 
            this.lb_Cam3Stats.AutoSize = true;
            this.lb_Cam3Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam3Stats.Name = "lb_Cam3Stats";
            this.lb_Cam3Stats.Size = new System.Drawing.Size(118, 65);
            this.lb_Cam3Stats.TabIndex = 0;
            this.lb_Cam3Stats.Tag = "3";
            this.lb_Cam3Stats.Text = "CAM 3";
            this.lb_Cam3Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam3Stats.DoubleClick += new System.EventHandler(this.lb_Cam1Stats_DoubleClick);
            // 
            // lb_Cam3_InsTime
            // 
            this.lb_Cam3_InsTime.AutoSize = true;
            this.lb_Cam3_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam3_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam3_InsTime.Location = new System.Drawing.Point(440, 1);
            this.lb_Cam3_InsTime.Name = "lb_Cam3_InsTime";
            this.lb_Cam3_InsTime.Size = new System.Drawing.Size(180, 65);
            this.lb_Cam3_InsTime.TabIndex = 2;
            this.lb_Cam3_InsTime.Text = "0 msec";
            this.lb_Cam3_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cdyDisplay2, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(642, 4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(631, 565);
            this.tableLayoutPanel5.TabIndex = 19;
            // 
            // cdyDisplay2
            // 
            this.cdyDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay2.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay2.Location = new System.Drawing.Point(4, 78);
            this.cdyDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay2.MouseWheelSensitivity = 1D;
            this.cdyDisplay2.Name = "cdyDisplay2";
            this.cdyDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay2.OcxState")));
            this.cdyDisplay2.Size = new System.Drawing.Size(623, 483);
            this.cdyDisplay2.TabIndex = 8;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2_Result, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2Stats, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lb_Cam2_InsTime, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(623, 67);
            this.tableLayoutPanel6.TabIndex = 9;
            // 
            // lb_Cam2_Result
            // 
            this.lb_Cam2_Result.AutoSize = true;
            this.lb_Cam2_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2_Result.Location = new System.Drawing.Point(128, 1);
            this.lb_Cam2_Result.Name = "lb_Cam2_Result";
            this.lb_Cam2_Result.Size = new System.Drawing.Size(303, 65);
            this.lb_Cam2_Result.TabIndex = 1;
            this.lb_Cam2_Result.Text = "Result";
            this.lb_Cam2_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam2Stats
            // 
            this.lb_Cam2Stats.AutoSize = true;
            this.lb_Cam2Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam2Stats.Name = "lb_Cam2Stats";
            this.lb_Cam2Stats.Size = new System.Drawing.Size(117, 65);
            this.lb_Cam2Stats.TabIndex = 0;
            this.lb_Cam2Stats.Tag = "2";
            this.lb_Cam2Stats.Text = "CAM 2";
            this.lb_Cam2Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam2Stats.DoubleClick += new System.EventHandler(this.lb_Cam1Stats_DoubleClick);
            // 
            // lb_Cam2_InsTime
            // 
            this.lb_Cam2_InsTime.AutoSize = true;
            this.lb_Cam2_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam2_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam2_InsTime.Location = new System.Drawing.Point(438, 1);
            this.lb_Cam2_InsTime.Name = "lb_Cam2_InsTime";
            this.lb_Cam2_InsTime.Size = new System.Drawing.Size(181, 65);
            this.lb_Cam2_InsTime.TabIndex = 2;
            this.lb_Cam2_InsTime.Text = "0 msec";
            this.lb_Cam2_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.cdyDisplay, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(631, 565);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // cdyDisplay
            // 
            this.cdyDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cdyDisplay.ColorMapLowerRoiLimit = 0D;
            this.cdyDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cdyDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cdyDisplay.ColorMapUpperRoiLimit = 1D;
            this.cdyDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdyDisplay.DoubleTapZoomCycleLength = 2;
            this.cdyDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cdyDisplay.Location = new System.Drawing.Point(4, 78);
            this.cdyDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cdyDisplay.MouseWheelSensitivity = 1D;
            this.cdyDisplay.Name = "cdyDisplay";
            this.cdyDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cdyDisplay.OcxState")));
            this.cdyDisplay.Size = new System.Drawing.Size(623, 483);
            this.cdyDisplay.TabIndex = 8;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1Stats, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1_Result, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.lb_Cam1_InsTime, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(623, 67);
            this.tableLayoutPanel10.TabIndex = 9;
            // 
            // lb_Cam1Stats
            // 
            this.lb_Cam1Stats.AutoSize = true;
            this.lb_Cam1Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1Stats.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1Stats.Location = new System.Drawing.Point(4, 1);
            this.lb_Cam1Stats.Name = "lb_Cam1Stats";
            this.lb_Cam1Stats.Size = new System.Drawing.Size(117, 65);
            this.lb_Cam1Stats.TabIndex = 0;
            this.lb_Cam1Stats.Tag = "1";
            this.lb_Cam1Stats.Text = "CAM 1";
            this.lb_Cam1Stats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Cam1Stats.DoubleClick += new System.EventHandler(this.lb_Cam1Stats_DoubleClick);
            // 
            // lb_Cam1_Result
            // 
            this.lb_Cam1_Result.AutoSize = true;
            this.lb_Cam1_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1_Result.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1_Result.Location = new System.Drawing.Point(128, 1);
            this.lb_Cam1_Result.Name = "lb_Cam1_Result";
            this.lb_Cam1_Result.Size = new System.Drawing.Size(303, 65);
            this.lb_Cam1_Result.TabIndex = 1;
            this.lb_Cam1_Result.Text = "Result";
            this.lb_Cam1_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Cam1_InsTime
            // 
            this.lb_Cam1_InsTime.AutoSize = true;
            this.lb_Cam1_InsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Cam1_InsTime.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_Cam1_InsTime.Location = new System.Drawing.Point(438, 1);
            this.lb_Cam1_InsTime.Name = "lb_Cam1_InsTime";
            this.lb_Cam1_InsTime.Size = new System.Drawing.Size(181, 65);
            this.lb_Cam1_InsTime.TabIndex = 3;
            this.lb_Cam1_InsTime.Text = "0 msec";
            this.lb_Cam1_InsTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logControl1
            // 
            this.logControl1.Color_ControlBack = System.Drawing.Color.Black;
            this.logControl1.Color_ErrorText = System.Drawing.Color.Red;
            this.logControl1.Color_NormalText = System.Drawing.Color.White;
            this.logControl1.Color_WarningText = System.Drawing.Color.Yellow;
            this.logControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logControl1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logControl1.Location = new System.Drawing.Point(3, 3);
            this.logControl1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(929, 308);
            this.logControl1.TabIndex = 41;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DimGray;
            this.tabPage2.Controls.Add(this.tableLayoutPanel19);
            this.tabPage2.Controls.Add(this.tableLayoutPanel20);
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(935, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel19.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel43, 1, 6);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel42, 0, 6);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel41, 1, 5);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel40, 0, 5);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel39, 1, 4);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel38, 0, 4);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel37, 1, 3);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel36, 0, 3);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel35, 1, 2);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel34, 0, 2);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel33, 1, 1);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel32, 0, 1);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel30, 1, 0);
            this.tableLayoutPanel19.Controls.Add(this.tableLayoutPanel26, 0, 0);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(113, 54);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 7;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(538, 256);
            this.tableLayoutPanel19.TabIndex = 46;
            // 
            // tableLayoutPanel43
            // 
            this.tableLayoutPanel43.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel43.ColumnCount = 2;
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel43.Controls.Add(this.btn_Output14, 0, 0);
            this.tableLayoutPanel43.Controls.Add(this.btn_Output13, 0, 0);
            this.tableLayoutPanel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel43.Location = new System.Drawing.Point(272, 220);
            this.tableLayoutPanel43.Name = "tableLayoutPanel43";
            this.tableLayoutPanel43.RowCount = 1;
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel43.Size = new System.Drawing.Size(262, 32);
            this.tableLayoutPanel43.TabIndex = 13;
            // 
            // btn_Output14
            // 
            this.btn_Output14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output14.Location = new System.Drawing.Point(134, 4);
            this.btn_Output14.Name = "btn_Output14";
            this.btn_Output14.Size = new System.Drawing.Size(124, 24);
            this.btn_Output14.TabIndex = 6;
            this.btn_Output14.Tag = "13";
            this.btn_Output14.Text = "13 OFF";
            this.btn_Output14.UseVisualStyleBackColor = true;
            this.btn_Output14.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output13
            // 
            this.btn_Output13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output13.Location = new System.Drawing.Point(4, 4);
            this.btn_Output13.Name = "btn_Output13";
            this.btn_Output13.Size = new System.Drawing.Size(123, 24);
            this.btn_Output13.TabIndex = 5;
            this.btn_Output13.Tag = "13";
            this.btn_Output13.Text = "13 ON";
            this.btn_Output13.UseVisualStyleBackColor = true;
            this.btn_Output13.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel42
            // 
            this.tableLayoutPanel42.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel42.ColumnCount = 2;
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Controls.Add(this.button25, 0, 0);
            this.tableLayoutPanel42.Controls.Add(this.btn_Output12, 0, 0);
            this.tableLayoutPanel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel42.Location = new System.Drawing.Point(4, 220);
            this.tableLayoutPanel42.Name = "tableLayoutPanel42";
            this.tableLayoutPanel42.RowCount = 1;
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Size = new System.Drawing.Size(261, 32);
            this.tableLayoutPanel42.TabIndex = 12;
            // 
            // button25
            // 
            this.button25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button25.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button25.Location = new System.Drawing.Point(134, 4);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(123, 24);
            this.button25.TabIndex = 6;
            this.button25.Tag = "12";
            this.button25.Text = "12 OFF";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output12
            // 
            this.btn_Output12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output12.Location = new System.Drawing.Point(4, 4);
            this.btn_Output12.Name = "btn_Output12";
            this.btn_Output12.Size = new System.Drawing.Size(123, 24);
            this.btn_Output12.TabIndex = 5;
            this.btn_Output12.Tag = "12";
            this.btn_Output12.Text = "12 ON";
            this.btn_Output12.UseVisualStyleBackColor = true;
            this.btn_Output12.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel41
            // 
            this.tableLayoutPanel41.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel41.ColumnCount = 2;
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel41.Controls.Add(this.button23, 0, 0);
            this.tableLayoutPanel41.Controls.Add(this.btn_Output11, 0, 0);
            this.tableLayoutPanel41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel41.Location = new System.Drawing.Point(272, 184);
            this.tableLayoutPanel41.Name = "tableLayoutPanel41";
            this.tableLayoutPanel41.RowCount = 1;
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel41.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel41.TabIndex = 11;
            // 
            // button23
            // 
            this.button23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button23.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button23.Location = new System.Drawing.Point(134, 4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(124, 21);
            this.button23.TabIndex = 6;
            this.button23.Tag = "11";
            this.button23.Text = "11 OFF";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output11
            // 
            this.btn_Output11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output11.Location = new System.Drawing.Point(4, 4);
            this.btn_Output11.Name = "btn_Output11";
            this.btn_Output11.Size = new System.Drawing.Size(123, 21);
            this.btn_Output11.TabIndex = 5;
            this.btn_Output11.Tag = "11";
            this.btn_Output11.Text = "11 ON";
            this.btn_Output11.UseVisualStyleBackColor = true;
            this.btn_Output11.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel40
            // 
            this.tableLayoutPanel40.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel40.ColumnCount = 2;
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel40.Controls.Add(this.button21, 0, 0);
            this.tableLayoutPanel40.Controls.Add(this.btn_Output10, 0, 0);
            this.tableLayoutPanel40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel40.Location = new System.Drawing.Point(4, 184);
            this.tableLayoutPanel40.Name = "tableLayoutPanel40";
            this.tableLayoutPanel40.RowCount = 1;
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel40.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel40.TabIndex = 10;
            // 
            // button21
            // 
            this.button21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button21.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button21.Location = new System.Drawing.Point(134, 4);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(123, 21);
            this.button21.TabIndex = 6;
            this.button21.Tag = "10";
            this.button21.Text = "10 OFF";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output10
            // 
            this.btn_Output10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output10.Location = new System.Drawing.Point(4, 4);
            this.btn_Output10.Name = "btn_Output10";
            this.btn_Output10.Size = new System.Drawing.Size(123, 21);
            this.btn_Output10.TabIndex = 5;
            this.btn_Output10.Tag = "10";
            this.btn_Output10.Text = "10 ON";
            this.btn_Output10.UseVisualStyleBackColor = true;
            this.btn_Output10.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel39
            // 
            this.tableLayoutPanel39.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel39.ColumnCount = 2;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.Controls.Add(this.button19, 0, 0);
            this.tableLayoutPanel39.Controls.Add(this.btn_Output9, 0, 0);
            this.tableLayoutPanel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel39.Location = new System.Drawing.Point(272, 148);
            this.tableLayoutPanel39.Name = "tableLayoutPanel39";
            this.tableLayoutPanel39.RowCount = 1;
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel39.TabIndex = 9;
            // 
            // button19
            // 
            this.button19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button19.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button19.Location = new System.Drawing.Point(134, 4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(124, 21);
            this.button19.TabIndex = 6;
            this.button19.Tag = "9";
            this.button19.Text = "9 OFF";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output9
            // 
            this.btn_Output9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output9.Location = new System.Drawing.Point(4, 4);
            this.btn_Output9.Name = "btn_Output9";
            this.btn_Output9.Size = new System.Drawing.Size(123, 21);
            this.btn_Output9.TabIndex = 5;
            this.btn_Output9.Tag = "9";
            this.btn_Output9.Text = "9 ON";
            this.btn_Output9.UseVisualStyleBackColor = true;
            this.btn_Output9.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel38
            // 
            this.tableLayoutPanel38.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel38.ColumnCount = 2;
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel38.Controls.Add(this.button17, 0, 0);
            this.tableLayoutPanel38.Controls.Add(this.btn_Output8, 0, 0);
            this.tableLayoutPanel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel38.Location = new System.Drawing.Point(4, 148);
            this.tableLayoutPanel38.Name = "tableLayoutPanel38";
            this.tableLayoutPanel38.RowCount = 1;
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel38.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel38.TabIndex = 8;
            // 
            // button17
            // 
            this.button17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button17.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button17.Location = new System.Drawing.Point(134, 4);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(123, 21);
            this.button17.TabIndex = 6;
            this.button17.Tag = "8";
            this.button17.Text = "8 OFF";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output8
            // 
            this.btn_Output8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output8.Location = new System.Drawing.Point(4, 4);
            this.btn_Output8.Name = "btn_Output8";
            this.btn_Output8.Size = new System.Drawing.Size(123, 21);
            this.btn_Output8.TabIndex = 5;
            this.btn_Output8.Tag = "8";
            this.btn_Output8.Text = "8 ON";
            this.btn_Output8.UseVisualStyleBackColor = true;
            this.btn_Output8.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel37.ColumnCount = 2;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel37.Controls.Add(this.button15, 0, 0);
            this.tableLayoutPanel37.Controls.Add(this.btn_Output7, 0, 0);
            this.tableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel37.Location = new System.Drawing.Point(272, 112);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 1;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel37.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel37.TabIndex = 7;
            // 
            // button15
            // 
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button15.Location = new System.Drawing.Point(134, 4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(124, 21);
            this.button15.TabIndex = 6;
            this.button15.Tag = "7";
            this.button15.Text = "7 OFF";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output7
            // 
            this.btn_Output7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output7.Location = new System.Drawing.Point(4, 4);
            this.btn_Output7.Name = "btn_Output7";
            this.btn_Output7.Size = new System.Drawing.Size(123, 21);
            this.btn_Output7.TabIndex = 5;
            this.btn_Output7.Tag = "7";
            this.btn_Output7.Text = "7 ON";
            this.btn_Output7.UseVisualStyleBackColor = true;
            this.btn_Output7.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel36
            // 
            this.tableLayoutPanel36.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel36.ColumnCount = 2;
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel36.Controls.Add(this.button13, 0, 0);
            this.tableLayoutPanel36.Controls.Add(this.btn_Output6, 0, 0);
            this.tableLayoutPanel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel36.Location = new System.Drawing.Point(4, 112);
            this.tableLayoutPanel36.Name = "tableLayoutPanel36";
            this.tableLayoutPanel36.RowCount = 1;
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel36.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel36.TabIndex = 6;
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button13.Location = new System.Drawing.Point(134, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(123, 21);
            this.button13.TabIndex = 6;
            this.button13.Tag = "6";
            this.button13.Text = "6 OFF";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output6
            // 
            this.btn_Output6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output6.Location = new System.Drawing.Point(4, 4);
            this.btn_Output6.Name = "btn_Output6";
            this.btn_Output6.Size = new System.Drawing.Size(123, 21);
            this.btn_Output6.TabIndex = 5;
            this.btn_Output6.Tag = "6";
            this.btn_Output6.Text = "6 ON";
            this.btn_Output6.UseVisualStyleBackColor = true;
            this.btn_Output6.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel35
            // 
            this.tableLayoutPanel35.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel35.ColumnCount = 2;
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel35.Controls.Add(this.button11, 0, 0);
            this.tableLayoutPanel35.Controls.Add(this.btn_Output5, 0, 0);
            this.tableLayoutPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel35.Location = new System.Drawing.Point(272, 76);
            this.tableLayoutPanel35.Name = "tableLayoutPanel35";
            this.tableLayoutPanel35.RowCount = 1;
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel35.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel35.TabIndex = 5;
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button11.Location = new System.Drawing.Point(134, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(124, 21);
            this.button11.TabIndex = 6;
            this.button11.Tag = "5";
            this.button11.Text = "5 OFF";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output5
            // 
            this.btn_Output5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output5.Location = new System.Drawing.Point(4, 4);
            this.btn_Output5.Name = "btn_Output5";
            this.btn_Output5.Size = new System.Drawing.Size(123, 21);
            this.btn_Output5.TabIndex = 5;
            this.btn_Output5.Tag = "5";
            this.btn_Output5.Text = "5 ON";
            this.btn_Output5.UseVisualStyleBackColor = true;
            this.btn_Output5.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel34
            // 
            this.tableLayoutPanel34.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel34.ColumnCount = 2;
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel34.Controls.Add(this.button9, 0, 0);
            this.tableLayoutPanel34.Controls.Add(this.btn_Output4, 0, 0);
            this.tableLayoutPanel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel34.Location = new System.Drawing.Point(4, 76);
            this.tableLayoutPanel34.Name = "tableLayoutPanel34";
            this.tableLayoutPanel34.RowCount = 1;
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel34.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel34.TabIndex = 4;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button9.Location = new System.Drawing.Point(134, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(123, 21);
            this.button9.TabIndex = 6;
            this.button9.Tag = "4";
            this.button9.Text = "4 OFF";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output4
            // 
            this.btn_Output4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output4.Location = new System.Drawing.Point(4, 4);
            this.btn_Output4.Name = "btn_Output4";
            this.btn_Output4.Size = new System.Drawing.Size(123, 21);
            this.btn_Output4.TabIndex = 5;
            this.btn_Output4.Tag = "4";
            this.btn_Output4.Text = "4 ON";
            this.btn_Output4.UseVisualStyleBackColor = true;
            this.btn_Output4.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel33.ColumnCount = 2;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.Controls.Add(this.button7, 0, 0);
            this.tableLayoutPanel33.Controls.Add(this.btn_Output3, 0, 0);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(272, 40);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 1;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel33.TabIndex = 3;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.Location = new System.Drawing.Point(134, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 21);
            this.button7.TabIndex = 6;
            this.button7.Tag = "3";
            this.button7.Text = "3 OFF";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output3
            // 
            this.btn_Output3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output3.Location = new System.Drawing.Point(4, 4);
            this.btn_Output3.Name = "btn_Output3";
            this.btn_Output3.Size = new System.Drawing.Size(123, 21);
            this.btn_Output3.TabIndex = 5;
            this.btn_Output3.Tag = "3";
            this.btn_Output3.Text = "3 ON";
            this.btn_Output3.UseVisualStyleBackColor = true;
            this.btn_Output3.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel32.ColumnCount = 2;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.Controls.Add(this.button5, 0, 0);
            this.tableLayoutPanel32.Controls.Add(this.btn_Output2, 0, 0);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(4, 40);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel32.TabIndex = 2;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button5.Location = new System.Drawing.Point(134, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(123, 21);
            this.button5.TabIndex = 6;
            this.button5.Tag = "2";
            this.button5.Text = "2 OFF";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output2
            // 
            this.btn_Output2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output2.Location = new System.Drawing.Point(4, 4);
            this.btn_Output2.Name = "btn_Output2";
            this.btn_Output2.Size = new System.Drawing.Size(123, 21);
            this.btn_Output2.TabIndex = 5;
            this.btn_Output2.Tag = "2";
            this.btn_Output2.Text = "2 ON";
            this.btn_Output2.UseVisualStyleBackColor = true;
            this.btn_Output2.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel30.ColumnCount = 2;
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel30.Controls.Add(this.btn_Output1, 0, 0);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(272, 4);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 1;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(262, 29);
            this.tableLayoutPanel30.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(134, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 21);
            this.button3.TabIndex = 6;
            this.button3.Tag = "14";
            this.button3.Text = "14 OFF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output1
            // 
            this.btn_Output1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output1.Location = new System.Drawing.Point(4, 4);
            this.btn_Output1.Name = "btn_Output1";
            this.btn_Output1.Size = new System.Drawing.Size(123, 21);
            this.btn_Output1.TabIndex = 5;
            this.btn_Output1.Tag = "14";
            this.btn_Output1.Text = "14 ON";
            this.btn_Output1.UseVisualStyleBackColor = true;
            this.btn_Output1.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel26.ColumnCount = 2;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.btn_Output0, 0, 0);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 1;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(261, 29);
            this.tableLayoutPanel26.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(134, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 21);
            this.button2.TabIndex = 6;
            this.button2.Tag = "0";
            this.button2.Text = "0 OFF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OUTPUTOFF_Click);
            // 
            // btn_Output0
            // 
            this.btn_Output0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Output0.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Output0.Location = new System.Drawing.Point(4, 4);
            this.btn_Output0.Name = "btn_Output0";
            this.btn_Output0.Size = new System.Drawing.Size(123, 21);
            this.btn_Output0.TabIndex = 5;
            this.btn_Output0.Tag = "0";
            this.btn_Output0.Text = "0 ON";
            this.btn_Output0.UseVisualStyleBackColor = true;
            this.btn_Output0.Click += new System.EventHandler(this.OUTPUT_Click);
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel20.ColumnCount = 1;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 2;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(104, 308);
            this.tableLayoutPanel20.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 152);
            this.label2.TabIndex = 0;
            this.label2.Text = "INPUT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 153);
            this.label3.TabIndex = 1;
            this.label3.Text = "OUTPUT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT15, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT14, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT13, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT12, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT11, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT10, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT9, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT0, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT3, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT4, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT5, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT6, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT8, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.btn_INPUT7, 2, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(110, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(819, 45);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btn_INPUT15
            // 
            this.btn_INPUT15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT15.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT15.Location = new System.Drawing.Point(276, 40);
            this.btn_INPUT15.Name = "btn_INPUT15";
            this.btn_INPUT15.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT15.TabIndex = 50;
            this.btn_INPUT15.Tag = "15";
            this.btn_INPUT15.Text = "15";
            this.btn_INPUT15.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT14
            // 
            this.btn_INPUT14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT14.Location = new System.Drawing.Point(276, 34);
            this.btn_INPUT14.Name = "btn_INPUT14";
            this.btn_INPUT14.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT14.TabIndex = 49;
            this.btn_INPUT14.Tag = "14";
            this.btn_INPUT14.Text = "14";
            this.btn_INPUT14.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT13
            // 
            this.btn_INPUT13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT13.Location = new System.Drawing.Point(276, 28);
            this.btn_INPUT13.Name = "btn_INPUT13";
            this.btn_INPUT13.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT13.TabIndex = 48;
            this.btn_INPUT13.Tag = "13";
            this.btn_INPUT13.Text = "13";
            this.btn_INPUT13.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT12
            // 
            this.btn_INPUT12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT12.Location = new System.Drawing.Point(276, 22);
            this.btn_INPUT12.Name = "btn_INPUT12";
            this.btn_INPUT12.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT12.TabIndex = 47;
            this.btn_INPUT12.Tag = "12";
            this.btn_INPUT12.Text = "12";
            this.btn_INPUT12.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT11
            // 
            this.btn_INPUT11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT11.Location = new System.Drawing.Point(276, 16);
            this.btn_INPUT11.Name = "btn_INPUT11";
            this.btn_INPUT11.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT11.TabIndex = 46;
            this.btn_INPUT11.Tag = "11";
            this.btn_INPUT11.Text = "11";
            this.btn_INPUT11.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT10
            // 
            this.btn_INPUT10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT10.Location = new System.Drawing.Point(276, 10);
            this.btn_INPUT10.Name = "btn_INPUT10";
            this.btn_INPUT10.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT10.TabIndex = 45;
            this.btn_INPUT10.Tag = "10";
            this.btn_INPUT10.Text = "10";
            this.btn_INPUT10.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT9
            // 
            this.btn_INPUT9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT9.Location = new System.Drawing.Point(276, 4);
            this.btn_INPUT9.Name = "btn_INPUT9";
            this.btn_INPUT9.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT9.TabIndex = 44;
            this.btn_INPUT9.Tag = "9";
            this.btn_INPUT9.Text = "9";
            this.btn_INPUT9.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT0
            // 
            this.btn_INPUT0.BackColor = System.Drawing.Color.LightGray;
            this.btn_INPUT0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT0.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT0.Location = new System.Drawing.Point(4, 4);
            this.btn_INPUT0.Name = "btn_INPUT0";
            this.btn_INPUT0.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT0.TabIndex = 2;
            this.btn_INPUT0.Tag = "0";
            this.btn_INPUT0.Text = "0";
            this.btn_INPUT0.UseVisualStyleBackColor = false;
            // 
            // btn_INPUT1
            // 
            this.btn_INPUT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT1.Location = new System.Drawing.Point(4, 10);
            this.btn_INPUT1.Name = "btn_INPUT1";
            this.btn_INPUT1.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT1.TabIndex = 4;
            this.btn_INPUT1.Tag = "1";
            this.btn_INPUT1.Text = "1";
            this.btn_INPUT1.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT2
            // 
            this.btn_INPUT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT2.Location = new System.Drawing.Point(4, 16);
            this.btn_INPUT2.Name = "btn_INPUT2";
            this.btn_INPUT2.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT2.TabIndex = 6;
            this.btn_INPUT2.Tag = "2";
            this.btn_INPUT2.Text = "2";
            this.btn_INPUT2.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT3
            // 
            this.btn_INPUT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT3.Location = new System.Drawing.Point(4, 22);
            this.btn_INPUT3.Name = "btn_INPUT3";
            this.btn_INPUT3.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT3.TabIndex = 8;
            this.btn_INPUT3.Tag = "3";
            this.btn_INPUT3.Text = "3";
            this.btn_INPUT3.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT4
            // 
            this.btn_INPUT4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT4.Location = new System.Drawing.Point(4, 28);
            this.btn_INPUT4.Name = "btn_INPUT4";
            this.btn_INPUT4.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT4.TabIndex = 10;
            this.btn_INPUT4.Tag = "4";
            this.btn_INPUT4.Text = "4";
            this.btn_INPUT4.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT5
            // 
            this.btn_INPUT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT5.Location = new System.Drawing.Point(4, 34);
            this.btn_INPUT5.Name = "btn_INPUT5";
            this.btn_INPUT5.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT5.TabIndex = 12;
            this.btn_INPUT5.Tag = "5";
            this.btn_INPUT5.Text = "5";
            this.btn_INPUT5.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT6
            // 
            this.btn_INPUT6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_INPUT6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT6.Location = new System.Drawing.Point(4, 40);
            this.btn_INPUT6.Name = "btn_INPUT6";
            this.btn_INPUT6.Size = new System.Drawing.Size(265, 1);
            this.btn_INPUT6.TabIndex = 14;
            this.btn_INPUT6.Tag = "6";
            this.btn_INPUT6.Text = "6";
            this.btn_INPUT6.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT8
            // 
            this.btn_INPUT8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT8.Location = new System.Drawing.Point(548, 40);
            this.btn_INPUT8.Name = "btn_INPUT8";
            this.btn_INPUT8.Size = new System.Drawing.Size(114, 1);
            this.btn_INPUT8.TabIndex = 51;
            this.btn_INPUT8.Tag = "8";
            this.btn_INPUT8.Text = "8";
            this.btn_INPUT8.UseVisualStyleBackColor = true;
            // 
            // btn_INPUT7
            // 
            this.btn_INPUT7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_INPUT7.Location = new System.Drawing.Point(548, 34);
            this.btn_INPUT7.Name = "btn_INPUT7";
            this.btn_INPUT7.Size = new System.Drawing.Size(114, 1);
            this.btn_INPUT7.TabIndex = 52;
            this.btn_INPUT7.Tag = "7";
            this.btn_INPUT7.Text = "7";
            this.btn_INPUT7.UseVisualStyleBackColor = true;
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.tabPage1);
            this.Main_TabControl.Controls.Add(this.tabPage2);
            this.Main_TabControl.Controls.Add(this.tabPage5);
            this.Main_TabControl.Location = new System.Drawing.Point(4, 648);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SelectedIndex = 0;
            this.Main_TabControl.Size = new System.Drawing.Size(943, 340);
            this.Main_TabControl.TabIndex = 25;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(935, 314);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableLayoutPanel27);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(935, 314);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel27.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel27.ColumnCount = 2;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel18, 1, 2);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel17, 1, 1);
            this.tableLayoutPanel27.Controls.Add(this.tableLayoutPanel16, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel27.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 3;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2849F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2849F));
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.2849F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(929, 308);
            this.tableLayoutPanel27.TabIndex = 0;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_NGRATE, 1, 3);
            this.tableLayoutPanel18.Controls.Add(this.label35, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_TOTAL, 1, 2);
            this.tableLayoutPanel18.Controls.Add(this.label37, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_NG, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.label39, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.lb_CAM3_OK, 1, 0);
            this.tableLayoutPanel18.Controls.Add(this.label41, 0, 0);
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(190, 208);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 4;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(735, 96);
            this.tableLayoutPanel18.TabIndex = 8;
            // 
            // lb_CAM3_NGRATE
            // 
            this.lb_CAM3_NGRATE.AutoSize = true;
            this.lb_CAM3_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM3_NGRATE.Location = new System.Drawing.Point(224, 70);
            this.lb_CAM3_NGRATE.Name = "lb_CAM3_NGRATE";
            this.lb_CAM3_NGRATE.Size = new System.Drawing.Size(507, 25);
            this.lb_CAM3_NGRATE.TabIndex = 7;
            this.lb_CAM3_NGRATE.Text = "0";
            this.lb_CAM3_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.ForeColor = System.Drawing.Color.Yellow;
            this.label35.Location = new System.Drawing.Point(4, 70);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(213, 25);
            this.label35.TabIndex = 6;
            this.label35.Text = "NG RATE";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_TOTAL
            // 
            this.lb_CAM3_TOTAL.AutoSize = true;
            this.lb_CAM3_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM3_TOTAL.Location = new System.Drawing.Point(224, 47);
            this.lb_CAM3_TOTAL.Name = "lb_CAM3_TOTAL";
            this.lb_CAM3_TOTAL.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM3_TOTAL.TabIndex = 5;
            this.lb_CAM3_TOTAL.Text = "0";
            this.lb_CAM3_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.Location = new System.Drawing.Point(4, 47);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(213, 22);
            this.label37.TabIndex = 4;
            this.label37.Text = "TOTAL";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_NG
            // 
            this.lb_CAM3_NG.AutoSize = true;
            this.lb_CAM3_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM3_NG.Location = new System.Drawing.Point(224, 24);
            this.lb_CAM3_NG.Name = "lb_CAM3_NG";
            this.lb_CAM3_NG.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM3_NG.TabIndex = 3;
            this.lb_CAM3_NG.Text = "0";
            this.lb_CAM3_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Black;
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label39.ForeColor = System.Drawing.Color.Red;
            this.label39.Location = new System.Drawing.Point(4, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(213, 22);
            this.label39.TabIndex = 2;
            this.label39.Text = "NG";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM3_OK
            // 
            this.lb_CAM3_OK.AutoSize = true;
            this.lb_CAM3_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM3_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM3_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM3_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM3_OK.Location = new System.Drawing.Point(224, 1);
            this.lb_CAM3_OK.Name = "lb_CAM3_OK";
            this.lb_CAM3_OK.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM3_OK.TabIndex = 1;
            this.lb_CAM3_OK.Text = "0";
            this.lb_CAM3_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Black;
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label41.ForeColor = System.Drawing.Color.Lime;
            this.label41.Location = new System.Drawing.Point(4, 1);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(213, 22);
            this.label41.TabIndex = 0;
            this.label41.Text = "OK";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_NGRATE, 1, 3);
            this.tableLayoutPanel17.Controls.Add(this.label27, 0, 3);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_TOTAL, 1, 2);
            this.tableLayoutPanel17.Controls.Add(this.label29, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_NG, 1, 1);
            this.tableLayoutPanel17.Controls.Add(this.label31, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.lb_CAM2_OK, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.label33, 0, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(190, 106);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 4;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(735, 95);
            this.tableLayoutPanel17.TabIndex = 7;
            // 
            // lb_CAM2_NGRATE
            // 
            this.lb_CAM2_NGRATE.AutoSize = true;
            this.lb_CAM2_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM2_NGRATE.Location = new System.Drawing.Point(224, 70);
            this.lb_CAM2_NGRATE.Name = "lb_CAM2_NGRATE";
            this.lb_CAM2_NGRATE.Size = new System.Drawing.Size(507, 24);
            this.lb_CAM2_NGRATE.TabIndex = 7;
            this.lb_CAM2_NGRATE.Text = "0";
            this.lb_CAM2_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.Yellow;
            this.label27.Location = new System.Drawing.Point(4, 70);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(213, 24);
            this.label27.TabIndex = 6;
            this.label27.Text = "NG RATE";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_TOTAL
            // 
            this.lb_CAM2_TOTAL.AutoSize = true;
            this.lb_CAM2_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM2_TOTAL.Location = new System.Drawing.Point(224, 47);
            this.lb_CAM2_TOTAL.Name = "lb_CAM2_TOTAL";
            this.lb_CAM2_TOTAL.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM2_TOTAL.TabIndex = 5;
            this.lb_CAM2_TOTAL.Text = "0";
            this.lb_CAM2_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Black;
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(4, 47);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(213, 22);
            this.label29.TabIndex = 4;
            this.label29.Text = "TOTAL";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_NG
            // 
            this.lb_CAM2_NG.AutoSize = true;
            this.lb_CAM2_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM2_NG.Location = new System.Drawing.Point(224, 24);
            this.lb_CAM2_NG.Name = "lb_CAM2_NG";
            this.lb_CAM2_NG.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM2_NG.TabIndex = 3;
            this.lb_CAM2_NG.Text = "0";
            this.lb_CAM2_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Black;
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Location = new System.Drawing.Point(4, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(213, 22);
            this.label31.TabIndex = 2;
            this.label31.Text = "NG";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM2_OK
            // 
            this.lb_CAM2_OK.AutoSize = true;
            this.lb_CAM2_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM2_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM2_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM2_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM2_OK.Location = new System.Drawing.Point(224, 1);
            this.lb_CAM2_OK.Name = "lb_CAM2_OK";
            this.lb_CAM2_OK.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM2_OK.TabIndex = 1;
            this.lb_CAM2_OK.Text = "0";
            this.lb_CAM2_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.ForeColor = System.Drawing.Color.Lime;
            this.label33.Location = new System.Drawing.Point(4, 1);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(213, 22);
            this.label33.TabIndex = 0;
            this.label33.Text = "OK";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel16.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_NGRATE, 1, 3);
            this.tableLayoutPanel16.Controls.Add(this.label24, 0, 3);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_TOTAL, 1, 2);
            this.tableLayoutPanel16.Controls.Add(this.label22, 0, 2);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_NG, 1, 1);
            this.tableLayoutPanel16.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.lb_CAM1_OK, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(190, 4);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 4;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(735, 95);
            this.tableLayoutPanel16.TabIndex = 6;
            // 
            // lb_CAM1_NGRATE
            // 
            this.lb_CAM1_NGRATE.AutoSize = true;
            this.lb_CAM1_NGRATE.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_NGRATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_NGRATE.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_NGRATE.ForeColor = System.Drawing.Color.Yellow;
            this.lb_CAM1_NGRATE.Location = new System.Drawing.Point(224, 70);
            this.lb_CAM1_NGRATE.Name = "lb_CAM1_NGRATE";
            this.lb_CAM1_NGRATE.Size = new System.Drawing.Size(507, 24);
            this.lb_CAM1_NGRATE.TabIndex = 7;
            this.lb_CAM1_NGRATE.Text = "0";
            this.lb_CAM1_NGRATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.Color.Yellow;
            this.label24.Location = new System.Drawing.Point(4, 70);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(213, 24);
            this.label24.TabIndex = 6;
            this.label24.Text = "NG RATE";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_TOTAL
            // 
            this.lb_CAM1_TOTAL.AutoSize = true;
            this.lb_CAM1_TOTAL.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_TOTAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_TOTAL.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_TOTAL.ForeColor = System.Drawing.Color.White;
            this.lb_CAM1_TOTAL.Location = new System.Drawing.Point(224, 47);
            this.lb_CAM1_TOTAL.Name = "lb_CAM1_TOTAL";
            this.lb_CAM1_TOTAL.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM1_TOTAL.TabIndex = 5;
            this.lb_CAM1_TOTAL.Text = "0";
            this.lb_CAM1_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(4, 47);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(213, 22);
            this.label22.TabIndex = 4;
            this.label22.Text = "TOTAL";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_NG
            // 
            this.lb_CAM1_NG.AutoSize = true;
            this.lb_CAM1_NG.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_NG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_NG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_NG.ForeColor = System.Drawing.Color.Red;
            this.lb_CAM1_NG.Location = new System.Drawing.Point(224, 24);
            this.lb_CAM1_NG.Name = "lb_CAM1_NG";
            this.lb_CAM1_NG.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM1_NG.TabIndex = 3;
            this.lb_CAM1_NG.Text = "0";
            this.lb_CAM1_NG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(4, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(213, 22);
            this.label20.TabIndex = 2;
            this.label20.Text = "NG";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CAM1_OK
            // 
            this.lb_CAM1_OK.AutoSize = true;
            this.lb_CAM1_OK.BackColor = System.Drawing.Color.Black;
            this.lb_CAM1_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_CAM1_OK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CAM1_OK.ForeColor = System.Drawing.Color.Lime;
            this.lb_CAM1_OK.Location = new System.Drawing.Point(224, 1);
            this.lb_CAM1_OK.Name = "lb_CAM1_OK";
            this.lb_CAM1_OK.Size = new System.Drawing.Size(507, 22);
            this.lb_CAM1_OK.TabIndex = 1;
            this.lb_CAM1_OK.Text = "0";
            this.lb_CAM1_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.Lime;
            this.label17.Location = new System.Drawing.Point(4, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(213, 22);
            this.label17.TabIndex = 0;
            this.label17.Text = "OK";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 101);
            this.label5.TabIndex = 0;
            this.label5.Text = "CAM1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(4, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 101);
            this.label6.TabIndex = 1;
            this.label6.Text = "CAM2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(4, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 102);
            this.label8.TabIndex = 2;
            this.label8.Text = "CAM3";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_IO
            // 
            this.btn_IO.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_IO.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_IO.ForeColor = System.Drawing.Color.White;
            this.btn_IO.Location = new System.Drawing.Point(101, 4);
            this.btn_IO.Name = "btn_IO";
            this.btn_IO.Size = new System.Drawing.Size(90, 37);
            this.btn_IO.TabIndex = 30;
            this.btn_IO.Tag = "1";
            this.btn_IO.Text = "I/O";
            this.btn_IO.UseVisualStyleBackColor = false;
            this.btn_IO.Click += new System.EventHandler(this.btn_Log_Click);
            // 
            // btn_Count
            // 
            this.btn_Count.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Count.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Count.ForeColor = System.Drawing.Color.White;
            this.btn_Count.Location = new System.Drawing.Point(198, 4);
            this.btn_Count.Name = "btn_Count";
            this.btn_Count.Size = new System.Drawing.Size(90, 37);
            this.btn_Count.TabIndex = 32;
            this.btn_Count.Tag = "2";
            this.btn_Count.Text = "수량";
            this.btn_Count.UseVisualStyleBackColor = false;
            this.btn_Count.Click += new System.EventHandler(this.btn_Log_Click);
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel31.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel31.ColumnCount = 5;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel31.Controls.Add(this.btn_Log, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_Light, 4, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_IO, 1, 0);
            this.tableLayoutPanel31.Controls.Add(this.btn_Count, 2, 0);
            this.tableLayoutPanel31.Location = new System.Drawing.Point(4, 652);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(489, 45);
            this.tableLayoutPanel31.TabIndex = 27;
            // 
            // btn_Log
            // 
            this.btn_Log.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Log.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Log.ForeColor = System.Drawing.Color.White;
            this.btn_Log.Location = new System.Drawing.Point(4, 4);
            this.btn_Log.Name = "btn_Log";
            this.btn_Log.Size = new System.Drawing.Size(90, 37);
            this.btn_Log.TabIndex = 34;
            this.btn_Log.Tag = "0";
            this.btn_Log.Text = "로그";
            this.btn_Log.UseVisualStyleBackColor = false;
            // 
            // btn_Light
            // 
            this.btn_Light.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Light.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Light.ForeColor = System.Drawing.Color.White;
            this.btn_Light.Location = new System.Drawing.Point(392, 4);
            this.btn_Light.Name = "btn_Light";
            this.btn_Light.Size = new System.Drawing.Size(93, 37);
            this.btn_Light.TabIndex = 33;
            this.btn_Light.Tag = "4";
            this.btn_Light.Text = "조명끄기";
            this.btn_Light.UseVisualStyleBackColor = false;
            this.btn_Light.Click += new System.EventHandler(this.btn_Light_Click);
            // 
            // btn_ReconnectCam
            // 
            this.btn_ReconnectCam.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ReconnectCam.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ReconnectCam.ForeColor = System.Drawing.Color.White;
            this.btn_ReconnectCam.Location = new System.Drawing.Point(949, 652);
            this.btn_ReconnectCam.Name = "btn_ReconnectCam";
            this.btn_ReconnectCam.Size = new System.Drawing.Size(137, 45);
            this.btn_ReconnectCam.TabIndex = 34;
            this.btn_ReconnectCam.Tag = "4";
            this.btn_ReconnectCam.Text = "카메라 재연결";
            this.btn_ReconnectCam.UseVisualStyleBackColor = false;
            this.btn_ReconnectCam.Click += new System.EventHandler(this.btn_ReconnectCam_Click);
            // 
            // bk_IO
            // 
            this.bk_IO.WorkerSupportsCancellation = true;
            this.bk_IO.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_IO_DoWork);
            // 
            // btn_inspectUp
            // 
            this.btn_inspectUp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_inspectUp.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_inspectUp.ForeColor = System.Drawing.Color.White;
            this.btn_inspectUp.Location = new System.Drawing.Point(949, 700);
            this.btn_inspectUp.Name = "btn_inspectUp";
            this.btn_inspectUp.Size = new System.Drawing.Size(288, 45);
            this.btn_inspectUp.TabIndex = 36;
            this.btn_inspectUp.Tag = "4";
            this.btn_inspectUp.Text = "검사 1 (상부)";
            this.btn_inspectUp.UseVisualStyleBackColor = false;
            this.btn_inspectUp.Click += new System.EventHandler(this.btn_inspectUp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_NutNG);
            this.groupBox1.Controls.Add(this.cb_AllNG);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(956, 751);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 126);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검사 방식 설정";
            // 
            // cb_NutNG
            // 
            this.cb_NutNG.AutoSize = true;
            this.cb_NutNG.BackColor = System.Drawing.Color.Red;
            this.cb_NutNG.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_NutNG.Location = new System.Drawing.Point(13, 85);
            this.cb_NutNG.Name = "cb_NutNG";
            this.cb_NutNG.Size = new System.Drawing.Size(259, 29);
            this.cb_NutNG.TabIndex = 1;
            this.cb_NutNG.Text = "너트 미조립 NG 불량 배출";
            this.cb_NutNG.UseVisualStyleBackColor = false;
            this.cb_NutNG.CheckedChanged += new System.EventHandler(this.cb_NutNG_CheckedChanged);
            // 
            // cb_AllNG
            // 
            this.cb_AllNG.AutoSize = true;
            this.cb_AllNG.BackColor = System.Drawing.Color.Lime;
            this.cb_AllNG.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_AllNG.Location = new System.Drawing.Point(13, 45);
            this.cb_AllNG.Name = "cb_AllNG";
            this.cb_AllNG.Size = new System.Drawing.Size(195, 29);
            this.cb_AllNG.TabIndex = 0;
            this.cb_AllNG.Text = "모든 NG 불량 배출";
            this.cb_AllNG.UseVisualStyleBackColor = false;
            this.cb_AllNG.CheckedChanged += new System.EventHandler(this.cb_AllNG_CheckedChanged);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_inspectUp);
            this.Controls.Add(this.btn_ReconnectCam);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tlpTopSide);
            this.Controls.Add(this.tlpUnder);
            this.Controls.Add(this.Main_TabControl);
            this.Controls.Add(this.tableLayoutPanel31);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISION PROGRAM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frm_Main_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Main_KeyDown);
            this.tlpUnder.ResumeLayout(false);
            this.tlpTopSide.ResumeLayout(false);
            this.tlpTopSide.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay3)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay2)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdyDisplay)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel43.ResumeLayout(false);
            this.tableLayoutPanel42.ResumeLayout(false);
            this.tableLayoutPanel41.ResumeLayout(false);
            this.tableLayoutPanel40.ResumeLayout(false);
            this.tableLayoutPanel39.ResumeLayout(false);
            this.tableLayoutPanel38.ResumeLayout(false);
            this.tableLayoutPanel37.ResumeLayout(false);
            this.tableLayoutPanel36.ResumeLayout(false);
            this.tableLayoutPanel35.ResumeLayout(false);
            this.tableLayoutPanel34.ResumeLayout(false);
            this.tableLayoutPanel33.ResumeLayout(false);
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.Main_TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpUnder;
        private System.Windows.Forms.Button btn_ToolSetUp;
        private System.Windows.Forms.Button btn_SystemSetup;
        private System.Windows.Forms.TableLayoutPanel tlpTopSide;
        private System.Windows.Forms.Label lb_Ver;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.Timer timer_Setting;
        private System.Windows.Forms.Button btn_Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.Label lb_CurruntModelName;
        public System.IO.Ports.SerialPort LightControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_CamSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label lb_Cam3_Result;
        private System.Windows.Forms.Label lb_Cam3Stats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        internal Cognex.VisionPro.Display.CogDisplay cdyDisplay2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lb_Cam2_Result;
        private System.Windows.Forms.Label lb_Cam2Stats;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl Main_TabControl;
        private System.Windows.Forms.Label lb_Cam3_InsTime;
        private System.Windows.Forms.Label lb_Cam2_InsTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label lb_Cam1Stats;
        private System.Windows.Forms.Label lb_Cam1_Result;
        private System.Windows.Forms.Label lb_Cam1_InsTime;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.Label lb_CAM3_NGRATE;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lb_CAM3_TOTAL;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lb_CAM3_NG;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lb_CAM3_OK;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Label lb_CAM2_NGRATE;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lb_CAM2_TOTAL;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lb_CAM2_NG;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lb_CAM2_OK;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label lb_CAM1_NGRATE;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lb_CAM1_TOTAL;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lb_CAM1_NG;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lb_CAM1_OK;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_IO;
        private System.Windows.Forms.Button btn_Count;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button btn_INPUT15;
        public System.Windows.Forms.Button btn_INPUT14;
        public System.Windows.Forms.Button btn_INPUT13;
        public System.Windows.Forms.Button btn_INPUT12;
        public System.Windows.Forms.Button btn_INPUT11;
        public System.Windows.Forms.Button btn_INPUT10;
        public System.Windows.Forms.Button btn_INPUT9;
        public System.Windows.Forms.Button btn_INPUT0;
        public System.Windows.Forms.Button btn_INPUT1;
        public System.Windows.Forms.Button btn_INPUT2;
        public System.Windows.Forms.Button btn_INPUT3;
        public System.Windows.Forms.Button btn_INPUT4;
        public System.Windows.Forms.Button btn_INPUT5;
        public System.Windows.Forms.Button btn_INPUT6;
        private System.Windows.Forms.Label lb_Mode;
        private System.Windows.Forms.Label lb_PLCStats;
        private System.Windows.Forms.Button btn_Light;
        private System.Windows.Forms.Button btn_ReconnectCam;
        private KimLib.LogControl logControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_Log;
        private System.ComponentModel.BackgroundWorker bk_IO;
        private System.Windows.Forms.Button btn_inspectUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel43;
        public System.Windows.Forms.Button btn_Output14;
        public System.Windows.Forms.Button btn_Output13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel42;
        public System.Windows.Forms.Button button25;
        public System.Windows.Forms.Button btn_Output12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel41;
        public System.Windows.Forms.Button button23;
        public System.Windows.Forms.Button btn_Output11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel40;
        public System.Windows.Forms.Button button21;
        public System.Windows.Forms.Button btn_Output10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel39;
        public System.Windows.Forms.Button button19;
        public System.Windows.Forms.Button btn_Output9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel38;
        public System.Windows.Forms.Button button17;
        public System.Windows.Forms.Button btn_Output8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel37;
        public System.Windows.Forms.Button button15;
        public System.Windows.Forms.Button btn_Output7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel36;
        public System.Windows.Forms.Button button13;
        public System.Windows.Forms.Button btn_Output6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel35;
        public System.Windows.Forms.Button button11;
        public System.Windows.Forms.Button btn_Output5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel34;
        public System.Windows.Forms.Button button9;
        public System.Windows.Forms.Button btn_Output4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel33;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button btn_Output3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button btn_Output2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel30;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button btn_Output1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel26;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btn_Output0;
        public System.Windows.Forms.Button btn_INPUT8;
        public System.Windows.Forms.Button btn_INPUT7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_NutNG;
        private System.Windows.Forms.CheckBox cb_AllNG;
    }
}

