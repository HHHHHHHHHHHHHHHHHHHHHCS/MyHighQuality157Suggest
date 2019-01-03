using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// IEnumerable<T> ,IQueryable<T>
    /// IQueryable<T>继承了IEnumerable<T>
    /// 区别是 LINQ分为三大类 LINQ to OBJECTS,LINQ to SQL,LINQ to XML
    /// 针对IE->objects用   针对IQ->SQL用
    /// IE 查询的逻辑可以直接用我们自己所定义的方法
    /// IQ则不行,他必须先生成表达树,如果强行用自定义方法,则会抛出异常
    /// </summary>
    public class _029_区别LINQ的IE和IQ
    {
        /// <summary>
        /// 因为没有装SQL,所以乱写
        /// AsEnumerable把远程数据转成本地的数据 就变成用IE了
        /// </summary>
        public void Test01()
        {
            /*
            SQL sql = sql.Connect("xxxx");
            Table<Person> persons = sql.GetTable<Person>();

            var temp1 = (from p in persons where p.Age > 20 select p)
                .AsEnumerable<Person>();
            var temp2 = from p in temp1 where p.Name.IndexOf('x') > 0 select p;

            foreach(var item in temp2)
            {
                Console.WriteLine(item);
            }
            */
        }

        /// <summary>
        /// 因为没有装SQL
        /// 这里的数据都是服务器SQL的,所以是IE
        /// </summary>
        public void Test02()
        {
            /*
            SQL sql = sql.Connect("xxxx");
            Table<Person> persons = sql.GetTable<Person>();

            var temp1 = (from p in persons where p.Age > 20 select p);
            var temp2 = from p in temp1 where p.Name.IndexOf('x') > 0 select p;

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }
            */
        }

        /// <summary>
        /// 这里的IQ 用了自定义的方法,会报错
        /// </summary>
        public void Test03()
        {
            /*
            SQL sql = sql.Connect("xxxx");
            Table<Person> persons = sql.GetTable<Person>();

            var temp1 = (from p in persons where OldThan(p.Age) select p);
            var temp2 = from p in temp1 where p.Name.IndexOf('x') > 0 select p;

            foreach (var item in temp2)
            {
                Console.WriteLine(item);
            }
            */
        }

        private bool OldThan(int age)
        {
            return age > 20;
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
