using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    /// <summary>
    /// 泛型事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PubSubEvent<T> : EventBase where T : EventArgs
    {
        protected static readonly object locker = new object();

        protected readonly List<Action<object, T>> subscriptions = new List<Action<object, T>>();

        public void Subscribe(Action<object, T> eventHandler)
        {
            lock (locker)
            {
                if (!subscriptions.Contains(eventHandler))
                {
                    subscriptions.Add(eventHandler);
                }
            }
        }

        public void Unsubscribe(Action<object, T> eventHandler)
        {
            lock (locker)
            {
                if (subscriptions.Contains(eventHandler))
                {
                    subscriptions.Remove(eventHandler);
                }
            }
        }

        public virtual void Publish(object sender, T eventArgs)
        {
            lock (locker)
            {
                for (int i = 0; i < subscriptions.Count; i++)
                {
                    subscriptions[i](sender, eventArgs);
                }
            }
        }
    }
}
