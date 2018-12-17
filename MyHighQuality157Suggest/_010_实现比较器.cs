using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在创建一些类的时候,考虑一下是否要实现比较器 或者抽象比较接口
    /// 比如一些要排序的如果排序规则改变
    /// 我们的代码可能也要改变
    /// </summary>
    public class _010_实现比较器
    {
        /// <summary>
        /// 实现IComparable 用sort
        /// </summary>
        public void Test01()
        {
            List<Salary> list = new List<Salary>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Salary(char.ToString((char) ('A' + i)), i, 10 - i));
            }

            list.Sort();
            list.ForEach(x => Console.WriteLine(x.ToString()));
        }

        /// <summary>
        /// 如果忽然想按照别的排序 又要符合开发原则
        /// new class 实现IComparer接口
        /// </summary>
        public void Test02()
        {
            List<Salary> list = new List<Salary>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Salary(char.ToString((char)('A' + i)), i, 10 - i));
            }

            list.Sort(new BonusCompare());
            list.ForEach(x => Console.WriteLine(x.ToString()));
        }


        private class Salary : IComparable<Salary>
        {
            public string Name { get; set; }
            public int BaseSalary { get; set; }
            public int Bonus { get; set; }

            public Salary(string name, int baseSalary, int bonus)
            {
                Name = name;
                BaseSalary = baseSalary;
                Bonus = bonus;
            }


            public int CompareTo(Salary obj)
            {
                var staff = obj as Salary;
                if (BaseSalary > staff.BaseSalary)
                {
                    return 1;
                }
                else if (BaseSalary == staff.BaseSalary)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }


            public override string ToString()
            {
                return Name + "   " + BaseSalary + "   " + Bonus;
            }
        }

        private class BonusCompare:IComparer<Salary>
        {
            public int Compare(Salary x, Salary y)
            {
                return x.Bonus.CompareTo(y.Bonus);
            }
        }

    }
}