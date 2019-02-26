using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用多态代替条件语句
    /// 我们之前用switch 或者 if 来判断 然后执行方法
    /// 但是多了之后 可以用多态来表示
    /// </summary>
    class _104_用多态代替条件语句
    {
        private enum DriveCommand
        {
            Start,
            Stop,
            Pause,
            TurnLeft,
            TurnRight,
        }


        /// <summary>
        /// 这是老的办法 但是会显示很长
        /// </summary>
        public void Test01()
        {
            DriveCommand command = DriveCommand.Start;
            switch (command)
            {
                case DriveCommand.Start:
                    break;
                case DriveCommand.Stop:
                    break;
                case DriveCommand.Pause:
                    break;
                case DriveCommand.TurnLeft:
                    break;
                case DriveCommand.TurnRight:
                    break;
                default:
                    break;
            }
        }





        /// <summary>
        /// 多态实现
        /// 用多态之后,代码简洁不少.并且可扩展性增强了
        /// 如果未来还要增加命令,扩充子类就可以了,
        /// 而且我们还关闭了修改 , 增加再多的命令 , 也不需要对其进行修改 .
        /// </summary>
        public void Test02()
        {
            Commander start = new StartCommander();
            Drive(start);
            Commander stop = new StopCommander();
            Drive(stop);
        }

        private void Drive(Commander command)
        {
            command.Execute();
        }

        private abstract class Commander
        {
            public abstract void Execute();
        }

        private class StartCommander : Commander
        {
            public override void Execute()
            {
            }
        }

        private class StopCommander : Commander
        {
            public override void Execute()
            {
            }
        }

        private class PauseCommander : Commander
        {
            public override void Execute()
            {
            }
        }

        private class TurnLeftCommander : Commander
        {
            public override void Execute()
            {
            }
        }

        private class TurnRightCommander : Commander
        {
            public override void Execute()
            {
            }
        }
    }
}
