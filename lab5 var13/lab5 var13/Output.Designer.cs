namespace lab5_var13
{
    partial class Output
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
            this.X0 = new System.Windows.Forms.Label();
            this.Y0 = new System.Windows.Forms.Label();
            this.textBoxX0 = new System.Windows.Forms.TextBox();
            this.textBoxY0 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // X0
            // 
            this.X0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.X0.AutoSize = true;
            this.X0.Location = new System.Drawing.Point(33, 32);
            this.X0.Name = "X0";
            this.X0.Size = new System.Drawing.Size(193, 17);
            this.X0.TabIndex = 0;
            this.X0.Text = "X0 в новій системі кординат";
            // 
            // Y0
            // 
            this.Y0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Y0.AutoSize = true;
            this.Y0.Location = new System.Drawing.Point(33, 73);
            this.Y0.Name = "Y0";
            this.Y0.Size = new System.Drawing.Size(193, 17);
            this.Y0.TabIndex = 1;
            this.Y0.Text = "Y0 в новій системі кординат";
            // 
            // textBoxX0
            // 
            this.textBoxX0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxX0.Location = new System.Drawing.Point(262, 32);
            this.textBoxX0.Name = "textBoxX0";
            this.textBoxX0.Size = new System.Drawing.Size(65, 22);
            this.textBoxX0.TabIndex = 2;
            // 
            // textBoxY0
            // 
            this.textBoxY0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxY0.Location = new System.Drawing.Point(262, 68);
            this.textBoxY0.Name = "textBoxY0";
            this.textBoxY0.Size = new System.Drawing.Size(65, 22);
            this.textBoxY0.TabIndex = 3;
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 134);
            this.Controls.Add(this.textBoxY0);
            this.Controls.Add(this.textBoxX0);
            this.Controls.Add(this.Y0);
            this.Controls.Add(this.X0);
            this.Name = "Output";
            this.Text = "Output";
            this.Load += new System.EventHandler(this.Output_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label X0;
        private System.Windows.Forms.Label Y0;
        public System.Windows.Forms.TextBox textBoxX0;
        public System.Windows.Forms.TextBox textBoxY0;
    }
}