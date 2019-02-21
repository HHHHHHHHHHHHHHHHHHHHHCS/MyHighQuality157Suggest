using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 优先考虑将基类或接口作为参数传递
    /// 这样我们可以更加灵活运用
    /// </summary>
    public class _097_优先考虑将基类或接口作为参数传递
    {
        //这样就可以利用 继承接口 直接去实现Take 了
        //public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        //{
        //    if (source == null)
        //    {
        //        throw new Exception("Source");
        //    }
        //
        //    return TakeIterator<TSource>(source, count);
        //}
    }
}
