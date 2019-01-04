using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 泛型会在IL阶段自动扩展 替换所需要的类型
    /// 比 指定类型,object 强太多了
    /// </summary>
    public class _032_优先考虑泛型
    {
        /// <summary>
        /// 只能有一种类型
        /// </summary>
        private class MyList_int
        {
            private int[] items;

            public int this[int i]
            {
                get => items[i];
                set => items[i] = value;
            }

            public int Count
            {
                get => items.Length;
            }
        }

        /// <summary>
        /// 不安全,拆装箱爆炸
        /// </summary>
        private class MyList_obj
        {
            private object[] items;

            public object this[int i]
            {
                get => items[i];
                set => items[i] = value;
            }

            public int Count
            {
                get => items.Length;
            }
        }

        /// <summary>
        /// 安全,多重类型,无拆装箱
        /// </summary>
        private class MyList_T<T>
        {
            private T[] items;

            public T this[int i]
            {
                get => items[i];
                set => items[i] = value;
            }

            public int Count
            {
                get => items.Length;
            }
        }
    }
}
