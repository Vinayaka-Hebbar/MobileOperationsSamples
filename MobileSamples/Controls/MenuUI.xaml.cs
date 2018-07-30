using MobileSamples.Common;
using MobileSamples.Models;
using System;
using System.Windows.Controls;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for MenuUI.xaml
    /// </summary>
    public partial class MenuUI : UserControl
    {
        private IMobileUI uI;
        public MenuUI(IMobileUI uI)
        {
            InitializeComponent();
            this.uI = uI;
            CreateMenu();
        }

        private void CreateMenu()
        {
            MenuList.ItemsSource = uI.Mobile.MobileApps;
            MenuList.Background = uI.Mobile.BackgroundColor;
        }

        private void OnAppRun(object sender, SelectionChangedEventArgs e)
        {
            if (MenuList.SelectedIndex == -1) return;
            MobileApp app = MenuList.SelectedItem as MobileApp;
            if(app.AppType == AppType.Background)
            {
                app = uI.GetApp<MobileApp>("Logs");
            }
            if (app != null)
            {
                var appUI = new AppUI(app);
                appUI.Modal += OnModal;
                appUI.Resume += OnResume;
                appUI.Log += OnLog;
                uI.RunningApp = appUI;
                uI.SetContent(appUI);
            }
        }

        private void OnLog(string message)
        {
            uI.GetApp<LoggerApp>("Logs").OnUpdate(message);
        }

        private void OnResume(AppUI appUI)
        {
            uI.SetContent(appUI);
        }

        private void OnModal(Modal modal)
        {
            uI.SetContent(modal);
        }
    }
}
