using System;
using System.Diagnostics;
using System.Text;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在字符串拼接的时候 建议手动添加tostring 防止装箱
    /// 在拼接字符串过多的时候建议用stringBuilder
    /// 或者用format 但是记得tostring()
    /// 在内部string 直接拼接的时候可以试一试 申明 const string
    /// </summary>
    public class _001_正确的字符串
    {
        #region 两个string 对比

        /// <summary>
        /// 使用string.Compare  避免大小写
        /// </summary>
        public void Test17()
        {
            const string str1 = "I am noob";
            if (string.Compare(str1, "I AM NOOB", StringComparison.OrdinalIgnoreCase) == 0)
                Console.WriteLine("is compared");
        }

        #endregion

        /*
         * 为什么 装箱 会效率慢
         * 1.)会为值类型在托管对中分配内存,除了值类型本身锁分配的内存外
         *  内存总量还要加上类型对象指针和同步块索引所占用的内存
         * 2.)将值类型的值复制到新分配的堆内存中
         * 3.)返回已成为引用类型的对象的地址
         */

        #region A:装箱

        /// <summary>
        /// + 即是 concat
        /// 233 会发生一次box
        /// </summary>
        public void A_Test01()
        {
            var s = "how" + 233;
        }

        /// <summary>
        /// tostring 是内存int->string 效率比box 快很多
        /// </summary>
        public void A_Test02()
        {
            var s = "how" + 233;
        }

        /// <summary>
        /// 这个等价于 A_Test04
        /// 会存储"{0}{1}" "how" 两个字符串
        /// 并且会发生装箱
        /// </summary>
        public void A_Test03()
        {
            var s = string.Format("{0}{1}", "how", 233);
        }

        /// <summary>
        /// 等价于 Test03
        /// </summary>
        public void A_Test04()
        {
            var s = $"{"how"}{233}";
        }

        #endregion

        #region B:多字符相加(concat format StringBuilder)

        /// <summary>
        /// 会有多次装箱
        /// </summary>
        public void B_Test01()
        {
            var s = "1" + 2 + "3" + 4 + "5";
        }

        /// <summary>
        /// 没有多次装箱
        /// </summary>
        public void B_Test02()
        {
            var s = "1" + 2 + "3" + 4 + "5";
        }

        /// <summary>
        /// 因为2 4 转string 的时候有装箱
        /// 内部是用stringBuilder 实现的
        /// 不过效率也是一般不如stringbuilder
        /// </summary>
        public void B_Test03()
        {
            var s = string.Format("{0}{1}{2}{4}", "1", 2, "3", 4, "5");
        }

        /// <summary>
        /// 因为sb 内部实现了int.ToString()
        /// 所以转不转成string 无所谓(不过建议不转换 不转换的效率快一点)
        /// 在拼接过多的时候 建议用
        /// StringBuilder->线程安全 StringBuffer->线程不安全
        /// </summary>
        public void B_Test04()
        {
            var sb = new StringBuilder();
            sb.Append("1").Append(2).Append("3").Append(4).Append("5");
        }

        /// <summary>
        /// 同 Test08,不过推荐Test08 比较好
        /// </summary>
        public void B_Test05()
        {
            var sb = new StringBuilder();
            sb.Append("1").Append(2.ToString()).Append("3").Append(4.ToString()).Append("5");
        }

        /// <summary>
        /// 多字符串拼接 format和stringbuilder
        /// </summary>
        public void B_Test06()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            const string str = "{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}";
            for (int i = 0; i < 1000000; i++)
            {
                string s = string.Format(str
                    , 1.ToString(), 2.ToString(), 3.ToString()
                    , 4.ToString(), 5.ToString(), 6.ToString()
                    , 7.ToString(), 8.ToString(), 9.ToString()
                    , 10.ToString());
            }

            sw.Stop();
            Console.WriteLine("format()" + sw.ElapsedMilliseconds);

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.Clear();
                sb.Append(1.ToString())
                    .Append(2.ToString())
                    .Append(3.ToString())
                    .Append(4.ToString())
                    .Append(5.ToString())
                    .Append(6.ToString())
                    .Append(7.ToString())
                    .Append(8.ToString())
                    .Append(9.ToString())
                    .Append(10.ToString());
            }

            sw.Stop();
            Console.WriteLine("tostring() Append()" + sw.ElapsedMilliseconds);

            sw.Restart();
            sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.Clear();
                sb.Append(1)
                    .Append(2)
                    .Append(3)
                    .Append(4)
                    .Append(5)
                    .Append(6)
                    .Append(7)
                    .Append(8)
                    .Append(9)
                    .Append(10);
            }

            sw.Stop();
            Console.WriteLine("notostring() Append()" + sw.ElapsedMilliseconds);
        }

        #endregion

        #region C:const string 的作用

        /// <summary>
        /// 这里创建了两个string 并且有发生一次concat
        /// </summary>
        public void C_Test01()
        {
            var a = "abc";
            var s = a + "def";
        }

        /// <summary>
        /// 直接编译成 abcedf 了
        /// </summary>
        public void C_Test02()
        {
            const string a = "abc";
            var s = a + "def";
        }

        /// <summary>
        /// 同C_Test02
        /// </summary>
        public void C_Test03()
        {
            var s = "abc" + "def";
        }

        /// <summary>
        /// C# 编译成 "abc"+"defghi" (一共2次创建  1次concat)
        /// </summary>
        public void C_Test04()
        {
            var a = "abc";
            const string b = "def";
            var s = a + b + "ghi";
        }

        /// <summary>
        /// C# 编译成 "abc"+"def"+"ghi" (一共3次创建  1次concat)
        /// </summary>
        public void C_Test05()
        {
            const string a = "abc";
            var b = "def";
            var s = a + b + "ghi";
        }

        #endregion

        #region D:+=  和 + 对比

        /// <summary>
        /// 发生了三次concat 效率慢
        /// </summary>
        public void D_Test01()
        {
            var a = "a";
            a += "b";
            a += "c";
            a += "d";
        }

        /// <summary>
        /// 发生了一次concat 效率快
        /// </summary>
        public void D_Test02()
        {
            string a = "a", b = "b", c = "c", d = "d";
            var s = a + b + c + d;
        }

        #endregion
    }
}