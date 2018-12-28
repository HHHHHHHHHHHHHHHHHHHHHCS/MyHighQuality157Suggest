using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免集合的可写属性,应该只有Add(),Remove()等方法
    /// 因为会增加抛出异常的错误的概率
    /// </summary>
    public class _025_避免集合的可写
    {
        /// <summary>
        /// 多线程设置,导致空指针
        /// </summary>
        public void Test01()
        {
            List<Student> list1 = new List<Student>()
            {
                new Student(){Name = "A", Age = 1},
                new Student() {Name = "B", Age = 2}
            };

            StudentTeamA teamA = new StudentTeamA();
            Thread t1 = new Thread(() =>
            {
                teamA.Students = list1;
                Thread.Sleep(3000);
                Console.WriteLine(teamA.Students.Count);
            });
            t1.Start();

            Thread t2 = new Thread(() => teamA.Students = null);
            t2.Start();
        }

        public void Test02()
        {
            List<Student> list1 = new List<Student>()
            {
                new Student(){Name = "A", Age = 1},
                new Student() {Name = "B", Age = 2}
            };

            StudentTeamB teamB = new StudentTeamB();
            Thread t1 = new Thread(() =>
            {
                teamB.AddRange(list1);
                Thread.Sleep(3000);
                Console.WriteLine(teamB.Students.Count);
            });
            t1.Start();

            Thread t2 = new Thread(() => teamB.Clear());
            t2.Start();
        }

        private class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private class StudentTeamA
        {
            public List<Student> Students { get; set; }

        }

        private class StudentTeamB
        {
            public List<Student> Students { get; private set; }

            public StudentTeamB()
            {
                Students = new List<Student>();
            }

            public void Add(Student s)
            {
                Students.Add(s);
            }

            public void AddRange(IEnumerable<Student> ie)
            {
                Students.AddRange(ie);
            }

            public void Clear()
            {
                Students.Clear();
            }
        }
    }
}