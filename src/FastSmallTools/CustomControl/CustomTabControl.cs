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
        private TabPage addTab = new TabPage();

        public delegate void AddButtonClickDelegate(object sender, EventArgs e);//建立委托
        public AddButtonClickDelegate AddButtonClick;

        public CustomTabControl() : base()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            closeIcon = Properties.Resources.close;
            addIcon = Properties.Resources.add;

            string name = "新增";
            addTab.Name = name;
            addTab.Text = name;
            this.Controls.Add(addTab);

        }


        private Rectangle GetCloseRect(int index)
        {
            Rectangle rect = GetTabRect(index);
            rect.Offset(rect.Width - rect.Height, 0);
            rect.Width = rect.Height;

            return rect;
        }

        private Rectangle GetMouseRect(int index)
        {
            if(index == 0)
            {
                return GetTabRect(0);
            }
            return GetCloseRect(index);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            Graphics g = e.Graphics;
            Rectangle tabRect = GetTabRect(e.Index);
            Rectangle closeRect = GetCloseRect(e.Index);

            Brush color = Brushes.AliceBlue; //非选中项的背景色

            if (e.Index == 0)  // 增加按钮
            {
                g.FillRectangle(color, tabRect); //改变选项卡标签的背景色
                string title = this.TabPages[e.Index].Text;
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(tabRect.X+2, tabRect.Y + 5));//PointF选项卡标题的位置
                g.DrawImage(addIcon, closeRect, 0, 0, addIcon.Width, addIcon.Height, GraphicsUnit.Pixel);

            }
            else
            {
                if (e.Index == this.SelectedIndex)    //当前选中的Tab页，设置不同的样式以示选中
                {
                    color = Brushes.SteelBlue; //选中项的背景色
                }
                g.FillRectangle(color, tabRect); //改变选项卡标签的背景色
                string title = this.TabPages[e.Index].Text;
                g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(tabRect.X+2, tabRect.Y + 5));//PointF选项卡标题的位置
                g.DrawImage(closeIcon, closeRect, 0, 0, closeIcon.Width, closeIcon.Height, GraphicsUnit.Pixel);
            }

        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point point = e.Location;
            Rectangle rect;

            if (this.SelectedIndex == 0)
            {
                rect = GetTabRect(0);
                if (rect.Contains(point))
                {
                    AddButtonClick(null, e);
                }
            }
            else
            {
                rect = GetCloseRect(this.SelectedIndex);
                if (rect.Contains(point))
                {
                    this.TabPages.RemoveAt(this.SelectedIndex);
                    if(this.SelectedIndex == this.TabCount)
                    {
                        this.SelectedIndex = this.TabCount - 1;
                    }
                }
            }


        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Point point = e.Location;
            this.Cursor = Cursors.Default;

            for (int i= 0; i<this.Controls.Count; i++)
            {
                Rectangle rect = GetMouseRect(i);
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
