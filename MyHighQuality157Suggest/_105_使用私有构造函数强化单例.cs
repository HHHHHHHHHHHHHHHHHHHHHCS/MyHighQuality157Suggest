using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用私有构造函数强化单例
    /// 同时添加 私有构造函数 不能在外部被实例化
    /// 添加lock 保证线程安全
    /// </summary>
    public class _105_使用私有构造函数强化单例
    {

        private sealed class Singleton
        {
            private static Singleton instance = null;

            private static readonly object padLock = new object();

            public static Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (padLock)
                        {
                            if (instance == null)
                            {
                                instance = new Singleton();
                            }
                        }
                    }

                    return instance;
                }
            }


            /// <summary>
            /// 限制不能在外部被实例化
            /// </summary>
            private Singleton()
            {

            }

            public void SampleMethod()
            {

            }
        }


    }
}
