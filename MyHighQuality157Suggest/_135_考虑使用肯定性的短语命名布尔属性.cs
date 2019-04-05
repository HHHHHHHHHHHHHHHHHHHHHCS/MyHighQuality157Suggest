using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用肯定性的短语来表示布尔值
    /// 以is can has 作为前缀
    ///
    /// 不要直接使用动词 可能会混淆
    /// </summary>
    public class _135_考虑使用肯定性的短语命名布尔属性
    {
        //推荐用下面的
        public bool IsEnabled { get; set; }
        public bool IsTabStop { get; set; }
        public bool AllowDrop { get; set; }
        public bool IsActive { get; }
        public bool IsChecked { get; set; }


        //不推荐用下面的
        public bool Checked { get; set; }
        public bool Loaded { get; set; }
    }
}
