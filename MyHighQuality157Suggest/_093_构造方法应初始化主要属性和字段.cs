using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 构造方法应初始化主要属性和字段
    /// 如果属性中没有一开始直接设置变量(这其实也是构造函数中添加的,在构造函数最开始的时候执行)
    ///   则应该在构造函数中设置
    /// 好比一只健康的猫来到世界上,他应该具有猫尾巴和猫爪,而不是在查看的时候得到一个null
    /// </summary>
    public class _093_构造方法应初始化主要属性和字段
    {
        private class Employee
        {
            public string Name { get; set; }
        }

        private class Company
        {
            public Employee CEO { get; set; }

            private Employee a = new Employee() {Name = "Mike"};
            private Employee b;

            public Company()
            {
                CEO = new Employee() { Name = "Steve"};
                b = new Employee() { Name = "Rose"};
            }

        }
    }
}