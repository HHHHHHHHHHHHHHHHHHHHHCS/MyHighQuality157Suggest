using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用抛出异常的操作代替返回代码
    /// 效率:抛出异常虽然有效率,但是那点效率与等待网络连接异常相比,微不足道
    /// </summary>
    public class _058_抛出异常代替返回代码
    {
        /// <summary>
        /// 正常使用代码,可能会存在很多潜在问题
        /// 比如磁盘满了,权限不足
        /// </summary>
        public int Test01()
        {
            if (!SaveToFile())
            {
                return 1;
            }

            if (!SaveDataBase())
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// 要写异常日志,但是还是存在潜在危险
        /// </summary>
        public int Test02()
        {
            if (!SaveToFile())
            {
                Console.WriteLine("保存文件失败");
                return 1;
            }

            if (!SaveDataBase())
            {
                Console.WriteLine("储存数据失败");
                return 2;
            }

            return 0;
        }

        public int Test03()
        {
            try
            {
                SaveToFile();
                SaveDataBase();
            }
            //catch (IOException e)
            //{
            //Console.WriteLine("读写异常:" + e.Message);
            //  return 1;
            //}
            //catch (NetException e)
            //{
            //Console.WriteLine("网络连接异常:" + e.Message);
            //  return 2;
            //}
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("权限不足:" + e.Message);
                return 3;
            }
            catch (Exception e)
            {
                Console.WriteLine("其他异常:" + e.Message);
                return 4;
            }

            return 0;
        }


        public bool SaveToFile()
        {
            return true;
            throw new Exception("Fuck");
        }

        public bool SaveDataBase()
        {
            return true;
            throw new Exception("Ohhhh");
        }
    }
}
