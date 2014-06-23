##MvvmCross - Secure Storage Plugin
=======================

MvvmCross plugin to store secure information using the mechanisms provided by each platform (Keychain, Private Preferences, Password Vault, etc.)

##Adding to your project

1. Add it from NuGet: https://www.nuget.org/packages/Beezy.MvvmCross.Plugins.SecureStorage/1.0.0
2. Ensure that the file SecureStoragePluginBootstrap has been created on the Bootstrap folder.
3. On the Core library you can inject the IMvxProtectedData to your ViewModels.