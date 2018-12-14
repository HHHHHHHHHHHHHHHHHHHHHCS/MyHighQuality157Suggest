using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _008_避免给枚举提供显示值
    {
        private enum Number
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            tempValue,
            Five = 5,
            Six = 6,
            Seven = 7,
        }

        /// <summary>
        /// 尽量避免给enum 加重复的int
        /// </summary>
        public void Test01()
        {
            Number num = Number.tempValue;
            Console.WriteLine(num);
            Console.WriteLine((int) num);
            Console.WriteLine(num == Number.Five);//这里为true 哦
            Console.WriteLine(num.Equals(Number.Five));//这里为true 哦
        }

    }
}
