﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Snotyak.EventBus
{
	public class EventBus
	{
		private List<object> _subscribers = new List<object>();

		public EventBus ()
		{
		}

		public void Register(object subscriber){
			if (!_subscribers.Contains (subscriber)) {
				_subscribers.Add (subscriber);
			}
		}

		public void Unregister(object subscriber){
			if (_subscribers.Contains (subscriber)) {
				_subscribers.Remove (subscriber);
			}
		}

		public void Post(object e){
			foreach(object instance in _subscribers){
				foreach(MethodInfo method in GetSubscribedMethods(instance.GetType (), e)){
					try{
						method.Invoke (instance, new object[]{e});
					}catch(TargetInvocationException){}
				}
			}
		}

		private List<MethodInfo> GetSubscribedMethods (Type type, object obj)
		{
			List<MethodInfo> subscribedMethods = new List<MethodInfo> ();

			var methods = type.GetRuntimeMethods ();
			foreach(MethodInfo info in methods){
				foreach(Attribute attr in info.GetCustomAttributes ()){
					if (attr.GetType () == typeof(Subscribe)) {
						var paramInfo = info.GetParameters ();
						if(paramInfo.Length == 1 && paramInfo[0].ParameterType == obj.GetType ()){
							subscribedMethods.Add (info);
						}
					}
				}
			}

			return subscribedMethods;
		}
	}
}

