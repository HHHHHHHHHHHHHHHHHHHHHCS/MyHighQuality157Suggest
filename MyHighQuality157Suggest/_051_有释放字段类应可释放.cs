using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 具有可释放字段的类型或拥有本机资源的类型应该是可以是释放的
    /// 这样别的类引用的时候就可以释放了
    /// </summary>
    public class _051_有释放字段类应可释放:IDisposable
    {
        private SampleClass res = new SampleClass();
        private bool disposed = false;

        ~_051_有释放字段类应可释放()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (res != null)
                {
                    res.Dispose();
                    res = null;
                }
            }

            disposed = true;
        }

        private class SampleClass : IDisposable
        {
            //非托管资源
            private IntPtr nativeResources = Marshal.AllocHGlobal(100);

            //托管资源
            private List<int> list = new List<int>();

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
                    if (list != null)
                    {
                        list = null;
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
    }
}
