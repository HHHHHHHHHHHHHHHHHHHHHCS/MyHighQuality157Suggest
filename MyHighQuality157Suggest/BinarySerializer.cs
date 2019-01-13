using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class BinarySerializer
    {
        public static T SerAndDeSer<T>(T t)where T:class
        {
            using (MemoryStream objStr = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(objStr, t);
                objStr.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(objStr) as T;
            }
        }

        /// <summary>
        /// 序列化转换成字符串
        /// </summary>
        public static string Serialize<T>(T t)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// 序列化到文件中
        /// </summary>
        public static void SerializeToFile<T>(T t, string path, string fullName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = path + @"\" + fullName;
            using (FileStream stream = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, t);
                stream.Flush();
            }
        }

        /// <summary>
        /// 把字符串反序列化
        /// </summary>
        public static T Deserialize<T>(string s) where T : class
        {
            byte[] bs = Convert.FromBase64String(s);
            using (MemoryStream stream = new MemoryStream(bs))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }

        public static T DeserializeFromFile<T>(string path) where T:class
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream) as T;
            }
        }
    }
}