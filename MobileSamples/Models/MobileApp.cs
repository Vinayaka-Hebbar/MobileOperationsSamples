using MobileSamples.Common;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MobileSamples.Models
{
    public abstract class MobileApp
    {
        public IAppUI AppUI { get; set; }

        public abstract string Name { get; }

        public abstract string IconPath { get; }

        public virtual AppType AppType => AppType.Foreground;

        public abstract SolidColorBrush Color { get; }

        public virtual SolidColorBrush TextColor => Brushes.White;

        public override string ToString()
        {
            return Name;
        }

        protected virtual void OnInitialize()
        {

        }

        public virtual void Initialize()
        {
            return;
        }

        public virtual UIElement ReRun(params object[] args)
        {
            throw new NotImplementedException();
        }

        public abstract UIElement Run();

        public virtual IList<AppMenu> GetMenus()
        {
            return null;
        }

        public virtual void OnUpdate(object value)
        {

        }
    }

    public enum AppType
    {
        Foreground,
        Background
    }
}
