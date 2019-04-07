using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 委托和事件类型应添加上级后缀
    /// 让我们知道他是委托或者事件
    /// </summary>
    public class _137_委托和事件类型应添加上级后缀
    {
        //好的建议
        public delegate void HttpContinueDelegate(int StatusCode);
        public delegate bool ValidateValueCallback(object value);
        public delegate void AsyncCallback(IAsyncResult ar);
        public delegate void MouseEventHandler(object sender, MouseEventHandler e);

        //不好的建议
        public delegate void DoSomething(int a, int b);
        public delegate void MouseClick(int a, int b);

    }
}
