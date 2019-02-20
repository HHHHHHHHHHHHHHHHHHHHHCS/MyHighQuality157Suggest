using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 如果是new 则独立于基类的方法
    /// override,子类的对象调用该方法,而不是调用基类的方法
    /// </summary>
    public class _094_区别对待override和new
    {
        public void Test01()
        {
            Shape s = new Circle();
            s.MethodVirtual();
            s.Method();

            Circle c = new Circle();
            c.MethodVirtual();
            c.Method();


            s = new Triangle();
            s.MethodVirtual();
            s.Method();

            Triangle t1 = new Triangle();
            t1.MethodVirtual();
            t1.Method();

            s = new Diamond();
            s.MethodVirtual();
            s.Method();

            Diamond d = new Diamond();
            d.MethodVirtual();
            d.Method();
        }


        private class Shape
        {
            public virtual void MethodVirtual()
            {
                Console.WriteLine("base method virtual");
            }

            public void Method()
            {
                Console.WriteLine("base method");
            }
        }

        private class Circle : Shape
        {
            public override void MethodVirtual()
            {
                Console.WriteLine("Circle Override MethodVirtual");
            }
        }

        private class Rectangle : Shape
        {
        }

        private class Triangle : Shape
        {
            public new void MethodVirtual()
            {
                Console.WriteLine("Triangle new MethodVirtual");
            }

            public new void Method()
            {
                Console.WriteLine("Triangle new Method");
            }
        }

        private class Diamond : Shape
        {
            public override void MethodVirtual()
            {
                Console.WriteLine("Diamond Override MethodVirtual");
            }
        }
    }
}