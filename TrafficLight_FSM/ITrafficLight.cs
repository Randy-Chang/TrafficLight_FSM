using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM
{
    public interface ITrafficLight
    {
        void Start();

        void Stop();

        void Pause();

        void SetDurations(int red, int green, int yellow);
    }
}
