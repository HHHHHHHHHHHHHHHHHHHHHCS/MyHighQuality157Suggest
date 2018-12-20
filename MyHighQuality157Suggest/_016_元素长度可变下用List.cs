using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在元素变化下用List<T> 代替array 和 ArrayList
    /// </summary>
    public class _016_元素长度可变下用List
    {
       /*
        * Array 扩充数组有开销,如果数据过大,分配和回收会很慢
        * ArrayList 有装箱 而且可能具有固定大小
        * 建议用List<T>
        */

        private const int times = 100000;

        public void Test01()
        {
            int[] iarr = {0};
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i <= times; i++)
            {
                Array.Resize(ref iarr, i+1);
                iarr[i] = i;
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public void Test02()
        {
            //下面这个会产生固定大小
            //int[] iarr = { 0,1,2,3,4,5,6 };
            //ArrayList arr = ArrayList.Adapter(iarr);
            ArrayList arr = new ArrayList();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i <= times; i++)
            {
                arr.Add(i);
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public void Test03()
        {
            int[] iarr = { 0,1,2,3,4,5,6 };
            List<int> list = iarr.ToList<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 1; i <= times; i++)
            {
                list.Add(i);
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
