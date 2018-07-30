using MobileSamples.Common;
using System.Windows.Controls;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for MainUI.xaml
    /// </summary>
    public partial class MainUI : UserControl
    {
        private IMobileUI uI;
        public MainUI(IMobileUI mobileUI)
        {
            InitializeComponent();
            uI = mobileUI;
        }

        private void OnMenuClick(object sender, System.Windows.RoutedEventArgs e)
        {
            uI.SetContent(new MenuUI(uI));
        }
    }
}
