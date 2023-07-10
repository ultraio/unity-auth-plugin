# Ultra Unity Plugin

Here is a first version of the Ultra Unity Plugin. It's primary purpose is to allow you to seamlessly retrieve the Ultra sessions of players without requiring them to enter their credentials in-game. Once such a session is retrieved you can use it to connect to BrainCloud's SDK to access to their features supporting the Ultra ecosystem.


## Installation

The Ultra Unity Plugin is based on UPM (Unity Package Manager). As of now it's not published to any registry so you will have to manually install the package with one of the following approaches:

### With a clone of the repository
-	Open the Package Manager (Window > Package Manager)
-	Click the `+` icon and select `Add package from disk`
-	Select the root folder of the plugin

### With a git URL
-	Open the Package Manager (Window > Package Manager)
-	Click the `+` icon and select `Add Package from git URL`

## Unity Compatibility

The plugin has been created and tested with Unity 2021.

## C# Library

Note that the plugin is currently developed and tested for Unity exclusively. A non-Unity dependent flavour of the library will require further adjustments. This will be done in a future version.

## Get Started

Once the plugin is installed, [check the plugin's documentation for implementation guidance](./Documentation/index.md).