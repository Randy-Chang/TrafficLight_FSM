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

        public static void InitTrafficLight()
        {
            switch (eTrafficLightType)
            {
                case ETrafficLightType.SwitchCase:
                    trafficLight = new TrafficLight1(mainForm);
                    break;

                case ETrafficLightType.StatePattern:
                    trafficLight = new TrafficLight2(mainForm);
                    break;
            }
        }

        public static void SetTrafficLightType(ETrafficLightType type)
        {
            trafficLight.Exit();
            eTrafficLightType = type;
            InitTrafficLight();
        }
    }
}
