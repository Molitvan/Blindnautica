# About Blindnautica

Blindnautica is a mod for Subnautica that aims to make it accessible to blind players by adding various accessibility features. I have planned most of the mod, but very little has actually been done. I'm publishing this here in hopes of someone making their own accessibility mod or finishing this one. Below you can find all my ideas and instructions for compiling, developing and installing the mod.

If you want to contribut or have any questions, you can message me on Discord @molitvan

# How to install

Note: this mod has only been tested on Windows, and probably won't work on other platforms like Linux and Mac
Note: Subnautica folder is the folder where Subnautica files are located

Prerequisites
- Subnautica
- [Melon Loader](https://github.com/LavaGang/MelonLoader) installed on Subnautica
- [NVDA](https://www.nvaccess.org/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs) with the .NET Desktop Development workload

First, clone this repo by running this command in your terminal:
```sh
git clone https://github.com/Molitvan/Blindnautica
``````

After that, open the Blindnautica.sln solution and add the following references:
- Subnautica\MelonLoader\net35\0Harmony.dll
- Subnautica\MelonLoader\net35\MelonLoader.dll
- Subnautica\Subnautica_Data\Managed\Assembly-CSharp.dll
- Subnautica\Subnautica_Data\Managed\UnityEngine.dll
- Subnautica\Subnautica_Data\Managed\UnityEngine.CoreModule.dll
- Subnautica\Subnautica_Data\Managed\UnityEngine.InputLegacyModule.dll
- Subnautica\\Subnautica_Data\Managed\UnityEngine.UI.dll
- Subnautica\Subnautica_Data\Managed\Unity.TextMeshPro.dll

Now you can compile the mod.
Tip: press CTRL + SHIFT + B

When the mod is compiled, copy it as well as nvdaControllerClient.dll (found in the root of the repo) to the mods folder located in the Subnautica folder.
NVDA Controller Client can also be downloaded manually from [the NVDA github](https://github.com/nvaccess/nvda/tree/master/extras/controllerClient).

# Ideas

These are some of my ideas for making Subnautica accessible. None of them have been implemented properly yet.

## Menu naration
Make all menus navigatable with keyboard and usable with a screen reader. This includes things like main menu, options, pause menu..., but also ingame menus like the fabricator, PDA... The screen reader also reads interaction tooltips, player status, and various indicators that appear when using tools.

## Audio Cues
Add various sounds that play when you can do something, for example pickup an item or interact with an object. I don't know if this is possible due to licensing, but I would like them to be the same audio cues found in some games published by SONY, for example The Last of Us Part I. and II. and God of War: Ragnarok.

## Resource Scanner
This is also pretty much the same thing as enhanced listen mode in The Last of Us series. It scans for nearby points of interests like items or creatures then guides you to them.

## Navigation Assistance
This comes in two forms. One where you're in a building like the precursor bases or Aurora, and one where you're in the outside world. When you're in a building, navigation assistance will guide you through that building, passing by all important things that can be found there. When you're not in a building, it navigates you to any of your waypoints. These waypoints can be set by you at any place, as well as automatically generate when you discover new buildings or biomes.

## Base Building Accessibility
This simply tells you eather via screen reader or an audio cue where you can and can't place base pieces, as well as play audio cues at places where you can connect a base piece to another base piece.

## Player Status
When you press a hotkey, the screen reader tells you your health, hunger, thirst, oxygen level, and depth, each of which can have it's own hotkey.

## Driving Assistance
This is probably the hardest one to get right. I don't have anything specific in mind, but just using navigation assistance when driving would probably work. If it doesn't, maybe make it possible to automatically drive to a waypoint.

## Audio Descriptions
When important events like intro, aurora explodion or sea emperor visions happen, an additional audio track of someone describing whats happening plays.
This is also probably the least important one.

This is what I have in mind for now, but will probably add more later.
