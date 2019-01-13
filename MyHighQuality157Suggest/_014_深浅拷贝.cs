using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 写的时候注意深拷贝和浅拷贝
    /// </summary>
    public class _014_深浅拷贝
    {
        /*
         * 共同点:把所有的字段都复制到新的对象上
         *   ,副本的值引用修改不会影响原来的
         * 不同点:
         *   浅拷贝:类型引用直接拷贝之前的,导致副本修改会修改副本的
         *   深拷贝:会重新创建类型引用,不会修改之前的
         */

        /// <summary>
        /// 浅拷贝
        /// </summary>
        public void Test01()
        {
            EasyClone b = new EasyClone();
            b.id = 0;
            b.name = "a";
            b.manInfo = new ManInfo();
            b.manInfo.sex = true;
            b.manInfo.phone = 233333;
            b.manInfo.address = "qwer";
            EasyClone c = b.Clone() as EasyClone;
            c.id = 1;
            c.name = "b";
            c.manInfo.sex = false;
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
        }

        /// <summary>
        /// 深拷贝
        /// </summary>
        public void Test02()
        {
            HardClone b = new HardClone();
            b.id = 0;
            b.name = "a";
            b.manInfo = new ManInfo();
            b.manInfo.sex = true;
            b.manInfo.phone = 233333;
            b.manInfo.address = "qwer";
            HardClone c = b.Clone() as HardClone;
            c.id = 1;
            c.name = "b";
            c.manInfo.sex = false;
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
        }

        [Serializable]
        private class ManInfo
        {
            public bool sex;
            public int phone;
            public string address;
        }


        private class EasyClone : ICloneable
        {
            public int id;
            public string name;
            public ManInfo manInfo;

            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public override string ToString()
            {
                return $"{id},{name},{manInfo.sex},{manInfo.phone},{manInfo.address}";
            }
        }

        [Serializable]
        private class HardClone : ICloneable
        {
            public int id;
            public string name;
            public ManInfo manInfo;

            public object Clone()
            {
                using (MemoryStream objStr = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(objStr, this);
                    objStr.Seek(0, SeekOrigin.Begin);
                    return formatter.Deserialize(objStr) as HardClone;
                }
            }

            public override string ToString()
            {
                return $"{id},{name},{manInfo.sex},{manInfo.phone},{manInfo.address}";
            }
        }
    }
}