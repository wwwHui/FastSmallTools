using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace FastSmallTools.Win32API
{
    public class MouseSimulation
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        //模拟鼠标滚轮滚动操作，必须配合dwData参数
        const int MOUSEEVENTF_WHEEL = 0x0800;



        public static void MoveMouseWHEEL(int dwData)
        {
            Console.WriteLine("模拟鼠标滚动-相对坐标");
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, dwData, 0);//鼠标滚动
        }
        public static void MoveMouseWHEEL(int x, int y, int dwData)
        {
            Console.WriteLine("模拟鼠标滚动-绝对坐标");
            mouse_event(MOUSEEVENTF_WHEEL | MOUSEEVENTF_ABSOLUTE, x, y, dwData, 0);//鼠标滚动
        }

    }
}
