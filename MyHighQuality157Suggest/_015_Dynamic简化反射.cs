using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用动态类型 来简化反射的写法
    /// 效率有点蛋疼
    /// </summary>
    public class _015_Dynamic简化反射
    {
        /// <summary>
        /// 书上说dynamic速度比较快
        /// 自己测试不一样
        /// 估计跟C#版本有关
        /// </summary>
        public void Test01()
        {
            int times = 1000000;

            Stopwatch sw = Stopwatch.StartNew(); 
            DynamicTest t1 = new DynamicTest();
            var addMethod = typeof(DynamicTest).GetMethod("Add");
            var delg = (Func<DynamicTest, int, int, int>)Delegate.CreateDelegate(
                typeof(Func<DynamicTest,int,int,int>),addMethod);
            for (var i = 0; i < times; i++)
            {
                int re = delg(t1, 1,2);
            }
            sw.Stop();
            Console.WriteLine($"typeof() time:{sw.ElapsedMilliseconds}");

            sw.Restart();
            dynamic dy = new DynamicTest();
            for (var i = 0; i < times; i++)
            {
                int re2 = dy.Add(1, 2);
            }
            sw.Stop();
            Console.WriteLine($"dynamic time:{sw.ElapsedMilliseconds}");

        }


        private class DynamicTest
        {
            public string Name { get; set; }

            public int Add(int a, int b)
            {
                return a + b;
            }

        }

    }
}
