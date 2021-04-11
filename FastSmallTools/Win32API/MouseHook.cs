using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastSmallTools;

namespace Win32API
{
    class MouseHook
    {
        /**
         * 全局鼠标钩子
         */
        #region API
        [StructLayout(LayoutKind.Sequential)]
        private class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        private class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        /// <summary>
        /// 钩子回调函数
        /// </summary>
        /// <param name="nCode">如果代码小于零，则挂钩过程必须将消息传递给CallNextHookEx函数，而无需进一步处理，并且应返回CallNextHookEx返回的值。</param>
        /// <param name="wParam">记录了按下的按钮</param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(IntPtr idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);
        #endregion

        #region 变量定义
        private Point point;
        private Point Point
        {
            get { return point; }
            set
            {
                if (point != value)
                {
                    point = value;
                    if (MouseMoveEvent != null)
                    {
                        var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
                        MouseMoveEvent(this, e);
                    }
                }
            }
        }
        private IntPtr hHook;
        private static int hMouseHook = 0;
        public HookProc hProc;
        #endregion // 变量定义

        #region 常量
        public const int WM_MOUSEMOVE = 0x200; // 鼠标移动
        public const int WM_LBUTTONDOWN = 0x201;// 鼠标左键按下
        public const int WM_RBUTTONDOWN = 0x204;// 鼠标右键按下
        public const int WM_MBUTTONDOWN = 0x207;// 鼠标中键按下
        public const int WM_LBUTTONUP = 0x202;// 鼠标左键抬起
        public const int WM_RBUTTONUP = 0x205;// 鼠标右键抬起
        public const int WM_MBUTTONUP = 0x208;// 鼠标中键抬起
        public const int WM_LBUTTONDBLCLK = 0x203;// 鼠标左键双击
        public const int WM_RBUTTONDBLCLK = 0x206;// 鼠标右键双击
        public const int WM_MBUTTONDBLCLK = 0x209;// 鼠标中键双击
        public const int WH_MOUSE_LL = 14; //可以截获整个系统所有模块的鼠标事件。
        #endregion

        #region 函数
        public MouseHook()
        {
            this.Point = new Point();
        }
        public IntPtr SetHook()
        {
            hProc = new HookProc(MouseHookProc);
            hHook = SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
            return hHook;
        }
        public void UnHook()
        {
            UnhookWindowsHookEx(hHook);
        }
        private IntPtr MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            String text = nCode.ToString() + "---" + wParam.ToString() +"---"+ lParam.ToString()+"\r\n";
            MainForm.TxtWrite("mouse.txt", text);
            MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
            if (nCode < 0)
            {
                return (IntPtr)1;
                //return CallNextHookEx(hHook, nCode, wParam, lParam);
                //return 0;
            }
            else
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;
                switch ((Int32)wParam)
                {
                    case WM_MOUSEMOVE:
                        Console.WriteLine("鼠标移动");
                        this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
                        return CallNextHookEx(IntPtr.Zero, -1, wParam, lParam);
                    //break;
                    case WM_LBUTTONDOWN:
                        //System.Threading.Thread.Sleep(3000);
                        button = MouseButtons.Left;
                        clickCount = 1;
                        Console.WriteLine("鼠标左键单击");
                        MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;

                    case WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;
                    case WM_MBUTTONDOWN:
                        button = MouseButtons.Middle;
                        clickCount = 1;
                        MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;
                    case WM_LBUTTONUP:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;
                    case WM_RBUTTONUP:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;
                    case WM_MBUTTONUP:
                        button = MouseButtons.Middle;
                        clickCount = 1;
                        MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                        break;
                }

                return (IntPtr)0;
                //return CallNextHookEx(hHook, -1, (IntPtr)WM_MOUSEMOVE, lParam);

            }
        }
        #endregion // 函数

        #region 委托处理鼠标事件
        public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
        public event MouseMoveHandler MouseMoveEvent;

        public delegate void MouseClickHandler(object sender, MouseEventArgs e);
        public event MouseClickHandler MouseClickEvent;

        public delegate void MouseDownHandler(object sender, MouseEventArgs e);
        public event MouseDownHandler MouseDownEvent;

        public delegate void MouseUpHandler(object sender, MouseEventArgs e);
        public event MouseUpHandler MouseUpEvent;
        # endregion  // 委托处理鼠标事件
    }
}

