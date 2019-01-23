using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 警惕线程的IsBackground
    /// 如果为false,会等待其他线程执行结束,才会结束主线程
    /// 如果为true,主线程会不管其他线程,执行完了直接退出
    /// </summary>
    public class _074_警惕IsBackground
    {
        public void Test01()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("线程开始工作.......");
                Console.ReadKey();
                Console.WriteLine("线程结束");
            });
            //默认就是falase
            t.IsBackground = false;
            t.Start();
            Console.WriteLine("主线程执行完毕");
        }

        public void Test02()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("线程开始工作.......");
                Console.ReadKey();
                Console.WriteLine("线程结束");
            });
            //默认就是falase
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("主线程执行完毕");
        }
    }
}
