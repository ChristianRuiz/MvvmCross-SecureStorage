// MvxPhoneProtectedData.cs
// (c) Copyright Christian Ruiz @_christian_ruiz
// MvvmCross - Secure Storage Plugin is licensed using Microsoft Public License (Ms-PL)
// 

using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Beezy.MvvmCross.Plugins.SecureStorage.WindowsPhone
{
    public class MvxPhoneProtectedData : IMvxProtectedData
    {
        public void Protect(string key, string value)
        {
            var valueByte = Encoding.UTF8.GetBytes(value);

            var protectedValueByte = ProtectedData.Protect(valueByte, null);

            WriteValueToFile(key, protectedValueByte);
        }

        public string Unprotect(string key)
        {
            try
            {
                var protectedValueByte = ReadValueFromFile(key);

                var valueByte = ProtectedData.Unprotect(protectedValueByte, null);

                return Encoding.UTF8.GetString(valueByte, 0, valueByte.Length);
            }
            catch
            {
                return null;
            }
        }

        public void Remove(string key)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            file.DeleteFile(key);
        }

        private void WriteValueToFile(string key, byte[] protectedValueByte)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            using (var isolatedStorageFileStream = new IsolatedStorageFileStream(key, FileMode.Create, FileAccess.Write, file))
            {
                using (var writer = new StreamWriter(isolatedStorageFileStream).BaseStream)
                {
                    writer.Write(protectedValueByte, 0, protectedValueByte.Length);
                }
            }
        }

        private byte[] ReadValueFromFile(string key)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            using (var isolatedStorageFileStream = new IsolatedStorageFileStream(key, FileMode.Open, FileAccess.Read, file))
            {
                using (var reader = new StreamReader(isolatedStorageFileStream).BaseStream)
                {
                    var valueArray = new byte[reader.Length];
                    reader.Read(valueArray, 0, valueArray.Length);
                    return valueArray;
                }
            }
        }

    }
}
