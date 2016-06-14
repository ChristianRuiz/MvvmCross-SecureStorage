// Plugin.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using MvvmCross.Platform.Plugins;
using MvvmCross.Platform;

namespace Beezy.MvvmCross.Plugins.SecureStorage.Droid
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IMvxProtectedData>(new MvxAndroidProtectedData());
        }
    }
}
