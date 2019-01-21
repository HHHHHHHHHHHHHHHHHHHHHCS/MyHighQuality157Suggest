using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 线程的本质
    ///   线程不是硬件的功能，是操作系统的一种逻辑功能
    ///   本质上是进程中一段并发运行的代码,所以线程需要操作系统投入CPU资源来运行和调度。
    /// 异步操作的优缺点
    ///   因为异步操作无须额外的线程负担,并且使用回调的方式进行处理
    ///   在设计良好的情况下,处理函数可以不必使用共享变量,减少了死锁的可能.
    ///   编写异步操作程序主要使用回调方式进行处理,而且难以调试。
    /// 多线程的优缺点
    ///   线程中的处理程序依然是顺序执行，符合普通人的思维习惯，所以编程简单。
    ///   线程的使用（滥用）会给系统带来上下文切换的额外负担。
    ///   并且线程间的共享变量可能造成死锁的出现。
    /// 适用范围
    ///  当需要执行I/O操作时，使用异步操作比使用线程+同步 I/O操作更合适。
    ///  I/O操作不仅包括了直接的文件、网络的读写，还包括数据库操作、Web Service、HttpRequest以及.net Remoting等跨进程的调用。
    ///  而线程的适用范围则是那种需要长时间CPU运算的场合，例如耗时较长的图形处理和算法执行。
    ///  由于使用线程编程的简单和符合习惯,所以很多朋友往往会使用线程来执行耗时较长的I/O操作。
    ///  这样在只有少数几个并发操作的时候还无伤大雅，如果需要处理大量的并发操作时就不合适了
    ///
    ///  计算密集型工作,采用多线程
    ///  IO密集型工作,采用异步机制
    /// </summary>
    public class _071_区分异步和多线程
    {
        /// <summary>
        /// 多线程去访问网页请求,不建议
        /// </summary>
        public void Test01()
        {
            Thread t = new Thread(() =>
            {
                var request = WebRequest.Create("https://www.baidu.com/");
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    string content;
                    while ((content = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(content);
                    }
                }
            });
            t.Start();
        }

        /// <summary>
        /// 异步请求网络,建议
        /// </summary>
        public void Test02()
        {
            var request = WebRequest.Create("https://www.baidu.com/");
            request.BeginGetResponse((/*IAsyncResult*/ar) =>
            {
                var web = ar.AsyncState as WebRequest;
                var response = web.EndGetResponse(ar);
                var stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    string content;
                    while ((content = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(content);
                    }
                }
            }, request);
        }
    }
}
