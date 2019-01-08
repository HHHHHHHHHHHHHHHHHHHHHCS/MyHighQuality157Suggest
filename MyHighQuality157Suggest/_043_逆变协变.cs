using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// in-通过逆变，可以使用与泛型参数指定的派生类型相比，派生程度更小的类型。这样可以对委托类型和实现变体接口的类进行隐式转换.
    /// out-通过协变，可以使用与泛型参数指定的派生类型相比，派生程度更大的类型。
    /// </summary>
    public class _043_逆变协变
    {
        /// <summary>
        /// 逆变
        /// </summary>
        public void Test01()
        {
            IInList<Parent> parents = new InList<Parent>();

            IInList<Son> sons = new InList<Son>();

            parents = sons;
            //sons = parents;//error
        }
        
        /// <summary>
        /// 协变
        /// </summary>
        public void Test02()
        {
            IOutList<Parent> parents = new OutList<Parent>();

            IOutList<Son> sons = new OutList<Son>();

            //parents = sons;//error
            sons = parents;
        }


        private class Son
        {

        }

        private class Parent:Son
        {

        }

        private interface IInList<in T>
        {
            void Add(T item);
        }

        private class InList<T>: IInList<T>
        {
            private List<T> list = new List<T>();

            public void Add(T item)
            {
                list.Add(item);
            }
        }

        private interface IOutList<out T>
        {
            
        }

        private class OutList<T> : IOutList<T>
        {
            private List<T> list = new List<T>();
        }
    }
}
