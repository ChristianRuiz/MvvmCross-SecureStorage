##MvvmCross - Secure Storage Plugin
=======================

MvvmCross plugin to store secure information using the mechanisms provided by each platform (Keychain, Password Vault, Private Preferences and encrypted data on IsolatedStorage)

For Android and Windows Phone, we cannot assure the privacity of the data because the file stored can be compromised (using a root user on Android and trying to decrypt the IsolatedStorage file on Windows Phone). You can always create your custom implementation of the IMvxProtectedData for those platforms with your custom Encryption and replacing it on the Mvx dependency container.

##Adding to your project

1. Add it from NuGet: https://www.nuget.org/packages/Beezy.MvvmCross.Plugins.SecureStorage
2. Ensure that the file SecureStoragePluginBootstrap has been created on the Bootstrap folder.
3. On the Core library you can inject the IMvxProtectedData to your ViewModels.