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
    /// MD5值或者说HASH值是一种不可逆的算法.如果需要从密文还原成明文,那么就需要对称和非对称这类可逆算法了
    /// 密钥加salt(盐)在加密中是用来防止字典攻击和穷举暴力破解法的.
    /// </summary>
    public class _116_避免用非对称算法加密文件
    {
        /// <summary>
        /// 缓冲区大小
        /// </summary>
        private static readonly int bufferSize = 128 * 1024;

        /// <summary>
        /// 加密用的salt
        /// </summary>
        private static byte[] salt = {134, 216, 7, 36, 80, 164, 91, 227, 174, 76, 191, 197, 192, 154, 200, 248};

        /// <summary>
        /// 初始化向量,加密数据块的时候用,作用是增加破解难度.因为数据块相同则密文会一样,则比较容易破解.
        /// 所以这次的加密会加上上一次数据快的密文,但是第一个数据块是没有的,所以要初始化
        /// </summary>
        private static byte[] iv = {134, 216, 7, 36, 80, 164, 91, 227, 174, 76, 191, 197, 192, 154, 200, 248};

        public void Test01()
        {
            EncryptFile(@"C:\Test.txt", @"C:\tempCM.txt", "123");
            Console.WriteLine("加密成功!");
            DecryptFile(@"C:\tempCM.txt", @"C:\tempM.txt", "123");
            Console.WriteLine("解密成功!");
        }

        /// <summary>
        /// 初始化并返回对称加密算法
        /// </summary>
        /// <returns></returns>
        private static SymmetricAlgorithm CreateRijndael(string password, byte[] salt)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt, "SHA256", 1000);
            SymmetricAlgorithm sma = Rijndael.Create();
            sma.KeySize = 256;
            sma.Key = pdb.GetBytes(32);
            sma.Padding = PaddingMode.PKCS7;
            return sma;
        }

        /// <summary>
        /// 加密
        /// </summary>
        private static void EncryptFile(string inFile, string outFile, string password)
        {
            using (FileStream inFileStream = File.OpenRead(inFile),
                outFileStream = File.Open(outFile, FileMode.OpenOrCreate))
            {
                using (SymmetricAlgorithm algorithm = CreateRijndael(password, salt))
                {
                    algorithm.IV = iv;
                    using (CryptoStream cryptoStream = new CryptoStream(outFileStream, algorithm.CreateEncryptor(),
                        CryptoStreamMode.Write))
                    {
                        byte[] bytes = new byte[bufferSize];
                        int readSize = -1;
                        while ((readSize = inFileStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            cryptoStream.Write(bytes, 0, readSize);
                        }

                        cryptoStream.Flush();
                    }
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        private static void DecryptFile(string inFile, string outFile, string password)
        {
            using (FileStream inFileStream = File.OpenRead(inFile)
            ,outFileStream = File.OpenWrite(outFile))
            {
                using (SymmetricAlgorithm algorithm = CreateRijndael(password, salt))
                {
                    algorithm.IV = iv;
                    using (CryptoStream cryptoStream = new CryptoStream(inFileStream, algorithm.CreateDecryptor(),
                        CryptoStreamMode.Read))
                    {
                        byte[] bytes = new byte[bufferSize];
                        int readSize = -1;
                        int numReads = (int)(inFileStream.Length / bufferSize);
                        int slack = (int) (inFileStream.Length % bufferSize);
                        for (int i = 0; i < numReads; i++)
                        {
                            readSize = cryptoStream.Read(bytes, 0, bytes.Length);
                            outFileStream.Write(bytes, 0, readSize);
                        }

                        if (slack > 0)
                        {
                            readSize = cryptoStream.Read(bytes, 0, (int) slack);
                            outFileStream.Write(bytes, 0, readSize);
                        }

                        outFileStream.Flush();
                    }
                }
            }
        }
    }
}