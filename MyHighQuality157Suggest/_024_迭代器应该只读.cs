using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 不要为迭代器设置可写选项
    /// 因为可能通知不到,还可能存在BUG
    /// </summary>
    public class _024_迭代器应该只读
    {
        private static MyIntList list = new MyIntList(1, 2, 3, 4, 5, 6, 7, 8, 9);

        /*
         * 先执行Test01,在执行Test02,在执行Test01
         * 1.没有重置
         * 2.就算类型改变了,但是输出的内容还是有问题
         */

        /// <summary>
        /// 自己实现迭代器
        /// </summary>
        public void Test01()
        {
            var enumerator = list.GetEnumerator();
            //enumerator.Reset();
            Console.WriteLine(enumerator);
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                Console.Write(current.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }

        /// <summary>
        /// 设置可写
        /// </summary>
        public void Test02()
        {
            MyIEnumerator2 enum2 = new MyIEnumerator2(list);
            list.SetEnumerator(enum2);

            while (enum2.MoveNext())
            {
                int current = enum2.Current;
                Console.Write(current.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("--------------");
        }


        private class MyIntList : IEnumerable<int>
        {
            public int[] intArray;
            private IEnumerator<int> enumerator2;

            public MyIntList(params int[] objs)
            {
                intArray = objs;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return enumerator2 ?? new MyIEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return enumerator2 ?? new MyIEnumerator(this);
            }

            public void SetEnumerator(IEnumerator<int> arg)
            {
                enumerator2 = arg;
            }
        }

        private class MyIEnumerator : IEnumerator<int>
        {
            protected MyIntList enumerable;
            protected int pos;

            public MyIEnumerator(MyIntList _enum)
            {
                enumerable = _enum;
                pos = -1;
            }

            public void Dispose()
            {
                enumerable = null;
            }

            public bool MoveNext()
            {
                pos++;
                return pos < enumerable.intArray.Length;
            }

            public void Reset()
            {
                pos = -1;
            }

            public virtual int Current => enumerable.intArray[pos];

            object IEnumerator.Current => Current;
        }

        private class MyIEnumerator2 : MyIEnumerator
        {
            public MyIEnumerator2(MyIntList _enum) : base(_enum)
            {
            }

            public void SetEnumerator(MyIntList _enum)
            {
                enumerable = _enum;
            }

            public int Current => 10000 + enumerable.intArray[pos];
        }
    }
}