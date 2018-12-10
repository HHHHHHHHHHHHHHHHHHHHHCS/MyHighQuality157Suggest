using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在字符串拼接的时候 建议手动添加tostring 防止装箱
    /// 在拼接字符串过多的时候建议用stringBuilder
    ///     或者用format 但是记得tostring()
    /// 在内部string 直接拼接的时候可以试一试 申明 const string
    /// </summary>
    public class _001_正确的字符串
    {
        /*
         * 为什么 装箱 会效率慢
         * 1.)会为值类型在托管对中分配内存,除了值类型本身锁分配的内存外
         *      内存总量还要加上类型对象指针和同步块索引所占用的内存
         * 2.)将值类型的值复制到新分配的堆内存中
         * 3.)返回已成为引用类型的对象的地址
         */

        #region 装箱

        /// <summary>
        /// + 即是 concat
        /// 233 会发生一次box
        /// </summary>
        public void Test01()
        {
            string s = "how" + 233;
        }

        /// <summary>
        /// tostring 是内存int->string 效率比box 快很多
        /// </summary>
        public void Test02()
        {
            string s = "how" + 233.ToString();
        }

        /// <summary>
        /// 这个等价于 Test04
        /// 会存储"{0}{1}" "how" 两个字符串
        /// 并且会发生装箱
        /// </summary>
        public void Test03()
        {
            string s = string.Format("{0}{1}", "how", 233);
        }

        /// <summary>
        /// 等价于 Test03
        /// </summary>
        public void Test04()
        {
            string s = $"{"how"}{233}";
        }

        #endregion

        #region 多字符相加(concat format StringBuilder)

        /// <summary>
        /// 会有多次装箱
        /// </summary>
        public void Test05()
        {
            string s = "1" + 2 + "3" + 4 + "5";
        }

        /// <summary>
        /// 没有多次装箱 
        /// </summary>
        public void Test06()
        {
            string s = "1" + 2.ToString() + "3" + 4.ToString() + "5";
        }

        /// <summary>
        /// 因为2 4 转string 的时候有装箱
        /// 内部是用stringBuilder 实现的
        /// </summary>
        public void Test07()
        {
            string s = string.Format("{0}{1}{2}{4}", "1", 2, "3", 4, "5");
        }

        /// <summary>
        /// 因为sb 内部实现了int.ToString() 所以转不转成string 无所谓
        /// 在拼接过多的时候 建议用
        /// StringBuilder->线程安全 StringBuffer->线程不安全
        /// </summary>
        public void Test08()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1").Append(2).Append("3").Append(4).Append("5");
        }

        /// <summary>
        /// 同 Test08,不过推荐Test08 比较好
        /// </summary>
        public void Test09()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("1").Append(2.ToString()).Append("3").Append(4.ToString()).Append("5");
        }

        #endregion

        #region const string 的作用

        /// <summary>
        /// 这里创建了两个string 并且有发生一次concat
        /// </summary>
        public void Test10()
        {
            string a = "abc";
            string s = a + "def";
        }

        /// <summary>
        /// 直接编译成 abcedf 了
        /// </summary>
        public void Test11()
        {
            const string a = "abc";
            string s = a + "def";
        }

        /// <summary>
        /// 同Test11
        /// </summary>
        public void Test12()
        {
            string s = "abc" + "def";
        }

        /// <summary>
        /// C# 编译成 "abc"+"defghi" (一共2次创建  1次concat)
        /// </summary>
        public void Test13()
        {
            string a = "abc";
            const string b = "def";
            string s = a + b + "ghi";
        }

        /// <summary>
        /// C# 编译成 "abc"+"def"+"ghi" (一共3次创建  1次concat)
        /// </summary>
        public void Test14()
        {
            const string a = "abc";
            string b = "def";
            string s = a + b + "ghi";
        }

        #endregion

        #region +=  和 + 对比

        /// <summary>
        /// 发生了三次concat 效率慢
        /// </summary>
        public void Test15()
        {
            string a = "a";
            a += "b";
            a += "c";
            a += "d";
        }

        /// <summary>
        /// 发生了一次concat 效率快
        /// </summary>
        public void Test16()
        {
            string a = "a", b = "b", c = "c", d = "d";
            string s = a + b + c + d;
        }

        #endregion
    }
}