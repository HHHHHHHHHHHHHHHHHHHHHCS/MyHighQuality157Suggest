using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _149_使用表驱动法避免过长的if和switch分支
    {
        private enum Week
        {
            Mon,
            Tues,
            Wed,
            Thus,
            Fri,
            Sat,
            Sun
        }

        //分支太长 而且出现了重复代码
        //不利于扩展 比如有星期八怎么办
        private string GetChineseWeek(Week week)
        {
            switch (week)
            {
                case Week.Mon:
                    return "星期一";
                    break;
                case Week.Tues:
                    return "星期二";
                    break;
                case Week.Wed:
                    return "星期三";
                    break;
                case Week.Thus:
                    return "星期四";
                    break;
                case Week.Fri:
                    return "星期五";
                    break;
                case Week.Sat:
                    return "星期六";
                    break;
                case Week.Sun:
                    return "星期日";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("week", "星期值超出范围");
            }
        }

        //查字典方法 即 表驱动法
        //但是 如果要用只是 int string 进行匹配还好
        //如果要执行方法 则不行
        private string GetChineseWeekInTable(Week week)
        {
            string[] chineseWeek = {"星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "星期日"};
            return chineseWeek[(int) week];
        }


        private void TestAct()
        {
            SampleClass sample = new SampleClass();
            var addMethod = typeof(SampleClass).GetMethod(ActionInTable(Week.Mon));
            addMethod.Invoke(sample, null);
        }


        private string ActionInTable(Week week)
        {
            string[] methods = {"Cleaning", "CleanCloset", "Quarrel", "Shopping", "Temp", "Temp", "Temp"};
            return methods[(int) week];
        }

        private class SampleClass
        {
            public void Cleaning()
            {
                Console.WriteLine("打扫");
            }

            public void CleanCloset()
            {
                Console.WriteLine("清理衣柜");
            }

            public void Quarrel()
            {
                Console.WriteLine("吵架");
            }
            public void Shopping()
            {
                Console.WriteLine("购物");
            }

        }
    }
}
