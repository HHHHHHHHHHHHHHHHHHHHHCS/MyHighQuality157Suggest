using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 类型成员如果优先考虑公开基类型或接口,那么会让类型支持更多的应用场合
    /// </summary>
    public class _096_成员优先考虑公开基类型或接口
    {
        //IEnumerable因为实现接口
        //所以现在所有的集合子类都可以不是实现自己的Empty方法
        //这样就能灵活运用
        //private class Sample<TResult> : IEnumerable<TResult>
        //{
        //    public IEnumerable<TResult> Empty<TResult>()
        //    {
        //        return EmptyEnumerable<TResult>.Instance;
        //    }
        //}

    }
}
