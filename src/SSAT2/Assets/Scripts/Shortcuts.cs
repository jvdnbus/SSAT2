using ModApi.Flight.MapView;

namespace ModApi.Common
{
	public static class Shortcuts
	{
		public static IMapViewManager MapViewManager
		{
			get
			{
				return Game.Instance.FlightScene.ViewManager.MapViewManager;
			}
		}
	}
}