using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 虽然Exception 比较耗性能,但是加上去可以避免一些为预料的异常
    /// 最好加到最后
    /// </summary>
    public class _065_总是处理未捕获的异常
    {

        public void Test01()
        {
            try
            {

            }
            catch (IndexOutOfRangeException e)
            {

            }
            catch (DivideByZeroException e)
            {

            }
            catch (Exception e)
            {

            }
        }
    }
}
