using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 线程有五个优先级:Highest,AboveNormal,Normal,BelowNormal,Lowest
    /// 如果线程有就绪状态并且优先级高的,会优先调用该线程
    /// 正常是Normal
    /// </summary>
    public class _076_线程优先级
    {
        public void Test01()
        {
            long t1Num = 0;
            long t2Num = 0;
            //取消的发送信号用
            CancellationTokenSource cts = new CancellationTokenSource();

            Thread t1 = new Thread(() =>
            {
                while ( !cts.Token.IsCancellationRequested)
                {
                    t1Num++;
                    Thread.Sleep(10);
                }
            });
            t1.Priority = ThreadPriority.Highest;
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    t1Num++;
                    Thread.Sleep(10);
                }
            });
            t2.Start();

            cts.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine($"t1Num:{t1Num}");
            Console.WriteLine($"t2Num:{t2Num}");
        }
    }
}
