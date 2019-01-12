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
    /// 序列化:对象->流
    /// 
    /// 为什么要序列化:
    ///     1.)把对象保存在本地,下次运行程序的时候,恢复对象
    ///     2.)把对象传到网络中的另外一个电脑,在另外一个电脑还原对象
    ///     3.)复制到粘贴板,ctrl+v恢复
    /// 为什么要无用字段不可序列化:
    ///     1.)节省空间.类型在系列化后往往会储存在某个地方,避免不要的空间浪费.
    ///     2.)反序列化后字段信息没有意义.
    ///     3.)字段因为业务上的原因不允许序列化.比如明文密码不应该被序列化后保存在文件中.
    ///     4.)字段本身对应的类型在代码中未被设定为可序列化,那它该标注不可序列化,否则运行时会抛出异常SerializationException
    /// 添加Serializable后,默认所有的字段会被标记成可序列化
    /// </summary>
    public class _054_为无用字段添加不可序列化
    {

    }
}