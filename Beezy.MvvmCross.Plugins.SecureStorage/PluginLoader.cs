// PluginLoader.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace Beezy.MvvmCross.Plugins.SecureStorage
{
    public class PluginLoader : IMvxPluginLoader
    {
        public static readonly PluginLoader Instance = new PluginLoader();

        public void EnsureLoaded()
        {
            var manager = Mvx.Resolve<IMvxPluginManager>();
            manager.EnsurePlatformAdaptionLoaded<PluginLoader>();
        }
    }
}
