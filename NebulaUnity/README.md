# NebulaUnity
(In progress)

## What is this?
This folder contains a Unity project that can be used to build custom UI elements used by this mod

## How do I use it
1. Open the Unity project using the Unity Editor.
2. Make the changes you would like to make.
3. After that is complete build the asset bundle (Window->DSP Utils->Build Asset Bundles)
4. Copy the generated asset bundle file named nebulabundle to NebulaWorld\Assets 
   `copy .\NebulaUnity\Assets\StreamingAssets\AssetBundles\nebulabundle .\NebulaWorld\Assets\`
5. Copy the script assembly into the main project
    `copy .\NebulaUnity\Library\ScriptAssemblies\chatGameAsm.dll .\Libs\`
7. Rebuild the main project to see your changes
8. Make sure to include changes to .\NebulaWorld\Assets\ in your PR