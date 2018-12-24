using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 因为foreach是只读的,不能删除
    /// 在比如说倒序访问
    /// </summary>
    public class _018_foreach不能代替for
    {
        public void Test01()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i);
            }

            //error
            //foreach (var item in list)
            //{
            //    list.Remove(item);
            //}

            for (int i = list.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(i);
            }
        }
    }
}
