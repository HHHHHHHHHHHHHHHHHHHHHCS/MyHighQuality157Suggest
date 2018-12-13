using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 根据传入的key  调用函数
    /// 当key 的类型过多的时候建议用Dictionary
    /// </summary>
    public class M001_SwitchDictionary
    {
        private readonly Dictionary<int, Action> dic;

        public M001_SwitchDictionary()
        {
            dic = new Dictionary<int, Action>
            {
                {1, Do1},
                {2, Do2},
                {3, Do3},
                {4, Do4},
                {5, Do5},
                {6, Do6},
                {7, Do7}
            };
        }

        public void Test01(int i)
        {
            switch (i)
            {
                case 1:
                    Do1();
                    break;
                case 2:
                    Do2();
                    break;
                case 3:
                    Do3();
                    break;
                case 4:
                    Do4();
                    break;
                case 5:
                    Do5();
                    break;
                case 6:
                    Do6();
                    break;
                case 7:
                    Do7();
                    break;
                default:
                    throw new Exception("Test01() 输入的Key不存在方法");
            }
        }

        public void Test02(int i)
        {
            if (dic.TryGetValue(i, out Action act))
            {
                act();
            }
            else
            {
                throw new Exception("Test02() 输入的Key不存在方法");
            }
        }


        private void Do1()
        {
        }

        private void Do2()
        {
        }

        private void Do3()
        {
        }

        private void Do4()
        {
        }

        private void Do5()
        {
        }

        private void Do6()
        {
        }

        private void Do7()
        {
        }
    }
}