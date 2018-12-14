using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// Enum的初始值建议设成0
    /// 之后如果没有手动设置 则是自动+1的
    /// </summary>
    public class _007_Enum初始为0
    {
        private enum Number
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
        }

        private static Number num;

        /// <summary>
        /// 让enum 的第一个值为0
        /// 因为如果未赋值的enum的初始值 为0
        /// 我们的初始值如果为1 可能会出问题
        /// </summary>
        public void Test01()
        {
            Console.WriteLine(num); //out 0
        }

        private enum Number2
        {
            Zero = 0,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven
        }

        /// <summary>
        /// 值会自动加一
        /// </summary>
        public void Test02()
        {
            Number2 num = Number2.Five;
            Console.WriteLine(num);
            Console.WriteLine((int) num);
        }

        private enum Number3
        {
            Two = 2 << 1,
            Four = 2 << 2,
            Eight = 2 << 3,
            Sixteen = 2 << 4,
            ThirtyTwo = 2 << 5,
        }

        public void Test03()
        {
            Number3 num = Number3.Sixteen;
            Console.WriteLine(num);
            Console.WriteLine((int) num);
             num = Number3.Four | Number3.Eight;
            //这里输出24  而不是Number3.Four | Number3.Eight
            //因为要加flags 参考Test04()
            Console.WriteLine(num);
            Console.WriteLine((int)num);
        }


        [Flags]//位域,可以标记复合状态,位计算
        private enum Number4
        {
            Zero = 0x0,
            One = 0x1,
            Two = 0x2,
            Four = 0x4,
            Eight = 0x8,
            Sixteen = 0x16,
            ThirtyTwo = 0x32,
        }

        /// <summary>
        /// 使用Flags 进行复合显示和位运算
        /// </summary>
        public void Test04()
        {
            Number4 num = Number4.Four | Number4.Two;
            Console.WriteLine(num);
            Console.WriteLine((int)num);
        }
    }
}