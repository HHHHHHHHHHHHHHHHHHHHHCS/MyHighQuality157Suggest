using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 警惕线程不会立即启动
    /// </summary>
    public class _075_警惕线程不会立即启动
    {
        /// <summary>
        /// 输出不正确
        /// </summary>
        public void Test01()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() => { Console.WriteLine("{0},{1}", Thread.CurrentThread.Name, i); });
                t.Name = "Thread:" + i;
                t.Start();
            }
        }


        public void Test02()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() =>
                {
                    int id = i;
                    Console.WriteLine("{0},{1}", Thread.CurrentThread.Name, id);
                });
                t.Name = "Thread:" + i;
                t.Start();
            }
        }
    }
}