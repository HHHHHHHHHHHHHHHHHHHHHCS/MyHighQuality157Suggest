using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 捕获异常输出要的信息
    /// </summary>
    public class _060_重新异常时用InnerException
    {
        public void Test01()
        {
            try
            {
                Network();
            }
            catch (SocketException err)
            {
                Console.WriteLine(err.Data["socketInfo"].ToString());
            }
        }


        private void Network()
        {
            try
            {
            }
            catch (SocketException err)
            {
                err.Data.Add("SocketInfo", "网络连接失败");
                throw err;
            }
        }
    }
}
