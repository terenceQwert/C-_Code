using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    static class CollectionNextMethods
    {
        #region 2.1 Looking for Duplicate Items in List<T>
        public static IEnumerable<T> GetAll<T>(this List<T> myList, T searchValue) => myList.Where(t => t.Equals(searchValue));
        public static T[] BinarySearchGetAll<T>(this List<T> myList, T searchValue)
        {
            List<T> retObj = new List<T>();
            // search first item 
            int center = myList.BinarySearch(searchValue);
            if (center > 0)
            {
                retObj.Add(myList[center]);
                int left = center;
                while (left > 0 && myList[left - 1].Equals(searchValue))
                {
                    //                    left = -1;
                    left -= 1;
                    retObj.Add(myList[left]);
                }
                int right = center;
                while (right < (myList.Count - 1) && myList[right + 1].Equals(searchValue))
                {
                    right += 1;
                    retObj.Add(myList[right]);
                }
            }
            return (retObj.ToArray());
        }
        public static int CountAll<T>(this List<T> myList, T searchValue) =>
            myList.GetAll(searchValue).Count();
        public static int BinarySearchCountAll<T>(this List<T> myList, T searchValue) =>
            myList.BinarySearchGetAll(searchValue).Count();
        #endregion
    }
}
