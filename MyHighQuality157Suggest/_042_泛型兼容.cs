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
    public class _042_泛型兼容
    {
        public void Test01()
        {
            ISalary<Programmer> p = new BaseSalaryCounter<Programmer>();
            PrintSalary(p);
        }

        private void PrintSalary<T>(ISalary<T> p) 
        {
            p.Pay();
        }

        interface ISalary< T>
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
