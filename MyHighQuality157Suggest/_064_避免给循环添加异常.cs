using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免给循环添加异常,应该手动处理
    /// </summary>
    public class _064_避免给循环添加异常
    {
        /// <summary>
        /// 速度1<2<3种方法
        /// </summary>
        public void Test01()
        {
            int step = 1000000;
            int j;
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                for (int i = step; i >= 0; i--)
                {
                     j = 10 / i;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            sw.Stop();
            Console.WriteLine("1::::" + sw.ElapsedMilliseconds);

            sw.Restart();

            for (int i = step; i >= 0; i--)
            {
                try
                {
                     j = 10 / i;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            sw.Stop();
            Console.WriteLine("2::::" + sw.ElapsedMilliseconds);

            sw.Restart();

            for (int i = step; i >= 0; i--)
            {
                if (i == 0)
                {
                    Console.WriteLine("i must not equal zero");
                    continue;
                }

                 j = 10 / i;
            }

            sw.Stop();
            Console.WriteLine("3::::"+sw.ElapsedMilliseconds);
        }
    }
}