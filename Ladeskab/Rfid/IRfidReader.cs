
using System;

namespace Ladeskab
{
	public interface IRfidReader
	{
		
		public event EventHandler<RfidDetectedEventArgs> RfidDetected;
		
	}
	
	public class RfidDetectedEventArgs : EventArgs
	{
		public int Id { get; }
		public RfidDetectedEventArgs(int Id)
		{
			this.Id = Id;
		}
	}
}
