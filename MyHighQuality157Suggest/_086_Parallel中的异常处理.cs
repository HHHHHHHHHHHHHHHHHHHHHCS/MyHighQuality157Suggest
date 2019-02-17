using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// _086_Parallel中的异常处理
    /// </summary>
    public class _086_Parallel中的异常处理
    {
        public void Test01()
        {
            try
            {
                var parallelExceptions = new ConcurrentQueue<Exception>();
                Parallel.For(0, 1, (i) =>
                {
                    try
                    {
                        throw new InvalidOperationException("并行任务中出现异常");
                    }
                    catch (Exception e)
                    {
                        parallelExceptions.Enqueue(e);
                    }

                    if (parallelExceptions.Count > 0)
                    {
                        throw new AggregateException(parallelExceptions);
                    }
                });
            }
            catch (AggregateException err)
            {
                foreach (var item in err.InnerExceptions)
                {
                    Console.WriteLine("异常类型:{0}{1}来自:{2}{3}异常内容:{4}", item.InnerException.GetType(),
                        Environment.NewLine, item.InnerException.Source, Environment.NewLine,
                        item.InnerException.Message);
                }

                Console.WriteLine("主线程马上结束");
            }

        }
    }
}
