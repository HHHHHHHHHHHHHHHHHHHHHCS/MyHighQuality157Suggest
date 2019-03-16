using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 托管代码中字符串是一个特殊类型,不能被改变.
    /// 每次用他的方法之一 或者运算 ,都要在内存中创建一个新的字符串,也就是分配了新的空间
    /// 那么问题来了!原来的字符串还是不是在内存中?如果在内存中那么机密数据该如何保存才够安全?
    /// 当你退出方法的时候,字符串也不一定回收,可能还在内存中
    /// 所以要加密字符串
    /// </summary>
    public class _118_使用SecureString保存密钥等机密字符串
    {

        /// <summary>
        /// 比如这段代码可以用断点
        /// 然后在dll中查看正在运行的内存
        /// </summary>
        public void Test01()
        {
            string str = "luminji";
            Console.WriteLine(str);//打上断点
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        public void Test02()
        {
            SecureString ss = new SecureString();
            foreach (var ch in "luminji")
            {
                ss.AppendChar(ch);
            }


            IntPtr addr = Marshal.SecureStringToBSTR(ss);//加密
            string temp = Marshal.PtrToStringBSTR(addr);//解密
            Marshal.ZeroFreeBSTR(addr);//释放内存

        }
    }
}
