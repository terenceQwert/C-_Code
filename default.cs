using System;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class @default<T>
    {
        T data = default(T);
        public bool IsDefaultData()
        {
            T temp = default(T);
            if( temp.Equals(data))
            {
                return (true);
            } else
            {
                Console.WriteLine($"current data :{data}");
                return (false);
            }
        }
        public void setData(T val) => data = val;
    }



    
}
