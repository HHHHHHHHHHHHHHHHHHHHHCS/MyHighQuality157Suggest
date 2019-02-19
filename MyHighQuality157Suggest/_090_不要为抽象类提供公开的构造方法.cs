using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 抽象类的构造方法不应该是public或者internal.
    /// 抽象类的只能让子类继承,而不是用于生成实例对象.
    /// 如果抽象类是public或者internal的,对于其他类就是可见的.
    /// 这是没有必要的,只用对于子类可见就行
    /// </summary>
    public class _090_不要为抽象类提供公开的构造方法
    {
        private abstract class Abs_Class
        {
            protected Abs_Class(){}
        }
    }
}
