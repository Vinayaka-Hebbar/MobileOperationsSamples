using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MobileSamples.Models
{
    public class Mobiles : ICollection<Mobile>
    {
        public Mobiles()
        {
            Items = new ObservableCollection<Mobile>();
        }
        

        public ObservableCollection<Mobile> Items { get; set; }

        public int Count => Items.Count;

        public bool IsReadOnly => false;

        public void Add(Mobile item)
        {
            Items.Add(item);
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Mobile item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Mobile[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<Mobile> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        public bool Remove(Mobile item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new KeyNotFoundException();
        }
    }
}
