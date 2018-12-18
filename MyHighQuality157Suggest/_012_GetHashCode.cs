using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 引用类型是否要重写GetHashCode
    /// 来进行比较和存储
    /// </summary>
    public class _012_GetHashCode
    {
        /*
         * 值类型如果值一样则GetHashCode 一样 hashcode为值 Test04()
         * struct 看第一个字段 Test03()
         * string 看字符串匹配 Test02()
         * 引用类型看初始化的时候生成一个固定的整数 Test01()
         * 但是hashcode在不同引用类型的时候还是可能会重复的 Test05()
         *
         */

        private static readonly Dictionary<Person, PersonMoreInfo> personList
            = new Dictionary<Person, PersonMoreInfo>();

        /// <summary>
        /// 重写了Equals 但是没有重写GetHashCode
        /// </summary>
        public void Test01()
        {
            Person mike = new Person("mike");
            PersonMoreInfo mikeInfo = new PersonMoreInfo()
            {
                Age = 1,
                Mail = "mike@mail.com",
                Address = "USA"
            };
            personList.Add(mike, mikeInfo);
            Console.WriteLine(personList.ContainsKey(mike)); //true
            Person mike2 = new Person("mike");
            Console.WriteLine(personList.ContainsKey(mike2)); //false
        }

        /// <summary>
        /// 重写GetHashCode 
        /// </summary>
        public void Test02()
        {
            List<People> list = new List<People>();
            People p1 = new People("p");
            People p2 = new People("p");
            list.Add(p1);
            list.Add(p2);
            Console.WriteLine("{0},{1},{2}", p1.GetHashCode(), p2.GetHashCode(), list.Count); //false
        }

        /// <summary>
        /// struct GetHashCode() 看第一个字段
        /// </summary>
        public void Test03()
        {
            Unit u1 = new Unit() {id = 0};
            Unit u2 = new Unit() {id = 0};
            Console.WriteLine("{0}  {1}", u1.GetHashCode(), u2.GetHashCode());
        }

        /// <summary>
        /// 基础类型 GetHashCode()
        /// </summary>
        public void Test04()
        {
            int i = 1;
            int j = 1;
            Console.WriteLine("{0}  {1}", i.GetHashCode(), j.GetHashCode());
        }

        /// <summary>
        /// GetHashCode()可能会重复
        /// </summary>
        public void Test05()
        {
            const string str1 = "NB0903100006";
            const string str2 = "NB0904140001";
            Console.WriteLine("{0}  {1}", str1.GetHashCode(), str2.GetHashCode());
        }


        private struct Unit
        {
            public int id;
            public int hp;
            public int mp;
        }


        private class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Person p))
                {
                    return false;
                }

                return p.Name == Name;
            }
        }


        private class People : IEquatable<People>
        {
            public string Name { get; set; }

            public People(string name)
            {
                Name = name;
            }

            public bool Equals(People other)
            {
                return other != null && other.Name == Name;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is People p))
                {
                    return false;
                }

                return p.Name == Name;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }


        private class PersonMoreInfo
        {
            public byte Age { get; set; }
            public string Mail { get; set; }
            public string Address { get; set; }
        }
    }
}