using FastSmallTools.CustomControl;
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

        

        //声明事件委托  给主窗口传递参数 这里也可以直接将主窗口作为参数传到本窗口中
        public delegate void StateChangedEventHandler(object sender, int flag);
         //定义事件
         public event StateChangedEventHandler StateChanged;

        #endregion // 变量定义

        #region 初始化
        public ImageForm(Bitmap bmp, String name = "name")
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;  //使窗口启动时直接最大化
            ToolTipInit();
            AddNewPicture(bmp, name);

            tabControlPicture.AddButtonClick += new CustomTabControl.AddButtonClickDelegate(AddNewPictureEvent);//把事件绑定到自定义的委托上
            tabControlPicture.ControlRemoved += TabControlPicture_ControlRemoved;

        }

        private void TabControlPicture_ControlRemoved(object sender, ControlEventArgs e)
        {
            //Console.WriteLine(e.Control.Text);
            //Console.WriteLine(this.tabControlPicture.SelectedIndex.ToString()); 
        }

        /// <summary>
        /// 提示初始化
        /// </summary>
        public void ToolTipInit()
        {

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;

            toolTip.ShowAlways = true;


        }
        /// <summary>
        /// 新增图片展示和编辑框
        /// </summary>
        /// <param name="bmp">新增的图片</param>
        /// <param name="name">图片名或标识</param>
        public void AddNewPicture(Bitmap bmp, String name = "name")
        {
            PictureBox pictureBox = new PictureBox();
            Panel panel = new Panel();
            TabPage tabPage = new TabPage();
            
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = bmp;

            panel.AutoScroll = true;
            //panel.AutoScrollMinSize = pictureBox.Size;
            panel.Dock = DockStyle.Fill;  // 大小随父容器变化

            if (name.Equals("name"))
            {
                name = DateTime.Now.ToString("yyyyMMdd-hhmmssffff");
            }
            if(!name.EndsWith("  "))
            {
                name = name + "  ";
            }
            tabPage.Name = name;
            tabPage.Text = name;
            tabPage.Dock = DockStyle.Fill;  // 大小随父容器变化


            panel.Controls.Add(pictureBox);
            tabPage.Controls.Add(panel);
            this.tabControlPicture.TabPages.Add(tabPage);
            this.tabControlPicture.SelectedTab = tabPage;

            //Console.WriteLine(pictureBox.Size.ToString() + "   " + panel.Size.ToString() + "   " + tabPage.Size.ToString() + "   " + this.tabControlPicture.Size.ToString());

            pictureBox.Left = (panel.Width - pictureBox.Width) / 2;
            //pictureBox.Location.X = (panel.Width - pictureBox.Width) / 2;

            //pictureBox.BackColor = System.Drawing.Color.Red;
            //panel.BackColor = System.Drawing.Color.Yellow;


        }


        public void AddNewPictureEvent(object sender, EventArgs e)
        {
            this.Hide();
            StateChanged(this, 1);
        }

        #endregion // 初始化

        #region 窗体事件
        /// <summary>
        /// 窗体关闭事件 - 给主窗口传递关闭信号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StateChanged(this, 0);
        }

        private void ImageForm_Resize(object sender, EventArgs e)
        {
            int width = this.Width - 20;
            int height = this.Height - 20;  
            // panelMenu  位置 和 大小
            //Console.WriteLine("edit from size " + width.ToString() + ", " + height.ToString());
            this.panelMenu.Location = new Point(5, 0);
            this.panelMenu.Size = new Size(width, 80);
            //Console.WriteLine("panelMenu size:" + this.panelMenu.Size.ToString());

            // tabControlPicture 位置 和 大小
            this.tabControlPicture.Location = new Point(5, 85);
            this.tabControlPicture.Size = new Size(width, height - 100);
            //Console.WriteLine("panelMenu size:" + this.tabControlPicture.Size.ToString());

            // tabControlPicture 中的控件  位置 和 大小
            foreach (Control control in this.tabControlPicture.Controls)
            {
                try
                {
                    TabPage tabPage = (TabPage)control;
                    Panel panel = (Panel)(tabPage.Controls[0]);
                    PictureBox pictureBox = (PictureBox)(panel.Controls[0]);
                    pictureBox.Left = (panel.Width - pictureBox.Width) / 2;
                }
                catch
                {

                }
                
            }
        }
        #endregion // 窗体事件


    }
}
