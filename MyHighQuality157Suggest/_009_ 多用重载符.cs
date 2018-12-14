using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 重载操作符 在之后写代码比较方便简单
    /// </summary>
    public class _009__多用重载符
    {
        private class Unit
        {
            public float HP { get; set; } = 0;
            public float MP { get; set; } = 0;

            public Unit()
            {

            }

            public Unit(float hp,float mp)
            {
                HP = hp;
                MP = mp;
            }

            public static Unit Add(Unit a, Unit b)
            {
                Unit unit = new Unit
                {
                    HP = a.HP + b.HP, MP = a.MP + b.MP
                };
                return unit;
            }

            public void Add(Unit unit)
            {
                HP += unit.HP;
                MP += unit.HP;
            }

            public static Unit operator +(Unit a, Unit b)
            {
                a.HP += b.HP;
                a.MP += b.HP;
                return a;
            }
        }

        public void Test01()
        {
            Unit unit1 = new Unit(1, 1);
            Unit unit2 = new Unit(2, 2);

            unit1 = Unit.Add(unit1, unit2);

            unit1.Add(unit2);

            unit1 = unit1 + unit2;
            unit1 += unit2;
        }
    }
}