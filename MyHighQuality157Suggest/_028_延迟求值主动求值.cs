using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 看查询是否是立即执行的
    /// </summary>
    public class _028_延迟求值主动求值
    {
        /// <summary>
        /// 比如延迟求值,在用到迭代器的时候在执行
        /// </summary>
        public void Test01()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var temp1 = from c in list where c > 5 select c;
            var temp2 = (from c in list where c > 5 select c).ToList<int>();

            list[0] = 11;
            Console.Write("temp1:");
            foreach (var item in temp1)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.Write("\ntemp1:");
            foreach (var item in temp2)
            {
                Console.Write(item.ToString() + " ");
            }
        }


        /// <summary>
        /// 延迟求值效率会好一点
        /// 延迟求值 有时候C# 会自动合并两句LINQ 进行执行
        /// 比立即求值 tolist之后再LINQ 会快一点
        /// </summary>
        public void Test02()
        {
            List<Person> pList = new List<Person>()
            {
                new Person("a1",1),
                new Person("b2",2),
                new Person("c1",3),
                new Person("d2",4),
                new Person("e1",5),
                new Person("f2",6),
            };

            var temp1 = from p in pList where p.Age >= 3 select p;
            var temp2 = from p in temp1 where p.Name.IndexOf('1') > 0 select p;

            foreach (var item in temp2)
            {
                Console.WriteLine($"{ item.Name},{item.Age}");
            }

        }


        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

    }
}
