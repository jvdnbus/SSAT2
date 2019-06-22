using ModApi.Common;
using ModApi.Flight.MapView;
using UnityEngine;

namespace SS2
{
	/// <summary>
	/// Main base class of RemoteTech. It is called by various inheriting classes: 
	///  * RTCoreFlight (Flight scene)
	///  * RTCoreTracking (Tracking station scene)
	///  * RTMainMenu (Main menu scene)
	/// </summary>
	public class SS2Core
	{
		/// <summary>
		/// Main class instance.
		/// </summary>
		public static SS2Core Instance { get; } = new SS2Core();

		/// <summary>
		/// RemoteTech satellites manager.
		/// </summary>
		public SatelliteManager Satellites { get; private set; }

		/// <summary>
		/// RemoteTech antennas manager.
		/// </summary>
		public AntennaManager Antennas { get; private set; }

		/// <summary>
		/// RemotTech network manager. 
		/// </summary>
		public NetworkManager Network { get; private set; }

		/// <summary>
		/// RemoteTech UI network renderer.
		/// </summary>
		public NetworkRenderer Renderer { get; private set; }

		private SS2Core()
		{
		}

		// New for handling the F2 GUI Hiding
		private bool _guiVisible = true;


		/// <summary>
		/// Called by Unity engine during initialization phase.
		/// Only ever called once.
		/// </summary>
		public void Initialize()
		{
			// managers
			Satellites = new SatelliteManager();
			Antennas = new AntennaManager();
			Network = new NetworkManager();

			Shortcuts.MapViewManager.MapView.Initialized += OnMapViewInitialized;

			// // register vessels and antennas
			// foreach (var vessel in FlightGlobals.Vessels)
			// {
			// 	// do not try to register vessel types that have no chance of being RT controlled.
			// 	// includes: debris, SpaceObject, unknown, EVA and flag
			// 	if ((vessel.vesselType <= VesselType.Unknown) || (vessel.vesselType >= VesselType.EVA))
			// 		continue;

			// 	Satellites.RegisterProto(vessel);
			// 	Antennas.RegisterProtos(vessel);
			// }
		}

		private void OnMapViewInitialized(IMapView source)
		{
			Renderer = NetworkRenderer.CreateAndAttach();
			Shortcuts.MapViewManager.ForegroundStateChanged += OnMapViewForegroundStateChanged;
		}

		private void OnMapViewForegroundStateChanged(bool foreground)
		{
			if (foreground)
				Debug.Log("Map view opened");
		}

		~SS2Core()
		{
			if (Renderer != null) Renderer.Detach();
			if (Network != null) Network.Dispose();
			if (Satellites != null) Satellites.Dispose();
			if (Antennas != null) Antennas.Dispose();
		}
	}
}
