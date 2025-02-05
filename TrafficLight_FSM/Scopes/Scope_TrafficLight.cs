using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight_FSM.Scopes
{
    enum ETrafficLightType { SwitchCase, StatePattern}

    internal partial class Scope
    {
        public static ITrafficLight trafficLight;
        public static ETrafficLightType eTrafficLightType = ETrafficLightType.SwitchCase;

        void InitTrafficLight()
        {
            switch (eTrafficLightType)
            {
                case ETrafficLightType.SwitchCase:
                    {
                        trafficLight = new TrafficLight1(Scope.mainForm);
                    }
                    break;

                    case ETrafficLightType.StatePattern:
                    {
                        trafficLight = new TrafficLight2(Scope.mainForm);
                    }
                    break;
            }
            
        }

    }
}
