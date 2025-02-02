using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using ToolFunctions_ByLuke;

namespace TrafficLight_FSM
{
    delegate void SetTextCallback(Control ctr, string text);

    public partial class Mainform : Form, ITrafficLightUIPack, ITrafficLightUIController
    {
        // readonly�׹��A�T�O���i���s���
        private readonly ITrafficLight pack;

        public Mainform(ITrafficLight pack)
        {
            InitializeComponent();
            this.pack = pack ?? throw new ArgumentNullException(nameof(pack));

            // �j�w���s�I���ƥ�A�� Lambda ��F��
            btnStart.Click += (s, e) => pack.Start();
            btnPause.Click += (s, e) => pack.Pause();
            btnStop.Click += (s, e) => pack.Stop();
        }

        #region ��@ ITrafficLightUIPack ����
        public PictureBox RedLight => pbRed;
        public PictureBox YellowLight => pbYellow;
        public PictureBox GreenLight => pbGreen;
        public Button Start => btnStart;
        public Button Stop => btnStop;
        public Button Pause => btnPause;
        #endregion

        #region ��@ ITrafficLightUIController ����
        public void ShowRedLight()
        {
            pbRed.BackColor = Color.Red;
            pbYellow.BackColor = Color.Gray;
            pbGreen.BackColor = Color.Gray;
        }

        public void ShowYellowLight()
        {
            pbRed.BackColor = Color.Gray;
            pbYellow.BackColor = Color.Yellow;
            pbGreen.BackColor = Color.Gray;
        }

        public void ShowGreenLight()
        {
            pbRed.BackColor = Color.Gray;
            pbYellow.BackColor = Color.Gray;
            pbGreen.BackColor = Color.Green;
        }

        public void EnableStartButton(bool enable)
        {
            btnStart.Enabled = enable;
        }

        public void EnablePauseButton(bool enable)
        {
            btnPause.Enabled = enable;
        }

        public void EnableStopButton(bool enable)
        {
            btnStop.Enabled = enable;
        }

        public void ShowTimerState(string timeState)
        {
            ToolFunctions.AsyncSetText(lbTimeNow, timeState);
        }
    }

    #endregion
}
