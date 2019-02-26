using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHighQuality157Suggest
{
    /// <summary>
    /// 区别:
    /// 1.接口支持多继承,抽象类则不能
    /// 2.接口可以包含方法.属性.索引器.事件的签名,但不能有实现.抽象类则可以.
    /// 3.接口在增加新方法后,所有的继承者都必须重构,否则编译不会通过,而抽象类则不需要
    /// 使用场景:
    /// 1.如果对象存在多个功能相近且关系密切的版本,则使用抽象类
    /// 2.如果对象关系不紧密,但是若干功能拥有共同的声明,则使用接口
    /// 3.抽象类适合于提供丰富功能的场合,接口则更倾向于提供单一的一组功能
    /// </summary>
    public class _102_区分接口和抽象类的应用场合
    {
        //比如Steam及子类FileStream,MemoryStream,BufferedStream 使用的就是抽象类
        //在某种角度来看,抽象类比接口更具有代码的重用性,子类无序编写代码即可具备一个共性的行为


        //接口的职责必须单一,在接口的方法应该尽可能简练.
        //比如List 之类的 就可以用接口 IEnumerable<T>
        //在比如IDispose
    }
}
