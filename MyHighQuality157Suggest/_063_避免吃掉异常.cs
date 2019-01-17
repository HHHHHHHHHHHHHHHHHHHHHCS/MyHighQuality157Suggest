using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免吃掉异常,比如异常嵌套,不抛出异常信息
    /// </summary>
    public class _063_避免吃掉异常
    {
        /// <summary>
        /// 异常嵌套,正确抛出
        /// </summary>
        public void Test01()
        {
            try
            {
                try
                {
                    int i = 0;
                    i = 10 / i;
                }
                catch(Exception e)
                {
                    Console.WriteLine("1:" + e);
                    throw e;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("2:" + e);
                throw e;
            }
        }

        /// <summary>
        /// 处理异常信息
        /// </summary>
        public void Test02()
        {
            try
            {
                int i = 0;
                i = 10 / i;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);//如果注释则是不输出信息,应该避免不输出的情况
            }
        }
    }
}
