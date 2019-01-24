using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 1.)线程不是立即启动的,也不是说停就停止的
    /// 2.)要正确停止线程,不在于调用者采取了什么行为(Thread.Abort()可以强制停止)
    ///    而更多依赖于工作线程是否能主动响应调用者的停止请求
    /// </summary>
    public class _077_正确停止线程
    {
        public void Test01()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("线程被终止了!");
                        break;
                    }

                    Console.WriteLine(DateTime.Now.Millisecond.ToString());
                    Thread.Sleep(10);
                }
            });
            t.Start();
            Thread.Sleep(100);
            cts.Cancel();
            //t.Abort();
        }
    }
}
