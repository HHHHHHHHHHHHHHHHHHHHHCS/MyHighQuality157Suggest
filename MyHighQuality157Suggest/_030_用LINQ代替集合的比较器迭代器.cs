using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _030_用LINQ代替集合的比较器迭代器
    {
        private static List<Person> pList = new List<Person>()
            {

                new Person(){Name="D",Age=4,Money=4},
                new Person(){Name="A",Age=1,Money=1},
                new Person(){Name="B",Age=2,Money=2},
                new Person(){Name="C",Age=3,Money=3},
                new Person(){Name="F",Age=6,Money=6},
                new Person(){Name="G",Age=7,Money=7},
                new Person(){Name="H",Age=8,Money=8},
                new Person(){Name="E",Age=5,Money=5},
            };

        /// <summary>
        /// 之前的方法
        /// 1).可扩展性太低,如果存在新的阿脾虚要求,就必须实现新的接口
        /// 2).对代码侵入性太高,为类型继承了接口,增加了新的方法
        /// </summary>
        public void Test01()
        {

            pList.Sort();
            Console.WriteLine("Normal Sort():");
            foreach (var item in pList)
            {
                Console.Write(item.ToString());
            }

            pList.Sort(new Company());
            Console.WriteLine("\nAge Sort():");
            foreach (var item in pList)
            {
                Console.Write(item.ToString());
            }
        }

        /// <summary>
        /// LINQ 排序
        /// 不会影响原来的list
        /// 用迭代器实现
        /// </summary>
        public void Test02()
        {
            var list = from p in pList orderby p.Age select p;
            Console.WriteLine("\nAge Sort():");
            foreach (var item in list)
            {
                Console.Write(item.ToString());
            }

            list = from p in pList orderby p.Name descending select p;
            Console.WriteLine("\nName Sort():");
            foreach (var item in list)
            {
                Console.Write(item.ToString());
            }


        }

        private class Company : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                if (x.Age > y.Age)
                {
                    return 1;
                }
                else if (x.Age < y.Age)
                {
                    return -1;
                }
                return 0;
            }
        }

        private class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Money { get; set; }

            public int CompareTo(Person other)
            {
                return -1 * this.Money.CompareTo(other.Money);
            }

            public override string ToString()
            {
                return $"{Name},{Age},{Money}  ";
            }
        }
    }
}
