
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
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBoxOption = new System.Windows.Forms.PictureBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.pictureBoxOption);
            this.panelMenu.Location = new System.Drawing.Point(1, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(799, 79);
            this.panelMenu.TabIndex = 0;
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBoxImage);
            this.panelImage.Location = new System.Drawing.Point(1, 85);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(799, 363);
            this.panelImage.TabIndex = 1;
            // 
            // pictureBoxOption
            // 
            this.pictureBoxOption.Location = new System.Drawing.Point(3, 49);
            this.pictureBoxOption.Name = "pictureBoxOption";
            this.pictureBoxOption.Size = new System.Drawing.Size(655, 30);
            this.pictureBoxOption.TabIndex = 0;
            this.pictureBoxOption.TabStop = false;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(799, 360);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelImage);
            this.Controls.Add(this.panelMenu);
            this.Name = "ImageForm";
            this.Text = "图片编辑器";
            this.panelMenu.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBoxOption;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}