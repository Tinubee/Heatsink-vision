using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VISION
{
    public partial class Frm_SystemSetUp : Form
    {
        Frm_Main Main;
        private PGgloble Unit;
        public Frm_SystemSetUp(Frm_Main main)
        {
            Main = main;
            InitializeComponent();
            Unit = PGgloble.getInstance;
            string[] Parity = { "NONE", "Odd", "Even", "Mark", "Space" };
            string[] Stopbit = { "NONE", "1", "2", "1.5" };
            string[] BaudRate = { "300", "600", "1200", "2400", "9600", "14400", "19200", "28800", "38400", "57600", "115200" };
            string[] Databit = { "5", "6", "7", "8" };
            cb_PortNumber.Items.Add("NONE");
            cb_PortNumber.Items.AddRange(SerialPort.GetPortNames());
            cb_ParityCheck.Items.AddRange(Parity);
            cb_Stopbit.Items.AddRange(Stopbit);
            cb_BaudRate.Items.AddRange(BaudRate);
            cb_Databit.Items.AddRange(Databit);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ImageRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_ImageSaveRoot.Text = fbd.SelectedPath;
            }
        }

        private void btn_DataRoot_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tb_DataSaveRoot.Text = fbd.SelectedPath;
            }
        }

        private void Frm_SystemSetUp_Load(object sender, EventArgs e)
        {
            tb_ImageSaveRoot.Text = Unit.ImageSaveRoot;
            tb_DataSaveRoot.Text = Unit.DataSaveRoot;

            cb_PortNumber.SelectedItem = Unit.PortName;
            cb_ParityCheck.SelectedItem = Unit.Parity;
            cb_Stopbit.SelectedItem = Unit.StopBits;
            cb_BaudRate.SelectedItem = Unit.BaudRate;
            cb_Databit.SelectedItem = Unit.DataBit;

            cb_OkSave.Checked = Unit.OKImageSave;
            cb_NGSave.Checked = Unit.NGImageSave;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            INIControl Writer = new INIControl(this.Unit.SETTING);
            Unit.ImageSaveRoot = tb_ImageSaveRoot.Text;
            Unit.DataSaveRoot = tb_DataSaveRoot.Text;

            if (cb_PortNumber.SelectedItem != null)
                Unit.PortName = cb_PortNumber.SelectedItem.ToString();
            Unit.Parity = cb_ParityCheck.SelectedItem.ToString();
            Unit.StopBits = cb_Stopbit.SelectedItem.ToString();
            Unit.BaudRate = cb_BaudRate.SelectedItem.ToString();
            Unit.DataBit = cb_Databit.SelectedItem.ToString();

            Writer.WriteData("SYSTEM", "Image Save Root", Unit.ImageSaveRoot);
            Writer.WriteData("SYSTEM", "Data Save Root", Unit.DataSaveRoot);

            Writer.WriteData("COMMUNICATION", $"Port number", Unit.PortName);
            Writer.WriteData("COMMUNICATION", $"Parity Check", Unit.Parity);
            Writer.WriteData("COMMUNICATION", $"Stop bits", Unit.StopBits);
            Writer.WriteData("COMMUNICATION", $"Data Bits", Unit.DataBit);
            Writer.WriteData("COMMUNICATION", $"Baud Rate", Unit.BaudRate);
            if (cb_OkSave.Checked)
            {
                Writer.WriteData("SYSTEM", "OK IMAGE SAVE", "1");
            }
            else
            {
                Writer.WriteData("SYSTEM", "OK IMAGE SAVE", "0");
            }
            if (cb_NGSave.Checked)
            {
                Writer.WriteData("SYSTEM", "NG IMAGE SAVE", "1");
            }
            else
            {
                Writer.WriteData("SYSTEM", "NG IMAGE SAVE", "0");
            }

            MessageBox.Show("저장 완료", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_OkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_OkSave.Checked == true)
            {
                Unit.OKImageSave = true;
                cb_OkSave.Text = "Save";
                cb_OkSave.BackColor = Color.Lime;
            }
            else
            {
                Unit.OKImageSave = false;
                cb_OkSave.Text = "UnSave";
                cb_OkSave.BackColor = Color.Red;
            }
        }

        private void cb_NGSave_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_NGSave.Checked == true)
            {
                Unit.NGImageSave = true;
                cb_NGSave.Text = "Save";
                cb_NGSave.BackColor = Color.Lime;
            }
            else
            {
                Unit.NGImageSave = false;
                cb_NGSave.Text = "UnSave";
                cb_NGSave.BackColor = Color.Red;
            }
        }
    }
}
