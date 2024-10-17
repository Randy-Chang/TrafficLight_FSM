using System.Diagnostics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace TrafficLight_FSM
{
    delegate void SetTextCallback(Control ctr, string text);

    public partial class Form1 : Form
    {
        TrafficLight trafficLight;
        public Form1()
        {
            InitializeComponent();

            trafficLight = new TrafficLight(pbRed, pbYellow, pbGreen, lbTimeNow);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            trafficLight.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            trafficLight.Stop();
        }

    }

    enum ETrafficLightState { Idle, Red, Green, Yellow }


    class TrafficLight
    {
        PictureBox pbRed, pbYellow, pbGreen;
        Label lbTime;

        ETrafficLightState stateNow;
        Stopwatch stopwatch;
        Thread thread;
        ManualResetEvent mre;
        bool IsFirst = false;

        public TrafficLight(PictureBox pbRed, PictureBox pbYellow, PictureBox pbGreen, Label lbTime)
        {
            this.pbRed = pbRed;
            this.pbYellow = pbYellow;
            this.pbGreen = pbGreen;
            this.lbTime = lbTime;

            stateNow = ETrafficLightState.Idle;

            stopwatch = new Stopwatch();
            stopwatch.Start();

            thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();

            // ManualResetEvent �i�H�b��l�Ʈɳ]�w�� true �� false�A���O�N��w�QĲ�o�Ω|��Ĳ�o�����A�C
            mre = new ManualResetEvent(false);
            // �N ManualResetEvent ���m����Ĳ�o���A�A�ϫ��򪺽u�{�A���Q����C
            mre.Reset();
        }

        public void Start()
        {
            stateNow = ETrafficLightState.Red;
            IsFirst = true;

            //Ĳ�o ManualResetEvent�A���Ҧ����ݪ��u�{�~�����C
            mre.Set();
        }

        public void Stop()
        {
            // �N ManualResetEvent ���m����Ĳ�o���A�A�ϫ��򪺽u�{�A���Q����C
            mre.Reset();
        }

        void Run()
        {
            while (true)
            {
                Thread.Sleep(20); // �קK�L�צ��� CPU

                mre.WaitOne(); // ���� Start()�� mre.Set() ���H��


                int timeNow = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                string text = $"Timer : {timeNow}";
                AsyncSetText(lbTime, text); // ��s�X��stopwatch

                switch (stateNow)
                {
                    case ETrafficLightState.Red:
                        {
                            if (IsFirst)
                            {
                                pbRed.BackColor = Color.Red;
                                pbGreen.BackColor = Color.Black;
                                pbYellow.BackColor = Color.Black;

                                stopwatch.Restart();
                                stateNow = ETrafficLightState.Green;

                                IsFirst = false;
                            }
                            else if (timeNow >= 5)
                            {
                                pbRed.BackColor = Color.Red;
                                pbGreen.BackColor = Color.Black;
                                pbYellow.BackColor = Color.Black;

                                stopwatch.Restart();
                                stateNow = ETrafficLightState.Green;
                            }
                        }
                        break;

                    case ETrafficLightState.Green:
                        {
                            if (timeNow >= 5)
                            {
                                pbRed.BackColor = Color.Black;
                                pbGreen.BackColor = Color.Green;
                                pbYellow.BackColor = Color.Black;

                                stopwatch.Restart();
                                stateNow = ETrafficLightState.Yellow;
                            }
                        }
                        break;

                    case ETrafficLightState.Yellow:
                        {
                            if (timeNow >= 5)
                            {
                                pbRed.BackColor = Color.Black;
                                pbGreen.BackColor = Color.Black;
                                pbYellow.BackColor = Color.Yellow;

                                stopwatch.Restart();
                                stateNow = ETrafficLightState.Red;
                            }
                        }
                        break;
                }

            }

        }

        void AsyncSetText(Control cntr, string text)
        {
            try
            {
                // �ˬd�O�_�ݭn�z�L Invoke �^�� UI �����
                if (cntr.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AsyncSetText);
                    cntr.BeginInvoke(d, new object[] { cntr, text });
                }
                else
                    cntr.Text = text;
            }
            catch (Exception e)
            {
                //WriteLog(DateTime.Now.ToLongTimeString() + " : " + cntr.Name + " , AsyncSetColor " + e.Message);
            }
        }
    }
}
