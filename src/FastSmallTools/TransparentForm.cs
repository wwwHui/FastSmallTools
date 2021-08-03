using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32API;

namespace FastSmallTools
{
    public partial class TransparentForm : Form
    {
        /**
         * 顶层透明窗口，用于截图时选择矩形框的位置和大小
         * 同样的功能也可以调用Win32API实现 
         */

        #region 变量定义
        private int areaX, areaY, areaWidth, areaHeight;
        private Bitmap screenImage, captureBitmap;
        private int state = 0;//状态 
        private bool simpleEdit = false;//截图结束后，是否编辑

        public int AreaX { get => areaX; set => areaX = value; }
        public int AreaY { get => areaY; set => areaY = value; }
        public int AreaWidth { get => areaWidth; set => areaWidth = value; }
        public int AreaHeight { get => areaHeight; set => areaHeight = value; }
        public Bitmap CaptureBitmap { get => captureBitmap; set => captureBitmap = value; }
        #endregion // 变量定义

        #region 构造函数 初始化
        public TransparentForm(bool simpleEdit)
        {
            InitializeComponent();
            //this.BackColor = Color.Blue;
            //this.TransparencyKey = this.BackColor;

            /* 参考了 https://blog.csdn.net/testcs_dn/article/details/23182607 中 截图窗口实现原理 的部分
             */
            Bitmap bkImage = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(bkImage);
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
            g.CopyFromScreen(0, 0, 0, 0, Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
            screenImage = (Bitmap)bkImage.Clone();
            //g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Gray)), Screen.PrimaryScreen.Bounds);
            this.BackgroundImage = bkImage;

            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = Screen.PrimaryScreen.Bounds.Location;

            this.WindowState = FormWindowState.Maximized;
            //this.Show();
            this.DialogResult = DialogResult.None;
            this.Cursor = Cursors.Cross;  //  鼠标形状

            this.simpleEdit = simpleEdit;

        }
        #endregion // 构造函数 初始化

        #region 鼠标事件
        private void TransparentForm_MouseMove(object sender, MouseEventArgs e)
        {


            Bitmap image = (Bitmap)screenImage.Clone();
            Graphics g = Graphics.FromImage(image);
            Point mousePoint = this.PointToScreen(Control.MousePosition);
            Pen pen = new Pen(Brushes.Red, 1);

            if (state == 0) // 未选中第一个点
            {
                g.DrawLine(pen, 0, mousePoint.Y, this.Width, mousePoint.Y);
                g.DrawLine(pen, mousePoint.X, 0, mousePoint.X, this.Height);
            }
            else if (state == 1)  // 已经选中了第一个点
            {
                g.DrawLine(pen, AreaX, AreaY, AreaX, mousePoint.Y);
                g.DrawLine(pen, AreaX, AreaY, mousePoint.X, AreaY);
                g.DrawLine(pen, mousePoint.X, mousePoint.Y, AreaX, mousePoint.Y);
                g.DrawLine(pen, mousePoint.X, mousePoint.Y, mousePoint.X, AreaY);

                //非选中区域暗色处理
                Region regoin = new Region(new Rectangle(0, 0, this.Width, this.Height));
                int w = Math.Abs(mousePoint.X - AreaX);
                int h = Math.Abs(mousePoint.Y - AreaY);
                int x = Math.Min(AreaX, mousePoint.X);
                int y = Math.Min(AreaY, mousePoint.Y);
                Rectangle select = new Rectangle(x, y, w, h);
                regoin.Xor(select);
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(100, Color.Gray));
                g.FillRegion(solidBrush, regoin);
            }

            //this.BackgroundImage = bkImage;
            this.CreateGraphics().DrawImage(image, 0, 0);
        }
        private void TransparentForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // 单击鼠标左键
            {
                Point mousePoint = this.PointToScreen(Control.MousePosition);
                switch (state)
                {
                    case 0: // 未选点 -> 选择第一个点

                        AreaX = mousePoint.X;
                        AreaY = mousePoint.Y;
                        state = 1;
                        break;
                    case 1: // 选择第二个点
                        int x2 = mousePoint.X;
                        int y2 = mousePoint.Y;
                        AreaWidth = Math.Abs(x2 - AreaX);
                        AreaHeight = Math.Abs(y2 - AreaY);
                        AreaX = Math.Min(AreaX, x2);
                        AreaY = Math.Min(AreaY, y2);
                        state = 2;
                        CaptureBitmap = new Bitmap(AreaWidth, AreaHeight);
                        Graphics g = Graphics.FromImage(CaptureBitmap);
                        Rectangle desRect = new Rectangle(0, 0, AreaWidth, AreaHeight);
                        Rectangle srcRect = new Rectangle(AreaX, AreaY, AreaWidth, AreaHeight);
                        g.DrawImage(screenImage, desRect, srcRect, GraphicsUnit.Pixel);
                        //screenImage.Save("screenImage.png", System.Drawing.Imaging.ImageFormat.Png);
                        if (simpleEdit)
                        {
                            //这里应该写展示编辑条的代码
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        
                        break;

                }
            }
        }

        private void TransparentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // 退出按钮
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void TransparentForm_Deactivate(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }
        #endregion // 鼠标事件

        #region 选中范围
        public Rectangle GetSelectRectangle()
        {
            return new Rectangle(AreaX, AreaY, AreaWidth, AreaHeight);
        }
        #endregion
    }
}
