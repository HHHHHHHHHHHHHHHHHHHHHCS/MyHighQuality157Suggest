using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 因为泛型,在编译阶段会自动扩展替换
    /// 所以会变成很多个类
    /// 静态类可能会不准确
    /// --------------------------
    /// 非泛型类型中的泛型方法不会在运行代码时生成不同类型
    /// </summary>
    public class _033_避免泛型静态成员
    {
        /// <summary>
        /// 正常的效果
        /// </summary>
        public void Test01()
        {
            MyList list1 = new MyList();
            MyList list2 = new MyList();
            Console.WriteLine(MyList.Count);
        }

        /// <summary>
        /// 被自动扩充完之后,可能达不到想要的效果
        /// </summary>
        public void Test02()
        {
            MyList<int> list1 = new MyList<int>();
            MyList<int> list2 = new MyList<int>();
            MyList<string> list3 = new MyList<string>();
            Console.WriteLine(MyList<int>.Count);
            Console.WriteLine(MyList<string>.Count);
        }

        /// <summary>
        /// 非泛型类型中的泛型方法不会在运行代码时生成不同类型
        /// </summary>
        public void Test03()
        {
            MyList.Count = 0;
            Console.WriteLine(MyList.Do<int>());
            Console.WriteLine(MyList.Do<string>());
            Console.WriteLine(MyList.Do<object>());
        }

        private class MyList
        {
            public static int Count { get; set; }
            public MyList()
            {
                Count++;
            }


            public static int Do<T>()
            {
                return Count++;
            }
        }

        private class MyList<T>
        {
            public static int Count { get; set; }

            public MyList()
            {
                Count++;
            }
        }
    }
}
