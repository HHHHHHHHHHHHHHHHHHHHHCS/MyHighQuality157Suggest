using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// TryParse Parse 效率比较
    /// </summary>
    public class _004_TryParse比Parse好
    {
        /// <summary>
        /// TryParse的效率比Parse要高 而且不用捕获异常有自动的初始值
        /// 也不是一味地使用try-do,如果do的效率比trydo效率高则可以使用
        /// </summary>
        public void Test01()
        {
            const string str1 = "123",str2="x1x2";
            double re;
            long ticks;
            var steps = 10000;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < steps; i++)
            {
                re = double.Parse(str1);
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.Parse() 成功,{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 1; i < steps; i++)
            {
                if (!double.TryParse(str1, out re))
                {
                    //re = 0;//这里其实也不用赋值 因为转换失败自动为0
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.TryParse() 成功,{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 0; i < steps; i++)
            {
                try
                {
                    re = double.Parse(str2);
                }
                catch
                {
                    re = 0;
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.Parse() 失败,{0} ticks", ticks);

            sw = Stopwatch.StartNew();
            for (int i = 1; i < steps; i++)
            {
                if (!double.TryParse(str1, out re))
                {
                    //re = 0;//这里其实也不用赋值 因为转换失败自动为0
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            Console.WriteLine("double.TryParse() 失败,{0} ticks", ticks);
        }
    }
}