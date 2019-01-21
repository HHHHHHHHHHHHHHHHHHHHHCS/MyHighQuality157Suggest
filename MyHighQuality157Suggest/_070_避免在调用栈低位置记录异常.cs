using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 避免在调用栈低位置记录异常
    /// 异常重复出现,也要一直避免漏了重新抛出
    /// </summary>
    public class _070_避免在调用栈低位置记录异常
    {
        public void Test01()
        {
            High();
        }

        private void High()
        {
            try
            {
                Middle();
            }
            catch (Exception e)
            {
                Console.WriteLine("High:" + e);
            }
        }

        private void Middle()
        {
            try
            {
                Low();
            }
            catch (Exception e)
            {
                Console.WriteLine("Middle:" + e);
                throw;
            }
        }

        private void Low()
        {
            try
            {
                throw new Exception("23333");
            }
            catch (Exception e)
            {
                Console.WriteLine("Low:" + e);
                throw;
            }
        }
    }
}