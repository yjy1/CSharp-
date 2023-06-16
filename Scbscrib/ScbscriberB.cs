using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    class ScbscriberB
    {
        public string Name { get; set; }

        public ScbscriberB(string name)
        {
            Name = name;
            EventBus.Default.GetEvent<TestBEvent>().Subscribe(TeatBEventHandler);
        }

        public void Unsubscribe_TeatBEvent()
        {
            EventBus.Default.GetEvent<TestBEvent>().Unsubscribe(TeatBEventHandler);
        }

        public void TeatBEventHandler(object sender, TestBEventArgs e)
        {
            Console.WriteLine(Name + ":" + e.Value);
        }
    }
}
