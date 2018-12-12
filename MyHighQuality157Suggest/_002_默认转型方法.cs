using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 类型的转换
    /// </summary>
    public class _002_默认转型方法
    {
        /// <summary>
        /// 基础类型 显式隐式转换
        /// </summary>
        public void Test01()
        {
            int i = 0;
            float j = 0;
            j = i; //存在隐式转换
            i = (int) j; //显式转换
        }

        /// <summary>
        /// 利用operator 进行显示和隐式转换
        /// </summary>
        public void Test02()
        {
            Ip ip1 = "192.168.0.1";
            Ip ip2 = (Ip) new byte[] {192, 168, 0, 1};
            Ip ip3 = new Ip("192.168.0.2");
        }

        /// <summary>
        /// 利用类型的parse TryParse toString 进行转换
        /// </summary>
        public void Test03()
        {
            int a = int.Parse("2333");
            Console.WriteLine(a);
            var isSuccess = int.TryParse("x2333", out int b);
            Console.WriteLine(new {isSuccess, b});
            var c = DateTime.Parse("2018/8/8");
            Console.WriteLine(c);
            isSuccess = int.TryParse("2018/88/88", out var d);
            Console.WriteLine(new {isSuccess, d});
        }

        /// <summary>
        /// 实现IConvertible接口 手动进行Convert
        /// </summary>
        public void Test04()
        {
            Ip ip1 = "192.168.0.1";
            var int64 = Convert.ToInt64(ip1);
            Console.WriteLine(int64);
        }

        public void Test05()
        {
            Animal anim = new Animal();
            Cat cat=new Cat();
            Dog dog=new Dog();

            anim = cat;//子类转换成父类(隐式转换)
            cat = (Cat)anim;//父类转换成子类(必须要显式转换)

            //cat= dog;//子类之间互相转换报错

            //子类转换成父类 在转成别的子类也会报错
            //anim = cat;
            //dog = (Dog)anim;
            //但是这里用as 是不会报错的  不过dog会是null
            //dog = anim as Dog;
        }

        #region Ip Class

        class Ip : IConvertible
        {
            private IPAddress value;

            public Ip(string ip)
            {
                value = IPAddress.Parse(ip);
            }

            public Ip(byte arg0, byte arg1, byte arg2, byte arg3)
            {
                value = new IPAddress(new[] {arg0, arg1, arg2, arg3});
            }

            public Ip(byte[] args)
            {
                value = new IPAddress(args);
            }

            /// <summary>
            /// 这个是隐式转换
            /// </summary>
            /// <param name="ip"></param>
            public static implicit operator Ip(string ip)
            {
                var ipTemp = new Ip(ip);
                return ipTemp;
            }

            /// <summary>
            /// 显式转换
            /// </summary>
            /// <param name="arg0"></param>
            /// <param name="arg1"></param>
            /// <param name="arg2"></param>
            /// <param name="arg3"></param>
            public static explicit operator Ip(byte[] bytes)
            {
                var ipTemp = new Ip(bytes);
                return ipTemp;
            }

            public override string ToString()
            {
                return value.ToString();
            }

            public TypeCode GetTypeCode()
            {
                throw new InvalidCastException("Can't convert GetTypeCode()");
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToChar()");
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToSByte()");
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToByte()");
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToInt16()");
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToUInt16()");
            }

            public int ToInt32(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToInt32()");
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToUInt32()");
            }

            public long ToInt64(IFormatProvider provider)
            {
                var l = ((((long) value.GetAddressBytes()[0])
                          * 1000 + value.GetAddressBytes()[1])
                         * 1000 + value.GetAddressBytes()[2])
                        * 1000 + value.GetAddressBytes()[3];
                return l;
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                var l = ((((ulong) value.GetAddressBytes()[0])
                          * 1000 + value.GetAddressBytes()[1])
                         * 1000 + value.GetAddressBytes()[2])
                        * 1000 + value.GetAddressBytes()[3];
                return l;
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToSingle()");
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToDouble()");
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToDecimal()");
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToDateTime()");
            }

            public string ToString(IFormatProvider provider)
            {
                return value.ToString();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new InvalidCastException("Can't convert ToType()");
            }
        }

        #endregion

        #region Parent and Son

        class Animal
        {
        }

        class Cat : Animal
        {
        }

        class Dog : Animal
        {
        }

        #endregion
    }
}