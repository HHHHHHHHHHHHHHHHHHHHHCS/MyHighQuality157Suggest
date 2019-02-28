using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// sealed是不能被其他类继承的
    /// </summary>
    public class _108_将类型标识为sealed
    {
        private sealed class SampleClass
        {

        }

        //不能继承会报错
        //private class OtherClass : SampleClass
        //{
        //
        //}
    }
}
