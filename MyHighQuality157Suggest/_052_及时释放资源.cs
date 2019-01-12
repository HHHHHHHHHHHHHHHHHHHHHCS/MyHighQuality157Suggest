using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 当我们不及时关闭一些资源
    ///     比如我们打开一个文件,却没有关闭
    ///     再次打开的时候,就会报占用的错误
    /// -----------------------------------
    /// 什么时候回收:
    ///     1.系统具有低的物理内存
    ///     2.托管堆上已分配的对象使用的内存超出了可接受的范围
    ///     3.手动调用GC.Collect()
    /// 垃圾回收有"代"的概念.分为3代:0代,1代,2代.
    ///     0代包含短期生存对象.
    ///     对象被丢到0代,不会立马回收.
    ///     只有当0代满的时候,低内存的时候才会进行回收.
    /// ------------------------------------
    /// 当一些出异常的时候不会立马进行回收
    /// </summary>
    public class _052_及时释放资源
    {
        /// <summary>
        /// 这是最正常的及时回收
        /// </summary>
        public void Test01()
        {
            FileStream fileStream = new FileStream(@"C:\test.txt", FileMode.Open);
            fileStream.Dispose();
        }

        /// <summary>
        /// 但是如果Test01报错,可能就不会回收了
        /// 所以可以用try catch finally 捕获
        /// </summary>
        public void Test02()
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(@"C:\test.txt", FileMode.Open);
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        /// <summary>
        /// 当然也可以用using 自动释放
        /// </summary>
        public void Test03()
        {
            using (FileStream fileStream 
                = new FileStream(@"C:\test.txt", FileMode.Open))
            {
            }
        }
    }
}