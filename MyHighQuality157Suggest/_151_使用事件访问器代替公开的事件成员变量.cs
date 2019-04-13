using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _151_使用事件访问器代替公开的事件成员变量
    {
        private EventHandlerList events = new EventHandlerList();

        /// <summary>
        /// 这样可以更详细的控制 , 但是会比较长
        /// </summary>
        public event EventHandler Click1
        {
            add { events.AddHandler(null, value); }
            remove { events.RemoveHandler(null, value); }
        }

        /// <summary>
        /// 这样比较短,但是不好详细控制
        /// </summary>
        public event EventHandler Click2;
    }
}
