using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 正常密码都被转成MD5储存
    /// 但是可以利用穷举法暴力破解
    /// </summary>
    public class _114_MD5不再安全
    {
        /// <summary>
        /// 正常的MD5加密
        /// </summary>
        public void Test01()
        {
            string source = "luminji's key";
            string hash = GetMD5Hash(source);
            Console.WriteLine("保存密码原文:{0}的MD5值:{1}到数据库.", source, hash);
        }

        /// <summary>
        /// 用穷举法破解用户密码
        /// 比如密码是0~9999,密码是888 查看效率
        /// </summary>
        public void Test02()
        {
            string md5 = GetMD5Hash(888.ToString());
            Console.WriteLine("开始穷举法破解用户密码.......");
            string key = string.Empty;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < 9999; i++)
            {
                if (GetMD5Hash(i.ToString()).Equals(md5))
                {
                    key = i.ToString();
                    break;
                }
            }

            watch.Stop();
            Console.WriteLine("密码已破解,为:{0},耗时{1}毫秒", key, watch.ElapsedMilliseconds);
        }

        private string GetMD5Hash(string input)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(md5.ComputeHash
                    (UTF8Encoding.Default.GetBytes(input))).Replace("-", "");
            }
        }
    }
}
