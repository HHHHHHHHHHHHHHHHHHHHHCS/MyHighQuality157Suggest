using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 1.)同步对象在需要同步的多个线程中是可见的同一个对象
    /// 2.)在非静态方法中,静态变量不应作为同步对象.
    ///     类型的静态方法应当保证线程安全,非静态方法不需要实现线程安全
    /// 3.)值类型对象不能作为同步对象
    /// 4.)避免讲字符串作为同步对象
    ///     字符串一样的对象,可能在C#被当做同一个对象
    /// 5.)降低同步对象的可见性
    ///
    /// 
    /// </summary>
    public class _073_避免锁定不恰当对象
    {

        /// <summary>
        /// 用锁正确处理
        /// </summary>
        public void Test01()
        {
            AutoResetEvent autoSet = new AutoResetEvent(false);
            List<int> list = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};

            Thread t1 = new Thread(() =>
            {
                autoSet.WaitOne();
                lock (list)
                {
                    foreach (var item in list)
                    {
                        Thread.Sleep(200);
                    }

                    Console.WriteLine("输出完毕");
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                autoSet.Set();
                Thread.Sleep(1000);
                lock (list)//如果注释了就会报错
                {
                    list.Remove(0);
                }
                Console.WriteLine("删除完毕");
            });
            t2.Start();

        }
    }
}
