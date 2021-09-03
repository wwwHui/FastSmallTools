
namespace FastSmallTools.ImageEdit
{
    partial class ImageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBoxOption = new System.Windows.Forms.PictureBox();
            this.tabControlPicture = new FastSmallTools.CustomControl.CustomTabControl();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.pictureBoxOption);
            this.panelMenu.Location = new System.Drawing.Point(1, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(799, 80);
            this.panelMenu.TabIndex = 0;
            // 
            // pictureBoxOption
            // 
            this.pictureBoxOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxOption.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBoxOption.Location = new System.Drawing.Point(0, 32);
            this.pictureBoxOption.Name = "pictureBoxOption";
            this.pictureBoxOption.Size = new System.Drawing.Size(798, 47);
            this.pictureBoxOption.TabIndex = 0;
            this.pictureBoxOption.TabStop = false;
            // 
            // tabControlPicture
            // 
            this.tabControlPicture.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabControlPicture.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlPicture.Location = new System.Drawing.Point(0, 85);
            this.tabControlPicture.Name = "tabControlPicture";
            this.tabControlPicture.SelectedIndex = 0;
            this.tabControlPicture.Size = new System.Drawing.Size(799, 364);
            this.tabControlPicture.TabIndex = 1;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlPicture);
            this.Controls.Add(this.panelMenu);
            this.Name = "ImageForm";
            this.Text = "图片编辑器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ImageForm_FormClosed);
            this.Resize += new System.EventHandler(this.ImageForm_Resize);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBoxOption;
        private FastSmallTools.CustomControl.CustomTabControl tabControlPicture;
    }
}