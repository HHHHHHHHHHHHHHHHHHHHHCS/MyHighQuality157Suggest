using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// MD5是最通用的HASH算法.
    /// MD5是一种压缩算法,一个1GB的文件,只改动一个字节的内容,MD5也会完全不同.
    /// </summary>
    public class _115_通过HASH来验证文件是否被篡改
    {

        public void Test01()
        {
            string fileHash = GetFileHash(@"C:\Test.txt");
            Console.WriteLine("文件MD5-HASH值为:{0}", fileHash);
        }

        public string GetFileHash(string filePath)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
                }
            }
        }
    }
}
