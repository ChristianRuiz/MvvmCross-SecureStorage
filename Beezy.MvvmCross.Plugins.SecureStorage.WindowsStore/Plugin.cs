// Plugin.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace Beezy.MvvmCross.Plugins.SecureStorage.WindowsStore
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IMvxProtectedData>(new MvxStoreProtectedData());
        }
    }
}
