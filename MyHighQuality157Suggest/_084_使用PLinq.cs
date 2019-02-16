using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 传统的Linq是单线程的,PLinq是并发的,多线程的
    /// </summary>
    public class _084_使用PLinq
    {
        /// <summary>
        /// 因为PLinq是并发多线程的,所以是无序的
        /// </summary>
        public void Test01()
        {
            List<int> intList = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var query = from p in intList select p;
            Console.WriteLine("下面是Linq并发");
            foreach (int item in query)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("下面是PLinq并发");
            var queryParallel = from p in intList.AsParallel() select p;
            foreach (var item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// AsOrdered能对结果进行排序,在查询后进行排序会消耗一定的性能
        /// 但是对forAll不起作用
        /// </summary>
        public void Test02()
        {
            List<int> intList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var queryParallel = from p in intList.AsParallel().AsOrdered() select p;
            foreach (var item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("---------------------------");
            queryParallel.ForAll(item => { Console.WriteLine(item.ToString()); });

        }


        /// <summary>
        /// 用Take无序选出前五个
        /// </summary>
        public void Test03()
        {
            List<int> intList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //指令预存,用到的时候直接先拿取,后Parallel
            var queryParallel = from p in intList.AsParallel().Take(5) select p;
            foreach (var item in queryParallel)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------");
            queryParallel = from p in intList.AsParallel() select p;
            //先执行Linq转换Parallel,在拿取5个
            foreach (var item in queryParallel.Take(5))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
