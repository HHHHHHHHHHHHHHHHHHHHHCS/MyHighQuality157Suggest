using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 尽量把变量都写成get set,优势如下
    /// 1.把getset是方法,所以方法内可以进行更多的操作
    /// 2.因为是方法,可以通过方法内部实现线程安全
    /// 3.得到VS编辑器的支持,同时在LINQ中得到广泛引用
    /// 4.可以设置public get private set,安全
    /// 5.可以进行绑定,如果某个属性被修改了,在方法内部添加通知代码就好了
    /// </summary>
    public class _091_可见字段应该重构为属性
    {
        /// <summary>
        /// 可以通过ILC# 查看
        /// </summary>
        public string Name { get; set; }

    }
}
