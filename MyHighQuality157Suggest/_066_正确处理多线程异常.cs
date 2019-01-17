using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 正确处理多线程的异常,应该在线程内处理
    /// 或者丢给统一的异常处理器
    /// </summary>
    public class _066_正确处理多线程异常
    {
        public event Action<Exception> events;

        public _066_正确处理多线程异常()
        {
            events += Console.WriteLine;
        }

        /// <summary>
        /// 错误的做法
        /// </summary>
        public void Test01()
        {
            try
            {
                Thread t = new Thread(() => throw new Exception("fuck"));
                t.Start();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 正确的做法
        /// </summary>
        public void Test02()
        {
            Thread t = new Thread(() => {
                try
                {
                    throw new Exception("ohhhh");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
            t.Start();
        }

        /// <summary>
        /// 丢给统一处理器
        /// </summary>
        public void Test03()
        {
            Thread t = new Thread(() => {
                try
                {
                    throw new Exception("ohhhh");
                }
                catch (Exception e)
                {
                    events(e);
                }
            });
            t.Start();
        }
    }
}
