using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Square : IComparable<Square>
    {
        public Square()
        {

        }
        public Square(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int CompareTo(object obj)
        {
            Square square = obj as Square;
            if (null != square)
                return CompareTo(square);
            throw
                new ArgumentException("Both object being compared must be of type Square");
        }
        public override string ToString() => ($"Height: {this.Height}   Width: {this.Width}");
        public override bool Equals(object obj)
        {
            if (null == obj)
                return false;
            Square square = obj as Square;
            if (square != null)
            {
                return this.Height == square.Height;

            }
            return false;
        }

        public override int GetHashCode() => (this.Height.GetHashCode() | this.Width.GetHashCode());

        public static bool operator ==(Square x, Square y) => x.Equals(y);
        public static bool operator !=(Square x, Square y) => !(x == y);
        public static bool operator <(Square x, Square y) => (x.CompareTo(y) < 0);
        public static bool operator >(Square x, Square y) => (x.CompareTo(y) > 0);
        public int CompareTo(Square other)
        {
            long area1 = this.Height * this.Width;
            long area2 = other.Height * other.Width;
            if (area1 == area2)
                return 0;
            else if (area1 > area2)
                return 1;
            else if (area1 < area2)
                return -1;
            else
                return -1;
        }
    }

}
