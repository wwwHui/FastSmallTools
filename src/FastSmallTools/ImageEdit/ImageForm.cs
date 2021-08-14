using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastSmallTools.ImageEdit
{
    public partial class ImageForm : Form
    {
        #region 变量定义
        private ToolTip toolTip = new ToolTip();

        #endregion // 变量定义

        //声明事件委托  给主窗口传递参数 这里也可以直接将主窗口作为参数传到本窗口中
        public delegate void StateChangedEventHandler(object sender, int flag);
         //定义事件
         public event StateChangedEventHandler StateChanged;

        #region 初始化
        public ImageForm(Bitmap bmp, String name = "name")
        {
            InitializeComponent();

            toolTipInit();

            addNewPicture(bmp, name);




           
        }

        public void toolTipInit()
        {

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;

            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.buttonAdd, this.buttonAdd.Tag.ToString());

        }

        public void addNewPicture(Bitmap bmp, String name = "name")
        {
            TabPage tabPage = new TabPage();
            Panel panel = new Panel();
            PictureBox pictureBox = new PictureBox();

            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = bmp;
            Console.WriteLine(pictureBox.Size.ToString());

            panel.AutoScroll = true;
            
            panel.Dock = DockStyle.Fill;  // 大小随父容器变化

            if (name.Equals("name"))
            {
                name = DateTime.Now.ToString("yyyyMMdd-hhmmssffff");
            }
            tabPage.Name = name;
            tabPage.Text = name;

            panel.Controls.Add(pictureBox);
            tabPage.Controls.Add(panel);
            this.tabControlPicture.Controls.Add(tabPage);


        }
        #endregion // 初始化


        private void buttonAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                this.Hide();
                StateChanged(this, 1);
            }
        }

        private void ImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StateChanged(this, 0);
        }
    }
}
