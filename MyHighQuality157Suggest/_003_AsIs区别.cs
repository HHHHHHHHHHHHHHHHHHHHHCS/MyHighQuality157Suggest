using System;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// as is 强转的使用
    /// </summary>
    public class _003_AsIs区别
    {
        /*
         * as 对比强转
         * as转换不会报异常有安全性 也不用trycatch捕获
         * 效率也比强转高 他会先判断是否属于转换目标类型 要么派生类
         * 并且不产生新的对象
         * 但是as 只用于非 基础类型
         *
         * 如果用 a as b  就没有必要使用is了 会重复进行一次判断
         *
         * 如果要基础类型进行转换 判断可以用is
         */

        /// <summary>
        /// 重载操作符 不能 使用as
        /// </summary>
        public void Test01()
        {
            var first = new FirstClass();
            var second = (SecondClass) first; //成功
            //second = first as SecondClass;//编译失败
        }

        /// <summary>
        /// as IL之后是castclass   强转 IL之后是isinit
        /// as 是不会报错的  但是转失败之后会为null
        /// </summary>
        public void Test02()
        {
            var first = new FirstClass();
            object obj = first;
            //SecondClass t = (SecondClass)obj;//欺骗了编译器 但是运行会报错
            var second = obj as SecondClass; //不会报错但是会为null
        }

        /// <summary>
        /// is 可以判断 是否是XX 的子类
        /// </summary>
        public void Test03()
        {
            Anim anim = new Anim();
            Cat cat = new Cat();
            Dog dog = new Dog();
            if (cat is Anim)
            {
                Console.WriteLine("cat is Anim");
            }

            if (anim is Cat)
            {
                Console.WriteLine("anim is Cat");
            }

            if (dog is Cat)
            {
                Console.WriteLine("dog is Cat");
            }

        }

        private class FirstClass
        {
            public string Name { get; set; } = "First";
        }

        private class SecondClass
        {
            public string Name { get; set; } = "Second";

            public static explicit operator SecondClass(FirstClass firstClass)
            {
                var second = new SecondClass()
                {
                    Name = "转型自:" + firstClass.Name
                };
                return second;
            }
        }

        private class Anim
        {
        }

        private class Dog : Anim
        {
        }

        private class Cat : Anim
        {
        }
    }
}