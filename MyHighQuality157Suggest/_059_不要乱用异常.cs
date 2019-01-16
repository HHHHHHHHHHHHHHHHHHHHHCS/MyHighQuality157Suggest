using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 不要乱用异常
    /// </summary>
    public class _059_不要乱用异常
    {
        /// <summary>
        /// 直接抛出异常,而不让流程继续
        /// </summary>
        public void Test01()
        {
            //错误做法
            //int age = 0;
            //if (age < 0)
            //{
            //    throw new ArgumentOutOfRangeException("Age不能为负数");
            //}
            //else if (age > 100)
            //{
            //    throw new ArgumentOutOfRangeException("Age不能为大于100");
            //}

            //正确
            int age = 0;
            string msg = null;
            if (!CheckAge(age,ref msg))
            {
                Console.WriteLine(msg);
                return;
            }
        }

        public bool CheckAge(int age, ref string msg)
        {
            if (age < 0)
            {
                msg = "Age不能为负数";
                return false;
            }
            else if (age > 100)
            {
                msg = "Age不能为大于100";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 重复抛出异常
        /// </summary>
        public void Test02()
        {
            //错误做法
            //object o = null;
            //if (o == null)
            //{
            //    throw new ArgumentNullException("空引用");
            //}
            //
            //Program p = null;
            //try
            //{
            //    p = (Program) o;
            //}
            //catch (InvalidCastException)
            //{
            //    throw new ArgumentNullException("输出的参数不是Program:" + o);
            //}

            //正确做法,C# 会自动抛出异常,不用包裹两层
            object o = null;
            Program p = null;
            p = (Program)o;
        }
    }
}
