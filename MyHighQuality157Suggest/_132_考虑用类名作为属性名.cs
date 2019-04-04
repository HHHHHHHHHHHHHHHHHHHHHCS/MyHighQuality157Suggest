using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 考虑用类名作为属性名
    /// 因为是public 所以用大写
    /// </summary>
    class _132_考虑用类名作为属性名
    {
        private class Company
        {

        }

        private class Person
        {
            public Company Company { get; set; }
            public Company SecondCompany { get; set; }
            public Company TheCompany { get; set; }
        }

    }
}
