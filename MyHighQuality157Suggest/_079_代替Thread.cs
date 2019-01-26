using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用ThreadPool 或者 BackgroundWorker 代替 Thread
    /// 用ThreadPool 线程池管理线程,避免无节制的开销.当一个工作完毕的时,线程池不会销毁这个线程,而是会保留一段时间
    ///     看是否有别的工作需要这个线程,销毁由CLR滋生的算法来决定
    /// 用BackgroundWorker.内部使用了线程池技术.给工作线程和UI线程提供了交互的能力:
    ///     报告进度,支持回调,取消任务,暂停任务
    /// 
    /// 空间开销
    /// 1.)线程内核对象.每个线程都会创建一个这样的对象,他主要包含线程上下文信息.
    ///     根据系统位大小改变,正常占用1kb左右
    /// 2.)线程环境块.里面包括线程的异常处理链.根据系统位大小改变,正常占用4kb左右
    /// 3.)用户模式栈,即线程栈.用于保存方法的参数,局部变量,返回值.每个线程栈占用1MB内存,
    ///     用完这些对方的方法是,写一个不能结束的递归方法,不停消耗内存,会异常OutOfMemoryException
    /// 4.)内核模式栈.当调用系统操作系统内核模式函数时,系统会将函数参数从线程栈复制到内核模式栈.
    ///     根据系统位大小改变,正常占用12kb左右
    ///
    /// 时间开销
    /// 1.)线程创建的时候,系统相机初始化以上这些内存空间的时间开销
    /// 2.)接着CLR会调用所有加载DLL的DLLMain方法,并传递连接标志
    ///     (线程终止的时候,也会调用DLL的DLLMain方法,并传递分离标志)
    /// 3.)线程上下文切换.一个系统中会加载很多的进程,而一个进程又包含若干个线程.
    ///     但是一个CPU在任何时候都只能有一个线程在执行.为了让每个线程看上去都在运行,
    ///     系统会不断的切换"线程上下文",每次切换大概有几十毫秒的时间.步骤如下
    ///     1.>进入内核模式
    ///     2.>将上下文信息保存到正在执行的线程内核对象上
    ///     3.>系统获取一个Spinlock,并确定下一个要执行的线程,释放Spinlock.
    ///         如果下一个线程不再同一个进程内,则需要进行虚拟地址交换
    ///     4.>将被执行的线程内核对象上载入上下文信息
    ///     5.>离开内核模式
    /// 
    /// </summary>
    public class _079_代替Thread
    {
        /// <summary>
        /// 使用ThreadPool
        /// </summary>
        public void Test01()
        {
            //Thread t = new Thread(() => { Console.WriteLine(1); });
            //t.Start();

            ThreadPool.QueueUserWorkItem((objState) => { Console.WriteLine(objState+"_____"+"Test"); }, "233");
            Thread.Sleep(100);
        }


        public void Test02()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;//要设置才能有进度条输出
            worker.DoWork += Test02_DoWork;
            worker.ProgressChanged += Test02_Changed;
            worker.RunWorkerAsync();
            Thread.Sleep(10000);
        }

        private void Test02_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            for (int i = 0; i < 10; i++)
            {
                worker.ReportProgress(i);
                Thread.Sleep(100);
            }
        }

        private void Test02_Changed(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.UserState}{e.ProgressPercentage.ToString()}");
        }
    }
}