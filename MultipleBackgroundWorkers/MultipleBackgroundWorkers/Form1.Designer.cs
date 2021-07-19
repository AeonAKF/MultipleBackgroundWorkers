
namespace MultipleBackgroundWorkers
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRun = new System.Windows.Forms.Button();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.prgMain = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.lblPrgMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(16, 324);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(133, 38);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run Async";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // pbLeft
            // 
            this.pbLeft.Location = new System.Drawing.Point(16, 18);
            this.pbLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(380, 264);
            this.pbLeft.TabIndex = 3;
            this.pbLeft.TabStop = false;
            // 
            // prgMain
            // 
            this.prgMain.Location = new System.Drawing.Point(16, 292);
            this.prgMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(768, 22);
            this.prgMain.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 324);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Canel Async";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(651, 324);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 38);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbRight
            // 
            this.pbRight.Location = new System.Drawing.Point(404, 18);
            this.pbRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(380, 264);
            this.pbRight.TabIndex = 8;
            this.pbRight.TabStop = false;
            // 
            // lblPrgMain
            // 
            this.lblPrgMain.AutoSize = true;
            this.lblPrgMain.Location = new System.Drawing.Point(404, 324);
            this.lblPrgMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrgMain.Name = "lblPrgMain";
            this.lblPrgMain.Size = new System.Drawing.Size(33, 20);
            this.lblPrgMain.TabIndex = 11;
            this.lblPrgMain.Text = "0 %";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 365);
            this.Controls.Add(this.lblPrgMain);
            this.Controls.Add(this.pbRight);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.prgMain);
            this.Controls.Add(this.pbLeft);
            this.Controls.Add(this.btnRun);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "3 x Background Worker Test";
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.ProgressBar prgMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.Label lblPrgMain;
    }
}

