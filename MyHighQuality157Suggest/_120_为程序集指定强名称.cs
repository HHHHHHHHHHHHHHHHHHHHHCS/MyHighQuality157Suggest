using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 强名称设计之初有防止未授权的第三方软件非法执行
    /// 也可以避免出现"DLL HELL"的现象
    /// "DLL HELL"多个应用程序可能存在调用同一个DLL的情况.
    /// 强名称扩大了DLL的唯一标识性.
    ///
    /// 运行下面的CMD,就能创建key
    /// sn -k youprofile.snk
    /// 然后在属性->签名里面设置
    /// </summary>
    public class _120_为程序集指定强名称
    {
    }
}
