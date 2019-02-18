using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 并行所带的后台任务及任务的管理,都会带来一定的开销
    /// 如果一箱工作本来就可能很快完成,或者循环体本来就很小,那么并行的速度也许会比非并行要慢
    /// </summary>
    public class _088_并行并不是总是速度更快
    {
        public void Test01()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(string.Empty);
            }

            sw.Stop();
            Console.WriteLine("小循环同步耗时:{0}", sw.Elapsed);
            sw.Restart();

            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(string.Empty);
                }
            }


            sw.Stop();
            Console.WriteLine("大循环同步耗时:{0}", sw.Elapsed);
            sw.Restart();

            Parallel.For(0, 200, (i) =>
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(string.Empty);
                }
            });
            sw.Stop();
            Console.WriteLine("大循环并行耗时:{0}", sw.Elapsed);
            sw.Restart();
        }
    }
}
