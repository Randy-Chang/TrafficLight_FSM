namespace TrafficLight_FSM
{
    partial class Mainform
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
            btnPause = new Button();
            gbSettingDuration = new GroupBox();
            label1 = new Label();
            tbRedLigtDuration = new TextBox();
            tbGreenLigtDuration = new TextBox();
            label2 = new Label();
            tbYellowLigtDuration = new TextBox();
            label3 = new Label();
            btnSettingDuration = new Button();
            ((System.ComponentModel.ISupportInitialize)pbRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbYellow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGreen).BeginInit();
            gbLight.SuspendLayout();
            gbSettingDuration.SuspendLayout();
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
            btnStart.Location = new Point(9, 186);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 65);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(101, 186);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(86, 65);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // lbTimeNow
            // 
            lbTimeNow.AutoSize = true;
            lbTimeNow.Location = new Point(9, 143);
            lbTimeNow.Name = "lbTimeNow";
            lbTimeNow.Size = new Size(94, 24);
            lbTimeNow.TabIndex = 6;
            lbTimeNow.Text = "Timer : --";
            // 
            // btnPause
            // 
            btnPause.Location = new Point(193, 186);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(86, 65);
            btnPause.TabIndex = 7;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // gbSettingDuration
            // 
            gbSettingDuration.BackColor = Color.FromArgb(255, 255, 192);
            gbSettingDuration.Controls.Add(btnSettingDuration);
            gbSettingDuration.Controls.Add(tbYellowLigtDuration);
            gbSettingDuration.Controls.Add(label3);
            gbSettingDuration.Controls.Add(tbGreenLigtDuration);
            gbSettingDuration.Controls.Add(label2);
            gbSettingDuration.Controls.Add(tbRedLigtDuration);
            gbSettingDuration.Controls.Add(label1);
            gbSettingDuration.Location = new Point(285, 12);
            gbSettingDuration.Name = "gbSettingDuration";
            gbSettingDuration.Size = new Size(289, 201);
            gbSettingDuration.TabIndex = 8;
            gbSettingDuration.TabStop = false;
            gbSettingDuration.Text = "Setting Duration";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 31);
            label1.Name = "label1";
            label1.Size = new Size(107, 24);
            label1.TabIndex = 7;
            label1.Text = "Red Light :";
            // 
            // tbRedLigtDuration
            // 
            tbRedLigtDuration.Location = new Point(152, 28);
            tbRedLigtDuration.Name = "tbRedLigtDuration";
            tbRedLigtDuration.Size = new Size(113, 32);
            tbRedLigtDuration.TabIndex = 8;
            // 
            // tbGreenLigtDuration
            // 
            tbGreenLigtDuration.Location = new Point(152, 66);
            tbGreenLigtDuration.Name = "tbGreenLigtDuration";
            tbGreenLigtDuration.Size = new Size(113, 32);
            tbGreenLigtDuration.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 69);
            label2.Name = "label2";
            label2.Size = new Size(127, 24);
            label2.TabIndex = 9;
            label2.Text = "Green Light :";
            // 
            // tbYellowLigtDuration
            // 
            tbYellowLigtDuration.Location = new Point(152, 104);
            tbYellowLigtDuration.Name = "tbYellowLigtDuration";
            tbYellowLigtDuration.Size = new Size(113, 32);
            tbYellowLigtDuration.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 107);
            label3.Name = "label3";
            label3.Size = new Size(131, 24);
            label3.TabIndex = 11;
            label3.Text = "Yellow Light :";
            // 
            // btnSettingDuration
            // 
            btnSettingDuration.Location = new Point(15, 142);
            btnSettingDuration.Name = "btnSettingDuration";
            btnSettingDuration.Size = new Size(250, 46);
            btnSettingDuration.TabIndex = 13;
            btnSettingDuration.Text = "Setting";
            btnSettingDuration.UseVisualStyleBackColor = true;
            // 
            // Mainform
            // 
            AutoScaleDimensions = new SizeF(12F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 271);
            Controls.Add(gbSettingDuration);
            Controls.Add(btnPause);
            Controls.Add(lbTimeNow);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(gbLight);
            Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 136);
            Margin = new Padding(5);
            Name = "Mainform";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbYellow).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGreen).EndInit();
            gbLight.ResumeLayout(false);
            gbSettingDuration.ResumeLayout(false);
            gbSettingDuration.PerformLayout();
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
        private Button btnPause;
        private GroupBox gbSettingDuration;
        private TextBox tbRedLigtDuration;
        private Label label1;
        private TextBox tbYellowLigtDuration;
        private Label label3;
        private TextBox tbGreenLigtDuration;
        private Label label2;
        private Button btnSettingDuration;
    }
}
