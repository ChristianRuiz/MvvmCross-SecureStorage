// IMvxProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using System.Threading.Tasks;
namespace Beezy.MvvmCross.Plugins.SecureStorage
{
    public interface IMvxProtectedData
    {
        void Protect(string key, string value);
        string Unprotect(string key);
        void Remove(string key);
    }
}
