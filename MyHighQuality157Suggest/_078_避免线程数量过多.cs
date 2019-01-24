using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免线程数量过多
    /// 线程过多会分配内存,新起的线程可以需要等待想当长的时间才会真正的运行
    /// </summary>
    public class _078_避免线程数量过多
    {
        public void Test01()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread t = new Thread(() =>
                {
                    int j = i;
                    while (true)
                    {
                        Thread.Sleep(10);
                    }
                });
                t.IsBackground = true;
                t.Start();
            }

            Thread.Sleep(1000);
            Thread t2 = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("T2正在执行");
                    Thread.Sleep(10);
                }
            });
            t2.Start();
            Console.ReadKey();
        }
    }
}
