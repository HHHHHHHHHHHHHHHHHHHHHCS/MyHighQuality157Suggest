using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 如果方法的参数数目不定,且参数类型一致.
    /// 则可以使用params关键字减少重复的参数声明.
    /// </summary>
    public class _098_用params减少重复参数
    {
        private void Method1(string err, object a)
        {

        }

        private void Method2(string err, object a, object b)
        {

        }

        private void Method3(string err, object a, object b, object c)
        {

        }

        private void Method1(string err, params object[] args)
        {

        }
    }
}
