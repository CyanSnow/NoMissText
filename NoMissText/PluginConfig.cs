using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]

namespace NoMissText
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public bool NoTextAnywhere = true;
    }
}
