using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
   

    /// <summary>
    /// 泛型事件实现-TestAEvent，重写事件的触发逻辑
    /// </summary>
    public class TestAEvent : PubSubEvent<TestAEventArgs>
    {
        public override void Publish(object sender, TestAEventArgs eventArgs)
        {
            lock (locker)
            {
                for (int i = 0; i < subscriptions.Count; i++)
                {
                    var action = subscriptions[i];
                    Task.Run(() => action(sender, eventArgs));
                }
            }
        }
    }
}
