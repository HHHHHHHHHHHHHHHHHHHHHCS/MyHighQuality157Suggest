using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 从System.Exception或者其他常见的异常中派生异常
    /// </summary>
    public class _068_从常见基本异常中派生异常
    {
        public void Test01()
        {
            try
            {
                throw new MyException("My", 233);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 小技巧,在打完Exception可以两下tab自动补全
        /// 异常必须可序列化,因为要穿越AppDomain边界
        /// </summary>
        [System.Serializable]
        public class MyException : Exception
        {
            private string msg;

            public MyException()
            {
            }

            public MyException(string message) : base(message)
            {
            }

            public MyException(string message, Exception inner) : base(message, inner)
            {
            }

            public MyException(String message, int arg)
            {
                msg = $"{message}_____{arg}";
            }

            public override string Message
            {
                get
                {
                    if (!string.IsNullOrEmpty(msg))
                    {
                        return msg;
                    }

                    return base.Message;
                }
            }

            protected MyException(
                System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context)
            {
            }
        }
    }
}