using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在线程同步中使用信号量
    /// EventWaitHandle(子类AutoResetEvent,ManualResetEvent),Semaphore,Mutex都继承WaitHandle
    ///
    /// 区分这三个
    /// EventWaitHandle维护一个bool,false->等待线程阻塞,true->解除阻塞,调用Set()可以设置为true
    ///   两个子类AutoResetEvent,ManualResetEvent区别不大
    /// Semaphore维护一个整型变量,如果值为0,阻塞线程,大于0接触阻塞,每解除一个线程阻塞就-1
    /// EventWaitHandle,Semaphore都是单应用程序域内的线程同步功能.
    /// Mutex不同,提供了跨应用程序域阻塞和解除阻塞线程的能力.
    /// </summary>
    public class _072_线程同步用信号量
    {
        /// <summary>
        /// AutoResetEvent,会自动将阻滞状态变成false
        /// 所以只执行一次
        /// </summary>
        public void Test01()
        {
            //构造函数的bool,表述初始状态就是终止状态
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("Thread1 Start");
                autoResetEvent.WaitOne();
                Console.WriteLine("Doing1");

            });

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("Thread2 Start");
                autoResetEvent.WaitOne();
                Console.WriteLine("Doing2");

            });
            t1.Start();
            t2.Start();
            Thread.Sleep(1);
            Console.WriteLine("Set");
            autoResetEvent.Set();
        }

        /// <summary>
        /// ManualResetEvent,需要手动设置阻滞状态为false
        /// 比如这里就一个信号量,所以应该只执行一次,
        /// </summary>
        public void Test02()
        {
            //构造函数的bool,表述初始状态就是终止状态
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("Thread1 Start");
                manualResetEvent.WaitOne();
                Console.WriteLine("Doing1");

            });

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("Thread2 Start");
                manualResetEvent.WaitOne();
                Console.WriteLine("Doing2");

            });
            t1.Start();
            t2.Start();
            Thread.Sleep(1);
            Console.WriteLine("Set");
            manualResetEvent.Set();
        }

    }
}
