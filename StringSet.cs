using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ConsoleApp1
{
    public class StringSet : IEnumerable<string>
    {
        private List<string> _items = new List<string>();
        public void Add ( string value)
        {
            _items.Add(value);
        }

        public IEnumerator<string> GetEnumerator()
        {
            try
            {
                for (int index = 0; index < _items.Count; index++)
                    yield return _items[index];
            }
            finally
            {
                Console.WriteLine("in iterator finally block");
            }
        }
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
