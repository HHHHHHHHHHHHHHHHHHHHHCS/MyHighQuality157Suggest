using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 谨慎将数组或集合作为属性,会引起歧义
    /// 如果属性是只读的,我们通常会认为他是不可改变的.
    /// 但是只读应用于数组和集合,而元素的内容和数量却可以随便改变
    /// 可以参考建议25进行规范
    /// </summary>
    public class _092_谨慎将数组或集合作为属性
    {
        public void Test01()
        {
            var mic = new Company();
            mic.Employees[0].Name = "BAT";
            foreach (var item in mic.Employees)
            {
                Console.WriteLine(item.Name);
            }
        }

        private class Employee
        {
            public string Name { get; set; }
        }

        private class Company
        {
            public List<Employee> Employees { get; private set; }

            public Company()
            {
                Employees = new List<Employee>
                {
                    new Employee() {Name = "Bill Gates"}
                };
            }
        }
    }
}
