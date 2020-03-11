
using System;

namespace Ladeskab
{
	class RfidReader : IRfidReader
	{
		
		public void OnRfidRead(int id)
		{
			RfidDetected.Invoke(this, new RfidDetectedEventArgs(id));
		}
		
		public event EventHandler<RfidDetectedEventArgs> RfidDetected;
		
	}
}
