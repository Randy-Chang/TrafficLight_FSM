using TrafficLight_FSM.Scopes;

namespace TrafficLight_FSM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Scope scope = new Scope();
            Application.Run(Scope.mainForm);
        }
    }
}