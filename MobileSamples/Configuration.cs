using MobileSamples.Common;
using MobileSamples.Models;
using MobileSamples.ViewModel;
using System.Windows.Media;

namespace MobileSamples
{
    public partial class MainWindow
    {
        private MobilesModel model;
        private MobilePlatform platform;

        internal void LoadConfiguration()
        {
            model = new MobilesModel();
            platform = new MobilePlatform();
            Mobile defaultMobile = new Mobile("Nokia 3311")
            {
                Display = new Display(300, 300)
            };
            defaultMobile.MobileApps.Add(new MessageApp());
            defaultMobile.MobileApps.Add(new ContactApp());
            defaultMobile.MobileApps.Add(new SettingApp());
            defaultMobile.MobileApps.Add(new CallApp());
            defaultMobile.MobileApps.Add(new LoggerApp());
            defaultMobile.MobileApps.Add(new BrowserApp());
            Mobile secondMobile = new Mobile("Nokia 110")
            {
                Display = new Display(300, 300),
                BackgroundColor = Brushes.CadetBlue
            };
            secondMobile.MobileApps.Add(new MessageApp());
            secondMobile.MobileApps.Add(new ContactApp());
            secondMobile.MobileApps.Add(new SettingApp());
            secondMobile.MobileApps.Add(new CallApp());
            secondMobile.MobileApps.Add(new LoggerApp());
            model.Mobiles.Add(defaultMobile);
            model.Mobiles.Add(secondMobile);
            MobileList.ItemsSource = model.Mobiles.Items;
        }
    }
}
