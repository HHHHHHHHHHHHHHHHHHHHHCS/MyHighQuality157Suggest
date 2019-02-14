using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// ThreadPool相对于Thread来说具有很多优势,但是存在一定的不方便
    /// ThreadPool不支持线程取消,完成,失败,通知等交互性操作
    /// ThreadPool不支持线程执行的先后次序
    /// </summary>
    public class _080_用Task代替ThreadPool
    {
        //IsCanceled 因为被取消而完成
        //IsCompleted 成功完成
        //IsFaulted 因为发生异常完成
        public void Test01()
        {
            Task t = new Task(() =>
            {
                Console.WriteLine("任务开始工作......");
                Thread.Sleep(5000);
            });
            t.Start();
            t.ContinueWith((task) =>
            {
                Console.WriteLine("任务完成,完成时候状态为:");
                Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCanceled,
                    task.IsFaulted);
            });
            Thread.Sleep(10000);
        }

        /// <summary>
        /// 手动完成 异常完成
        /// </summary>
        public void Test02()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> t = new Task<int>(() => Add(cts.Token), cts.Token);
            t.Start();
            t.ContinueWith(TaskEnded);
            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();
        }

        private void TaskEnded(Task<int> task)
        {
            Console.WriteLine("任务完成,完成时候状态为:");
            Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCanceled,
                task.IsFaulted);
            Console.WriteLine("任务的返回值为{0}", task.Result);
        }

        private int Add(CancellationToken ct)
        {
            Console.WriteLine("任务开始...");
            int result = 0;
            while (!ct.IsCancellationRequested)
            {
                result++;
                if (result == 5)
                {
                    throw new Exception("error: result is 5");
                }
                Thread.Sleep(1000);
            }

            return result;
        }

        /// <summary>
        /// 任务工厂的概念,共享相同的状态
        /// </summary>
        public void Test03()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            TaskFactory taskFactory = new TaskFactory();
            Task[] tasks = new Task[]
            {
                taskFactory.StartNew(()=>Add(cts.Token)),
                taskFactory.StartNew(()=>Add(cts.Token)),
                taskFactory.StartNew(()=>Add(cts.Token)),
            };
            taskFactory.ContinueWhenAll(tasks, TasksEnded, CancellationToken.None);
            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();
        }


        private void TasksEnded(Task[] tasks)
        {
            Console.WriteLine("所有任务完成");
        }
    }
}
