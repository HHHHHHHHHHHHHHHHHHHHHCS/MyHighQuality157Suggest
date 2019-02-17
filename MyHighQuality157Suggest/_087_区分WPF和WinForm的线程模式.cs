using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 区分WPF和WinForm的线程模式
    /// 
    /// </summary>
    public class _087_区分WPF和WinForm的线程模式
    {
        /// <summary>
        /// WPF    模拟按钮点击  button,label
        /// </summary>
        public void Test01()
        {
            bool isErr = false;

            Task errT = new Task(() =>
            {
                Thread.Sleep(3000);
                isErr = true;
            });

            Task t = new Task(() =>
            {
                while (true)
                {

                    Console.WriteLine(DateTime.Now.ToString());
                    if (isErr)
                    {
                        throw new Exception("WPF出错");
                    }
                    else
                    {
                        Thread.Sleep(1000);

                    }
                }
            });

            t.ContinueWith(task =>
            {
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (var inner in ex.InnerExceptions)
                    {
                        Console.WriteLine(
                            $"异常类型:{inner.GetType()}{Environment.NewLine}来自:{inner.Source}{Environment.NewLine}异常内容:{inner.Message}");
                    }
                }
            },TaskContinuationOptions.OnlyOnFaulted);

            errT.Start();
            t.Start();

            Thread.Sleep(10000);
        }

        /// <summary>
        /// WinFom    用label.BeginInvoke'
        /// 这里用不到就不写了
        /// </summary>
        public void Test02()
        {

        }
    }
}
