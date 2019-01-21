using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用using或者finally在报错的时候也进行释放资源,
    /// </summary>
    public class _069_使用finally避免资源泄漏
    {
        public void Test01()
        {
            Sample sample = null;
            try
            {
                sample = new Sample();
                throw new Exception("2333");
            }
            finally
            {
                sample.Dispose();
            }
        }

        private class Sample : IDisposable
        {
            ~Sample()
            {
                Console.WriteLine("~Sample");
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose");
            }
        }
    }
}