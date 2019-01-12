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
    /// 必要时应该将不再使用的对象引用赋值为null
    ///     虽然编译器会在局部代码的时候,自动为我们在末尾设置null
    /// 但是在static字段 引用的类会留下"根"
    ///     不会被自动清理,手动设置null
    /// 合理使用static变量
    /// </summary>
    public class _053_及时赋值null
    {

    }
}