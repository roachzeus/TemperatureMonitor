using LibreHardwareMonitor.Hardware.Motherboard;

namespace TemperatureMonitor
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
            // create model and presenter here.
            Model.MainModel model = new Model.MainModel();
            View.MainUI view = new View.MainUI();
            // Poor Man's Dependency Injection/Pure Dependency Injection, Main() is the Composition Root.
            // See https://github.com/mrts/winforms-mvp/issues/2.
            Presenter.MainPresenter presenter = new Presenter.MainPresenter(view, model);
            // in presenter constructor call view.setPresenter(this)
            //Application.Run(view);
            Console.WriteLine("App starting");
            Application.Run(view);
        }
    }
}