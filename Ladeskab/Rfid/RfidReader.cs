
using System;

namespace Ladeskab
{
	public class RfidReader : IRfidReader
	{
		
		public void OnRfidRead(int id)
		{
			RfidDetected?.Invoke(this, new RfidDetectedEventArgs(id));
		}
		
		public event EventHandler<RfidDetectedEventArgs> RfidDetected;
		
	}
}
