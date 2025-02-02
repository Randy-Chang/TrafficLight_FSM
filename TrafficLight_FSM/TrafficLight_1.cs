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
    public enum ES1 { Idle, Pause, Actice }

    public partial class TrafficLight : ITrafficLight
    {
        ITrafficLightUIController uIController;
        ES1 S1 { get; set; }
        EKey key { get; set; }

        ETrafficLightState stateNow;
        ETrafficLightState stateSave;
        Stopwatch stopwatch;
        Thread thread;
        bool IsFirst = true;

        public TrafficLight(ITrafficLightUIController uIController)
        {
            this.uIController = uIController;

            S1 = ES1.Idle;
            stateNow = ETrafficLightState.Idle;

            stopwatch = new Stopwatch();

            thread = new Thread(RunFSM);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Start()
        {
            if (IsFirst)
                SetState(ES1.Actice, ETrafficLightState.Red);
            else
                SetState(ES1.Actice, stateSave);

            stopwatch.Start();
        }

        public void Stop()
        {
            SetState(ES1.Idle);
            IsFirst = true;
            stopwatch.Reset();
        }

        public void Pause()
        {
            SetState(ES1.Pause);
            stopwatch.Stop();
        }

        void SetState(ES1 s1)
        {
            this.S1 = s1;
        }

        void SetState(ES1 s1, ETrafficLightState state)
        {
            this.S1 = s1;
            this.stateNow = state;
            this.stateSave = state;
        }

        void SetState(ETrafficLightState state)
        {
            stateNow = state;
            stateSave = state;
        }

        void RunFSM()
        {
            while (true)
            {
                Thread.Sleep(20); // 避免過度佔用 CPU

                switch (S1)
                {
                    case ES1.Idle:
                        { 

                        }
                        break;

                    case ES1.Pause:
                        {

                        }
                        break;

                    case ES1.Actice:
                        {
                            int timeNow = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                            string text = $"Timer : {timeNow}";
                            uIController.ShowTimerState(text);// 更新碼表stopwatch

                            switch (stateNow)
                            {
                                case ETrafficLightState.Red:
                                    {
                                        if (IsFirst == true || timeNow >= 5)
                                        {
                                            uIController.ShowRedLight();

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
                                            uIController.ShowGreenLight();

                                            stopwatch.Restart();
                                            SetState(ETrafficLightState.Yellow);
                                        }
                                    }
                                    break;

                                case ETrafficLightState.Yellow:
                                    {
                                        if (timeNow >= 5)
                                        {
                                            uIController.ShowYellowLight();

                                            stopwatch.Restart();
                                            SetState(ETrafficLightState.Red);
                                        }
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
