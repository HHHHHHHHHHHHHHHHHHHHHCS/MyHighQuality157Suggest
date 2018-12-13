using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// const的效率比readonly高
    /// readonly的多变性适用情况比const 高
    /// </summary>
    public class _006_ConstReadonly
    {
        private const int constInt = 100;
        private const string constString = "吃饭";
        private readonly string readonlyString = "喝水";

        /// <summary>
        /// readonly在构造函数会赋值一边
        /// 看IL readonlyString会被先赋值成"喝水" 在赋值成"敦敦敦"
        /// 同时也说明了readonly是可以多次赋值的
        /// </summary>
        public _006_ConstReadonly()
        {
            readonlyString = "敦敦敦";
        }

        /// <summary>
        /// 下面对比IL代码会发现const 在编译的时候被替换了
        /// "吃饭饭" 也是一个cost
        /// 但是"吃饭饭饭"不是   如果是const 尽量加上const
        /// IL的优化 const比readonly好
        /// </summary>
        public void Test01()
        {
            Console.WriteLine(constInt);
            Console.WriteLine(99);

            Console.WriteLine(constString);
            Console.WriteLine("吃饭饭");
            var s = "吃饭饭饭";
            Console.WriteLine(s);
            const string cf = "吃饭饭饭饭";
            Console.WriteLine(cf);
            Console.WriteLine(readonlyString);
        }
    }
}