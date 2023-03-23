![Coconut Consolidation](media/CoconutConsolidation.png)

# Consolidate Liquid
Consolidates all liquids into as few of containers as possible.  Great for consolidating many coconuts of water.

Only includes containers in the current location and does not include containers in a recipe.

# Settings
|Name|Default|Description|
|--|--|--|
|ConsolidateHotKey|P|The hotkey to consolidate liquid|

# Changing the Configuration
All options are contained in the config file which is located at ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\config\CardSurvival-LoadTravois.cfg```.

The .cfg file will not exist until the mod is installed and then the game is run.
To reset the config, delete the config file.  A new config will be created the next time the game is run.

## ConfigurationManager
ConfigurationManager is a useful mod which provides a UI to edit all mod configs by pressing F1

ConfigManager Web page: https://github.com/BepInEx/BepInEx.ConfigurationManager/
ConfigManager Mod download:  https://github.com/BepInEx/BepInEx.ConfigurationManager/releases

# Installation 
This section describes how to manually install the mod.

**If using the Vortex mod manager from NexusMods, these steps are not needed.**

## Overview
This mod requires the BepInEx mod loader.

## BepInEx Setup
If BepInEx has already been installed, skip this section.

Download BepInEx from https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip

* Extract the contents of the BepInEx zip file into the game's directory:
```<Steam Directory>\steamapps\common\Card Survival Tropical Island```

    __Important__:  The .zip file *must* be extracted to the root folder of the game.  If BepInEx was extracted correctly, the following directory will exist: ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```.  This is a common install issue.

* Run the game.  Once the main menu is shown, exit the game.
    
* In the BepInEx folder, there will now be a "plugins" directory.

## Mod Setup
* Download the CardSurvival-LoadTravois.zip.  
    * If on Nexumods.com, download from the Files tab.
    * Otherwise, download from https://github.com/NBKRedSpy/CardSurvival-CardSurvival-LoadTravois/releases/

* Extract the contents of the zip file into the ```BepInEx/plugins``` folder.

* Run the Game.  The mod will now be enabled.

# Uninstalling

## Uninstall
This resets the game to an unmodded state.

Delete the BepInEx folder from the game's directory
```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx```

## Uninstalling This Mod Only

This method removes this mod, but keeps the BepInEx mod loader and any other mods.

Delete the ```CardSurvival-LoadTravois.dll``` from the ```<Steam Directory>\steamapps\common\Card Survival Tropical Island\BepInEx\plugins``` directory.

# Compatibility
Safe to add and remove from existing saves.

# Change Log 

## 1.0.0
* Release


