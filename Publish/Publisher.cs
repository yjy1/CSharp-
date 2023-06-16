using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    class Publisher
    {
        public void PublishTeatAEvent(string value)
        {
            EventBus.Default.GetEvent<TestAEvent>().Publish(this, new TestAEventArgs() { Value = value });
        }

        public void PublishTeatBEvent(int value)
        {
            EventBus.Default.GetEvent<TestBEvent>().Publish(this, new TestBEventArgs() { Value = value });
        }
    }
}
