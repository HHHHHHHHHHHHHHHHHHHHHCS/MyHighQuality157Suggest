using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用匿名类存储LINQ的结果
    /// 1.方便
    /// 2.不用创建新的类
    /// 3.可以减少修改
    /// </summary>
    public class _026_匿名类存储LINQ结果
    {
        /*
         * 匿名类(C#3.0+)
         * 支持简单类型也支持复杂类型.
         *   简单类型必须是一个非空值初始值.
         *   复杂类型是一个以new开头的初始化项.
         * 匿名类是只读的,没有属性设置器.它一旦被初始化就不能更改.
         * 如果两个匿名类的属性值相同.那么C#认为他们两个匿名类相等.
         * 匿名类可以在循环中用做初始化器.
         * 匿名类支持智能感知.
         * 匿名类可以拥有方法.
         * ---------------------------
         * 匿名类是在C#编译的时候自动创建的
         * 匿名类自动重写tostring()方法
         * 匿名类{name=value}如果没有写name= 则 tostring 为value 的name
         */

        public void Test01()
        {
            List<Company> companyList = new List<Company>
            {
                new Company() {CompanyID = 0, Name = "AAA"},
                new Company() {CompanyID = 1, Name = "BBB"}
            };

            List<Person> personList = new List<Person>()
            {
                new Person() {Name = "a", CompanyID = 0},
                new Person() {Name = "b", CompanyID = 1},
                new Person() {Name = "c", CompanyID = 2},
            };

            var personWithCompanyList =
                from person in personList
                join company in companyList
                    on person.CompanyID equals company.CompanyID
                select new {PersonName = person.Name, company.Name};

            foreach (var item in personWithCompanyList)
            {
                Console.WriteLine(item);
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int CompanyID { get; set; }
        }

        private class Company
        {
            public int CompanyID { get; set; }
            public string Name { get; set; }
        }
    }
}