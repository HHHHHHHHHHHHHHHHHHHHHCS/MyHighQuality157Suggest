using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _001_正确的字符串
    {
        public void Test01()
        {
            string s = "how" + 233;
        }


        public void Test02()
        {
            string s = "how" + 233.ToString();
        }
    }
}