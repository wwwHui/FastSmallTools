
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.pictureBoxOption = new System.Windows.Forms.PictureBox();
            this.tabControlPicture = new System.Windows.Forms.TabControl();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonAdd);
            this.panelMenu.Controls.Add(this.pictureBoxOption);
            this.panelMenu.Location = new System.Drawing.Point(1, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(799, 79);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonAdd.BackgroundImage = global::FastSmallTools.Properties.Resources.add;
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAdd.Location = new System.Drawing.Point(738, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(45, 45);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Tag = "新增截图";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAdd_MouseDown);
            // 
            // pictureBoxOption
            // 
            this.pictureBoxOption.Location = new System.Drawing.Point(0, 32);
            this.pictureBoxOption.Name = "pictureBoxOption";
            this.pictureBoxOption.Size = new System.Drawing.Size(732, 47);
            this.pictureBoxOption.TabIndex = 0;
            this.pictureBoxOption.TabStop = false;
            // 
            // tabControlPicture
            // 
            this.tabControlPicture.Location = new System.Drawing.Point(1, 85);
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
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBoxOption;
        private System.Windows.Forms.TabControl tabControlPicture;
        private System.Windows.Forms.Button buttonAdd;
    }
}