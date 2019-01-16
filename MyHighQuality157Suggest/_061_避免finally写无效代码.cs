using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免无效finally代码
    /// 有时候出错,会不执行catch finally
    /// </summary>
    public class _061_避免finally写无效代码
    {
        public void Test01()
        {
            Console.WriteLine(Test01_01()); //输出1
            Console.WriteLine(Test01_02()); //输出2
        }

        /// <summary>
        /// finally赋值输出1
        /// </summary>
        private int Test01_01()
        {
            int i = 0;
            try
            {
                i = 1;
            }
            finally
            {
                i = 2;
            }

            return i;
        }

        /// <summary>
        /// try被后执行,输出2
        /// </summary>
        private int Test01_02()
        {
            int i = 0;
            try
            {
                i = 1;
                return i ;
            }
            finally
            {
                Console.WriteLine("finally");
                i = 2;
            }

            return i;
        }


        public void Test02()
        {
            Console.WriteLine(Test02_01().Name);
        }

        /// <summary>
        /// 这里返回两个B,引用的问题
        /// </summary>
        private Person Test02_01()
        {
            Person p = new Person() { Name = "A", Age = 1 };

            try
            {
                return p;
            }
            finally
            {
                p.Name = "B";
                Console.WriteLine(p.Name);
            }
            return p;
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}