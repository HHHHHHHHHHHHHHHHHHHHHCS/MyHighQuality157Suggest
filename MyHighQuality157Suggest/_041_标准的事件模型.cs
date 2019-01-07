using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 标准的代码格式
    /// </summary>
    public class _041_标准的事件模型
    {
        /*
         * 1.)委托类型的名称已EventHandler结束
         * 2.)委托原型返回值为void
         * 3.)具有两个参数,sender发送者,e表示事件参数
         * 4.)事件参数的名称以EventArgs结束
         * 5.)事件参数的名词以Handler结束
         */
        public delegate void DoEventHandler(object sender, EventArgs e);

        public event DoEventHandler doHandler;

        public void Test01()
        {
            doHandler += (sender, e) =>
            {
                Console.WriteLine(sender);
                Console.WriteLine((e as DoEventArgs)?.Money);
            };

            doHandler(this, new DoEventArgs(1000));
        }


        private class DoEventArgs : EventArgs
        {
            public int Money { get; private set; }

            public DoEventArgs(int money)
            {
                Money = money;
            }
        }
    }
}
