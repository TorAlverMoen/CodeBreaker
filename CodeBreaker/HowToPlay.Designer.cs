namespace CodeBreaker
{
    partial class HowToPlay
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
            this.howto_heading = new System.Windows.Forms.Label();
            this.howto_text = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // howto_heading
            // 
            this.howto_heading.AutoSize = true;
            this.howto_heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.howto_heading.Location = new System.Drawing.Point(12, 12);
            this.howto_heading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.howto_heading.Name = "howto_heading";
            this.howto_heading.Size = new System.Drawing.Size(113, 20);
            this.howto_heading.TabIndex = 0;
            this.howto_heading.Text = "howto heading";
            // 
            // howto_text
            // 
            this.howto_text.AutoSize = true;
            this.howto_text.Location = new System.Drawing.Point(12, 50);
            this.howto_text.Name = "howto_text";
            this.howto_text.Size = new System.Drawing.Size(71, 17);
            this.howto_text.TabIndex = 1;
            this.howto_text.Text = "howto text";
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_OK.Location = new System.Drawing.Point(372, 269);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 30);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // HowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CancelButton = this.btn_OK;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.howto_text);
            this.Controls.Add(this.howto_heading);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "HowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "How to play";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label howto_heading;
        private System.Windows.Forms.Label howto_text;
        private System.Windows.Forms.Button btn_OK;
    }
}