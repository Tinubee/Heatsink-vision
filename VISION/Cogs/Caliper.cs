using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISION.Cogs
{
    public class Caliper
    {
        private Cognex.VisionPro.Caliper.CogCaliperTool Tool;

        public Caliper(int Toolnumber)
        {
            Tool = new Cognex.VisionPro.Caliper.CogCaliperTool();
            Tool.Name = "Caliper - " + Toolnumber.ToString();
        }

        private void NewTool()
        {
            this.Tool.RunParams.EdgeMode = Cognex.VisionPro.Caliper.CogCaliperEdgeModeConstants.SingleEdge;

            Cognex.VisionPro.CogRectangleAffine Region = new Cognex.VisionPro.CogRectangleAffine();

            Region.CenterX = 400;
            Region.CenterY = 300;

            Region.SideXLength = 100;
            Region.SideYLength = 100;

            Region.LineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.Solid;
            Region.LineWidthInScreenPixels = 1;
            Region.Color = Cognex.VisionPro.CogColorConstants.Green;

            Region.SelectedLineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.DashDot;
            Region.SelectedLineWidthInScreenPixels = 1;
            Region.SelectedColor = Cognex.VisionPro.CogColorConstants.Cyan;

            Region.DragLineStyle = Cognex.VisionPro.CogGraphicLineStyleConstants.Dot;
            Region.DragLineWidthInScreenPixels = 1;
            Region.DragColor = Cognex.VisionPro.CogColorConstants.Yellow;

            Region.GraphicDOFEnable = Cognex.VisionPro.CogRectangleAffineDOFConstants.All;
            Region.Interactive = true;

            this.Tool.Region = Region;
        }

        /// <summary>
        /// 파일에서 툴을 불러 옴. 파일이 있는 폴더의 경로만 제공 하면 됨.
        /// </summary>
        /// <param name="path">파일이 있는  폴더의 경로</param>
        /// <returns></returns>
        public bool Loadtool(string path)
        {
            string Savepath = path;

            if (System.IO.Directory.Exists(Savepath) == false)
            {
                NewTool();
                return true;
            }

            Savepath = Savepath + "\\" + Tool.Name + ".vpp";

            if (System.IO.File.Exists(Savepath) == false)
            {
                NewTool();
                return false;
            }

            Tool = (Cognex.VisionPro.Caliper.CogCaliperTool)Cognex.VisionPro.CogSerializer.LoadObjectFromFile(Savepath);

            return true;
        }

        /// <summary>
        /// 파일에 툴의 정보를 씀. 대상 파일이 위치 할 폴더의 경로만 제공 하면 됨.
        /// </summary>
        /// <param name="path">저장 할 대상 폴더의 경로</param>
        /// <returns></returns>
        public bool Savetool(string path)
        {
            string Savepath = path;

            if (System.IO.Directory.Exists(Savepath) == false)
            {
                return false;
            }

            Savepath = Savepath + "\\" + Tool.Name + ".vpp";

            Cognex.VisionPro.CogSerializer.SaveObjectToFile(this.Tool, Savepath);

            return true;
        }

        /// <summary>
        /// 툴에 이미지 입력
        /// </summary>
        /// <param name="image">툴에 입력 할 이미지</param>
        /// <returns></returns>
        public bool InputImage(Cognex.VisionPro.CogImage8Grey image)
        {
            if (image == null)
            {
                return false;
            }

            this.Tool.InputImage = image;
            return true;
        }

        public bool Run(Cognex.VisionPro.CogImage8Grey image)
        {
            if (!InputImage(image))
            {
                return false;
            }

            this.Tool.Run();

            if (this.Tool.Results == null)
            {
                return false;
            }

            if (this.Tool.Results.Count < 1)
            {
                return false;
            }

            return true;
        }

        public void Area(ref Cognex.VisionPro.Display.CogDisplay Display, Cognex.VisionPro.CogImage8Grey Image, string ImageSpace)
        {
            Tool.CurrentRecordEnable = Cognex.VisionPro.Caliper.CogCaliperCurrentRecordConstants.All;

            Tool.Region.SelectedSpaceName = ImageSpace;
            //this.Tool.RunParams.e.SelectedSpaceName = ImageSpace;

            Display.InteractiveGraphics.Add(this.Tool.Region, null, false);
        }

        public double Threshold()
        {
            return this.Tool.RunParams.ContrastThreshold;
        }

        public void Threshold(double threshold)
        {
            this.Tool.RunParams.ContrastThreshold = threshold;
        }

        public int Halfpixel()
        {
            return this.Tool.RunParams.FilterHalfSizeInPixels;
        }

        public void Halfpixel(int halfpixel)
        {
            this.Tool.RunParams.FilterHalfSizeInPixels = halfpixel;
        }

        public void Length(double Length)
        {
            this.Tool.RunParams.Edge0Position = (Length / 2) * -1;
            this.Tool.RunParams.Edge1Position = Length / 2;
        }

        public double Length()
        {
            return this.Tool.RunParams.Edge1Position * 2;
        }

        public int Polarty(int Edge)
        {
            switch (Edge)
            {
                case 1:
                    switch (this.Tool.RunParams.Edge0Polarity)
                    {
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight:
                            return 0;
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DontCare:
                            return 2;
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark:
                            return 1;
                    }
                    break;
                case 2:
                    switch (this.Tool.RunParams.Edge1Polarity)
                    {
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight:
                            return 0;
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DontCare:
                            return 2;
                        case Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark:
                            return 1;
                    }
                    break;
            }

            return 2;
        }

        public void Polarty(int edge, int polarity)
        {
            switch (edge)
            {
                case 1:
                    switch (polarity)
                    {
                        case 1:
                            this.Tool.RunParams.Edge0Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight;
                            break;
                        case 3:
                            this.Tool.RunParams.Edge0Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DontCare;
                            break;
                        case 2:
                            this.Tool.RunParams.Edge0Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark;
                            break;
                    }
                    break;
                case 2:
                    switch (polarity)
                    {
                        case 1:
                            this.Tool.RunParams.Edge1Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DarkToLight;
                            break;
                        case 3:
                            this.Tool.RunParams.Edge1Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.DontCare;
                            break;
                        case 2:
                            this.Tool.RunParams.Edge1Polarity = Cognex.VisionPro.Caliper.CogCaliperPolarityConstants.LightToDark;
                            break;
                    }
                    break;
            }
        }

        public double Result_X()
        {
            if (this.Tool.Results == null)
            {
                return 0;
            }

            if (this.Tool.Results.Count < 1)
            {
                return 0;
            }
            double Result = 0.0;

            if (this.Tool.RunParams.EdgeMode == Cognex.VisionPro.Caliper.CogCaliperEdgeModeConstants.SingleEdge)
            {
                Result = this.Tool.Results[0].Edge0.PositionX;
            }
            else
            {
                Result = (this.Tool.Results[0].Edge0.PositionX + this.Tool.Results[0].Edge1.PositionX) / 2;
            }

            return Result;
        }

        public double Result_Y()
        {
            if (this.Tool.Results == null)
            {
                return 0;
            }

            if (this.Tool.Results.Count < 1)
            {
                return 0;
            }
            double Result = 0.0;

            if (this.Tool.RunParams.EdgeMode == Cognex.VisionPro.Caliper.CogCaliperEdgeModeConstants.SingleEdge)
            {
                Result = this.Tool.Results[0].Edge0.PositionY;
            }
            else
            {
                Result = (this.Tool.Results[0].Edge0.PositionY + this.Tool.Results[0].Edge1.PositionY) / 2;
            }

            return Result;
        }

        public void ResultDisplay(ref Cognex.VisionPro.Display.CogDisplay display)
        {
            if (this.Tool.Results == null)
            {
                return;
            }

            if (this.Tool.Results.Count <= 0)
            {

                return;
            }
            display.InteractiveGraphics.Add(this.Tool.Results[0].CreateResultGraphics(Cognex.VisionPro.Caliper.CogCaliperResultGraphicConstants.All), null, false);
        }

        /// <summary>
        /// 검사 툴 전체 셋업 화면을 화면에 표시
        /// </summary>
        public void ToolSetup()
        {
            System.Windows.Forms.Form Window = new System.Windows.Forms.Form();
            Cognex.VisionPro.Caliper.CogCaliperEditV2 Edit = new Cognex.VisionPro.Caliper.CogCaliperEditV2();

            Edit.Dock = System.Windows.Forms.DockStyle.Fill; // 화면 채움
            Edit.Subject = Tool; // 에디트에 툴 정보 입력.
            Window.Controls.Add(Edit); // 폼에 에디트 추가.

            Window.Width = 800;
            Window.Height = 600;

            Window.Show(); // 폼 실행
        }
    }
}
