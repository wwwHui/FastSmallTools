using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Win32API
{
    class User32
    {
        /**
         * Win32API声明及部分封装 
         */

        #region 自定义结构
        //定义 RECT
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT // GetWindowRect 函数需要
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }

        //自定义一个struct，用来保存句柄信息
        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion

        #region 值定义
        const int RDW_INVALIDATE = 0x0001;
        const int RDW_INTERNALPAINT = 0x0002;
        const int RDW_ERASE = 0x0004;

        const int RDW_VALIDATE = 0x0008;
        const int RDW_NOINTERNALPAINT = 0x0010;
        const int RDW_NOERASE = 0x0020;

        const int RDW_NOCHILDREN = 0x0040;
        const int RDW_ALLCHILDREN = 0x0080;

        const int RDW_UPDATENOW = 0x0100;
        const int RDW_ERASENOW = 0x0200;

        const int RDW_FRAME = 0x0400;
        const int RDW_NOFRAME = 0x0800;
        #endregion  // 值定义

        #region API函数
        /* API函数 需要引用System.Runtime.InteropServices;
         * 下面的 DllImport("user32.dll") 中的字符串可以是"user32.dll"、"user32"、"User32.dll"等
         */
        //获取当前窗口句柄
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        //获取窗口大小及位置
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);
        //用来遍历所有窗口 
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);
        //获取窗口Text 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        //获取窗口类名 
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);
        //根据坐标获取窗口句柄
        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(System.Drawing.Point Point);
        //激活窗口并前置
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        public extern static System.IntPtr GetDC(System.IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hwnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, UInt32 nFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        //[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern bool RedrawWindow(IntPtr hwnd, ref RECT rcUpdate, IntPtr hrgnUpdate, int flags);
        [DllImport("User32.dll")]
        private static extern bool RedrawWindow(int h, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(ref POINT pt);

        [DllImport("user32")]
        public static extern bool EnableWindow(IntPtr hwnd,bool fEnable);

        #endregion // API函数

        #region 封装部分API

        /// <summary>
        /// 封装 GetWindowRect 函数
        /// </summary>
        /// <returns></returns>
        public static bool GetWindowRectangle(IntPtr hWnd, ref Rectangle rect)
        {
            RECT lpRect = new RECT();
            rect = new Rectangle();
            GetWindowRect(hWnd, ref lpRect);//h为窗口句柄
            rect.X = lpRect.Left;
            rect.Y = lpRect.Top;
            rect.Width = lpRect.Right - lpRect.Left;
            rect.Height = lpRect.Bottom - lpRect.Top;
            return true;
        }


        public bool GetMousePos(ref Point point)
        {
            POINT currentPosition = new POINT();
            GetCursorPos(ref currentPosition);
            point.X = currentPosition.x;
            point.Y = currentPosition.y;
            return true;
        }

        /// <summary>
        /// 重新刷新桌面，而从清楚绘制内容
        /// </summary>
        public static void RefreshFullScreen()
        {
            RedrawWindow(0, IntPtr.Zero, IntPtr.Zero, 4 | 1 | 128);
            /**
             * RedrawWindow的第一个参数，如果用GetDesktopWindow()就无效，原因未知
             * 也试过其他函数，如InvalidateRect,UpdateWindow等均无法刷新
             */
        }

        #endregion //封装部分API


    }
}
