// MvxStoreProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

namespace Beezy.MvvmCross.Plugins.SecureStorage.WindowsStore
{
    public class MvxStoreProtectedData : IMvxProtectedData
    {
        public void Protect(string key, string value)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential(
                Windows.ApplicationModel.Package.Current.Id.Name, key, value));
        }

        public string Unprotect(string key)
        {
            try
            {
                var vault = new Windows.Security.Credentials.PasswordVault();
                return vault.Retrieve(Windows.ApplicationModel.Package.Current.Id.Name, key).Password;
            }
            catch
            {
                return null;
            }
        }

        public void Remove(string key)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var passwordCredential = vault.Retrieve(Windows.ApplicationModel.Package.Current.Id.Name, key);
            vault.Remove(passwordCredential);
        }

    }
}
