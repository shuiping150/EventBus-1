using System;

namespace Snotyak.EventBus
{
	[AttributeUsage(AttributeTargets.Method)]
	public class Subscribe : System.Attribute
	{
		public Subscribe () : base()
		{
		}
	}
}

