namespace TrafficLight_FSM
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
            pbRed = new PictureBox();
            pbYellow = new PictureBox();
            pbGreen = new PictureBox();
            gbLight = new GroupBox();
            btnStart = new Button();
            btnStop = new Button();
            lbTimeNow = new Label();
            ((System.ComponentModel.ISupportInitialize)pbRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGreen).BeginInit();
            gbLight.SuspendLayout();
            SuspendLayout();
            // 
            // pbRed
            // 
            pbRed.BackColor = Color.Black;
            pbRed.Location = new Point(6, 31);
            pbRed.Name = "pbRed";
            pbRed.Size = new Size(80, 80);
            pbRed.TabIndex = 0;
            pbRed.TabStop = false;
            // 
            // pbYellow
            // 
            pbYellow.BackColor = Color.Black;
            pbYellow.Location = new Point(92, 31);
            pbYellow.Name = "pbYellow";
            pbYellow.Size = new Size(80, 80);
            pbYellow.TabIndex = 1;
            pbYellow.TabStop = false;
            // 
            // pbGreen
            // 
            pbGreen.BackColor = Color.Black;
            pbGreen.Location = new Point(178, 31);
            pbGreen.Name = "pbGreen";
            pbGreen.Size = new Size(80, 80);
            pbGreen.TabIndex = 2;
            pbGreen.TabStop = false;
            // 
            // gbLight
            // 
            gbLight.BackColor = Color.FromArgb(192, 255, 255);
            gbLight.Controls.Add(pbRed);
            gbLight.Controls.Add(pbGreen);
            gbLight.Controls.Add(pbYellow);
            gbLight.Location = new Point(12, 12);
            gbLight.Name = "gbLight";
            gbLight.Size = new Size(267, 121);
            gbLight.TabIndex = 3;
            gbLight.TabStop = false;
            gbLight.Text = "Light";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 188);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(124, 65);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(146, 188);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(124, 65);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lbTimeNow
            // 
            lbTimeNow.AutoSize = true;
            lbTimeNow.Location = new Point(12, 145);
            lbTimeNow.Name = "lbTimeNow";
            lbTimeNow.Size = new Size(94, 24);
            lbTimeNow.TabIndex = 6;
            lbTimeNow.Text = "Timer : --";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 384);
            Controls.Add(lbTimeNow);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(gbLight);
            Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGreen).EndInit();
            gbLight.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbRed;
        private PictureBox pbYellow;
        private PictureBox pbGreen;
        private GroupBox gbLight;
        private Button btnStart;
        private Button btnStop;
        private Label lbTimeNow;
    }
}
