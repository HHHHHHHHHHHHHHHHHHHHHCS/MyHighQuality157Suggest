using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 重写时不应使用子类参数,偏离设计者的预期目标
    /// </summary>
    public class _099_重写时不应使用子类参数
    {
        /// <summary>
        /// 比如我们这里想用 经理设置了薪水
        /// 但是结果是 职员设置了薪水
        /// </summary>
        public void Test01()
        {
            ManagerSalary m = new ManagerSalary();
            m.SetSalary(new Employee());
        }


        private class Employee
        {

        }

        private class Manager : Employee
        {

        }

        private class Salary
        {
            public void SetSalary(Employee e)
            {
                Console.WriteLine("职员被设置了薪水");
            }
        }

        private class ManagerSalary : Salary
        {
            public void SetSalary(Manager m)
            {
                Console.WriteLine("经理被设置了薪水");
            }
        }
    }
}
