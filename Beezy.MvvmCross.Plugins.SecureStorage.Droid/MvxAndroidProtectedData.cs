// MvxAndroidProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Preferences;
using Java.Security;

namespace Beezy.MvvmCross.Plugins.SecureStorage.Droid
{
    public class MvxAndroidProtectedData : IMvxProtectedData
    {
        private readonly ISharedPreferences _preferences;

        public MvxAndroidProtectedData()
        {
            _preferences = Application.Context.GetSharedPreferences(Application.Context.PackageName + ".SecureStorage",
                FileCreationMode.Private);
        }

        public void Protect(string key, string value)
        {
            var editor = _preferences.Edit();
            editor.PutString(key, value);
            editor.Commit();
        }

        public string Unprotect(string key)
        {
            try
            {
                return _preferences.GetString(key, null);
            }
            catch
            {
                return null;
            }
        }

        public void Remove(string key)
        {
            if (_preferences.Contains(key))
            {
                var editor = _preferences.Edit();
                editor.Remove(key);
                editor.Commit();
            }
        }
    }
}
