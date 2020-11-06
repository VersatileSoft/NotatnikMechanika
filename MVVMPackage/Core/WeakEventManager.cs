using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.String;

namespace MVVMPackage.Core
{
    /// <summary>
    /// Weak event manager to subscribe and unsubscribe from events.
    /// </summary>
    public class WeakEventManager
    {
        private readonly Dictionary<string, List<Subscription>> eventHandlers = new Dictionary<string, List<Subscription>>();

        /// <summary>
        /// Add an event handler to the manager.
        /// </summary>
        /// <typeparam name="TEventArgs">Event handler of T</typeparam>
        /// <param name="handler">Handler of the event</param>
        /// <param name="eventName">Name to use in the dictionary. Should be unique.</param>
        public void AddEventHandler<TEventArgs>(EventHandler<TEventArgs> handler, [CallerMemberName] string eventName = "")
            where TEventArgs : EventArgs
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        /// <summary>
        /// Add an event handler to the manager.
        /// </summary>
        /// <param name="handler">Handler of the event</param>
        /// <param name="eventName">Name to use in the dictionary. Should be unique.</param>
        public void AddEventHandler(EventHandler handler, [CallerMemberName] string eventName = "")
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            AddEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        /// <summary>
        /// Handle an event
        /// </summary>
        /// <param name="sender">Sender of the event</param>
        /// <param name="args">Arguments for the event</param>
        /// <param name="eventName">Name of the event.</param>
        public void HandleEvent(object sender, object args, string eventName)
        {
            List<(object subscriber, MethodInfo handler)> toRaise = new List<(object subscriber, MethodInfo handler)>();
            List<Subscription> toRemove = new List<Subscription>();

            if (eventHandlers.TryGetValue(eventName, out List<Subscription> target))
            {
                for (int i = 0; i < target.Count; i++)
                {
                    Subscription subscription = target[i];
                    bool isStatic = subscription.Subscriber == null;
                    if (isStatic)
                    {
                        // For a static method, we'll just pass null as the first parameter of MethodInfo.Invoke
                        toRaise.Add((null, subscription.Handler));
                        continue;
                    }

                    object subscriber = subscription.Subscriber?.Target;

                    if (subscriber is null)
                    {
                        // The subscriber was collected, so there's no need to keep this subscription around
                        toRemove.Add(subscription);
                    }
                    else
                    {
                        toRaise.Add((subscriber, subscription.Handler));
                    }
                }

                for (int i = 0; i < toRemove.Count; i++)
                {
                    Subscription subscription = toRemove[i];
                    target.Remove(subscription);
                }
            }

            for (int i = 0; i < toRaise.Count; i++)
            {
                (object subscriber, MethodInfo handler) = toRaise[i];
                handler.Invoke(subscriber, new[] { sender, args });
            }
        }

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        /// <typeparam name="TEventArgs">Type of the EventArgs</typeparam>
        /// <param name="handler">Handler to remove</param>
        /// <param name="eventName">Event name to remove</param>
        public void RemoveEventHandler<TEventArgs>(EventHandler<TEventArgs> handler, [CallerMemberName] string eventName = "")
            where TEventArgs : EventArgs
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        /// <param name="handler">Handler to remove</param>
        /// <param name="eventName">Event name to remove</param>
        public void RemoveEventHandler(EventHandler handler, [CallerMemberName] string eventName = "")
        {
            if (IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName));
            }

            if (handler is null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            RemoveEventHandler(eventName, handler.Target, handler.GetMethodInfo());
        }

        private void AddEventHandler(string eventName, object handlerTarget, MethodInfo methodInfo)
        {
            if (!eventHandlers.TryGetValue(eventName, out List<Subscription> targets))
            {
                targets = new List<Subscription>();
                eventHandlers.Add(eventName, targets);
            }

            if (handlerTarget is null)
            {
                // This event handler is a static method
                targets.Add(new Subscription(null, methodInfo));
                return;
            }

            targets.Add(new Subscription(new WeakReference(handlerTarget), methodInfo));
        }

        private void RemoveEventHandler(string eventName, object handlerTarget, MemberInfo methodInfo)
        {
            if (!eventHandlers.TryGetValue(eventName, out List<Subscription> subscriptions))
            {
                return;
            }

            for (int n = subscriptions.Count; n > 0; n--)
            {
                Subscription current = subscriptions[n - 1];

                if (current.Subscriber?.Target != handlerTarget || current.Handler.Name != methodInfo.Name)
                {
                    continue;
                }

                subscriptions.Remove(current);
                break;
            }
        }

        private struct Subscription
        {
            public Subscription(WeakReference subscriber, MethodInfo handler)
            {
                Subscriber = subscriber;
                Handler = handler ?? throw new ArgumentNullException(nameof(handler));
            }

            public readonly WeakReference Subscriber;
            public readonly MethodInfo Handler;
        }
    }
}