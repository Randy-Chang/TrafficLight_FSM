using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM.Scopes
{
    public enum ETrafficLightState { Idle, Red, Green, Yellow }

    internal partial class Scope
    {
        public static TrafficLight2 trafficLight;

        void InitTrafficLight()
        {
            trafficLight = new TrafficLight2(Scope.mainForm);
        }

    }
}
