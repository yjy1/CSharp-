using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    /// <summary>
    /// 泛型事件参数实现-TestBEventArgs
    /// </summary>
    public class TestBEventArgs : PubSubEventArgs<int> { }
}
