using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 将现实世界中的对象抽象为类,将可复用对象圈起来就是命名空间
    /// 比如把cat dog 放到animals 文件夹下 用namespace 就是分类命名空间了
    /// </summary>
    public class _112_现实对象抽象类复用对象命名空间
    {
        public void Test01()
        {
            Cat tom = new Cat();
            tom.Name = "Tom";
            tom.ScratchSofa();
        }


        private class Cat
        {
            public string Name { get; set; }

            public void ScratchSofa()
            {
                Console.WriteLine("{0}在挠沙发", Name);
            }
        }


    }
}
