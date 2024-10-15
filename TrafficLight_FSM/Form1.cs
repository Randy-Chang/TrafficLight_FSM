using System.Diagnostics;
using System.Threading;

namespace TrafficLight_FSM
{
    public partial class Form1 : Form
    {
        TrafficLight trafficLight;
        

        public Form1()
        {
            InitializeComponent();

            trafficLight = new TrafficLight(pbRed, pbYellow, pbGreen);

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
        ETrafficLightState stateNow;
        PictureBox pbRed, pbYellow, pbGreen;
        Stopwatch stopwatch;
        Thread thread;
        ManualResetEvent mre;
        bool IsFirst = false;

        public TrafficLight(PictureBox pbRed, PictureBox pbYellow, PictureBox pbGreen)
        {
            this.pbRed = pbRed;
            this.pbYellow = pbYellow;
            this.pbGreen = pbGreen;

            stateNow = ETrafficLightState.Idle;

            stopwatch = new Stopwatch();
            stopwatch.Start();

            thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();

            // ManualResetEvent 可以在初始化時設定為 true 或 false，分別代表已被觸發或尚未觸發的狀態。
            mre = new ManualResetEvent(false);
            // 將 ManualResetEvent 重置為未觸發狀態，使後續的線程再次被阻塞。
            mre.Reset();
        }

        public void Start()
        {
            stateNow = ETrafficLightState.Red;
            IsFirst = true;

            //觸發 ManualResetEvent，讓所有等待的線程繼續執行。
            mre.Set();
        }

        public void Stop()
        {
            // 將 ManualResetEvent 重置為未觸發狀態，使後續的線程再次被阻塞。
            mre.Reset();
        }

        void Run()
        {
            while (true)
            {
                mre.WaitOne();

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
                            else if (stopwatch.Elapsed.TotalSeconds >= 2)
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
                            if (stopwatch.Elapsed.TotalSeconds >= 2)
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
                            if (stopwatch.Elapsed.TotalSeconds >= 2)
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
    }
}
