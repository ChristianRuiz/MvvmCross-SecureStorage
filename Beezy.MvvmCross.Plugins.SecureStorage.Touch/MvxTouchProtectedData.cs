// MvxTouchProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using Foundation;
using Security;

namespace Beezy.MvvmCross.Plugins.SecureStorage.Touch
{
    public class MvxTouchProtectedData : IMvxProtectedData
    {
		bool _synchronizable = false;

		public void Protect (string key, string value)
		{
			Remove (key.ToLower ());

			var result = SecKeyChain.Add (new SecRecord (SecKind.GenericPassword) {
				Service = NSBundle.MainBundle.BundleIdentifier,
				Label = key.ToLower(),
				Account = key.ToLower (),
				ValueData = NSData.FromString (value),
				Generic = NSData.FromString (key.ToLower ()),
				Accessible = SecAccessible.WhenUnlockedThisDeviceOnly,
				Synchronizable = _synchronizable
			});
		}

        public string Unprotect(string key)
        {
            var existingRecord = new SecRecord(SecKind.GenericPassword)
            {
				Generic = NSData.FromString (key.ToLower ()),
				Service = NSBundle.MainBundle.BundleIdentifier,
				Label = key.ToLower (),
				Account = key.ToLower (),
				Synchronizable = _synchronizable
            };

            // Locate the entry in the keychain, using the label, service and account information.
            // The result code will tell us the outcome of the operation.
            SecStatusCode resultCode;
            existingRecord = SecKeyChain.QueryAsRecord(existingRecord, out resultCode);

            if (resultCode == SecStatusCode.Success)
				return NSString.FromData(existingRecord.ValueData, NSStringEncoding.UTF8);
            else
                return null;
        }

        public void Remove(string key)
        {
            var existingRecord = new SecRecord(SecKind.GenericPassword)
            {
				Generic = NSData.FromString (key.ToLower ()),
                Account = key.ToLower (),
                Label = key.ToLower (),
                Service = NSBundle.MainBundle.BundleIdentifier
            };
            SecKeyChain.Remove(existingRecord);
        }
    }
}
