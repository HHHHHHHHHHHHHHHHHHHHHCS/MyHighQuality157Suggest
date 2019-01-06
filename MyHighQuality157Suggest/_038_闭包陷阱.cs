using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _038_闭包陷阱
    {
        /// <summary>
        /// 陷阱:闭包对象  IL之后跟Test02一样
        /// </summary>
        public void Test01()
        {
            List<Action> lists = new List<Action>();
            for(int i=0;i<5;i++)
            {
                Action act = () =>
                {
                    Console.WriteLine(i.ToString());
                };
                lists.Add(act);
            }

            foreach(var item in lists)
            {
                item();
            }
        }

        /// <summary>
        /// 跟Test01一样
        /// </summary>
        public void Test02()
        {
            List<Action> lists = new List<Action>();
            TempClass tempClass = new TempClass();

            for(tempClass.i=0;tempClass.i<5;tempClass.i++)
            {
                Action act = tempClass.TempFunc;
                lists.Add(act);
            }
            foreach(var item in lists)
            {
                item();
            }
        }

        /// <summary>
        /// 正确的做法,跟Test04一样
        /// </summary>
        public void Test03()
        {
            List<Action> lists = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                int tempI = i;
                Action act = () =>
                {
                    Console.WriteLine(tempI.ToString());
                };
                lists.Add(act);
            }

            foreach (var item in lists)
            {
                item();
            }
        }

        /// <summary>
        /// 跟Test03一样
        /// </summary>
        public void Test04()
        {
            List<Action> lists = new List<Action>();
            

            for (var i=0;i<5;i++)
            {
                TempClass tempClass = new TempClass();
                tempClass.i = i;
                Action act = tempClass.TempFunc;
                lists.Add(act);
            }
            foreach (var item in lists)
            {
                item();
            }
        }


        private class TempClass
        {
            public int i;
            public void TempFunc()
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
