using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBindingCommands
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DateTime data = DateTime.Now;
            Application.Current.Properties["dtAtual"] = data;
            Application.Current.Properties["AcaoInicial"] =
                string.Format("* App executado às {0}. \n", data);

            MainPage = new MainPage();
        }
        protected override void OnStart()
        {
            Application.Current.Properties["AcaoStart"] =
                string.Format("* App iniciado às {0}. \n", DateTime.Now);
        }
        protected override void OnSleep()
        {
            Application.Current.Properties["AcaoSleep"] =
                string.Format("* App em segundo plano às {0}. \n", DateTime.Now);
        }
        protected override void OnResume()
        {
            Application.Current.Properties["AcaoResume"] =
                string.Format("* App reativado às {0}. \n", DateTime.Now);
        }
    }
}
