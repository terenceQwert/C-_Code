using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleApp1.DataType;
using ConsoleApp1.Lambda;
namespace ConsoleApp1
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SignedNumber
    {
        [FieldOffset(0)]
        public sbyte Num1;
        [FieldOffset(0)]
        public short Num2;
        [FieldOffset(0)]
        public int Num3;
        [FieldOffset(0)]
        public long Num4;
        [FieldOffset(0)]
        public float Num5;
        [FieldOffset(0)]
        public double Num6;
        [FieldOffset(16)]
        public string Data;
    };

    

    partial class Program
    {
        public static void TestDefaultData()
        {
            @default<int> dv = new @default<int>();
            bool isDefault = dv.IsDefaultData();
            Console.WriteLine($"Initialized data: {isDefault}");
            dv.setData ( 100 );
            isDefault = dv.IsDefaultData();
            Console.WriteLine($"Set data: {isDefault}");
        }
        public static void TestSortedList()
        {
            SortedList<int, string> data = new SortedList<int, string>
            {
                {2, "two" },
                {5, "five" },
                {3, "three" },
                {1, "one" }
            };
            foreach( KeyValuePair <int, string> kvp in data)
            {
                Console.WriteLine($"\t {kvp.Key}\t {kvp.Value}");
            }

            var query = from d in data orderby d.Key descending select d;
            Console.WriteLine("after sorted");
            foreach ( var item in query)
            {
                Console.WriteLine($"{item.Key} \t ${item.Value}");
            }
        }
        public static void TestStream()
        {
            FileStream FS;
            using (FS = new FileStream("test.txt", FileMode.Create))
            {
                FS.WriteByte((byte)1);
                FS.WriteByte((byte)2);
                FS.WriteByte((byte)4);
                using (StreamWriter SW = new StreamWriter(FS))
                {
                    SW.WriteLine("some text");
                }
            }
        }
        public static void TestConst()
        {
            var foo = Foo.y;
            
        }
        public static void TestClone()
        {
            DeepClone dc = new DeepClone();
            var Data = dc.DeepCopy();

            
        }
        public static void TestSort()
        {
            List<Square> listOfSquares = new List<Square>
           {
               new Square(1,3),
               new Square(4,3),
               new Square(2,1),
               new Square(6,1)
           };
            // List<string>
            foreach( Square squa in listOfSquares)
            {
                Console.WriteLine(squa.ToString());
            }
            Console.WriteLine();

            IComparer<Square> heightComparer = new CompareHeight();
            listOfSquares.Sort(heightComparer);
            Console.WriteLine("Sorted list using Icomparer<Square> = heighComparer");
            foreach (Square squa in listOfSquares)
            {
                Console.WriteLine(squa.ToString());
            }
            Console.WriteLine();

            ///
            ///
            ///
            int found = listOfSquares.BinarySearch(new Square(1, 3), heightComparer);
            Console.WriteLine($"Found (1,3): {found}");

            Console.WriteLine();
            Console.WriteLine("Sorted list using IComparer<Square>");
            listOfSquares.Sort();
            foreach (Square squa in listOfSquares)
            {
                Console.WriteLine(squa.ToString());
            }
            found = listOfSquares.BinarySearch(new Square(6, 1));
            Console.WriteLine($"Found (6,1): {found}");

            // test sortedlist
            var sortedListOfSquares = new SortedList<int, Square>()
            {
                { 0, new Square(1,3)},
                { 2, new Square(3,3) },
                { 1, new Square(2,1)},
                { 3, new Square(6,1) }
            };
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("SortedList <Square>");
            foreach( KeyValuePair<int , Square> kvp in sortedListOfSquares)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
            bool foundItem = sortedListOfSquares.ContainsKey(2);
            Console.Write($"sortedListOfSquares.ContainKey(2):{foundItem}");

            Console.WriteLine();
            Square value = new Square(6, 1);
            foundItem = sortedListOfSquares.ContainsValue(value);
            Console.WriteLine("sortedListOfSquares.ContainsVAlue: " + $"(new Square(6,1): {foundItem}");
        }
        static void TestStructure()
        {
            Data data = default(Data);
            Console.WriteLine(data.ToString());

            Data[] dataArray = new Data[4];
            dataArray = (from d in dataArray select new Data()).ToArray();
            Console.ReadKey();
        }
        static void TestNullString()
        {
            string[]  val = new string[] { "Hello World", null };
            Console.WriteLine(val?[1]?.Trim().ToUpper());
            Approval approvalDelegate = () => { return true; };
            approvalDelegate?.Invoke();
            int? len = val[0]?.Length;
            string[] val1 = null;
            if(val1?.Length > 0)
            {
                Console.WriteLine("val.Length > 0");
            } else if(val1?.Length == 0)
            {
                Console.WriteLine("val.Length ==0 or null");
            } else
            {
                Console.WriteLine("val is null");
            }
            Console.ReadKey();
        }
        public delegate bool Approval();
        public static void TestSimpleNullOrNot()
        {
            List<string> strings = new List<string> { "one", null, "three" };
            string str = strings.TrueForAll((val) => { if (val != null) return true; else return false; }).ToString();
            Console.WriteLine(str);
        }
        public static void TestSortStaticMethods()
        {
            List<int> listRetrieval = new List<int> { 2,2,2,2,-1, -1, -2, -4, 5, 6, -2, 100, 3, 7 };
            {
                string file_name = "E:\\list.txt";
                StatusStore.SerializeToFile<List<int>>(listRetrieval, file_name);
                List<int> read_back = StatusStore.DeserializeFromFile<List<int>>(file_name);
            }
            Console.WriteLine("--Get All--");
            IEnumerable<int> items = listRetrieval.GetAll(2);
            foreach( var item in items)
            {
                Console.WriteLine($"item: {item}");
            }
            Console.WriteLine();
            items = listRetrieval.GetAll(-2);
            foreach( var item in items)
            {
                Console.WriteLine($"item -2: {item}");
            }

            Console.WriteLine();
            items = listRetrieval.GetAll(5);
            foreach (var item in items)
            {
                Console.WriteLine($"item 5: {item}");
            }
            Console.WriteLine("\r\n--BINARY SEARCH GET ALL--");
            listRetrieval.Sort();
            int[] listItems = listRetrieval.BinarySearchGetAll(-2);
            foreach( var item in listItems)
            {
                Console.WriteLine($"item-2: {item}");
            }

            Console.WriteLine();
            listItems = listRetrieval.BinarySearchGetAll(2);
            foreach( var item in listItems)
            {
                Console.WriteLine($"item 2: {item}");
            }
            Console.WriteLine();
            listItems = listRetrieval.BinarySearchGetAll(5);
            foreach( var item in listItems)
            {
                Console.WriteLine($"item5: {item}");
            }

        }

        static void _KeepToFile(Dictionary<string, string> hash)
        {
            string hash_file = "E:\\hash.txt";
            StatusStore.SerializeToFile<Dictionary<string, string>>(hash, hash_file);

            Dictionary<string, string> hash_back = StatusStore.DeserializeFromFile<Dictionary<string, string>>(hash_file);
        }
        static void TestDictionaryObject()
        {
            Dictionary<string, string> hash = new Dictionary<string, string>()
            {
                { "2","two" },
                { "3", "three" },
                { "4","four" },
                {"5", "five" },
                { "1" ,"one"}
            };
            _KeepToFile(hash);
            var x = from k in hash.Keys orderby k ascending select k;
            foreach( string s in x)
            {
                Console.WriteLine($"Key: {s} Value:{hash[s]}");
            }

            x = from k in hash.Keys orderby k descending select k;
            foreach( string s in x)
            {
                Console.WriteLine($"Key {s} Value: {hash[s]}");
            }
        }
        static void TestMinMaxValue()
        {
            MinMaxValueDictionary<String, int> dictionary = new MinMaxValueDictionary<string, int>(10, 20);
            try {
                dictionary.Add("1", 20);
                dictionary.Add("2", 12);
                Console.WriteLine("no exception");
            } catch (Exception e)
            {
                Console.WriteLine($"exception error {e.Data}");
            }
        }
        static void TestContain()
        {
            Container<int> data = new Container<int>() { 1, 2, 3, 5, 6, 7, 4, 2, 3, 5 };
            IEnumerable<int> lData = Container<int>.GetValues();
            int id = 0;
            foreach( var item in lData)
            {
                id++;
                Console.WriteLine($"item id{id} = {item}");
            }
            int i = 0;
            Console.WriteLine("Container Order List");
            foreach( int item in data)
            {
                i++;
                Console.WriteLine($"item#{i} is {item} ");
            }
            // Container reverse order list
            Console.WriteLine("Container reverse order list");
            i = 0;
            foreach( int item in data.GetReverseOrderEnumerator())
            {
                i++;
                Console.WriteLine($"item#{i}: {item}");
            }
            // Container steps order list
            Console.WriteLine("Container step order list");
            i = 0;
            foreach( int item in data.GetForwardStepEnumerator(2))
            {
                i++;
                Console.WriteLine($"item {i}: {item}");
            }

        }
        static void TestStringSet()
        {
            StringSet strSet = new StringSet() { "item 1", "item 2", "item 3", "item 4", "item 5" };
            foreach( string s in strSet)
            {
                Console.WriteLine(s);
            }
        }
        static void TestLambdaObject()
        {
            dailySecurityLog log = new dailySecurityLog();
            log.TestProjectWithInspect();
            log.Testlogin();
            LinqExtensions.TestLinqExtension();
        }
        
        static void TestReadXML()
        {
            ReadXml xml = new ReadXml();
            xml.TestReadXml();
        }
        static void Main(string[] args)
        {
            TestReadXML();
            TestLambdaObject();
            DataTypeExtMethods.TestOverflow();
            DataEncoding.TestParser();
            DataEncoding.TestBinaryToAscii_Unicode();
            MultipleTask.TestMultipleGate();
            TestStringSet();
            TestContain();
            TestSimpleNullOrNot();
            TestSortStaticMethods();
            TestDictionaryObject();
            TestMinMaxValue();
            TestNullString();
            TestStructure();
            TestDelegate.InvokeEveryOtherOperation();
            TestDefaultData();
            TestSortedList();
            TestStream();
            TestClone();
            TestConst();
            SignedNumber sn = new SignedNumber();
            TestSort();
            Console.ReadKey();
           
            sn.Num2 = 0x3;
            Console.WriteLine("Hello World!");
        }
    }
    
}
