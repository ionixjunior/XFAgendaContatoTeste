using AgendaContato.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using AgendaContato.Interfaces;
using AgendaContato.Models;

namespace AgendaContato
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var conn = DependencyService.Get<ISQLite>()
                                        .GetConnection();

            conn.CreateTable<ContatoModel>();

            MainPage = new NavigationPage(new ContatoView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
