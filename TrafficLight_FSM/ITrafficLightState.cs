using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM
{
    public interface ITrafficLightState
    {
        void EnterState(TrafficLight2 context);
        void UpdateState(TrafficLight2 context);
    }
}
