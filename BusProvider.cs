using System;

namespace Snotyak.EventBus
{
	public class BusProvider
	{
		private static EventBus _instance;
		public static EventBus Instance {
			get{
				if(_instance == null){
					_instance = new EventBus ();
				}

				return _instance;
			}
		}

		public BusProvider ()
		{
		}
	}
}

