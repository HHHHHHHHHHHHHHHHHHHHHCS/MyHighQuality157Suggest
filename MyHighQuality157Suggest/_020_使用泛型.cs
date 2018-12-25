using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 非泛型
    /// 1).有多次装箱 储存的时候转换为object  读取的时候又转换回来
    /// 2).不安全 object可以塞入string int
    /// 所以要用泛型 效率快 安全
    /// </summary>
    public class _020_使用泛型
    {
        public void Test01()
        {
            ArrayList aList = new ArrayList();
            aList.Add(1);
            aList.Add("1");
            aList.Add(1f);

            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);

            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);


        }


        public void Test02()
        {
            Hashtable ht = new Hashtable();
            ht.Add("1", 1);
            ht.Add("2", 2f);
            ht.Add(3f, 3);

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("1", 1);
            dic.Add("2", 2);
            dic.Add("3", 3);
        }
    }
}
