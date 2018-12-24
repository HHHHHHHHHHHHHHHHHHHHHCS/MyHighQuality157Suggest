using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用foreach 代替一些循环
    /// 但是foreach的时候是只读的不能改变值,且不能删除
    /// foreach自带try-catch
    /// 而且foreach代码简洁,看起来方便
    /// </summary>
    public class _017_用Foreach
    {
        /// <summary>
        /// 效率 比for快
        /// </summary>
        public void Test01()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i);
            }

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < list.Count; i++)
            {
                var x = list[i];
            }

            sw.Stop();
            var time1 = sw.ElapsedMilliseconds;

            sw.Restart();
            foreach (var item in list)
            {
            }

            Console.WriteLine($"{time1},{sw.ElapsedMilliseconds}");
        }

        /// <summary>
        /// 效率没有MoveNext()快
        /// 因为还有trycatch
        /// </summary>
        public void Test02()
        {
            var hash = new HashSet<int>();
            for (int i = 0; i < 10000000; i++)
            {
                hash.Add(i);
            }

            Stopwatch sw = Stopwatch.StartNew();
            var enumerator = hash.GetEnumerator();
            while (enumerator.MoveNext())
            {
                //Console.Write($"{enumerator.Current},");
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            foreach (var item in hash)
            {
                //Console.Write($"{enumerator.Current},");
            }

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}