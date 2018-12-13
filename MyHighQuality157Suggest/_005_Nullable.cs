using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 服务器有时候会传来基础类型空值 所以有时候需要nullable
    /// </summary>
    public class _005_Nullable
    {
        /// <summary>
        /// 基础类型空值写法
        /// </summary>
        public void Test01()
        {
            //模拟服务器传来的空值

            //以前写法
            object input = null;
            int a;
            if (input != null)
            {
                a = (int) input;
            }

            //nullable写法
            int? b;
            b = (int?)input;
        }

        /// <summary>
        /// nullable 和 类型转换
        /// </summary>
        public void Test02()
        {
            int? i = null;
            int j = 0;
            i = j;

            j = i.HasValue ? i.Value : 0;
            j = i ?? 0;
        }
    }
}