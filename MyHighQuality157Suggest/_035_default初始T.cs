using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 泛型的初始化用default
    /// 有一些无参数结构体也可以用default
    /// </summary>
    public class _035_default初始T
    {
        public void Test01<T>(T t)
        {
            T temp = default(T);
        }

        public void Test02()
        {
            var p1 = default(Person);
            Person p2 = default;
            var p3 = default(P);
            P p4 = default;
        }

        private class Person
        {
            public Person()
            {

            }
        }

        private struct P
        {

        }
    }
}
