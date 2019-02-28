using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 枚举最大的有点在于它的类型是值类型.
    /// 相比较引用类型来说,他可以在关键算法中提升性能,因为他不需要创建在 堆 中.
    /// 但是如果不考虑这方便的因素 , 我们不妨让类(引用类型)来代替枚举
    /// </summary>
    public class _110_用类代替enum
    {
        public void Test01()
        {
            Console.WriteLine(WeekClass_CN.Saturday.Msg());
            Console.WriteLine(WeekClass_USA.Saturday.Msg());
        }




        public enum Week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }



        /// <summary>
        /// class WeekClass相比enum Week 
        /// 优点在于它能够添加方法或重写基类方法
        /// 扩展enum也可以提供方法,但是不能重写
        /// 以便提供更丰富的功能
        /// </summary>
        private class WeekClass_CN
        {
            public static readonly WeekClass_CN Monday = new WeekClass_CN(0);
            public static readonly WeekClass_CN Tuesday = new WeekClass_CN(1);
            public static readonly WeekClass_CN Saturday = new WeekClass_CN(5);

            protected int _infoType;

            protected WeekClass_CN(int infoType)
            {
                _infoType = infoType;
            }

            public virtual string Msg()
            {
                switch (_infoType)
                {
                    case 0:
                        return "星期一";
                    case 1:
                        return "星期二";
                    case 2:
                        return "星期三";
                    case 3:
                        return "星期四";
                    case 4:
                        return "星期五";
                    case 5:
                        return "星期六";
                    case 6:
                        return "星期天";
                    default:
                        return "星期错误";
                }
            }
        }

        private class WeekClass_USA:WeekClass_CN
        {
            public static readonly WeekClass_USA Monday = new WeekClass_USA(0);
            public static readonly WeekClass_USA Tuesday = new WeekClass_USA(1);
            public static readonly WeekClass_USA Saturday = new WeekClass_USA(5);

            protected WeekClass_USA(int infoType) : base(infoType)
            {

            }

            public override string Msg()
            {
                switch (_infoType)
                {
                    case 0:
                        return "Mon";
                    case 1:
                        return "Tue";
                    case 2:
                        return "Wed";
                    case 3:
                        return "Thu";
                    case 4:
                        return "Fri";
                    case 5:
                        return "Sat";
                    case 6:
                        return "Sun";

                    default:
                        return "week err";
                }
            }
        }
    }

    public static class WeekEx
    {
        public static string Chinese(this _110_用类代替enum.Week week)
        {
            switch (week)
            {
                case _110_用类代替enum.Week.Monday:
                    return "星期一";
                case _110_用类代替enum.Week.Tuesday:
                    return "星期二";
                case _110_用类代替enum.Week.Wednesday:
                    return "星期三";
                case _110_用类代替enum.Week.Thursday:
                    return "星期四";
                case _110_用类代替enum.Week.Friday:
                    return "星期五";
                case _110_用类代替enum.Week.Saturday:
                    return "星期六";
                case _110_用类代替enum.Week.Sunday:
                    return "星期天";
                default:
                    return "星期错误";
            }
        }
    }
}
