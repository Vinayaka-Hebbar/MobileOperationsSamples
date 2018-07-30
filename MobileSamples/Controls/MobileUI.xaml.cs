using MobileSamples.Common;
using MobileSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for MobileUI.xaml
    /// </summary>
    public partial class MobileUI : UserControl, IMobileUI
    {
        public Mobile Mobile { get; }
        public IAppUI RunningApp { get; set; }

        private IList<MobileApp> backgroundApp;

        public delegate void ShutdownEvent();

        public delegate void PowerOnEvent();
        public event PowerOnEvent PowerOn;

        public event ShutdownEvent Shutdown;

        public MobileUI(Mobile mobile)
        {
            InitializeComponent();
            backgroundApp = new List<MobileApp>
            {
                new LoggerApp()
            };
            Mobile = mobile;
            MobileUIPresenter.Content = new MainUI(this);
            DateField.Text = DateTime.Now.ToString();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            GetApp<LoggerApp>("Logs").OnUpdate("App Started");
            OnPowerOn();
        }

        public void GoHome()
        {
            MobileUIPresenter.Content = new MainUI(this);
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void SetContent(UIElement element)
        {
            MobileUIPresenter.Content = element;
        }

        public void OnShutdown()
        {
            Shutdown?.Invoke();
            GetApp<LoggerApp>("Logs").OnUpdate("Phone off");
        }

        public void OnPowerOn()
        {
            PowerOn?.Invoke();
            GetApp<LoggerApp>("Logs").OnUpdate("Phone On");
        }

        public T GetApp<T>(string appName) where T : MobileApp
        {
            var app =  backgroundApp.FirstOrDefault(runningApp => runningApp.Name.Equals(appName));
            return (T)app;
        }
    }
}
