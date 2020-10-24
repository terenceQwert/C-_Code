using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Foo
    {
        public readonly int x;
        public const int y=1;
        public Foo() { }
        public Foo( int roInitValue)
        { x = roInitValue; }
    }
}

