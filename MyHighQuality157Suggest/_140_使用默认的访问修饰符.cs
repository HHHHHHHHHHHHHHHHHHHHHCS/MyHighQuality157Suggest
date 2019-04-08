using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 省略一些没有意义的修饰符
    /// 这也有利于我们了解Code的默认行为
    /// 但是我不喜欢和建议 internal 除外
    /// </summary>
    public class _140_使用默认的访问修饰符
    {
        /// <summary>
        /// 有private和没有 是一样的效果
        /// </summary>
        private string name0;

        private void SampleMethod0()
        {

        }

        string name1;

        void SampleMethod1()
        {

        }

        /// <summary>
        /// 有internal和没有 是一样的效果
        /// </summary>
        internal class Class0
        {

        }

        class Class1
        {

        }
    }
}
