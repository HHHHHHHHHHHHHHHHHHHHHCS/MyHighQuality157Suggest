using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 多线程的时候 注意选择线程安全容器
    /// 线程操作的时候甚至可以使用原子操作
    /// </summary>
    public class _022_线程安全容器
    {
        private static List<Person> list = new List<Person>()
        {
            new Person() {Name = "Rose", Age = 19},
            new Person() {Name = "Steve", Age = 45},
            new Person() {Name = "Jessica", Age = 20},
        };

        /// <summary>
        /// 阻塞线程,直到收到通知
        /// false表示要手动初始化
        /// </summary>
        private static AutoResetEvent autoSet = new AutoResetEvent(false);


        /// <summary>
        /// foreach的时候改变了List的东西会报错
        /// </summary>
        public void Test01()
        {
            Thread t1 = new Thread(() =>
            {
                autoSet.WaitOne(); //阻塞线程等到收到通知
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Name},{item.Age}");
                    Thread.Sleep(1000);
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                autoSet.Set(); //通知t1执行
                Thread.Sleep(1000); //跟t1抢夺资源,删除list
                list.RemoveAt(2);
                Console.WriteLine("删除成功");
            });
            t2.Start();
        }

        /// <summary>
        /// 添加安全锁来避免
        /// ArrayList自带SyncRoot
        /// List需要转换为ICollection才有SyncRoot
        /// </summary>
        public void Test02()
        {
            Thread t1 = new Thread(() =>
            {
                autoSet.WaitOne(); //阻塞线程等到收到通知
                lock (((ICollection) list).SyncRoot)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.Name},{item.Age}");
                        Thread.Sleep(1000);
                    }
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                autoSet.Set(); //通知t1执行
                lock (((ICollection) list).SyncRoot)
                {
                    Thread.Sleep(1000); //跟t1抢夺资源,删除list
                    list.RemoveAt(2);
                    Console.WriteLine("删除成功");
                }
            });
            t2.Start();
        }

        /// <summary>
        /// 也可以自己添加属性来加锁
        /// </summary>
        public void Test03()
        {
            object syncRoot = new object();
            Thread t1 = new Thread(() =>
            {
                autoSet.WaitOne(); //阻塞线程等到收到通知
                lock (syncRoot)
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine($"{item.Name},{item.Age}");
                        Thread.Sleep(1000);
                    }
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                autoSet.Set(); //通知t1执行
                lock (syncRoot)
                {
                    Thread.Sleep(1000); //跟t1抢夺资源,删除list
                    list.RemoveAt(2);
                    Console.WriteLine("删除成功");
                }
            });
            t2.Start();
        }

        /// <summary>
        /// 用线程安全列表(ConcurrentBag)做安全保护
        /// 但是效果可能达不到想要的效果
        /// </summary>
        public void Test04()
        {
            ConcurrentBag<Person> cList = new ConcurrentBag<Person>();

            foreach (var item in list)
            {
                cList.Add(item);
            }

            Thread t1 = new Thread(() =>
            {
                autoSet.WaitOne(); //阻塞线程等到收到通知

                foreach (var item in cList)
                {
                    Console.WriteLine($"{item.Name},{item.Age}");
                    Thread.Sleep(1000);
                }
            });
            t1.Start();

            Thread t2 = new Thread(() =>
            {
                autoSet.Set(); //通知t1执行

                Thread.Sleep(1000); //跟t1抢夺资源,删除list
                cList.TryTake(out Person p);
                Console.WriteLine($"删除成功:{p.Name},{p.Age}");
            });
            t2.Start();
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}