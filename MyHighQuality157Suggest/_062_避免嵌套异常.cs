using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    public class _062_避免嵌套异常
    {
        /// <summary>
        /// 正确做法
        /// </summary>
        public void Test01()
        {
            try
            {
                int i = 0;
                i = 10 / i;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 错误做法不抛出throw 导致后面的catch没有被不活
        /// </summary>
        public void Test02()
        {
            try
            {
                try
                {
                    int i = 0;
                    i = 10 / i;
                }
                catch (Exception e)
                {
                    Console.WriteLine("1:" + e);
                    //throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("2:" + e);
            }
        }
    }
}
