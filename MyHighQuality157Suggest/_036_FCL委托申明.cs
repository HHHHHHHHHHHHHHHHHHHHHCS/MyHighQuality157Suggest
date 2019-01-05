using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用Action,Function,Predicate
    /// Delegate至少0个参数，至多32个参数，可以无返回值，也可以指定返回值类型。这个是祖宗。
    /// Func可以接受0个至16个传入参数，必须具有返回值。
    /// Action可以接受0个至16个传入参数，无返回值。
    /// Predicate只能接受一个传入参数，返回值为bool类型。
    /// </summary>
    public class _036_FCL委托申明
    {
        public delegate void Dg();
        public event Dg evt; 

        public void Test01()
        {
            evt += ()=>{ Console.WriteLine("Test01"); };
        }

        public void Test02()
        {
            Action act1 = () => { Console.WriteLine("Test02"); };
            Action<int> act2 = (x) => { Console.WriteLine(x + "Test02"); };
            act1();
            act2(1);
        }

        public void Test03()
        {
            Func<int> func1 = () => { return 1; };
            Func<int, int> func2 = (x) => { return 1 + x; };
            Console.WriteLine(func1());
            Console.WriteLine(func2(2));
        }

        public void Test04()
        {
            Predicate<int> pre1 = (x) => x > 100;
            Console.WriteLine(pre1(1));
        }
    }
}
