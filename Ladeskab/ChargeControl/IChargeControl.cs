
namespace Ladeskab
{
	public interface IChargeControl
	{
		public void StartCharge();
		public void StopCharge();
		public bool IsConnected();
	}
}