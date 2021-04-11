using System.Drawing;

namespace FastSmallTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonActiveWindow = new System.Windows.Forms.Button();
            this.buttonObjectWindow = new System.Windows.Forms.Button();
            this.buttonRectangeArea = new System.Windows.Forms.Button();
            this.buttonHandArea = new System.Windows.Forms.Button();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonRollScreen = new System.Windows.Forms.Button();
            this.buttonFixedRectange = new System.Windows.Forms.Button();
            this.buttonVideo = new System.Windows.Forms.Button();
            this.buttonOutput = new System.Windows.Forms.Button();
            this.buttonSetting = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonIcon = new System.Windows.Forms.Button();
            this.buttonMini = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelFunction = new System.Windows.Forms.Panel();
            this.buttonText = new System.Windows.Forms.Button();
            this.panelFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonOpenFile.BackgroundImage = global::FastSmallTools.Properties.Resources.open;
            this.buttonOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonOpenFile.FlatAppearance.BorderSize = 0;
            this.buttonOpenFile.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenFile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenFile.Location = new System.Drawing.Point(5, 2);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(30, 30);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Tag = "打开文件";
            this.buttonOpenFile.UseVisualStyleBackColor = false;
            this.buttonOpenFile.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOpenFile_MouseDown);
            // 
            // buttonActiveWindow
            // 
            this.buttonActiveWindow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonActiveWindow.BackgroundImage = global::FastSmallTools.Properties.Resources.activeWindow;
            this.buttonActiveWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonActiveWindow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonActiveWindow.FlatAppearance.BorderSize = 0;
            this.buttonActiveWindow.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonActiveWindow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonActiveWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiveWindow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonActiveWindow.Location = new System.Drawing.Point(35, 2);
            this.buttonActiveWindow.Name = "buttonActiveWindow";
            this.buttonActiveWindow.Size = new System.Drawing.Size(30, 30);
            this.buttonActiveWindow.TabIndex = 0;
            this.buttonActiveWindow.Tag = "捕捉活动窗口";
            this.buttonActiveWindow.UseVisualStyleBackColor = false;
            this.buttonActiveWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonActiveWindow_MouseDown);
            // 
            // buttonObjectWindow
            // 
            this.buttonObjectWindow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonObjectWindow.BackgroundImage = global::FastSmallTools.Properties.Resources.objectWindow;
            this.buttonObjectWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonObjectWindow.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonObjectWindow.FlatAppearance.BorderSize = 0;
            this.buttonObjectWindow.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonObjectWindow.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonObjectWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonObjectWindow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonObjectWindow.Location = new System.Drawing.Point(65, 2);
            this.buttonObjectWindow.Name = "buttonObjectWindow";
            this.buttonObjectWindow.Size = new System.Drawing.Size(30, 30);
            this.buttonObjectWindow.TabIndex = 0;
            this.buttonObjectWindow.Tag = "捕捉窗口/对象";
            this.buttonObjectWindow.UseVisualStyleBackColor = false;
            this.buttonObjectWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonObjectWindow_MouseDown);
            // 
            // buttonRectangeArea
            // 
            this.buttonRectangeArea.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonRectangeArea.BackgroundImage = global::FastSmallTools.Properties.Resources.rect;
            this.buttonRectangeArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRectangeArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRectangeArea.FlatAppearance.BorderSize = 0;
            this.buttonRectangeArea.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRectangeArea.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRectangeArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRectangeArea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRectangeArea.Location = new System.Drawing.Point(95, 2);
            this.buttonRectangeArea.Name = "buttonRectangeArea";
            this.buttonRectangeArea.Size = new System.Drawing.Size(30, 30);
            this.buttonRectangeArea.TabIndex = 0;
            this.buttonRectangeArea.Tag = "捕捉矩形区域";
            this.buttonRectangeArea.UseVisualStyleBackColor = false;
            this.buttonRectangeArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRectangeArea_MouseDown);
            // 
            // buttonHandArea
            // 
            this.buttonHandArea.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonHandArea.BackgroundImage = global::FastSmallTools.Properties.Resources.handArea;
            this.buttonHandArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonHandArea.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonHandArea.FlatAppearance.BorderSize = 0;
            this.buttonHandArea.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonHandArea.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonHandArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHandArea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonHandArea.Location = new System.Drawing.Point(125, 2);
            this.buttonHandArea.Name = "buttonHandArea";
            this.buttonHandArea.Size = new System.Drawing.Size(30, 30);
            this.buttonHandArea.TabIndex = 0;
            this.buttonHandArea.Tag = "捕捉手绘区域";
            this.buttonHandArea.UseVisualStyleBackColor = false;
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFullScreen.BackgroundImage = global::FastSmallTools.Properties.Resources.full;
            this.buttonFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFullScreen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonFullScreen.FlatAppearance.BorderSize = 0;
            this.buttonFullScreen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFullScreen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullScreen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonFullScreen.Location = new System.Drawing.Point(155, 2);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(30, 30);
            this.buttonFullScreen.TabIndex = 0;
            this.buttonFullScreen.Tag = "捕捉整个屏幕";
            this.buttonFullScreen.UseVisualStyleBackColor = false;
            this.buttonFullScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonFullScreen_MouseDown);
            // 
            // buttonRollScreen
            // 
            this.buttonRollScreen.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonRollScreen.BackgroundImage = global::FastSmallTools.Properties.Resources.roll;
            this.buttonRollScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRollScreen.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRollScreen.FlatAppearance.BorderSize = 0;
            this.buttonRollScreen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRollScreen.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRollScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRollScreen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRollScreen.Location = new System.Drawing.Point(185, 2);
            this.buttonRollScreen.Name = "buttonRollScreen";
            this.buttonRollScreen.Size = new System.Drawing.Size(30, 30);
            this.buttonRollScreen.TabIndex = 0;
            this.buttonRollScreen.Tag = "捕捉滚动屏幕";
            this.buttonRollScreen.UseVisualStyleBackColor = false;
            this.buttonRollScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRollScreen_MouseDown);
            // 
            // buttonFixedRectange
            // 
            this.buttonFixedRectange.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonFixedRectange.BackgroundImage = global::FastSmallTools.Properties.Resources.fixedRect;
            this.buttonFixedRectange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonFixedRectange.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonFixedRectange.FlatAppearance.BorderSize = 0;
            this.buttonFixedRectange.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFixedRectange.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFixedRectange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFixedRectange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonFixedRectange.Location = new System.Drawing.Point(215, 2);
            this.buttonFixedRectange.Name = "buttonFixedRectange";
            this.buttonFixedRectange.Size = new System.Drawing.Size(30, 30);
            this.buttonFixedRectange.TabIndex = 0;
            this.buttonFixedRectange.Tag = "捕捉固定区域";
            this.buttonFixedRectange.UseVisualStyleBackColor = false;
            // 
            // buttonVideo
            // 
            this.buttonVideo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonVideo.BackgroundImage = global::FastSmallTools.Properties.Resources.video;
            this.buttonVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonVideo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonVideo.FlatAppearance.BorderSize = 0;
            this.buttonVideo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonVideo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVideo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonVideo.Location = new System.Drawing.Point(245, 2);
            this.buttonVideo.Name = "buttonVideo";
            this.buttonVideo.Size = new System.Drawing.Size(30, 30);
            this.buttonVideo.TabIndex = 0;
            this.buttonVideo.Tag = "录屏";
            this.buttonVideo.UseVisualStyleBackColor = false;
            // 
            // buttonOutput
            // 
            this.buttonOutput.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonOutput.BackgroundImage = global::FastSmallTools.Properties.Resources.edit;
            this.buttonOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOutput.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonOutput.FlatAppearance.BorderSize = 0;
            this.buttonOutput.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOutput.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOutput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOutput.Location = new System.Drawing.Point(275, 2);
            this.buttonOutput.Name = "buttonOutput";
            this.buttonOutput.Size = new System.Drawing.Size(30, 30);
            this.buttonOutput.TabIndex = 0;
            this.buttonOutput.Tag = "输出";
            this.buttonOutput.UseVisualStyleBackColor = false;
            // 
            // buttonSetting
            // 
            this.buttonSetting.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonSetting.BackgroundImage = global::FastSmallTools.Properties.Resources.setting;
            this.buttonSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSetting.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSetting.FlatAppearance.BorderSize = 0;
            this.buttonSetting.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSetting.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetting.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSetting.Location = new System.Drawing.Point(305, 2);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(30, 30);
            this.buttonSetting.TabIndex = 0;
            this.buttonSetting.Tag = "设置";
            this.buttonSetting.UseVisualStyleBackColor = false;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = global::FastSmallTools.Properties.Resources.icon;
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            // 
            // buttonIcon
            // 
            this.buttonIcon.BackColor = System.Drawing.SystemColors.Control;
            this.buttonIcon.BackgroundImage = global::FastSmallTools.Properties.Resources.tool;
            this.buttonIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonIcon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonIcon.FlatAppearance.BorderSize = 0;
            this.buttonIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIcon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonIcon.Location = new System.Drawing.Point(0, 0);
            this.buttonIcon.Name = "buttonIcon";
            this.buttonIcon.Size = new System.Drawing.Size(20, 20);
            this.buttonIcon.TabIndex = 1;
            this.buttonIcon.UseVisualStyleBackColor = false;
            // 
            // buttonMini
            // 
            this.buttonMini.BackColor = System.Drawing.SystemColors.Control;
            this.buttonMini.BackgroundImage = global::FastSmallTools.Properties.Resources.mini;
            this.buttonMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMini.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMini.FlatAppearance.BorderSize = 0;
            this.buttonMini.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GrayText;
            this.buttonMini.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GrayText;
            this.buttonMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMini.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMini.Location = new System.Drawing.Point(295, 0);
            this.buttonMini.Name = "buttonMini";
            this.buttonMini.Size = new System.Drawing.Size(20, 20);
            this.buttonMini.TabIndex = 3;
            this.buttonMini.Tag = "最小化";
            this.buttonMini.UseVisualStyleBackColor = false;
            this.buttonMini.Click += new System.EventHandler(this.buttonMini_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClose.BackgroundImage = global::FastSmallTools.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonClose.Location = new System.Drawing.Point(320, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(20, 20);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Tag = "退出";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelFunction
            // 
            this.panelFunction.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelFunction.Controls.Add(this.buttonOpenFile);
            this.panelFunction.Controls.Add(this.buttonActiveWindow);
            this.panelFunction.Controls.Add(this.buttonObjectWindow);
            this.panelFunction.Controls.Add(this.buttonRectangeArea);
            this.panelFunction.Controls.Add(this.buttonHandArea);
            this.panelFunction.Controls.Add(this.buttonFullScreen);
            this.panelFunction.Controls.Add(this.buttonRollScreen);
            this.panelFunction.Controls.Add(this.buttonFixedRectange);
            this.panelFunction.Controls.Add(this.buttonVideo);
            this.panelFunction.Controls.Add(this.buttonOutput);
            this.panelFunction.Controls.Add(this.buttonSetting);
            this.panelFunction.Location = new System.Drawing.Point(0, 23);
            this.panelFunction.Name = "panelFunction";
            this.panelFunction.Size = new System.Drawing.Size(340, 35);
            this.panelFunction.TabIndex = 5;
            // 
            // buttonText
            // 
            this.buttonText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonText.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonText.FlatAppearance.BorderSize = 0;
            this.buttonText.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonText.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonText.Font = new System.Drawing.Font("宋体", 10F);
            this.buttonText.Location = new System.Drawing.Point(25, 0);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(255, 22);
            this.buttonText.TabIndex = 2;
            this.buttonText.Text = "FastSmallTool";
            this.buttonText.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.buttonText.UseVisualStyleBackColor = true;
            this.buttonText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonText_MouseDown);
            this.buttonText.MouseEnter += new System.EventHandler(this.buttonText_MouseEnter);
            this.buttonText.MouseLeave += new System.EventHandler(this.buttonText_MouseLeave);
            this.buttonText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonText_MouseMove);
            this.buttonText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonText_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(340, 59);
            this.Controls.Add(this.panelFunction);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonMini);
            this.Controls.Add(this.buttonText);
            this.Controls.Add(this.buttonIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 59);
            this.MinimumSize = new System.Drawing.Size(340, 59);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FastSmallTool";
            this.panelFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonActiveWindow;
        private System.Windows.Forms.Button buttonObjectWindow;
        private System.Windows.Forms.Button buttonRectangeArea;
        private System.Windows.Forms.Button buttonHandArea;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonRollScreen;
        private System.Windows.Forms.Button buttonFixedRectange;
        private System.Windows.Forms.Button buttonVideo;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.Button buttonSetting;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button buttonIcon;
        private System.Windows.Forms.Button buttonMini;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelFunction;
        private System.Windows.Forms.Button buttonText;
    }
}

