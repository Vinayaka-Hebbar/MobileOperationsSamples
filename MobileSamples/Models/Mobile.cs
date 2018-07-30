using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MobileSamples.Models
{
    [Serializable]
    public sealed class Mobile
    {
        public Mobile()
        {
            MobileApps = new ObservableCollection<MobileApp>();
            BackgroundColor = Brushes.Black;
        }

        public MobileState State { get; set; } = MobileState.Off;

        public Mobile(string name)
        {
            Name = name;
            MobileApps = new ObservableCollection<MobileApp>();
        }

        public string Name { get; set; }

        public MobileDb MobileDb { get; set; }

        public Display Display { get; set; }

        public IList<MobileApp> MobileApps { get; set; }

        public SolidColorBrush BackgroundColor { get; set; } = Brushes.Black;

        public SolidColorBrush TextColor { get; set; } = Brushes.White;

        public override string ToString()
        {
            return Name;
        }
    }

    public enum MobileState
    {
        On,
        Off
    }
}
