using Smod2.Attributes;

namespace NameCensor
{
	[PluginDetails(
	author = "Cyanox",
	name = "NameCensor",
	description = "Censors names.",
	id = "cyan.namecensor",
	version = "1.0.0",
	SmodMajor = 3,
	SmodMinor = 0,
	SmodRevision = 0
	)]
	public class Plugin : Smod2.Plugin
	{
		public override void OnDisable() { }

		public override void OnEnable() { }

		public override void Register()
		{
			AddConfig(new Smod2.Config.ConfigSetting("nc_blacklist", new string[]{}, false, true, "The words to be censored."));

			AddEventHandlers(new EventHandler(this));
		}
	}
}
