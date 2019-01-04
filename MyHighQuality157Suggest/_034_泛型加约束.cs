using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 为泛型添加约束,确保更安全
    /// 同时也可以加一些方法
    /// </summary>
    public class _034_泛型加约束
    {

        /**
         * 约束不能是基础类型
         * T:struct,class,new(),自定义类,自定义接口,另外一个泛型
         */


        private class PersonCompare
        {
            //会报错
            //public bool Compare_Error<T1, T2>(T1 a, T2 b)
            //{
            //    return a.Age > b.Age;
            //}

            public bool Compare<T1,T2>(T1 a,T2 b) 
                where T1:Person where T2:T1
            {
                return a.Age > b.Age;
            }
        }


        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
