using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    class ScbscriberA
    {
        public string Name { get; set; }

        public ScbscriberA(string name)
        {
            Name = name;
            EventBus.Default.GetEvent<TestAEvent>().Subscribe(TeatAEventHandler);
        }

        public void TeatAEventHandler(object sender, TestAEventArgs e)
        {
            Console.WriteLine(Name + ":" + e.Value);
        }
    }
}
