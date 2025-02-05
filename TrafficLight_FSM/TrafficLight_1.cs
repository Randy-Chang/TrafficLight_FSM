using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight_FSM.Scopes;
using ToolFunctions_ByLuke;

namespace TrafficLight_FSM
{
    public enum EKey { Auto, Pause, Resume }
    public enum ES1 { Idle, Pause, Active }

    public partial class TrafficLight1 : ITrafficLight
    {
        ITrafficLightUIController uIController;
        ES1 S1 { get; set; }
        EKey key { get; set; }

        ETrafficLightState stateNow;
        ETrafficLightState stateSave;
        Stopwatch stopwatch;
        Thread thread;
        bool IsFirst = true;
        int redDuration = 5;
        int greenDuration = 5;
        int yellowDuration = 5;

        public TrafficLight1(ITrafficLightUIController uIController)
        {
            this.uIController = uIController;

            S1 = ES1.Idle;
            stateNow = ETrafficLightState.Red;

            stopwatch = new Stopwatch();

            thread = new Thread(RunFSM);
            thread.IsBackground = true;
            thread.Start();
        }

        public void SetDurations(int red, int green, int yellow)
        {
            redDuration = red > 0 ? red : 5;        // 預防錯誤輸入
            greenDuration = green > 0 ? green : 5;
            yellowDuration = yellow > 0 ? yellow : 5;
        }

        public void Start()
        {
            if (IsFirst)
                SetState(ES1.Active, ETrafficLightState.Red);
            else
                SetState(ES1.Active, stateSave);

            stopwatch.Start();
        }

        public void Stop()
        {
            SetState(ES1.Idle); // 讓 FSM 進入待機模式
            IsFirst = true;      // 確保下一次 Start() 會從紅燈開始
            stopwatch.Reset();
        }

        public void Pause()
        {
            SetState(ES1.Pause);
            stopwatch.Stop();
        }

        void SetState(ES1 s1, ETrafficLightState state = default)
        {
            S1 = s1;
            if (state != default)
            {
                stateNow = state;
                stateSave = state;
            }
        }

        void RunFSM()
        {
            while (true) // 讓執行緒永久運行
            {
                Thread.Sleep(20); // 避免過度佔用 CPU

                switch (S1)
                {
                    case ES1.Idle:
                        {
                            // 進入待機模式，不做任何事
                            uIController.ShowTimerState("Idle");
                        }
                        break;

                    case ES1.Pause:
                        {
                            uIController.ShowTimerState("Paused");
                        }
                        break;

                    case ES1.Active:
                        {
                            int timeNow = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                            string text = $"Timer : {timeNow}";
                            uIController.ShowTimerState(text);

                            switch (stateNow)
                            {
                                case ETrafficLightState.Red:
                                    {
                                        if (IsFirst)
                                        {
                                            stopwatch.Restart();
                                            IsFirst = false; // 設為 false，避免重複進入
                                        }
                                        else if (timeNow >= redDuration)
                                        {
                                            SetState(ES1.Active, ETrafficLightState.Green);
                                            stopwatch.Restart();
                                        }

                                        uIController.ShowRedLight();
                                    }
                                    break;

                                case ETrafficLightState.Green:
                                    {
                                        if (timeNow >= greenDuration)
                                        {
                                            SetState(ES1.Active, ETrafficLightState.Yellow);
                                            stopwatch.Restart();
                                        }

                                        uIController.ShowGreenLight();
                                    }
                                    break;

                                case ETrafficLightState.Yellow:
                                    {
                                        if (timeNow >= yellowDuration)
                                        {
                                            SetState(ES1.Active, ETrafficLightState.Red);
                                            stopwatch.Restart();
                                        }

                                        uIController.ShowYellowLight();
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

    }
}
