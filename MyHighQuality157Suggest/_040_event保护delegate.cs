using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用event保护委托delegate
    /// 1.)另起一个线程,把委托null,可能会报错
    /// 2.)可以直接外部调用delegate
    /// </summary>
    public class _040_event保护delegate
    {
        public delegate void Act_dg();
        public Act_dg acts;
        public event Act_dg Act_event;

        /// <summary>
        /// 会报错
        /// </summary>
        public void Test01()
        {
            //会报错
            //acts = null;
            //acts(); 

            //会报错
            //Act_event = null;
            //Act_event();
        }

        /// <summary>
        /// 使用方法
        /// </summary>
        public void Test02()
        {
            Act_event += Log;
            Act_event();
            Act_event -= Log;
            //Act_event();//为空就报错了
            Act_event?.Invoke();
        }

        public void Log()
        {
            Console.WriteLine("qq");
        }
    }
}
