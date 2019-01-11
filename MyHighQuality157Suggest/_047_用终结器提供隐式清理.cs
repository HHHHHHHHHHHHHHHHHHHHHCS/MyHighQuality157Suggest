using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 为了防止程序员忘了调用显式清理
    /// 用析构函数进行隐式清理
    /// </summary>
    public class _047_用终结器提供隐式清理 
    {

        /// <summary>
        /// 显示调用 和 自动清理
        /// 顺序如下:
        /// 手动Dispose
        /// using执行的Dispose
        /// 析构函数调用Dispose
        /// </summary>
        public void Test01()
        {
            using (SampleClass c = new SampleClass())
            {
                c.Dispose();
                Console.WriteLine("-----------------");
            }
        }


        private class SampleClass : IDisposable
        {
            /// <summary>
            /// 析构函数
            /// </summary>
            ~SampleClass()
            {
                Console.WriteLine("~");
                Dispose();
            }


            public void Dispose()
            {
                Console.WriteLine("Dispose");
            }
        }
    }
}