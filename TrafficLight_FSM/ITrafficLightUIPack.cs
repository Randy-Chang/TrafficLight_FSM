using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM
{
    internal interface ITrafficLightUIPack
    {
        PictureBox RedLight { get; }
        PictureBox YellowLight { get; }
        PictureBox GreenLight { get; }

        Button Start { get; }
        Button Stop { get; }
        Button Pause { get; }
    }
}
