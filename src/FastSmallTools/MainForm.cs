using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Win32API;

//using FastSmallTools.test;
using FastSmallTools.Tools;
using FastSmallTools.Win32API;
using FastSmallTools.ImageEdit;


namespace FastSmallTools
{

    public partial class MainForm : Form
    {
        #region 变量定义
        enum State
        {
            None,
            Editing,
            SelectWindow,
            RectArea,
            HandArea,
            RollArea,
            FullArea,
            Video
        }
        private State state = State.None;
        private int DELAY_TIME = 500;  // 延时 0.5 秒

        private bool autoSave=true; // 是否自动保存
        private string autoSaveCapture = "./Capture/"; // 自动保存文件夹
        private bool openEdit = true; // 是否打开编辑窗口

        private MouseHook mh;
        private IntPtr hWnd, foreHwnd, oldHwnd = IntPtr.Zero;

        private ContextMenuStrip menuSetting = new ContextMenuStrip();

        private ToolTip toolTip = new ToolTip();

        private bool moving = false;
        private Point pointRecord = new Point();  //拖动窗口时记录相对位置

        private ImageForm editFrom = null;


        #endregion // 变量定义

        #region 初始化
        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;  // 顶层窗口

            settingMenuInit();
            toolTipInit();
            
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 
                Screen.PrimaryScreen.WorkingArea.Height - 2*this.Height);
        }
        public void toolTipInit()
        {

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;

            toolTip.ShowAlways = true;
            //遍历窗体所有控件
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    if (control.Tag != null)
                    {
                        toolTip.SetToolTip(control, control.Tag.ToString());
                    }                    
                }
            }
            foreach (Control control in this.panelFunction.Controls)
            {
                if (control is Button)
                {
                    if (control.Tag != null)
                    {
                        toolTip.SetToolTip(control, control.Tag.ToString());
                    }
                    else
                    {
                        toolTip.SetToolTip(control, "未写标签");
                    }

                }
            }

        }
        

        #endregion // 初始化

        #region 功能按钮函数-打开文件
        private void buttonOpenFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                //do left-click thing!
                
            }
        }
        #endregion // 打开文件

        #region 功能按钮函数-窗口截图
        /// <summary>
        /// 截图-活动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonActiveWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                this.Visible = false;
                System.Threading.Thread.Sleep(DELAY_TIME);
                IntPtr hWnd = User32.GetForegroundWindow();
                Rectangle rect = new Rectangle(0, 0, 0, 0);
                User32.GetWindowRectangle(hWnd, ref rect);
                Bitmap bmp = captureBitmap(rect);
                afterCapture(bmp);
                this.Visible = true;
            }
        }

        /// <summary>
        /// 截图-选择窗口或对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonObjectWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                
                this.Visible = false;
                this.state = State.SelectWindow;

                System.Threading.Thread.Sleep(DELAY_TIME);
                
                foreHwnd = User32.GetForegroundWindow();
                int length = User32.GetWindowTextLength(hWnd);
                StringBuilder windowName = new StringBuilder(length + 1);
                User32.GetWindowText(hWnd, windowName, windowName.Capacity);
                TxtWrite("fore.txt", "+" + windowName.ToString() + foreHwnd.ToString() + "\r\n");

                oldHwnd = IntPtr.Zero;
                mh = new MouseHook();
                mh.SetHook();
                mh.MouseDownEvent += mh_MouseDownEvent;
                mh.MouseUpEvent += mh_MouseUpEvent;
                mh.MouseMoveEvent += mh_MouseMoveEvent;
                MainForm.TxtWrite("mouse.txt", "start **********\r\n");
                //wh = new WindowsHook();
                //wh.SetHook();
                //MainForm.TxtWrite("windows.txt", "start **********\r\n");

            }
        }
        #endregion // 窗口截图

        #region 功能按钮函数-矩形截图
        /// <summary>
        /// 截图-自选矩形区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRectangeArea_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                this.Visible = false;
                System.Threading.Thread.Sleep(DELAY_TIME);  //等待
                TransparentForm transparentForm = new TransparentForm(true);
                transparentForm.ShowDialog();
                if (transparentForm.DialogResult == DialogResult.OK)
                {
                    //截图
                    //Bitmap bmp = captureBitmap(transparentForm.AreaX, transparentForm.AreaY, transparentForm.AreaWidth, transparentForm.AreaHeight);
                    Bitmap bmp = transparentForm.CaptureBitmap;
                    afterCapture(bmp);

                }
                else if (transparentForm.DialogResult == DialogResult.Cancel)
                {
                    // 没有截图

                }
                
                transparentForm.Close();


            }
        }
        #endregion // 矩形截图

        #region 功能按钮函数-全屏截图
        /// <summary>
        /// 截图-全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFullScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                //this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                System.Threading.Thread.Sleep(DELAY_TIME);  //等待
                //获取整个屏幕图像,不包括任务栏
                Rectangle ScreenArea = Screen.GetWorkingArea(this);
                Bitmap bmp = captureBitmap(0, 0, ScreenArea.Width, ScreenArea.Height);
                afterCapture(bmp);
                //bmp.Save("out.jpeg", ImageFormat.Jpeg);

                //this.WindowState = FormWindowState.Maximized;
                this.Visible = true;

            }
        }
        #endregion // 全屏截图

        #region 功能按钮函数-滚动截图
        /// <summary>
        /// 截图-滚动图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRollScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                //this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                //选中区域默认为屏幕范围,不包括任务栏
                Rectangle selectRect = Screen.GetWorkingArea(this);
                
                System.Threading.Thread.Sleep(DELAY_TIME);  //等待
                // 区域选择
                TransparentForm transparentForm = new TransparentForm(false);
                transparentForm.ShowDialog();
                if (transparentForm.DialogResult == DialogResult.OK)
                {
                    //截图区域
                    selectRect = transparentForm.GetSelectRectangle();
                }
                else if (transparentForm.DialogResult == DialogResult.Cancel)
                {
                    // 全屏幕范围

                }
                transparentForm.Close();
                MainForm.TxtWrite("roll.txt", "start **********\r\n");

                System.Threading.Thread.Sleep(DELAY_TIME);
                hWnd = User32.GetForegroundWindow();
                int length = User32.GetWindowTextLength(hWnd);
                StringBuilder windowName = new StringBuilder(length + 1);
                User32.GetWindowText(hWnd, windowName, windowName.Capacity);
                TxtWrite("roll.txt", "+" + windowName.ToString() + foreHwnd.ToString()+"\r\n");
                Bitmap bitmap = captureLongBitmap(selectRect);
                afterCapture(bitmap);
                MainForm.TxtWrite("roll.txt", "结束 **********\r\n");
                this.Visible = true;
                


            }
        }

        /// <summary>
        /// 长截图函数，合并图像部分还有待完善
        /// </summary>
        /// <param name="selectRect"></param>
        /// <returns></returns>
        private Bitmap captureLongBitmap(Rectangle selectRect)
        {
            List<Bitmap> bitmaps = new List<Bitmap>();
            int dwData = (int)(0.9 * selectRect.Height);
            Bitmap bitmap = captureBitmap(selectRect);
            bitmaps.Add(bitmap);
            Double distance = 0;
            int wheelPointX = selectRect.X + selectRect.Width / 2;
            int wheelPointY = selectRect.Y + selectRect.Height / 2;
            while (true)
            {
                MouseSimulation.MoveMouseWHEEL(wheelPointX, wheelPointY, -dwData);
                System.Threading.Thread.Sleep(DELAY_TIME);
                bitmap = captureBitmap(selectRect);
                distance = ImageTool.Calculate_Distance(bitmap, bitmaps[bitmaps.Count - 1]);
                if (distance < 0.4)
                {
                    //bitmaps.Add(bitmap);
                    Console.WriteLine("滚动结束," + distance.ToString());
                    break;
                }
                else
                {
                    bitmaps.Add(bitmap);
                    Console.WriteLine("滚动图片" + bitmaps.Count.ToString() + "," + distance.ToString());
                }



            }
            int i = 0;
            foreach (Bitmap b in bitmaps)
            {
                string filename = "roll/" + i++.ToString() + ".png";
                b.Save(filename, ImageFormat.Png);
            }
            Bitmap longBitmap = generateLongBitmap(bitmaps, selectRect);

            return longBitmap;
        }


        #endregion // 滚动截图

        #region 功能按钮函数-设置
        /// <summary>
        /// 设置按钮处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetting_Click(object sender, EventArgs e)
        {
            menuSetting.Show(MousePosition.X, MousePosition.Y);
            //menuSetting.Show();
        }
        private void settingMenuInit()
        {
            //增加设置菜单
            ToolStripMenuItem item = new ToolStripMenuItem("设置");
            item.Click += new EventHandler(menuSetting_ItemClick);
            item.DropDownItemClicked += new ToolStripItemClickedEventHandler(menuSetting_ItemClick);
            item.DropDown.Items.Add("二级菜单");
            item.DropDown.Items.Add("设置项2");
            menuSetting.Items.Add(item);
            item = new ToolStripMenuItem("测试");
            item.Click += new EventHandler(menuSetting_ItemClick);
            item.DropDownItemClicked += new ToolStripItemClickedEventHandler(menuSetting_ItemClick);
            menuSetting.Items.Add(item);


        }
        private void menuSetting_ItemClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            ToolStripItemClickedEventArgs toolStripItemClickedEventArgs;
            ToolStripMenuItem toolStripMenuItem = (sender as ToolStripMenuItem);
            Type t = e.GetType();
            switch (toolStripMenuItem.Text)
            {
                case "设置":
                    if (t.Name == "EventArgs")
                    {

                    }
                    else if (t.Name == "ToolStripItemClickedEventArgs")
                    {
                        toolStripItemClickedEventArgs = e as ToolStripItemClickedEventArgs;
                        switch (toolStripItemClickedEventArgs.ClickedItem.Text)
                        {
                            case "二级菜单":
                                Console.WriteLine("设置-二级菜单");
                                break;
                            case "设置项2":
                                Console.WriteLine("设置-设置项2");
                                break;
                        }
                    }
                    break;
                case "测试":
                    //TestForm tf = new TestForm();
                    //tf.Show();
                    break;
            }
        }
        #endregion // 设置

        #region 截图及后续处理函数

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">截图区域左上角的x坐标</param>
        /// <param name="y">截图区域左上角的y坐标</param>
        /// <param name="width">截图区域的宽度</param>
        /// <param name="height">截图区域的高度</param>
        /// <returns>Bitmap图片</returns>
        private Bitmap captureBitmap(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
            }
            return bmp;
        }

        private Bitmap captureBitmap(Rectangle rect)
        {
            return captureBitmap(rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <summary>
        /// 截图后的处理，保存或编辑等，待完善
        /// </summary>
        /// <param name="bmp"></param>
        private void afterCapture(Bitmap bmp)
        {
            if (autoSave)  // 自动保存
            {
                if (!Directory.Exists(autoSaveCapture))//如果不存在就创建文件夹
                {
                    Directory.CreateDirectory(autoSaveCapture);
                }
                //String filename = DateTime.Now.ToString("G"); //  DateTime.Now.ToString("yyyy-M-d H:mm:ss");
                String filename = autoSaveCapture + DateTime.Now.ToString("yyyyMd-Hmmss") + ".png";
                bmp.Save(filename, ImageFormat.Png);
            }

            if (openEdit)  // 打开编辑窗口
            {
                this.Visible = false;
                if (editFrom == null)
                {
                    editFrom = new ImageForm(bmp);
                    editFrom.StateChanged += new ImageForm.StateChangedEventHandler(editFromStateChanged);
                }
                else
                {
                    editFrom.AddNewPicture(bmp);
                }
                
                editFrom.Show();
            }
            else
            {
                this.Visible = true;
            }
            
            
        }

        public void editFromStateChanged(object sender, int flag)
        {
            switch (flag)
            {
                case 0:  // 编辑窗口被关闭  -> 关闭主窗口
                    this.Close();
                    break;
                case 1:  // 编辑窗口中要求新增截图  -> 显示主窗口
                    this.Visible = true;
                    break;

            }
        }

        #endregion

        #region 鼠标事件-全局鼠标
        /// <summary>
        /// 全局鼠标-单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mh_MouseDownEvent(object sender, MouseEventArgs e)
            {
                if(state == State.SelectWindow)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        User32.RefreshFullScreen();
                        System.Threading.Thread.Sleep(DELAY_TIME);
                        Rectangle rect = new Rectangle(0, 0, 0, 0);
                        User32.GetWindowRectangle(hWnd, ref rect);
                        Bitmap bmp = captureBitmap(rect);
                        afterCapture(bmp);
                    
                    }
                    state = State.None;
                    this.Visible = true;
                    mh.UnHook();
                    mh.MouseDownEvent -= mh_MouseDownEvent;
                    mh.MouseUpEvent -= mh_MouseUpEvent;
                    mh.MouseMoveEvent -= mh_MouseMoveEvent;
                    MainForm.TxtWrite("mouse.txt", "end **********\r\n");
                    //wh.UnHook();
                }

                if (e.Button == MouseButtons.Right)
                {
                }
            }
        /// <summary>
        /// 全局鼠标-移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (state == State.SelectWindow)
            {
                Rectangle rect = new Rectangle();
                Point ptSpy = Control.MousePosition;
                hWnd = User32.WindowFromPoint(ptSpy);
                User32.GetWindowRectangle(hWnd, ref rect);
                
                if (oldHwnd != hWnd)
                {
                    
                    User32.RefreshFullScreen();//刷新桌面，删掉先前画的矩形
                }
                Graphics g = Graphics.FromHdc(User32.GetWindowDC(IntPtr.Zero));
                g.DrawRectangle(new Pen(Color.Red, 2), rect.Left + 2, rect.Top + 2, rect.Width - 4, rect.Height - 4);
                g.Dispose();
                oldHwnd = hWnd;
            }


        }
        /// <summary>
        /// 全局鼠标-松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mh_MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (state == State.SelectWindow)
            {

            }

        }
        #endregion // 鼠标事件

        #region 鼠标事件-拖动窗口
        private void buttonText_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!moving)
                {
                    pointRecord = new Point(this.Location.X - Control.MousePosition.X, this.Location.Y - Control.MousePosition.Y);
                    moving = true;
                    //Console.WriteLine("开始移动");
                }
            }
        }

        private void buttonText_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (moving)
                {
                    moving = false;
                    //Console.WriteLine("停止移动");
                }
            }
        }

        private void buttonText_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.NoMove2D;
            
        }

        private void buttonText_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void buttonText_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                this.Location = new Point(Control.MousePosition.X + pointRecord.X,
                    Control.MousePosition.Y + pointRecord.Y);
                //Console.WriteLine("ing," + e.Location.ToString() + ",");
                //this.buttonText.Focus();
            }

        }




        #endregion // 鼠标事件

        #region 窗口-最小化和关闭
        private void notifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)  // 单击鼠标左键
            {
                this.Visible = !this.Visible;
            }
            else if (e.Button == MouseButtons.Right)  // 单击鼠标右键
            {

            }
        }
        /// <summary>
        /// 窗口最小化-实际是隐藏了窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMini_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            /**只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，
             * 另外若有托管线程（非主线程），也无法干净地退出。
             */
            this.Close();   
        }
        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon.Visible = false;  // 关闭托盘图标
        }

        #endregion // 窗口-最小化和关闭

        #region 其他函数
        public static void TxtWrite(String path, String text)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            //获得字节数组
            byte[] data = System.Text.Encoding.Default.GetBytes(text);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }


        public static Bitmap generateLongBitmap(List<Bitmap> bitmaps, Rectangle selectRect)
        {
            if(bitmaps.Count == 0)
            {
                return new Bitmap(10,10);
            }
            else if(bitmaps.Count == 1)
            {
                return bitmaps[0];
            }
            Bitmap longBitmap = new Bitmap(selectRect.Width, selectRect.Height * bitmaps.Count);
            Graphics g = Graphics.FromImage(longBitmap);
            // 将画布涂为白色(底部颜色可自行设置)
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, longBitmap.Width, longBitmap.Height));

            List<int> bitmapRowCRCList1, bitmapRowCRCList2, bitmapColmunCRCList, lastBitmapColmunCRCList;
            Bitmap bitmap = bitmaps[0];
            bitmapColmunCRCList = ImageTool.GetBitmapCRCCode(bitmap, false);
            
            g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
            int edgeIndex1 = 0, edgeIndex2 = 0, height = 0, img1Index = 0, img2Index = 0;
            for (int i = 1; i < bitmaps.Count; i++)
            {
                bitmap = bitmaps[i];
                lastBitmapColmunCRCList = bitmapColmunCRCList;
                bitmapColmunCRCList = ImageTool.GetBitmapCRCCode(bitmap, false);
                ImageTool.FindMaxCommonEdge(bitmapColmunCRCList, lastBitmapColmunCRCList, ref edgeIndex1, ref edgeIndex2);
                bitmapRowCRCList1 = ImageTool.GetBitmapCRCCode(bitmaps[i-1], true, edgeIndex1, edgeIndex2);
                bitmapRowCRCList2 = ImageTool.GetBitmapCRCCode(bitmap, true, edgeIndex1, edgeIndex2);
                if (ImageTool.FindMaxCommonList(bitmapRowCRCList1, bitmapRowCRCList2, ref img1Index, ref img2Index))
                {
                    height += img1Index;
                }
                else
                {
                    height += bitmap.Height;
                    img2Index = 0;
                }
                //g.DrawImage(bitmap, i*selectRect.Width, index, bitmap.Width, bitmap.Height);
                g.DrawImage(bitmap, new Rectangle(0, height, bitmap.Width, bitmap.Height - img2Index), 
                    new Rectangle(0, img2Index, bitmap.Width, bitmap.Height - img2Index), GraphicsUnit.Pixel);
                Console.WriteLine(string.Format("合并,i:{0},h:{1},i1:{2},i2:{3},e1;{4},e2:{5}", 
                    i, height, img1Index, img2Index, edgeIndex1, edgeIndex2));
            }
            g.Dispose();
            height += bitmap.Height;

            bitmap = new Bitmap(selectRect.Width, height);
            g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            g.DrawImage(longBitmap, new Rectangle(0, 0, bitmap.Width, height),
                   new Rectangle(0, 0, bitmap.Width, height), GraphicsUnit.Pixel);
            g.Dispose();

            return bitmap;
        }

        #endregion // 其他函数

    }
}
