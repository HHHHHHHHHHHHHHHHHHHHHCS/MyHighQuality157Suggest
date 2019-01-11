using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// Dispose应该可以被多次调用
    /// 因为可能存在手动执行清理,之后系统自动清理
    /// </summary>
    public class _048_Dispose可被多次调用
    {
        /// <summary>
        /// 多次清理
        /// 这里执行了三次,手动Dispose,using Dispose,析构 Dispose
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
            public List<int> list = new List<int>();


            private bool isDisposed = false;

            /// <summary>
            /// 析构函数
            /// </summary>
            ~SampleClass()
            {
                Console.WriteLine("~");
                Dispose();
            }

            public SampleClass()
            {
                list = new List<int>();
            }


            public void Dispose()
            {
                if (isDisposed)
                {
                    return ;
                }

                isDisposed = true;
                Console.WriteLine("Dispose");
            }
        }
    }
}
