using System;
using System.Collections.ObjectModel;

namespace MobileSamples.Common
{

    [Serializable]
    public class ItemsSerializable<T> : ObservableCollection<T>
    {
    }
}
