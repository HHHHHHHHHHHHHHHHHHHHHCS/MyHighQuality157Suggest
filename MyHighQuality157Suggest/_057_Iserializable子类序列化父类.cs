using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 如果父类没有继承ISerializable和Serializable,所以不能直接序列化
    /// 则可以利用子类去继承实现序列化父类
    /// 但是如果父类已经实现了,则可以直接override
    /// </summary>
    public class _057_ISerializable子类序列化父类
    {

        /// <summary>
        /// 父类没有,子类也没有写,正常情况
        /// </summary>
        public void Test01()
        {
            Son0 s0 = new Son0(){Name="A",Age=1};
            var s1 = BinarySerializer.SerAndDeSer(s0);
            Console.WriteLine($"{s1.Name}, {s1.Age}");
        }

        /// <summary>
        /// 父类没有,子类也没有写了,实现父类
        /// </summary>
        public void Test02()
        {
            Son1 s0 = new Son1() { Name = "A", Age = 1 };
            var s1 = BinarySerializer.SerAndDeSer(s0);
            Console.WriteLine($"{s1.Name}, {s1.Age}");
        }

        /// <summary>
        /// 父类有,子类重写
        /// </summary>
        public void Test03()
        {
            Son2 s0 = new Son2() { Name = "A", Age = 1 };
            var s1 = BinarySerializer.SerAndDeSer(s0);
            Console.WriteLine($"{s1.Name}, {s1.Age}");
        }

        private class Parent0
        {
            public string Name { get; set; }
        }


        [Serializable]
        private class Son0 : Parent0, ISerializable
        {
            public int Age { get; set; }

            public Son0()
            {

            }

            public Son0(SerializationInfo info, StreamingContext context)
            {
                Age = info.GetInt32("age");
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("age", Age);
            }


        }

        [Serializable]
        private class Son1 : Parent0, ISerializable
        {
            public int Age { get; set; }

            public Son1()
            {

            }

            public Son1(SerializationInfo info,StreamingContext context)
            {
                Name = info.GetString("name");
                Age = info.GetInt32("age");
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("name", Name);
                info.AddValue("age", Age);
            }
        }


        [Serializable]
        public class Parent1:ISerializable
        {
            public string Name { get; set; }

            public Parent1()
            {

            }

            public Parent1(SerializationInfo info, StreamingContext context)
            {
                Name = info.GetString("name");
            }

            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("name", Name);
            }
        }

        [Serializable]
        public class Son2 : Parent1
        {
            public int Age { get; set; }

            public Son2()
            {

            }

            public Son2(SerializationInfo info, StreamingContext context)
                :base(info,context)
            {
                
                Age = info.GetInt32("age");
            }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("age", Age);
            }
        }
    }
}
