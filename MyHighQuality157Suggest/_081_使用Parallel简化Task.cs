using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 使用Parallel简化同步状态下Task的使用
    /// Parallel会自动分配Task来完成任务
    /// </summary>
    public class _081_使用Parallel简化Task
    {
        /// <summary>
        /// 输出的顺序不是依次的
        /// 所以如果我们的输出必须是同步的或者说必须是顺序输出,则不应该是用Parallel
        /// </summary>
        public void Test01()
        {
            int[] nums = new int[] {0, 1, 2, 3, 4};
            Parallel.For(0, nums.Length, (i) => { Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码......", i, nums[i]); });
        }

        /// <summary>
        /// 用foreach处理泛型集合
        /// </summary>
        public void Test02()
        {
            List<int> nums = new List<int> {0, 1, 2, 3, 4};
            Parallel.ForEach(nums,
                (i) => { Console.WriteLine("针对数组索引{0}对应的那个元素{1}的一些工作代码......", i, nums[i]); });
        }

        /// <summary>
        /// 用Invoke执行多Task任务,不保证顺序
        /// </summary>
        public void Test03()
        {
            Parallel.Invoke(
                () => { Console.WriteLine("任务1......"); },
                () => { Console.WriteLine("任务2......"); },
                () => { Console.WriteLine("任务3......"); });
        }
    }
}