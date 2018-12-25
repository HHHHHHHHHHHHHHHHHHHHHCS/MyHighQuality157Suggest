using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用正确的容器可以提高效率
    /// </summary>
    public class _021_正确容器
    {
        /*
         * 集合-线性-直接存储:array,List<T>,字符串,结构
         * 集合-线性-顺序存取:栈Stack<T>,队列Queue<T>
         * 集合-线性-顺序存取-索引集群:散列,字典Dictionary<TKey,TValue>,链表LinkedList<T>
         * 集合-非线性-层级群集:树
         * 集合-非线性-组群集:集HashSet<T>
         * 集合-非线性-组群集:图
         *
         * -----特殊-----
         * -----(自动排序)----- 看Test05
         * SortedList<T>,SortedDictionary<TKey,TValue>,SortedSet<T>
         * 上面这三个是扩展了 List<T>,Dictionary<TKey,TValue>,Set<T>
         * -----多线程使用----- 看_022.cs
         * ConcurrentBag<int> 对应 List<T>
         * ConcurrentDictionary<int, int> 对应 Dictionary<TKey,TValue>
         * ConcurrentQueue<int> 对应 Queue<T>
         * ConcurrentStack<int> 对应 Stack<T>
         */

        /// <summary>
        /// 如何集合的数目固定,建议使用Array
        /// 否则使用list
        /// </summary>
        public void Test01()
        {
            int[] a = new int[10000];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i;
            }

            List<int> list = new List<int>();
            list.Capacity = 10000;
            for (int i = 0; i < list.Count; i++)
            {
                list.Add(i);
            }
        }

        /// <summary>
        /// LinkedList<T>的插入效率比List<T>快
        /// 但是读取效率没有List<T>快
        /// 而且LinkedList<T>不能读取随机索引
        /// </summary>
        public void Test02()
        {
            LinkedList<int> ll = new LinkedList<int>();
            for (int i = 0; i < 10000; i++)
            {
                ll.AddLast(i);
            }

            foreach (var item in ll)
            {
            }

            //ll.First.Next;
            //ll.Last.Previous;

            List<int> list = new List<int>();
            list.Capacity = 10000;
            for (int i = 0; i < list.Count; i++)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
            }

            //list[233];
        }

        /// <summary>
        /// 线性容器 插入效率比较高
        /// 但是完全读取效率比较低,并且不能随机读取某个位置
        /// 如:栈Stack<T>,队列Queue<T>,链表LinkedList<T>
        /// </summary>
        public void Test03()
        {
            //先进后出
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Peek();
            stack.Pop();

            //先进先出
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Peek();
            queue.Dequeue();

            //只能从头尾开始读取
            LinkedList<int> llist = new LinkedList<int>();
            llist.AddLast(1);
            llist.AddFirst(0);
        }

        /// <summary>
        /// 字典Dictionary<TKey,TValue> 由N个桶组成,每个桶管理一堆物体绑定的哈希值
        /// 因为Dic储存的特殊性,只能得到key取得value,或者遍历
        /// 而且foreach读取时于存的时候顺序不一定一样
        /// </summary>
        public void Test04()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("a", 1);
            dic.Add("b", 2);
            dic.Add("c", 3);
            dic.Add("d", 4);
        }

        /// <summary>
        /// 自动排序用
        /// </summary>
        public void Test05()
        {
            SortedList<int, int> sList = new SortedList<int, int>();
            sList.Add(5, 0);
            sList.Add(4, 1);
            sList.Add(1, 4);
            sList.Add(3, 2);
            sList.Add(2, 3);
            foreach (var item in sList)
            {
                Console.WriteLine(item);
            }

            SortedDictionary<int, int> sDic = new SortedDictionary<int, int>();
            sDic.Add(1, 11);
            sDic.Add(3, 12);
            sDic.Add(2, 12);
            sDic.Add(4, 14);
            sDic.Remove(1);
            sDic.Add(1, 21);
            foreach (var kv in sDic)
            {
                Console.WriteLine(kv);
            }

            SortedSet<int> sSet = new SortedSet<int>();
            sSet.Add(1);
            sSet.Add(3);
            sSet.Add(5);
            sSet.Add(7);
            sSet.Add(9);
            sSet.Add(2);
            sSet.Add(4);
            sSet.Add(6);
            sSet.Add(7);
            foreach (var v in sSet)
            {
                Console.WriteLine(v);
            }
        }

        /// <summary>
        /// 多线程安全用
        /// </summary>
        public void Test06()
        {
            ConcurrentBag<int> cBag = new ConcurrentBag<int>();
            ConcurrentDictionary<int, int> cDic = new ConcurrentDictionary<int, int>();
            ConcurrentQueue<int> cQueue = new ConcurrentQueue<int>();
            ConcurrentStack<int> cStack = new ConcurrentStack<int>();
        }
    }
}