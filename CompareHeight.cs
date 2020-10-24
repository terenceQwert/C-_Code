using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace ConsoleApp1
{
    public class CompareHeight : IComparer<Square>
    {
        public int Compare(object firstSquare, object secondSquare)
        {
            Square square1 = firstSquare as Square;
            Square square2 = secondSquare as Square;
            if (null == square1 || null == square2)
                throw (new ArgumentException("Both parameters must be of type square"));
            else
                return Compare(firstSquare, secondSquare);
        }
        #region IComparable<Square> Members;
        public int Compare(Square x, Square y)
        {
            if (x.Height == y.Height)
                return 0;
            else if (x.Height < y.Height)
                return -1;
            else if (x.Height > y.Height)
                return 1;
            else
                return -1;
        }
        #endregion
    }
}
