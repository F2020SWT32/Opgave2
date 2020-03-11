
using System;

namespace Ladeskab
{
	public interface IRfidReader
	{
		
		public event EventHandler<RfidDetectedEventArgs> RfidDetected;
		
	}
}
