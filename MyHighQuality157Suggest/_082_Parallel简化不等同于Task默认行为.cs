using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// Parallel简化不等同于Task默认行为
    /// Parallel只提供了Invoke没有提供BeginInvoke
    /// Parallel一直等待线程池中的相关工作全部完成,在告诉主线程完成了
    ///     而Task在不一定跟主线程挂钩
    /// </summary>
    public class _082_Parallel简化不等同于Task默认行为
    {

        public void Test01()
        {
            Task t = new Task(() =>
            {
                while (true)
                {

                }
            });
            t.Start();
            Console.WriteLine("主线程即将结束");
        }

        public void Test02()
        {
            Parallel.For(0, 1, (i) =>
            {
                while (true)
                {

                }
            });
            Console.WriteLine("主线程即将结束");
        }
    }
}
