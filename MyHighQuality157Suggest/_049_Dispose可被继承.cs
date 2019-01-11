using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _049_Dispose可被继承
    {
        public void Test01()
        {
            using (Cls cls = new Cls())
            {
                cls.Dispose();
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


            public virtual void Dispose()
            {
                if (isDisposed)
                {
                    return;
                }

                isDisposed = true;
                Console.WriteLine("SampleClass Dispose");
            }
        }

        private class Cls : SampleClass
        {
            private List<string> list;

            private bool isDisposed = false;

            public Cls()
            {
                list = new List<string>();
            }

            public override void Dispose()
            {
                if (isDisposed)
                {
                    return;
                }

                isDisposed = true;

                list = null;
                Console.WriteLine("Cls Dispose");

                base.Dispose();
            }
        }
    }
}