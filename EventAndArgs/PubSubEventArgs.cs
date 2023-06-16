using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    /// <summary>
    /// 泛型事件参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PubSubEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
}
