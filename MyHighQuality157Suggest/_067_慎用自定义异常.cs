using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 除非有充分的理由,否则一般不要创建自定义异常
    /// 1.)方便调试.通过抛出一个自定的异常,我们可以捕获,并且精确知道发生了什么
    /// 2.)自定义异常可以包装多个其他异常,然后抛出一个业务异常
    /// 3.)方便调用者编码.比如:把保存数据失败,分成两个异常"数据库连接失败"和"网络异常"
    /// 4.)引入新异常类,这使程序员能够根据异常类在代码中采取不同的操作
    /// </summary>
    public class _067_慎用自定义异常
    {
    }
}
