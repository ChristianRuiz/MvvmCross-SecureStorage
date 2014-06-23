// MvxTouchProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using MonoTouch.Foundation;
using MonoTouch.Security;

namespace Beezy.MvvmCross.Plugins.SecureStorage.Touch
{
    public class MvxTouchProtectedData : IMvxProtectedData
    {
        public void Protect(string key, string value)
        {
            SecKeyChain.Add(new SecRecord(SecKind.GenericPassword)
            {
                Service = NSBundle.MainBundle.BundleIdentifier,
                Account = key,
                ValueData = NSData.FromString(value, NSStringEncoding.UTF8)
            });
        }

        public string Unprotect(string key)
        {
            var existingRecord = new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Label = key,
                Service = NSBundle.MainBundle.BundleIdentifier
            };

            // Locate the entry in the keychain, using the label, service and account information.
            // The result code will tell us the outcome of the operation.
            SecStatusCode resultCode;
            SecKeyChain.QueryAsRecord(existingRecord, out resultCode);

            if (resultCode == SecStatusCode.Success)
                return NSString.FromData(existingRecord.ValueData, NSStringEncoding.UTF8);
            else
                return null;
        }

        public void Remove(string key)
        {
            var existingRecord = new SecRecord(SecKind.GenericPassword)
            {
                Account = key,
                Label = key,
                Service = NSBundle.MainBundle.BundleIdentifier
            };
            SecKeyChain.Remove(existingRecord);
        }
    }
}
