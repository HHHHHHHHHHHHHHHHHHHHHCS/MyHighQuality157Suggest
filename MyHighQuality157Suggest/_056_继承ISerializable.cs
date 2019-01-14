using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 继承ISerializable,实现序列化,
    /// 对比OnSerializing...这四种,这个能实现序列化成别的自定义class
    /// </summary>
    public class _056_继承ISerializable
    {
        /// <summary>
        /// 正常的方法
        /// </summary>
        public void Test01()
        {
            Person p = new Person() {firstName="F",lastName="L"};
            var x = BinarySerializer.SerAndDeSer(p);
            Console.WriteLine(x.chineseName);
        }

        /// <summary>
        /// 序列化成别的对象
        /// </summary>
        public void Test02()
        {
            People p1 = new People() {p1 = "a", p2 = "b", p3 = "c"};
            BinarySerializer.SerializeToFile(p1,@"E:/","x.txt");
            var x= BinarySerializer.DeserializeFromFile<Human>(@"E:/x.txt");
            Console.WriteLine(x.name);
        }

        [Serializable]
        private class Human : ISerializable
        {
            public string name;

            public Human()
            {

            }

            protected Human(SerializationInfo info, StreamingContext context)
            {
                name = info.GetString("name");
            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
            }
        }

        [Serializable]
        private class People : ISerializable
        {
            public string p1 { get; set; }
            public string p2 { get; set; }
            public string p3 { get; set; }

            public People()
            {

            }

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.SetType(typeof(Human));
                info.AddValue("name", $"{p1},{p2},{p3}");
            }
        }

        [Serializable]
        private class Person : ISerializable
        {
            public string firstName;
            public string lastName;
            public string chineseName;

            public Person()
            {
            }

            protected Person(SerializationInfo info, StreamingContext context)
            {
                firstName = info.GetString("firstName");
                lastName = info.GetString("lastName");
                chineseName = $"{lastName} {firstName}";
            }


            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("firstName",firstName);
                info.AddValue("lastName", lastName);
                //info.SetType(typeof(OtherInfo));
            }
        }
    }
}
