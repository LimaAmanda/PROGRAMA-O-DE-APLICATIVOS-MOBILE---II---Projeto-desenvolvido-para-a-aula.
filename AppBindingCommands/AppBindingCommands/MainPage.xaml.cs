using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBindingCommands
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "Info", async (msg) =>
            {
                await DisplayAlert("Informação", msg, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "Info");
        }

        private void btnAtualizarInfo_Clicked(object sender, EventArgs e)
        {
            string informacoes = string.Empty;

            if (Application.Current.Properties.ContainsKey("AcaoInicial"))
                informacoes += Application.Current.Properties["AcaoInicial"];

            if (Application.Current.Properties.ContainsKey("AcaoStart"))
                informacoes += Application.Current.Properties["AcaoStart"];

            if (Application.Current.Properties.ContainsKey("AcaoSleep"))
                informacoes += Application.Current.Properties["AcaoSleep"];

            if (Application.Current.Properties.ContainsKey("AcaoResume"))
                informacoes += Application.Current.Properties["AcaoResume"];

            lblInformacoes.Text = informacoes;
        }
    }
}
