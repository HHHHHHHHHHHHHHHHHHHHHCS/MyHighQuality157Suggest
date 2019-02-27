using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 单例是一个实例对象,而静态类不是
    /// 静态类也直接违反面向对象散打特性中的两项 , 继承和多态.
    /// 在C#中,静态类不会被认为是一个"真正的对象"
    /// 而单例不会存在这样的问题
    /// </summary>
    public class _107_区分静态类和单例
    {

        interface ISample
        {

        }

        private static class SampleClass //: ISample//静态类不能实现接口
        {
            /// <summary>
            /// 不能让静态类作为参数和返回值进行传递
            /// </summary>
            //private static void SampleMethod(SampleClass sample)
            //{
            //
            //}
        }
    }
}
