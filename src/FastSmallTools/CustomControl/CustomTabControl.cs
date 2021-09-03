/**自定义控件
 * https://www.cnblogs.com/YYkun/p/9199773.html
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FastSmallTools.CustomControl
{
    public partial class CustomTabControl : TabControl
    {

        private Image closeIcon = null;
        private Image addIcon = null;


        public CustomTabControl() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            closeIcon = Properties.Resources.close;
            addIcon = Properties.Resources.add;

            //Console.WriteLine(icon.Size.ToString());
            //IconWOrH = icon.Width;
            //IconWOrH = icon.Height;
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            Rectangle rect = GetTabRect(this.Controls.Count-1);
            rect.Offset(rect.Width - rect.Height, 0);
            rect.Width = rect.Height;
        
        }

        private Rectangle GetCloseRect(int index)
        {
            Rectangle rect = GetTabRect(index);
            rect.Offset(rect.Width - rect.Height, 0);
            rect.Width = rect.Height;

            return rect;
        }

        private Rectangle GetAddRect()
        {
            Rectangle rect = GetTabRect(this.Controls.Count - 1);
            rect.Offset(rect.Width - rect.Height, 0);
            rect.Width = rect.Height;
            Rectangle addRect = new Rectangle(rect.X + rect.Width, rect.Y, rect.Width, rect.Height);
            return addRect;
        }

        

        

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle tabRect = GetTabRect(e.Index);
            Rectangle closeRect = GetCloseRect(e.Index);

            Brush color = Brushes.AliceBlue; //非选中项的背景色
            if (e.Index == this.SelectedIndex)    //当前选中的Tab页，设置不同的样式以示选中
            {
                color = Brushes.SteelBlue; //选中项的背景色
            }

            g.FillRectangle(color, tabRect); //改变选项卡标签的背景色
            string title = this.TabPages[e.Index].Text;
            g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(tabRect.X, tabRect.Y + 5));//PointF选项卡标题的位置
            g.DrawImage(closeIcon, closeRect, 0, 0, closeIcon.Width, closeIcon.Height, GraphicsUnit.Pixel);

            if(e.Index == this.Controls.Count - 1)
            {
                // 绘制增加按钮
                Brush addColor = Brushes.Blue;
                Rectangle addRect = GetAddRect();
                //g.FillRectangle(addColor, addRect);
                g.DrawImage(addIcon, addRect, 0, 0, addIcon.Width, addIcon.Height, GraphicsUnit.Pixel);
            }


        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point point = e.Location;
            Rectangle rect = GetCloseRect(this.SelectedIndex);
            if (rect.Contains(point))
            {
                this.TabPages.RemoveAt(this.SelectedIndex);
            }

            Rectangle addRect = GetAddRect();
            if (addRect.Contains(point))
            {
                this.Cursor = Cursors.Hand;
                return;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point point = e.Location;
            this.Cursor = Cursors.Default;
            Rectangle addRect = GetAddRect();
            if (addRect.Contains(point))
            {
                this.Cursor = Cursors.Hand;
                return;
            }

            for (int i= 0; i<this.Controls.Count; i++)
            {
                Rectangle rect = GetCloseRect(i);
                if (rect.Contains(point))
                {
                    this.Cursor = Cursors.Hand;
                    break;
                }
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
        }

    }

}
