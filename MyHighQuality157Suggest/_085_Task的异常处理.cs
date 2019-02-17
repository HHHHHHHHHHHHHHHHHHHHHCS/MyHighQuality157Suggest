using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 处理不是主线程的异常,最好把异常包装到主线程捕获
    /// ---------------------------------------------
    /// 任务调度器TaskScheduler提供了这样一个功能 TaskScheduler.UnobservedTaskException,
    /// 它有一个静态时间用于处理未捕获的异常,一般不建议这样使用,因为这个事件的回调是在进行垃圾回收的时候才发生
    /// </summary>
    public class _085_Task的异常处理
    {
        /// <summary>
        /// 用AggregateException包装,捕获异常,
        /// 如果有异常会阻碍当前线程
        /// </summary>
        public void Test01()
        {
            Task t = new Task(() => { throw new Exception("任务并行编码中产生的位置异常"); });
            t.Start();

            try
            {
                t.Wait();
            }
            catch (AggregateException e)
            {
                foreach (var item in e.InnerExceptions)
                {
                    Console.WriteLine("异常类型:{0},{1} 来自内容:{2},{3} 异常内容:{4}", item.GetType(), Environment.NewLine
                        , item.Source, Environment.NewLine, item.Message);
                }
            }
        }

        /// <summary>
        /// 不阻碍当前线程,进行输出异常,但是异常没有回到主线程
        /// </summary>
        public void Test02()
        {
            Task t = new Task(() => { throw new Exception("任务并行编码中产生的位置异常"); });
            t.Start();

            Task tEnd = t.ContinueWith(task =>
            {
                foreach (Exception item in task.Exception.InnerExceptions)
                {
                    Console.WriteLine("异常类型:{0},{1} 来自内容:{2},{3} 异常内容:{4}", item.GetType(), Environment.NewLine
                        , item.Source, Environment.NewLine, item.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            Console.WriteLine("主线程马上结束");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// 把异常包装到主线程,还是会阻塞主线程
        /// </summary>
        public void Test03()
        {
            Task t = new Task(() => { throw new Exception("任务并行编码中产生的位置异常"); });
            t.Start();

            Task tEnd = t.ContinueWith(task =>
            {
                foreach (Exception item in task.Exception.InnerExceptions)
                {
                    Console.WriteLine("异常类型:{0},{1} 来自内容:{2},{3} 异常内容:{4}", item.GetType(), Environment.NewLine
                        , item.Source, Environment.NewLine, item.Message);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            try
            {
                tEnd.Wait();
            }
            catch (AggregateException e)
            {
                foreach (var item in e.InnerExceptions)
                {
                    Console.WriteLine("异常类型:{0},{1} 来自内容:{2},{3} 异常内容:{4}", item.GetType(), Environment.NewLine
                        , item.Source, Environment.NewLine, item.Message);
                }
            }

            Console.WriteLine("主线程马上结束");
        }

        private event EventHandler<AggregateExceptionArgs> aggregateExceptCatched;

        public class AggregateExceptionArgs : EventArgs
        {
            public AggregateException AggregateException { get; set; }
        }

        /// <summary>
        /// 使用通知的方式,不阻塞主线程捕获异常
        /// </summary>
        public void Test04()
        {
            aggregateExceptCatched += Notifi_AggregateExceptCatched;
            Task t = new Task(() =>
            {
                try
                {
                    throw new Exception("任务并行编码中产生的位置异常");
                }
                catch (Exception e)
                {
                    AggregateExceptionArgs errArgs = new AggregateExceptionArgs()
                    {
                        AggregateException = new AggregateException(e)
                    };
                    aggregateExceptCatched(this, errArgs);
                }
            });

            t.Start();

            Console.WriteLine("主线程马上结束");
            Thread.Sleep(3000);

        }

        private void Notifi_AggregateExceptCatched(object sender, AggregateExceptionArgs e)
        {
            foreach (var item in e.AggregateException.InnerExceptions)
            {
                Console.WriteLine("异常类型:{0},{1} 来自内容:{2},{3} 异常内容:{4}", item.GetType(), Environment.NewLine
                    , item.Source, Environment.NewLine, item.Message);

            }
        }
    }
}