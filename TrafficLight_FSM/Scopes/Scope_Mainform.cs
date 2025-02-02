using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLight_FSM.Scopes
{


    internal partial class Scope
    {
        public static Mainform mainForm = null!;

        void Init_MainForm()
        {
            mainForm = new Mainform(new MainformPack());
        }
    }

    class MainformPack : ITrafficLight
    {
        public void Pause()
        {
            Scope.trafficLight.Pause();
        }

        public void Start()
        {
            Scope.trafficLight.Start();
        }

        public void Stop()
        {
            Scope.trafficLight.Stop();
        }
    }
}
