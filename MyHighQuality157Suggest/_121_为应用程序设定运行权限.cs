using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 比如只有系统管理员才能访问的若干功能
    /// 这个时候可以结合.NET中代码访问的安全性和基于角色的安全性去实现
    /// </summary>
    public class _121_为应用程序设定运行权限
    {
        /// <summary>
        /// 如果是@"Administrator" 则需要管理员权限运行
        /// 如果是@"Users" 则可以直接运行
        /// </summary>
        public void Test01()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            SampleClass sample = new SampleClass();
            Console.WriteLine("代码运行成功");
        }

        /// <summary>
        /// 也能用权限的方法来执行
        /// </summary>
        public void Test02()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            UserClass sample = new UserClass();
            sample.Test01();
            sample.Test02();
        }

        /// <summary>
        /// 不同用户权限不同
        /// </summary>
        public void Test03()
        {
            GenericIdentity examIdentity = new GenericIdentity("ExamUser");
            //string[] users = {"Teacher", "Student"};
            string[] users = {"Student"};
            GenericPrincipal myPrincipal = new GenericPrincipal(examIdentity, users);
            Thread.CurrentPrincipal = myPrincipal;//这里是设置了主线程的权限
            ScoreProcessor score = new ScoreProcessor();
            score.Update();//这里有匹配用户
        }


        [PrincipalPermission(SecurityAction.Demand,Role =@"Administrator")]
        //[PrincipalPermission(SecurityAction.Demand,Role =@"Users")]
        private class SampleClass
        {

        }

        private class UserClass
        {
            public void Test01()
            {
                Console.WriteLine("执行方法Test01");
            }

            [PrincipalPermission(SecurityAction.Demand, Role = @"Administrator")]
            //[PrincipalPermission(SecurityAction.Demand,Role =@"Users")]
            public void Test02()
            {
                Console.WriteLine("执行方法Test02");
            }
        }

        private class ScoreProcessor
        {
            public void Update()
            {
                try
                {
                    PrincipalPermission permission = new PrincipalPermission("ExamUser", "Teacher");
                    permission.Demand();//检测权限是否匹配
                    Console.WriteLine("修改成绩成功");
                }
                catch (SecurityException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
