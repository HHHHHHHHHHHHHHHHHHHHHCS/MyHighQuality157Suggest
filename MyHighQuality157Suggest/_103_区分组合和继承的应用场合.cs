using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 继承所带来的多态性虽然是面向对象的一个重要特性,但是这种特性不能在所有的应用场合做滥用.
    /// 继承应该被当作设计架构的有用补充,而不是全部
    /// 组合相对继承的一个重要的劣势,就是组合不能用于多态.
    /// 不过现状是,在大多数的开发场合下,组合使用的频率要远高于继承
    ///
    /// 不要为了让代码看起来像 面向对象 而滥用继承
    /// </summary>
    public class _103_区分组合和继承的应用场合
    {
        //-----继承-----

        private abstract class Stream
        {

        }

        private class FileStream : Stream
        {

        }

        private class MemoryStream : Stream
        {

        }

        //-----组合-----
        private class Context
        {

        }

        private class CultureInfo
        {

        }

        private class Thread
        {
            private Context context;
            private CultureInfo currentCulture;
        }

        //继承也可以继承接口,第一个方法可以返回多个Stream, 
        //第二个方法也可以处理多个Stream ,这提高了代码的复用性, 组合不具备这种特性
        private Stream SampleMethod1(bool condition)
        {
            return null;
        }

        private void SampleMethod2(Stream stream)
        {

        }


        //继承易于扩展,基类一旦扩展一个具有public internal protected 所有的子类会自动拥有接口
        //组合则不能 组合要拥有任何内部对象的行为, 必须手动编码
        //但是基类 不要过多层数的继承
    }
}
