using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 并行中谨慎用锁,比如某些需要同步运行的场合,或者需要较长时间锁定共享资源的场合
    /// </summary>
    public class _089_并行中谨慎用锁
    {
        /// <summary>
        /// 对于整数进行同步操作时,可以用静态类Interlocked的Add 方法
        /// 这就极大的避免了进行原子操作长时间锁定某个共享资源所带来的的同步性能消耗
        /// </summary>
        public void Test01()
        {
            int[] nums = new int[] {1, 2, 3, 4};
            int total = 0;
            Parallel.For<int>(0, nums.Length, () => 0, (i, loopState, subTotal) =>
                {
                    subTotal += nums[i];
                    return subTotal;
                },
                (x) => { Interlocked.Add(ref total, x); });
            Console.WriteLine("Total={0}", total);
        }

        /// <summary>
        /// 这里如果不用锁,原子操作,volatile关键字,Interlocked的Add 之类的会出错
        /// 这里用lock处理
        /// 由于锁的存在,系统的开销也增加了,同步带来的线程上下文切换,是我们牺牲了CPU时间和空间性能
        /// 简单来说这段代码还不如不用并行,在建议73中说过,锁就是让多线程变成单线程(因为同时只有一个线程能访问资源)
        /// </summary>
        public void Test02()
        {
            object o = new object();
            SampleClass sample = new SampleClass();
            Parallel.For(0, 100000000, (i) =>
            {
                lock (o)
                {
                    sample.SimpleAdd();
                }
            });
            Console.WriteLine(sample.SomeCount);
        }

        private class SampleClass
        {
            //public volatile int SomeCount = 0;
            public long SomeCount{ get; private set; }

            public void SimpleAdd()
            {
                SomeCount++;
            }
        }
    }
}
