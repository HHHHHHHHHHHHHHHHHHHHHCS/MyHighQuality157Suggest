using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 以复数命名枚举类型,以单数命名枚举元素
    /// 比如Week对于星期几来说具有负数含义.
    /// 如果我们这里将Week修改为Day , Day.Monday 看起来就会很奇怪 意义不明
    /// </summary>
    public class _130_以复数命名枚举类型以单数命名枚举元素
    {
        public enum Week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        public enum Day
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
