using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 继承集合的时候 最好继承他们的接口,抽象类等
    /// 而不是继承实现类的本身
    /// 第一他们没有什么继承能修改的方法(protected)
    /// 第二可能还有隐藏的Bug
    /// </summary>
    public class _023_避免继承List等
    {
        /// <summary>
        /// 构造的时候{} 自动执行Add
        /// </summary>
        public void Test01()
        {
            PersonList list = new PersonList()
            {
                new Person() {Name = "A", Age = 1},
                new Person() {Name = "B", Age = 2},
                new Person() {Name = "C", Age = 3},
            };
            list.Add(new Person() {Name = "D", Age = 4});

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// 如果用原来的接口
        /// 我们自定义的new Add 会不执行
        /// </summary>
        public void Test02()
        {
            PersonList list = new PersonList()
            {
                new Person() {Name = "A", Age = 1},
                new Person() {Name = "B", Age = 2},
                new Person() {Name = "C", Age = 3},
            };
            IList<Person> ilist = list;

            ilist.Add(new Person() { Name = "D", Age = 4 });

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// 用自己的
        /// </summary>
        public void Test03()
        {
            MyPersonList list = new MyPersonList()
            {
                new Person() {Name = "A", Age = 1},
                new Person() {Name = "B", Age = 2},
                new Person() {Name = "C", Age = 3},
            };
            ICollection<Person> ilist = list;

            ilist.Add(new Person() { Name = "D", Age = 4 });

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private class PersonList : List<Person>
        {
            public new void Add(Person p)
            {
                p.Name = "Changed: " + p.Name;
                base.Add(p);
            }
        }

        private class MyPersonList : IEnumerable<Person>,ICollection<Person>
        {
            private List<Person> items = new List<Person>();

            public IEnumerator<Person> GetEnumerator()
            {
                return items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Add(Person item)
            {
                item.Name = "Changed: " + item.Name;
                items.Add(item);
            }

            public void Clear()
            {
                items.Clear();
            }

            public bool Contains(Person item)
            {
                return items.Contains(item);
            }

            public void CopyTo(Person[] array, int arrayIndex)
            {
                items.CopyTo(array, arrayIndex);
            }

            public bool Remove(Person item)
            {
                return items.Remove(item);
            }

            public int Count => items.Count;

            public bool IsReadOnly => false;

            public int IndexOf(Person item)
            {
                return items.IndexOf(item);
            }

            public void Insert(int index, Person item)
            {
                items.IndexOf(item);
            }

            public void RemoveAt(int index)
            {
                items.RemoveAt(index);
            }

            public Person this[int index]
            {
                get => items[index];
                set => items[index]=value;
            }
        }
    }
}
