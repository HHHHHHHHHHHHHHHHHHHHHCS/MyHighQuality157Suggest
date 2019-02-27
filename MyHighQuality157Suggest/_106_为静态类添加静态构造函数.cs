using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 静态类可以拥有构造方法,这就是静态构造方法.
    /// 静态构造方法与实力构造方法相比较,他有几个自己的特点.
    /// 1.只被执行一次,且在第一次调用类成员之前运行时执行,
    /// 2.代码无法调用它,不像实例构造方法使用new关键字就可以被执行
    /// 3.没有访问标识符
    /// 4.不能带任何参数
    /// </summary>
    public class _106_为静态类添加静态构造函数
    {
        public void Test01()
        {
            Console.WriteLine("肚子好饿");
            SampleClass.Print();
        }


        private static class SampleClass
        {
            static SampleClass()
            {
                Console.WriteLine("我要吃饭");
            }

            public static void Print()
            {
                Console.WriteLine("2333");
            }
        }
    }
}
