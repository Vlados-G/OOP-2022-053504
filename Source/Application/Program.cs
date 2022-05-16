using System;
using System.Windows.Forms;
using MVC;

namespace Laba2
{
    static class Program
    {
        public static AppController Controller = null;
        public static AppModel AppModel = null;
        public static DomainModel.DomainModel DomainModel = null;
        public static AppView View = null;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeMVC();
            Application.Run(View.GetMainForm());
        }

        private static void InitializeMVC()
        {
            // Creating Model, View, Controller
            AppModel = new AppModel();
            DomainModel = new DomainModel.DomainModel();
            View = new AppView();
            Controller = new AppController(AppModel, DomainModel, View);

            // Initializing Model, View, Controller
            Controller.Initialize();
            View.Initialize();
            DomainModel.Initialize(View.Graphics);
            
            // Additional initialization steps
            Controller.LoadPlugin();
            View.CreateMenu();
        }
    }
}