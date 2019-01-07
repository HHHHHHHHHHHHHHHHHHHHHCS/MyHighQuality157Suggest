using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 协变-> out T
    /// </summary>
    public class _042_泛型协变
    {
        public void Test01()
        {
            ISalary<Programmer> p = new BaseSalaryCounter<Programmer>();
            PrintSalary1(p);
            PrintSalary(p);
        }

        //注意 如果不加out T 会报类型转换错误
        private void PrintSalary1(ISalary<Employee> p)
        {
            p.Pay();
        }

        //不过也能这样
        private void PrintSalary<T>(ISalary<T> p) 
        {
            p.Pay();
        }

        interface ISalary<out T>
        {
            void Pay();
        }

        private class BaseSalaryCounter<T> : ISalary<T>
        {
            public void Pay()
            {
                Console.WriteLine("Pay base salary");
            }
        }

        private class Employee 
        {
            public string Name { get; set; }
        }

        private class Programmer : Employee
        {

        }

        private class Manager : Employee
        {

        }
    }
}
