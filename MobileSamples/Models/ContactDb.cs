using System;
using System.Collections.Generic;

namespace MobileSamples.Models
{
    public class ContactDb : MobileDb
    {
        public override IList<T> LoadDb<T>()
        {
            throw new NotImplementedException();
        }

        public override void SaveDb()
        {
            throw new NotImplementedException();
        }
    }
}
