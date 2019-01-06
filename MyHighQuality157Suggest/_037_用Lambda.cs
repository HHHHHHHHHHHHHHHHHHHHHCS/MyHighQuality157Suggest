using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用Lambda 替代方法和匿名方法
    /// </summary>
    public class _037_用Lambda
    {
        /// <summary>
        /// 老的方式一
        /// </summary>
        public void Test01()
        {
            //1-----
            Func<int, int, int> add1 = Add;
            Action<string> print1 = Print;
            print1(add1(1, 2).ToString());

            //2-----
            Func<int, int, int> add2 = new Func<int, int, int>(
            delegate (int i, int j)
            {
                return i + j;
            });
            Action<string> print2 = new Action<string>(delegate (string msg)
            {
                Console.WriteLine(msg);
            });
            print2(add2(1, 2).ToString());

            //3-----
            Func<int, int, int> add3 = delegate (int i, int j)
            {
                return i + j;
            };
            Action<string> print3 = delegate (string msg)
            {
                Console.WriteLine(msg);
            };
            print3(add3(1, 2).ToString());
        }

        /// <summary>
        /// Lambda函数
        /// </summary>
        public void Test02()
        {
            Func<int, int, int> add = (i, j) =>
              {
                  return i + j;
              };
            Action<string> print = (msg) =>
            {
                Console.WriteLine(msg);
            };

            print(add(1, 2).ToString());
        }


        private int Add(int i, int j)
        {
            return i + j;
        }

        private void Print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
