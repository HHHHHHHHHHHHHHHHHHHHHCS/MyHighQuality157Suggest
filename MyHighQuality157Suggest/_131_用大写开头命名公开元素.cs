using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用大写开头命名公开元素 这样可以区分可访问性
    /// 我们在调用的时候会写person.Name
    /// 如果是person.name 我们会怀疑可访问性
    /// </summary>
    public class _131_用大写开头命名公开元素
    {
        private class Person
        {
            public string FirstName;
            public string LastName;

            public string Name => $"{FirstName} {LastName}";

            public string GetName() => Name;
        }
    }
}
