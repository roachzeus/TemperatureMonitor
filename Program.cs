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
            //var repository = new Model.CustomerXmlRepository(Application.StartupPath);
            //var view = new View.CustomerForm();
            // Poor Man's Dependency Injection/Pure Dependency Injection, Main() is the Composition Root.
            // See https://github.com/mrts/winforms-mvp/issues/2.
            //var presenter = new Presenter.CustomerPresenter(view, repository);
            // in presenter constructor call view.setPresenter(this)
            //Application.Run(view);
            Console.WriteLine("App starting");
            Application.Run(new MainUI());
        }
    }
}