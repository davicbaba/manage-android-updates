# .NET MAUI Android Silent Updates - Proof of Concept

This repository contains a proof of concept (PoC) application designed to demonstrate how to update Android apps silently using .NET MAUI.

## Requirements

To run this application, you'll need the following:

1. **Android SDK Platform Tools**  
   Download the Android SDK Platform Tools from the official [Android Developer site](https://developer.android.com/tools/releases/platform-tools).

2. **Set the App as Device Owner**  
   Make the app the device owner by running the following command in your terminal:

   ```bash
   adb shell dpm set-device-owner "com.companyname.manageandroidupdates/.MyDeviceAdminReceiver"


## Removing Device Owner Status

You can remove the device owner status using the button on the home screen of the application.
