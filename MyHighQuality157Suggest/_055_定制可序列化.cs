using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 利用四个属性,可以定制序列化,添加callback
    /// OnSerializing,OnSerialized
    /// OnDeserializing,OnDeserialized
    /// </summary>
    public class _055_定制可序列化
    {
        public void Test01()
        {
            Person p1 = new Person() {firstName = "F", lastName = "L"};
            Person p2 = BinarySerializer.SerAndDeSer(p1);

        }


        [Serializable]
        private class Person
        {
            public string firstName;
            public string lastName;
            [NonSerialized]
            public string chineseName;


            [OnSerializing]
            private void OnSerializing(StreamingContext context)
            {
                Console.WriteLine("执行序列化中");
            }

            [OnDeserialized]
            private void OnDeSerialized(StreamingContext context)
            {
                chineseName = $"{lastName} {firstName}";
                Console.WriteLine(chineseName);
            }
        }
    }
}
