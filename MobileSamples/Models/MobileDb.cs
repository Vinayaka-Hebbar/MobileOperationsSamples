using System.Collections.Generic;

namespace MobileSamples.Models
{
    public abstract class MobileDb
    {
        public abstract void SaveDb();
        public abstract IList<T> LoadDb<T>();
    }
}
