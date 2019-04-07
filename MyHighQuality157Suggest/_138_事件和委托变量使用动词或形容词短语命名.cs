using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 事件和委托变量使用动词或形容词短语命名
    /// </summary>
    public class _138_事件和委托变量使用动词或形容词短语命名
    {
        //建议的做法
        public delegate void RouteEventHandler();
        public delegate void SizeChangedEventHandler();

        public event RouteEventHandler Click;
        public event SizeChangedEventHandler SizeChanged
        {
            add
            {

            }

            remove
            {

            }
        }

        //不建议的做法 这样会分不清命名
        public event SizeChangedEventHandler SizeChangedEventHanlder;
    }
}