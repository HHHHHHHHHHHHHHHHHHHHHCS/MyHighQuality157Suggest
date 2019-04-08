using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 为了清晰
    /// </summary>
    public class _143_方法抽象级别应在同一层次
    {
        private class SampleClass0
        {
            public void Init()
            {
                //本地初始化代码1
                //本地初始化代码2
                RemoteInit();
            }

            private void RemoteInit()
            {
                //远程初始化代码1
                //远程初始化代码2
            }
        }

        private class SampleClass1
        {
            public void Init()
            {
                LoadInit();
                RemoteInit();
            }

            private void LoadInit()
            {                
                //本地初始化代码1
                //本地初始化代码2
            }

            private void RemoteInit()
            {
                //远程初始化代码1
                //远程初始化代码2
            }
        }
    }
}
