using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 继承IDisposable 释放
    /// </summary>
    public class _046_显示释放IDisposable
    {
        /// <summary>
        /// 默认finally释放
        /// </summary>
        public void Test01()
        {
            SampleClass c1 = null;
            try
            {
                c1 = new SampleClass();
            }
            finally
            {
                c1?.Dispose();
            }
        }

        /// <summary>
        /// using释放
        /// </summary>
        public void Test02()
        {
            using (SampleClass c1 = new SampleClass())
            {
            }

            using (SampleClass c1 = new SampleClass(), c2 = new SampleClass())
            {
            }

            using (SampleClass c1 = new SampleClass())
            {
                using (AnotherResources ar = new AnotherResources())
                {

                }
            }
        }


        private class SampleClass : IDisposable
        {
            //非托管资源
            private IntPtr nativeResources = Marshal.AllocHGlobal(100);

            //托管资源
            private AnotherResources anotherResources = new AnotherResources();

            private bool disposed = false;

            public void Dispose()
            {
                Dispose(true);
                //释放自己
                GC.SuppressFinalize(this);
            }

            public void Close()
            {
                Dispose();
            }

            ~SampleClass()
            {
                Dispose(false);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposed)
                {
                    return;
                }

                if (disposing)
                {
                    //清理普通资源
                    if (anotherResources != null)
                    {
                        anotherResources.Dispose();
                        anotherResources = null;
                    }

                    //清理非托管资源
                    if (nativeResources != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(nativeResources);
                        nativeResources = IntPtr.Zero;
                    }

                    disposed = true;
                }
            }
        }

        private class AnotherResources : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}