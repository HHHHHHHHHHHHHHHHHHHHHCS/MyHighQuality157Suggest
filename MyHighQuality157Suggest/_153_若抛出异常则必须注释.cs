using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 必须加注释的场景就是异常
    /// 如果API抛出异常 则必须给出注释
    /// 调用者必须通过注释才能知道如何处理那些专有的异常
    /// 就算良好的命名也不能告诉我们会有哪些异常
    /// 
    /// </summary>
    public class _153_若抛出异常则必须注释
    {

        /// <summary>
        /// 注释
        /// </summary>
        /// <param name="value">输入参数注释</param>
        /// <returns>返回值注释</returns>
        /// <exception cref="System.IO.IOException"如果被占用,则抛出IOException</exception>
        public string SampleClass(int value)
        {
            if (true)
            {
                throw new IOException("一些IO异常");
            }
        }
    }
}
