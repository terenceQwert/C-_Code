using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    
    public class TestInvokeIntReturn
    {
        public static int Method1()
        {
            return 1;
        }
        public static int Method2()
        {
            return 2;
        }
        public static int Method3()
        {
            return 3;
        }
    }

    public static class TestDelegate
    {
        static IEnumerable<T> EveryOther<T>(this IEnumerable<T> enumerable)
        {
            bool retNext = true;
            foreach (T t in enumerable)
            {
                if (retNext)
                    yield return t;
                retNext = !retNext;
            }
        }
        public static void InvokeEveryOtherOperation()
        {
            Func<int > myDelegateInstance1 = TestInvokeIntReturn.Method1;
            Func<int> myDelegateInstance2 = TestInvokeIntReturn.Method2;
            Func<int> myDelegateInstance3 = TestInvokeIntReturn.Method3;

            Func<int> allInstance = myDelegateInstance1 + myDelegateInstance2 + myDelegateInstance3;
            Delegate[] delegateList = allInstance.GetInvocationList();
            foreach (Func<int> instance in delegateList.EveryOther())
            {
                /// invoke delegate
                int retVal = instance();
                Console.WriteLine($"Delegate returned {retVal}");
            }
        }
        
    }
}
