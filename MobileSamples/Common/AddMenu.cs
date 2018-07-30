using System.Windows.Media;
using MobileSamples.Models;

namespace MobileSamples.Common
{
    public sealed class AddMenu : AppMenu
    {
        public override string IconPath => "M 35,19L 41,19L 41,35L 57,35L 57,41L 41,41L 41,57L 35,57L 35,41L 19,41L 19,35L 35,35L 35,19 Z";

        public override string ToolTip => "Add";

        public override SolidColorBrush FillColor => Brushes.White;
    }
}
