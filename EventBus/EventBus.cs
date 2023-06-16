using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 事件总线
{
    /// <summary>
    /// 事件总线
    /// </summary>
    class EventBus
    {
        private static EventBus _default;
        private static readonly object locker = new object();
        private Dictionary<Type, EventBase> eventDic = new Dictionary<Type, EventBase>();

        /// <summary>
        /// 默认事件总线实例，建议只使用此实例
        /// </summary>
        public static EventBus Default
        {
            get
            {
                if (_default == null)
                {
                    lock (locker)
                    {
                        // 如果类的实例不存在则创建，否则直接返回
                        if (_default == null)
                        {
                            _default = new EventBus();
                        }
                    }
                }
                return _default;
            }
        }

        /// <summary>
        /// 构造函数，自动加载EventBase的派生类实现
        /// </summary>
        public EventBus()
        {
            Type type = typeof(EventBase);
            Type typePubSub = typeof(PubSubEvent<>);
            Assembly assembly = Assembly.GetAssembly(type);
            List<Type> typeList = assembly.GetTypes()
                .Where(t => t != type && t != typePubSub && type.IsAssignableFrom(t))
                .ToList();
            foreach (var item in typeList)
            {
                EventBase eventBase = (EventBase)assembly.CreateInstance(item.FullName);
                eventDic.Add(item, eventBase);
            }
        }

        /// <summary>
        /// 获取事件实例
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns></returns>
        public TEvent GetEvent<TEvent>() where TEvent : EventBase
        {
            return (TEvent)eventDic[typeof(TEvent)];
        }

        /// <summary>
        /// 添加事件类型
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        public void AddEvent<TEvent>() where TEvent : EventBase, new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (!eventDic.ContainsKey(type))
                {
                    eventDic.Add(type, new TEvent());
                }
            }
        }

        /// <summary>
        /// 移除事件类型
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        public void RemoveEvent<TEvent>() where TEvent : EventBase, new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (eventDic.ContainsKey(type))
                {
                    eventDic.Remove(type);
                }
            }
        }
    }
}
