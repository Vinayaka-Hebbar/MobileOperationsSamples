using MobileSamples.Common;
using MobileSamples.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for AppUI.xaml
    /// </summary>
    public partial class AppUI : UserControl, IAppUI
    {
        private MobileApp app;

        public delegate void ModalEvent(Modal modal);

        public delegate void ResumeEvent(AppUI appUI);

        public delegate void LogEvent(string message);

        public event LogEvent Log;

        public event ResumeEvent Resume;

        public event ModalEvent Modal;

        public AppUI(MobileApp app)
        {
            InitializeComponent();
            this.app = app;
            app.AppUI = this;
            RunApp();
        }

        private void RunApp()
        {
            AppPreseneter.Content = app.Run();
            app.Initialize();
            IList<AppMenu> menus = app.GetMenus();

            Loaded += OnLoaded;
            if (menus == null) return;
            foreach(var menu in menus)
            {
                RoundButton button = new RoundButton
                {
                    IconPath = menu.IconPath,
                    FillBrush = menu.FillColor
                };
                button.Click += (object sender, RoutedEventArgs e) => menu.OnClick();
                AppControls.Children.Add(button);
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            OnLog(string.Format("App {0} is Started", app.Name));
        }

        public void OnStart(params object[] args)
        {
            throw new NotImplementedException();
        }

        public void OnResume(params object[] args)
        {
            AppPreseneter.Content = app.ReRun();
            Resume?.Invoke(this);
        }

        public void OnStop()
        {

        }

        public void OnModal(Modal modal)
        {
            Modal?.Invoke(modal);
        }

        public void OnLog(string message)
        {
            Log?.Invoke(message);
        }

        public void OnRestart()
        {
            AppPreseneter.Content = app.Run();
            app.Initialize();
        }
    }
}
