using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace ConsoleApp1
{
    public class Container<T> : IEnumerable<T>
    {
#if false
        public static IEnumerable<T> EveryNthItem(this IEnumerable<T> enumerable, int step)
        {
            int current = 0;
            foreach (T item in enumerable)
            {
                ++current;
                if (current % step == 0)
                    yield return item;
            }
        }
#else
        public IEnumerable<T> GetForwardStepEnumerator(int step)
        {
            int current = 0;
            foreach (T item in _internalList)
            {
                ++current;
                if (current % step == 0)
                    yield return item;
            }
        }
#endif
        public Container() { }
        private List<T> _internalList = new List<T>();

        // from first to last
        public IEnumerator<T> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }
        // from last to first
        public IEnumerable<T> GetReverseOrderEnumerator()
        {
            foreach (T item in ((IEnumerable<T>)_internalList).Reverse())
                yield return item;
        }


        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        public void Clear() => _internalList.Clear();
        public void Add(T item) => _internalList.Add(item);
        public void AddRange(ICollection<T> collection)
        {
            _internalList.AddRange(collection);
        }
        public static IEnumerable<int> GetValues()
        {
            yield return 10;
            yield return 20;
            yield return 30;
            yield return 40;
        }
    }
}
