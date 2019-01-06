using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 委托是方法指针
    /// 委托需要实例化类的方法,或者静态方法
    /// </summary>
    public class _039_委托delegate
    {
        public delegate void DoThing();
        public DoThing dg1;
        public DoThing dg2;


        public void Test01()
        {
            dg1 += T;
            TempClass tc = new TempClass();
            dg2 +=tc.T;
        }

        public void T()
        {

        }
         
        private class TempClass
        {
            public void T()
            {

            }
        }
    }
}
