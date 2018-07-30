using MobileSamples.Models;
using System.Windows.Media;

namespace MobileSamples.Common
{
    public sealed class SaveMenu : AppMenu
    {
        public override string IconPath => "M 20.5833,20.5833L 55.4167,20.5833L 55.4167,55.4167L 45.9167,55.4167L 45.9167,44.3333L 30.0833,44.3333L 30.0833,55.4167L 20.5833,55.4167L 20.5833,20.5833 Z M 33.25,55.4167L 33.25,50.6667L 39.5833,50.6667L 39.5833,55.4167L 33.25,55.4167 Z M 26.9167,23.75L 26.9167,33.25L 49.0833,33.25L 49.0833,23.75L 26.9167,23.75 Z";

        public override string ToolTip => "Save";

        public override SolidColorBrush FillColor => Brushes.White;
    }
}
