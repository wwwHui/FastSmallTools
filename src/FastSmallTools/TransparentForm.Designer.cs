namespace FastSmallTools
{
    partial class TransparentForm
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
            this.SuspendLayout();
            // 
            // TransparentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "TransparentForm";
            this.Text = "TransparentForm";
            this.Deactivate += new System.EventHandler(this.TransparentForm_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TransparentForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TransparentForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}