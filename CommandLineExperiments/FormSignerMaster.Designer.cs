namespace CommandLineExperiments
{
    partial class FormSignerMaster
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
            this.btnSign = new System.Windows.Forms.Button();
            this.lblPin = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbPin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(173, 12);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 23);
            this.btnSign.TabIndex = 0;
            this.btnSign.Text = "firma";
            this.btnSign.UseVisualStyleBackColor = true;
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(13, 17);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(25, 13);
            this.lblPin.TabIndex = 1;
            this.lblPin.Text = "PIN";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 50);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(274, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbPin
            // 
            this.tbPin.Location = new System.Drawing.Point(55, 13);
            this.tbPin.Name = "tbPin";
            this.tbPin.Size = new System.Drawing.Size(100, 20);
            this.tbPin.TabIndex = 3;
            // 
            // FormSignerMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 72);
            this.Controls.Add(this.tbPin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.btnSign);
            this.Name = "FormSignerMaster";
            this.Text = "Firma Documento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox tbPin;
        protected internal System.Windows.Forms.Button btnSign;
    }
}

