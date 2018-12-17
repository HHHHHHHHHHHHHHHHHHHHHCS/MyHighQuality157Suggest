using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 利用== 和Equals做对比
    /// </summary>
    public class _011_等号Equals
    {
        /*
         * ==和Equals的共同点
         *  值类型,如果值相等,返回true
         *  引用类型,如果是一个对象,返回true
         * 不同点,如果重写equals就不一样了
         *  equals = 的重写方式不一样(说了也白说)
         */

        /// <summary>
        /// 值类型比较
        /// </summary>
        public void Test01()
        {
            int i = 1;
            int j = 1;
            Console.WriteLine(i == j); //true
            Console.WriteLine(i.Equals(j)); //true
            j = i;
            Console.WriteLine(i == j);//true
            Console.WriteLine(i.Equals(j)); //true
        }

        /// <summary>
        /// 引用类型比较
        /// </summary>
        public void Test02()
        {
            var a = new People("ABC");
            var b = new People("ABC");

            Console.WriteLine(a == b); //false
            Console.WriteLine(a.Equals(b)); //false
            b = a;
            Console.WriteLine(a == b);//true
            Console.WriteLine(a.Equals(b)); //true
        }

        /// <summary>
        /// 重写Equals operator ==
        /// </summary>
        public void Test03()
        {
            var a = new Unit(123456);
            var b = new Unit(12345);

            Console.WriteLine(a == b); //false
            Console.WriteLine(a.Equals(b)); //false
            b.ID = 123456;
            Console.WriteLine(a == b);//false
            Console.WriteLine(a.Equals(b)); //true
        }

        /// <summary>
        /// 重写判断符之后 
        /// 用ReferenceEquals 判断引用原示例是否相等
        /// </summary>
        public void Test04()
        {
            var a = new Unit(123456);
            var b = new Unit(123456);
            Console.WriteLine(a == b); //true
            Console.WriteLine(a.Equals(b)); //true
            Console.WriteLine(ReferenceEquals(a, b));//false
        }

        private class People
        {
            public string Name { get; set; }

            public People(string name)
            {
                Name = name;
            }
        }

        private class Unit
        {
            public int ID { get; set; }

            public Unit(int id)
            {
                ID = id;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Unit o))
                {
                    return false;
                }
                return ID == o.ID;
            }


            public static bool operator == (Unit unit, object obj)
            {
                if (!(obj is Unit o))
                {
                    return false;
                }

                return unit.ID == o.ID;
            }

            public static bool operator !=(Unit unit, object obj)
            {
                if (!(obj is Unit o))
                {
                    return false;
                }

                return unit.ID != o.ID;
            }

        }

    }
}
