/**自定义控件
 * https://www.cnblogs.com/YYkun/p/9199773.html
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastSmallTools.CustomControl
{
    public partial class CustomTabControl : TabControl
    {
        //public CustomTabControl()
        //{
        //    InitializeComponent();
        //}

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private int IconWOrH = 16;
        private Image icon = null;

        public CustomTabControl() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            icon = Properties.Resources.close;
            
            //Console.WriteLine(icon.Size.ToString());
            //IconWOrH = icon.Width;
            //IconWOrH = icon.Height;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = GetTabRect(e.Index);
            //Console.WriteLine(r.Size.ToString());
            if (e.Index == this.SelectedIndex)    //当前选中的Tab页，设置不同的样式以示选中
            {
                Brush selected_color = Brushes.SteelBlue; //选中的项的背景色
                g.FillRectangle(selected_color, r); //改变选项卡标签的背景色
                string title = this.TabPages[e.Index].Text;
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X, r.Y + 5));//PointF选项卡标题的位置
                r.Offset(r.Width - IconWOrH, 2);
                //g.DrawImage(icon, new Point(r.X, r.Y));//选项卡上的图标的位置 fntTab = new System.Drawing.Font(e.Font, FontStyle.Bold);
                g.DrawImage(icon, new Rectangle(r.X, r.Y, r.Height, r.Height), 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel);
            }
            else//非选中的
            {
                Brush selected_color = Brushes.AliceBlue; //选中的项的背景色
                g.FillRectangle(selected_color, r); //改变选项卡标签的背景色
                string title = this.TabPages[e.Index].Text + "  ";
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X, r.Y + 5));//PointF选项卡标题的位置
                r.Offset(r.Width - IconWOrH, 2);
                //g.DrawImage(icon, new Point(r.X, r.Y));//选项卡上的图标的位置
                g.DrawImage(icon, new Rectangle(r.X, r.Y, r.Height, r.Height), 0, 0, icon.Width, icon.Height, GraphicsUnit.Pixel);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point point = e.Location;
            Rectangle r = GetTabRect(this.SelectedIndex);
            r.Offset(r.Width - IconWOrH - 3, 2);
            r.Width = IconWOrH;
            r.Height = IconWOrH;
            if (r.Contains(point)) this.TabPages.RemoveAt(this.SelectedIndex);
        }
    }

}
