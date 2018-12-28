using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在查询中,等方法中用lambda
    /// 不用专门写方法->简洁
    /// 如果参数改变类型也能跟着改变->方便
    /// </summary>
    public class _027_查询中用Lambda
    {
        /// <summary>
        /// 不用lambda
        /// </summary>
        public void Test01()
        {
            List<Person> personList = new List<Person>()
            {
                new Person() {Name = "a", CompanyID = 0},
                new Person() {Name = "b", CompanyID = 1},
                new Person() {Name = "c", CompanyID = 2},
            };

            var personWithCompanyList =
                from person in personList
                select new {PName = person.Name, CName = person.CompanyID == 0 ? "AAA" : "BBB"};

            foreach (var item in personWithCompanyList)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 使用lambda
        /// </summary>
        public void Test02()
        {
            List<Person> personList = new List<Person>()
            {
                new Person() {Name = "a", CompanyID = 0},
                new Person() {Name = "b", CompanyID = 1},
                new Person() {Name = "c", CompanyID = 2},
            };

            foreach (var item in personList
                .Select(p=>new {PName=p.Name,CName=p.CompanyID==0?"AAA":"BBB"}))
            {
                Console.WriteLine(item);
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int CompanyID { get; set; }
        }
    }
}