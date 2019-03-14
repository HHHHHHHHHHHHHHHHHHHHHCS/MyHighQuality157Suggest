using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 注意数值的最大值的安全性
    /// </summary>
    public class _113_声明变量前考虑最大值
    {
        /// <summary>
        /// 注意数据溢出
        /// </summary>
        public void Test01()
        {
            ushort salary = 65534;
            salary = (ushort) (salary + 1);
            //注意这里不能用$可能会出现0的情况
            //所以用string.format
            Console.WriteLine(string.Format("第一次加薪,工资总数:{0}", salary));
            salary = (ushort) (salary + 1);
            Console.WriteLine(string.Format("第二次加薪,工资总数:{0}", salary));
        }

        /// <summary>
        /// 可以用checked检查数据溢出
        /// 异常报错
        /// </summary>
        public void Test02()
        {
            ushort salary = 65534;
            checked
            {
                salary = (ushort) (salary + 1);
                //注意这里不能用$可能会出现0的情况
                //所以用string.format
                Console.WriteLine(string.Format("第一次加薪,工资总数:{0}", salary));
                salary = (ushort) (salary + 1);
                Console.WriteLine(string.Format("第二次加薪,工资总数:{0}", salary));
            }
        }
    }
}