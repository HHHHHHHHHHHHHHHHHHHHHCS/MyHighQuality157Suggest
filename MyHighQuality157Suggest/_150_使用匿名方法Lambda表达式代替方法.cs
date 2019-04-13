using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 方法体如果过小(如小于3行) 专门写一个方法就会显得过于烦琐
    /// 我们就能用Lambda表达式来重构
    /// </summary>
    public class _150_使用匿名方法Lambda表达式代替方法
    {
        /// <summary>
        /// 如果不用Lambda 则多一个方法 烦琐
        /// </summary>
        public void Test01()
        {
            List<string> list = new List<string>() {"Mike", "Rose", "Steve"};
            var mike = list.Find(new Predicate<string>(HaveLengthFive));
            Console.WriteLine(mike);
        }

        private bool HaveLengthFive(string value)
        {
            return value.Length == 5;
        }

        /// <summary>
        /// 用Lambda
        /// </summary>
        public void Test02()
        {
            List<string> list = new List<string>() { "Mike", "Rose", "Steve" };
            var mike = list.Find(value=>value.Length==5);
            Console.WriteLine(mike);
        }
    }
}
