using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 可以用一种空间换时间的办法  空间开销也不大
    /// </summary>
    public class M002_字符判断
    {
        private static readonly byte[] charMap;

        static M002_字符判断()
        {
            charMap = new byte[char.MaxValue];
            for (char i = '0'; i <= '9'; i++)
            {
                charMap[i] = 1;
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                charMap[i] = 2;
            }

            for (char i = 'A'; i <= 'Z'; i++)
            {
                charMap[i] = 3;
            }

            charMap['/'] = 4;
            charMap['\\'] = 4;
            charMap['|'] = 4;
            charMap['$'] = 4;
            charMap['#'] = 4;
            charMap['+'] = 4;
            charMap['%'] = 4;
            charMap['&'] = 4;
            charMap['-'] = 4;
            charMap['^'] = 4;
            charMap['*'] = 4;
            charMap['='] = 4;

            charMap[','] = 5;
            charMap['.'] = 5;
            charMap['!'] = 5;
            charMap[':'] = 5;
            charMap[';'] = 5;
            charMap['?'] = 5;
            charMap['"'] = 5;
            charMap['\''] = 5;
        }

        public string Test01(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return "数字";
            }
            else if (c >= 'a' && c <= 'z')
            {
                return "小写字母";
            }
            else if (c >= 'A' && c < 'Z')
            {
                return "大写字母";
            }
            else
                switch (c) //跟下面的else if 一样
                {
                    case '/':
                    case '\\':
                    case '|':
                    case '$':
                    case '#':
                    case '+':
                    case '%':
                    case '&':
                    case '-':
                    case '^':
                    case '*':
                    case '=':
                        return "特殊符号";
                    case ',':
                    case '.':
                    case '!':
                    case ':':
                    case ';':
                    case '?':
                    case '"':
                    case '\'':
                        return "标点符号";
                    default:
                        return "其他";
                }

            //else if (c == '/' || c == '\\' || c == '|'
            //         || c == '$' || c == '#' || c == '+'
            //         || c == '%' || c == '&' || c == '-'
            //         || c == '^' || c == '*' || c == '=')
            //{
            //    return "特殊符号";
            //}
            //else if (c == ',' || c == '.' || c == '!'
            //         || c == ':' || c == ';' || c == '?'
            //         || c == '"' || c == '\'')
            //{
            //    return "标点符号";
            //}
        }

        public string Test02(char c)
        {
            switch (charMap[c])
            {
                case 0:
                    return "其他";
                case 1:
                    return "数字";
                case 2:
                    return "小写字母";
                case 3:
                    return "大写字母";
                case 4:
                    return "特殊符号";
                case 5:
                    return "标点符号";
                default:
                    return "其他";
            }
        }
    }
}