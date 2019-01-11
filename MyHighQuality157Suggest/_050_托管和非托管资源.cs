using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 托管资源:
    ///     不要显式的去释放自己使用的内存资源.
    ///     系统内存匮乏时,进行GC,自动释放那些没有被使用的托管资源.
    ///     数组，用户定义的类、接口、委托，object,字符串等引用类型
    ///     栈上保存着一个地址而已，当栈释放后， 即使对象已经没有用了
    ///     但堆上分配的内存还在,只能等GC收集时才能真正释放.
    ///     但注意int,string,float,DateTime,struct之类的值类型,
    ///     GC会自动释放他们占用的内存,不需要GC来回收释放
    /// 非托管资源:
    ///     GC只能跟踪非托管资源的生存期,而不知道如何去释放它.
    ///     可以利用Dispose，Finalize(析构)来释放
    ///     用析构方法回收对象使用的内存需要至少两次垃圾回收.
    ///     所以有析构函数的对象，需要两次，第一次调用析构函数，第二次删除对象.
    ///     而且在析构函数中包含大量的释放资源代码，会降低垃圾回收器的工作效率，影响性能
    ///     所以对于包含非托管资源的对象，最好及时的调用Dispose()方法来回收资源
    ///     而不是依赖垃圾回收器。
    /// 
    ///     注意,不能在析构函数中释放托管资源
    ///     因为析构函数是有垃圾回收器调用的,可能在析构函数调用之前
    ///     类包含的托管资源已经被回收了,从而导致无法预知的结果
    /// </summary>
    public class _050_托管和非托管资源
    {

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
