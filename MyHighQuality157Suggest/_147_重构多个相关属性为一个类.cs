using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在必要的时候 可以把一些相关属性 重构为一个新的类  方法后续使用
    /// 比如把 很多地址相关的 和 人 分开
    /// </summary>
    public class _147_重构多个相关属性为一个类
    {
        private class Person
        {
            public string Name;
            public Contanct Contanct;
        }

        private class Contanct
        {
            public string Address;
            public int ZipCode;
            public string Mobile;
            public string Hotmail;
        }
    }
}
