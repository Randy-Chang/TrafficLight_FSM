using System.Diagnostics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
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

        private void btnPause_Click(object sender, EventArgs e)
        {
            trafficLight.Pause();
        }
    }

    enum ETrafficLightState { Idle, Red, Green, Yellow }

    class TrafficLight
    {
        PictureBox pbRed, pbYellow, pbGreen;
        Label lbTime;

        ETrafficLightState stateNow;
        ETrafficLightState stateSave;
        Stopwatch stopwatch;
        Thread thread;
        ManualResetEvent mre;
        bool IsFirst = true;

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

            // ManualResetEvent 可以在初始化時設定為 true 或 false，分別代表已被觸發或尚未觸發的狀態。
            mre = new ManualResetEvent(false);
            // 將 ManualResetEvent 重置為未觸發狀態，使後續的線程再次被阻塞。
            mre.Reset();
        }

        public void Start()
        {
            if(IsFirst)
                SetState(ETrafficLightState.Red);

            //觸發 ManualResetEvent，讓所有等待的線程繼續執行。
            mre.Set();
        }

        public void Stop()
        {
            // 將 ManualResetEvent 重置為未觸發狀態，使後續的線程再次被阻塞。
            mre.Reset();

            SetState(ETrafficLightState.Red);
            IsFirst = true;
        }

        public void SetState(ETrafficLightState state)
        {
            stateNow = state;
            stateSave = state;
        }

        public void Pause()
        {
            // 將 ManualResetEvent 重置為未觸發狀態，使後續的線程再次被阻塞。
            mre.Reset();
            stateNow = stateSave;
        }

        void Run()
        {
            while (true)
            {
                Thread.Sleep(20); // 避免過度佔用 CPU

                mre.WaitOne(); // 等待 Start()中 mre.Set() 的信號


                int timeNow = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                string text = $"Timer : {timeNow}";
                AsyncSetText(lbTime, text); // 更新碼表stopwatch

                switch (stateNow)
                {
                    case ETrafficLightState.Red:
                        {
                            if (IsFirst == true || timeNow >= 5)
                            {
                                pbRed.BackColor = Color.Red;
                                pbGreen.BackColor = Color.Black;
                                pbYellow.BackColor = Color.Black;

                                stopwatch.Restart();
                                SetState(ETrafficLightState.Green);
                                IsFirst = false;
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
                                SetState(ETrafficLightState.Yellow);
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
                                SetState(ETrafficLightState.Red);
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
                // 檢查是否需要透過 Invoke 回到 UI 執行緒
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
