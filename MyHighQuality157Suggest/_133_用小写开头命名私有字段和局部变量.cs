using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 私有字段和局部变量用小写开头
    /// 但是我自己不建议方法开头用小写
    /// </summary>
    public class _133_用小写开头命名私有字段和局部变量
    {
        private string firstName;
        private string lastName;

        public string Name => $"{firstName} {lastName}";

        private int DoSomeThing(int a, int b)
        {
            int iTemp = 10;
            return a + b + iTemp;
        }
    }
}
