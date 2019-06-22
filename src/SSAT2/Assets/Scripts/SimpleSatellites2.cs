namespace Assets.Scripts
{
	using SS2;

	/// <summary>
	/// A singleton object representing this mod that is instantiated and initialize when the mod is loaded.
	/// </summary>
	public class SimpleSatellites2 : ModApi.Mods.GameMod
	{
		/// <summary>
		/// Prevents a default instance of the <see cref="SimpleSatellites2"/> class from being created.
		/// </summary>
		private SimpleSatellites2() : base()
		{
		}

		protected override void OnModInitialized()
		{
			SS2Core.Instance.Initialize();
		}

		/// <summary>
		/// Gets the singleton instance of the mod object.
		/// </summary>
		/// <value>The singleton instance of the mod object.</value>
		public static SimpleSatellites2 Instance { get; private set; } = GetModInstance<SimpleSatellites2>();
	}
}