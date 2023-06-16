using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    class Program
    {
        //参考资料：
        //作者：二次元攻城狮的博客
        //博客地址：https://www.cnblogs.com/timefiles/p/CsharpEventBase.html#%E5%8F%82%E8%80%83%E8%B5%84%E6%96%99

        //简介#
        //事件总线是对发布-订阅模式的一种实现，是一种集中式事件处理机制，允许不同的组件之间进行彼此通信而又不需要相互依赖，达到一种解耦的目的。
        //实现事件总线#
        //EventBus维护一个事件的字典，发布者、订阅者在事件总线中获取事件实例并执行发布、订阅操作，事件实例负责维护、执行事件处理程序。流程如下：
        //定义事件基类#
        //事件实例需要在事件总线中注册，定义一个基类方便事件总线进行管理，代码如下：
        /// <summary>
        /// 事件基类
        /// </summary>
        //事件实例需要管理、执行已经注册的事件处理程序，为了适应不同的事件参数使用泛型参数，不允许此类实例化。代码如下：
        /// <summary>
        /// 泛型事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
       
        //定义事件参数基类#
        //事件参数基类继承EventArgs，使用泛型参数适应不同的参数类型，不允许此类实例化。代码如下：
        /// <summary>
        /// 泛型事件参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
      
        //定义EventBus#
        //EventBus只提供事件实例的管理，具体事件处理程序的执行由事件实例自己负责。为了使用方便，构造函数有自动注册事件的功能，在有多个程序集时可能会有bug。代码如下：
        
        //使用事件总线#
        //事件及事件参数#
        //使用事件总线前，需要定义好事件及事件参数。在使用时，发布者、订阅者也必须知道事件类型及事件参数类型。代码如下：
        /// <summary>
        /// 泛型事件实现-TestAEvent，重写事件的触发逻辑
        /// </summary>
      
        /// <summary>
        /// 泛型事件参数实现-TestAEventArgs
        /// </summary>
        

        /// <summary>
        /// 泛型事件实现-TestBEvent
        /// </summary>
         
        /// <summary>
        /// 泛型事件参数实现-TestBEventArgs
        /// </summary>
        
        //注：TestAEvent中重写了事件发布的逻辑，每个事件在任务中执行。
        //定义发布者#
        //发布者通过事件总线获取事件实例，在实例上发布事件，代码如下：
       
        //定义订阅者#
        //订阅者通过事件总线获取事件实例，在实例上订阅事件，代码如下：

       
        //实际使用#
        //代码如下：
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            ScbscriberA scbscriberA = new ScbscriberA("scbscriberA");
            ScbscriberB scbscriberB1 = new ScbscriberB("scbscriberB1");
            ScbscriberB scbscriberB2 = new ScbscriberB("scbscriberB2");
            publisher.PublishTeatAEvent("test");
            publisher.PublishTeatBEvent(123);

            scbscriberB2.Unsubscribe_TeatBEvent();
            publisher.PublishTeatBEvent(12345);

            Console.ReadKey();
        }
        //运行结果：
        //scbscriberB1:123
        //scbscriberB2:123
        //scbscriberA:test
        //scbscriberB1:12345
        //总结#
        //这个事件总线只提供了基础功能，实现的发布者和订阅者的解耦，发布者、订阅者只依赖事件不互相依赖。
        //感觉我对事件总线的理解还有点不足，欢迎大家来一起讨论！
         
    }
}
