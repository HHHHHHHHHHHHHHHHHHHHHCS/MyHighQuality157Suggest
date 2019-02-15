using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 小心Parallel中的陷阱
    /// Parallel是可以监视线程的状态而不是任务的状态
    /// 我们不能确定Parallel为了执行代码,启动了多少个线程,而导致自己的代码出现纰漏
    /// </summary>
    public class _083_小心Parallel中的陷阱
    {
        public void Test01()
        {
            
            int[] nums = new int[] {0, 1, 2, 3};
            int total = 0;
            //三个匿名方法分别为 执行前,执行中,执行完 
            Parallel.For<int>(0, nums.Length
                , () =>
                {
                    Console.WriteLine("执行方法1");
                    return 1;//每次执行把SubTotal初始化为1
                }
                , (i, loopState, subTotal) =>
                {//for loop执行中
                    subTotal += nums[i];
                    Console.WriteLine($"{i},{loopState}, {subTotal}");
                    return subTotal;
                }
                ,//收尾工作
                (x)=> Interlocked.Add(ref total,x));
            Console.WriteLine("total={0}", total);
        }

        /// <summary>
        /// 这里如果启动多个线程,则会出现多个 -
        /// 如果只启动一个线程 只会出现一个 -
        /// 我们无法预估C#会启动多少个线程
        /// </summary>
        public void Test02()
        {
            string[] stringArr = new string[]
            {
                "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh"
            };

            string result = string.Empty;
            Parallel.For<string>(0, stringArr.Length, () => "-",
                (i, loopState, subResult) => { return subResult += stringArr[i]; },
                (threadEndString) =>
                {
                    result += threadEndString;
                    Console.WriteLine("Inner:" + threadEndString);
                });
            Console.WriteLine(result);

        }
    }
}
