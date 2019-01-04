using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 有时候LINQ只想返回一个值
    /// 可以不用集合,避免不必要的迭代
    /// </summary>
    public class _031_LINQ避免不必要的迭代
    {
        /// <summary>
        /// 第一个迭代了8次
        /// 第二个迭代了5次
        /// 因为第二个找到答案就直接返回了
        /// </summary>
        public void Test01()
        {
            MyList list = new MyList();
            var temp1 = (from c in list where c.Age > 4 select c).ToList();
            Console.WriteLine(list.IteratedNum.ToString());

            var temp2 = (from c in list where c.Age > 4 select c).First();
            Console.WriteLine(list.IteratedNum.ToString());
        }

        /// <summary>
        /// Take是拿取几个
        /// 因为查询是延迟求值的,所以迭代次数会先卡在那
        /// 只有在用到的的时候,才会去把剩下的拿取掉
        /// </summary>
        public void Test02()
        {
            MyList list = new MyList();
            var temp1 = (from c in list where c.Age ==6 select c).First();
            Console.WriteLine(list.IteratedNum.ToString());

            var temp2 = (from c in list where c.Age ==6 select c).Take(3);
            Console.WriteLine(list.IteratedNum.ToString());


            foreach(var item in temp2)
            {

            }
            Console.WriteLine(list.IteratedNum.ToString());
        }

        private class MyList : IEnumerable<Person>
        {
            private List<Person> pList = new List<Person>()
            {
                new Person(){Name="A",Age=1,Money=1},
                new Person(){Name="B",Age=2,Money=2},
                new Person(){Name="C",Age=3,Money=3},
                new Person(){Name="D",Age=4,Money=4},
                new Person(){Name="E",Age=6,Money=5},
                new Person(){Name="F",Age=6,Money=6},
                new Person(){Name="G",Age=6,Money=7},
                new Person(){Name="H",Age=6,Money=8},
            };

            /// <summary>
            /// 迭代的次数
            /// </summary>
            public int IteratedNum { get; set; }

            public Person this[int i]
            {
                get { return pList[i]; }
                set { pList[i] = value; }
            }

            public IEnumerator<Person> GetEnumerator()
            {
                IteratedNum = 0;
                foreach (var item in pList)
                {
                    IteratedNum++;
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return pList.GetEnumerator();
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Money { get; set; }


            public override string ToString()
            {
                return $"{Name},{Age},{Money}  ";
            }
        }
    }
}
