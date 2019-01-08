using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 逆变的使用环境
    /// </summary>
    public class _044_添加逆变
    {
        public void Test01()
        {
            SuperMan sm = new SuperMan() {Name = "A", Age = 10};
            DogeMan dm = new DogeMan() { Name = "B", Age = 20 };
            _Test01(sm, dm);//如果这里没有加in会报错
        }

        private void _Test01<T>(IMyComparable<T> t1, T t2)
        {

        }

        public interface IMyComparable<in T>
        {
            int Compare(T other);
        }

        public class Person : IMyComparable<Person>
        {
            public string Name;
            public int Age;

            public int Compare(Person other)
            {
                return Age.CompareTo(other.Age);
            }
        }

        public class SuperMan : Person,IMyComparable<SuperMan>
        {
            public int Compare(SuperMan other)
            {
                return Age.CompareTo(other.Age);
            }
        }

        public class DogeMan : Person
        {

        }
    }
}
