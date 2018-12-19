using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 实现tostring的接口 来展现更多的tostring效果
    /// </summary>
    public class _013_FormatToString
    {
        /// <summary>
        /// 直接实现IFormattable 
        /// </summary>
        public void Test01()
        {
            Man man = new Man();
            Console.WriteLine(man.ToString());
            Console.WriteLine(man.ToString("One", null));
            Console.WriteLine(man.ToString("Two", null));
        }

        /// <summary>
        /// 实现IFormatProvider,ICustomFormatter
        /// </summary>
        public void Test02()
        {
            Man man = new Man();
            ManFormat mf = new ManFormat();
            Console.WriteLine(man.ToString("One", mf));
            Console.WriteLine(man.ToString("Two", mf));
            Console.WriteLine(man.ToString("Four", mf));
        }


        private class Man:IFormattable
        {
            public string Name { get; set; } = "name";
            public int Age { get; set; } = 2333;
            public string Mail { get; set; } = "mail";
            public string Address { get; set; } = "address";

            public string ToString(string format, IFormatProvider formatProvider)
            {
                string str;
                switch (format)
                {
                    case "All":
                        str = $"Name:{Name},Age:{Age},Mail:{Mail},Address:{Address}";
                        break;
                    case "One":
                        str = $"Name:{Name}";
                        break;
                    case "Two":
                        str = $"Name:{Name},Age:{Age}";
                        break;
                    case "Three":
                        str = $"Name:{Name},Age:{Age},Mail:{Mail}";
                        break;
                    default:
                        if (!(formatProvider is ICustomFormatter customFormatter))
                        {
                            str = this.ToString();
                        }
                        else
                        {
                            str = customFormatter.Format(format, this, null);
                        }
                        break;
                }
                return str;
            }

            public override string ToString()
            {
                return $"Name:{Name},Age:{Age}";
            }
        }

        private class ManFormat:IFormatProvider,ICustomFormatter
        {
            public object GetFormat(Type formatType)
            {
                if (formatType ==typeof( ICustomFormatter))
                {
                    return this;
                }
                else
                {
                    return null;
                }
            }

            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                if (!(arg is Man man))
                {
                    return string.Empty;
                }

                string str;
                switch (format)
                {
                    case "Four":
                        str = $"Name:{man.Name},Age:{man.Age},Mail:{man.Mail},Address:{man.Address}";
                        break;
                    default:
                        if (!(formatProvider is ICustomFormatter customFormatter))
                        {
                            str = this.ToString();
                        }
                        else
                        {
                            str = customFormatter.Format(format, this, null);
                        }
                        break;
                }
                return str;
            }
        }

    }
}
