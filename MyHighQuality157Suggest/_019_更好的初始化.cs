using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 用{} 初始化写起来更快,看起来更简洁
    /// 而且还能写匿名类
    /// </summary>
    public class _019_更好的初始化
    {
        public void Test01()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
        }

        public void Test02()
        {
            var list = new List<People>
            {
                new People {Name = "a", Age = 1},
                new People {Name = "b", Age = 2},
                new People {Name = "c", Age = 3},
                new People {Name = "d", Age = 4},
                new People {Name = "e", Age = 5},
                new People {Name = "f", Age = 18},
                new People {Name = "g", Age = 19},
                new People {Name = "h", Age = 61},
            };

            var pTemp = from p in list
                where p.Age >= 18
                select new
                {
                    p.Name,
                    AgeScope = p.Age >= 60 ? "old" : "young"
                };
            foreach (var item in pTemp)
            {
                Console.Write(item+"///");
                Console.Write(item.Name+","+item.AgeScope);
            }
        }

        private class People
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}