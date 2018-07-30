using MobileSamples.Common;
using MobileSamples.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MobileSamples.Controls
{
    /// <summary>
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : UserControl
    {
        private object[] values;
        private Result[] results;
        private IAppUI uI;

        public delegate void SubmitEvent(params object[] values);

        public event SubmitEvent Submit;

        public Modal()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            results = new Result[values.Length];
            for (int count = 0; count < values.Length; count++)
            {
                var ui = (UIElement)null;
                if (values[count] is string str)
                    ui = new Label() { Content = str, FontSize = 16, Foreground = Brushes.White };
                else if (values[count] is Type type)
                {
                    results[count] = new Result();
                    ui = Activator.CreateInstance(type) as UIElement;
                }
                switch (ui)
                {
                    case TextBox text:
                        Binding textBind = new Binding()
                        {
                            Source = results[count],
                            Mode = BindingMode.TwoWay,
                            Path = new PropertyPath("Value"),
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                        };
                        text.SetBinding(TextBox.TextProperty, textBind);
                        break;
                }
                ModalControl.Children.Add(ui);
            }
        }

        public Modal(IAppUI uI, params object[] types)
        {
            this.values = types;
            this.uI = uI;
            InitializeComponent();
            CreateUI();
        }

        private void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            Submit?.Invoke(results);
        }
    }
}
