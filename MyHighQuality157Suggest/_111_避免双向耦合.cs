using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 双向耦合是指两个类型之间互相引用
    /// 双向耦合不会存在太多的问题,但是会带来设计问题
    /// 解决方法是提炼一个接口,这样也能让其规范化
    /// </summary>
    public class _111_避免双向耦合
    {

        interface ISample
        {
            void MethodA();
        }

        private class A : ISample
        {
            B b;

            public void MethodA()
            {
                b.MehtodB();
            }
        }

        private class B
        {
            ISample a;

            public void MehtodB()
            {
                a.MethodA();
            }
        }
    }
}
