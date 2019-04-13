//#define ONLINE
//#define OFFLINE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 比如以下理由
    /// 应用程序有体验版和完整功能版
    /// 应用程序在迭代过程中需要屏蔽一些不成熟的功能
    ///
    /// 可以用Attribute 和 define 来实现
    ///
    /// 也可以在VS 中 ->生成 条件编译符号 中添加
    /// </summary>
    public class _156_利用特性为应用程序提供多个版本
    {
        [Conditional("ONLINE")]
        public void Testing()
        {
            Console.WriteLine("完整功能版");
        }

        [Conditional("ONLINE"),Conditional("OFFLINE")]
        public void GetInfoFromNet()
        {
            Console.WriteLine("单机版功能");
        }
    }
}
