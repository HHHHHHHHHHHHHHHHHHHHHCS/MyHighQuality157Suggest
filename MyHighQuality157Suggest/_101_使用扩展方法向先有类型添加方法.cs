using System;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 1.可以扩展密封类型
    /// 2.可以扩展第三方程序集中的类型
    /// 3.扩展方法可以避免不必要的深度继承体系
    /// 4.扩展方法还能扩展接口
    /// 当然还要遵循一些要求
    /// 1.扩展方法最必须在静态类,而且不能是嵌套类
    /// 2.扩展方法必须是静态的
    /// 3.扩展方法的第一参数必须是要扩展的类型,而且必须加上this关键字
    /// 4.不支持扩展属性和事件
    /// </summary>
    public class _101_使用扩展方法向先有类型添加方法
    {
        /// <summary>
        /// 以前的办法
        /// </summary>
        public void Test01()
        {
            Student s = new Student();
            Console.WriteLine(StudentConverter.GetSexString(s));
        }

        public void Test02()
        {
            Student s = new Student();
            Console.WriteLine(s.GetSexString());
        }

        public class Student
        {
            public bool GetSex()
            {
                return false;
            }
        }

        private static class StudentConverter
        {
            public static string GetSexString( Student student)
            {
                return student.GetSex() ? "男" : "女";
            }
        }

    }


    public static class StudentExtension
    {
        public static string GetSexString(this _101_使用扩展方法向先有类型添加方法.Student student)
        {
            return student.GetSex() ? "男 W" : "女 M";
        }
    }
}