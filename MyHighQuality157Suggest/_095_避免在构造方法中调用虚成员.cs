using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 在构造方法中调用虚成员,会带来一些意想不到的错误
    /// 虽然这种用法不常见,但是还是注意这类陷阱
    /// </summary>
    public class _095_避免在构造方法中调用虚成员
    {
        /// <summary>
        /// 这里先调用父类的构造方法,但是子类还没有执行Init
        /// 所以会直接报错:空引用
        /// </summary>
        public void Test01()
        {
            American american = new American();
        }

        private class Person
        {
            public Person()
            {
                InitSkin();
            }

            protected virtual void InitSkin()
            {
                Console.WriteLine("Base InitSkin");
            }
        }

        private class American : Person
        {
            Race race;

            public American():base()
            {
                race = new Race() {Name = "White"};
            }

            protected override void InitSkin()
            {
                Console.WriteLine(race.Name);
            }
        }

        private class Race
        {
            public string Name { get; set; }
        }
    }
}
