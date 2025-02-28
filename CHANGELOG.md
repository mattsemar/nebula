## Changelog

0.8.6:

- @starfish: Bugfix regarding NRE exception in UpdateDirtyMeshes()
- @starfish: Bugfix desync issues regarding ILS and PLS
- @starfish: Add milestone syncing
- @sp00ktober: Add gracefull error messages regarding broken traffic monitors and broken compression of factory data
- @sp00ktober: Add a reconnect command to the chat for easy and fast reconnection of clients

0.8.5:

- @starfish: Add Dyson Sphere color syncing
- @starfish: Add syncing for fast insert / fast take out of items to / from buildings
- @starfish: Add syncing for fractionator and power generator product
- @starfish: Save game to Last Quit when exiting multiplayer game.
- @starfish: Fix a bug that would lead to an inserter's filter to not set correctly
- @starfish: Fix planet terrain not synced when client loads a factory.
- @starfish: Fix trash item count incorrect when item count > 256.
- @sp00ktober: UI adjustments to account for the game update
- @sp00ktober: Disable metadata upgrades for clients in tech tree
- @sp00ktober: Add syncing for fast insert / fast take out of items to / from belts

0.8.4:

- @kremnev8: add two new events to Nebula API
- @starfish: fixed issue where client would sometimes be unable to load in while using GalacticScale
- @starfish: custom planet and star names now show up in lobby (not while GalacticScale is active)
- @starfi5h: show correct resource amount in UIPlanetDetail
- @starfi5h: show custom planet and star names in lobby screen
- @starfi5h: the selected starting planet name will now show on the lobby screen
- @starfi5h: fixed issue where the nametag on the minimap wouldn't show up for a client that rejoined

0.8.3:

- @kremnev8: improved ingame chat
- @starfish: added compatibility with BulletTime which enables fluent loading times on Planet and System arrival
- @starfish: bugfix regarding too large dyson sphere data
- @starfish: bugfix regarding reloading of dyson sphere
- @starfish: improved loading of solar systems, this now runs on its own thread
- @starfish: developer commands can now be executed from the ingame chat (using /xconsole [command] )
- @sp00ktober: added tooltips to the Nebula settings
- @sp00ktober: added setting to prevent `System.ObjectDisposedException` errors resulting in random client disconnect
- @sp00ktober: added code to handle IndexOutOfBounds errors when importing PlanetFactory data (very rare issue)
- @sp00ktober: fixed wrong array size for storage and slots in ILS
- @sp00ktober: added minimap indicator for other players positions (on the same planet)
- @sp00ktober: added chat command to list planets in a system
- @sp00ktober: added chat command to navigate to star, planet or player by name or id

0.8.2:

- @kremnev8: fix issue with EmojiDataManager when a save was loaded multiple times in a row.

0.8.1:

- @starfish: Add copy&close error button
- @starfish: bugfixes regarding dyson sphere editor
- @starfish: bugfix regarding item refund in matrix labs
- @starfish: bugfix regarding the ILS UI
- @starfish: bugfix regarding placement of spraycoaters, traffic monitors and inserters
- @starfish: bugfix regarding drone and ship counts in stations
- @PhantomGamers, @sp00ktober: adjust TCP fragment size for faster data transmission
- @sp00ktober: bugfix regarding players getting stuck with the "player joining" message
- @sp00ktober: bugfix regarding wrong mecha color until hitting "apply" in mecha editor
- @sp00ktober: bugfix regarding ILS ship rendering clientside
- @sp00ktober: add optional soil syncing
- @sp00ktober: add syncing of mecha editor state and items
- @mattsemar, @kremnev8: add in-game chat functionality with commands (open with `Alt` + `~` by default)

0.8.0:

- Now compatible with DSP 0.9.24
- @starfish: Refactoring of the ILS UI making it more stable and accurate
- @starfish: Update Dyson Sphere syncing to match the new features of the game update
- @starfish: Add UPS syncing to the game making the overall game state more accurate
- @starfish: Updates for the proliferator and advanced miner
- @starfish: Bugfix for wrong objId
- @sp00ktober: Rework ILS ship rendering to be more accurate for clients
- @sp00ktober: Rework ILS item adding (into stations) to be more accurate for clients
- @sp00ktober: Bugfixes related to belts placed with a filter set
- @sp00ktober: Add syncing of MechaAppearance
- @sp00ktober: Fixed a bug that would lock the host with the "player joining" message when multiple clients try to join at the same time

0.7.10:

- @starfish: Added WarningSystem syncing
- @PhantomGamers: Fixed case of NRE when arriving on another planet
- @PhantomGamers: Fixed issue where Universe Exploration tech would break while in a multiplayer game

0.7.9:

- @sp00ktober: gracefully tell older nebula versions that there is a mod version missmatch.
- @sp00ktober: fix planet detail ui stuck in lobby mode while in game.
- @starfish: fix jaggy remote player movement

0.7.8:

- @sp00ktober: Added Lobby feature where you can preview solar systems and choose your birth planet.

0.7.7:

- @starfi5h, @PhantomGamers: Fixed issue where research removed by clients would not be synced.

0.7.6:

- @starfi5h: Added syncing of ray receiver output
- @starfi5h: Fixed lighting of remote players
- @starfi5h: Fixed clients receiving duplicate items when cancelling manual research

0.7.5:

- @sp00ktober: Fixed error caused by warning system introduced in previous update
- @PhantomGamers: Fixed compatibility with DSP 0.8.23.9989

0.7.4:

- @sp00ktober: adjusted mod to be compatible with game version 0.8.23

0.7.3:

- @PhantomGamers: Fixed error when upgrading blueprint previews.
- @sp00ktober: Added hotfix to prevent error caused by ILS ships

0.7.2:

- @sp00ktober: Fixed issue where the host would render buildings placed by players on other planets on his current planet.

0.7.1:

- @starfi5h: Fixed research desync issues
- @sp00ktober: Fixed error when client upgrades buildings on different planet from the host.
- @PhantomGamers: Fixed compatibility with DSP 0.8.22.9331+

0.7.0:

- @phantomgamers: Fixed instance where error would trigger by loading saves made on earlier Nebula versions. **WARNING: All previous client inventory and position data will be lost!** (should be for the last time!)
- @phantomgamers: Fixed error that was triggered by the client loading a planet after traveling to a different planetary system
- @phantomgamers: Fixed error that was triggered by the client warping outside of a planetary system
- @starfi5h: Added syncing of solar sails and rockets when client does not have the planet they originated from loaded.
- @sp00ktober: Implemented smooth loading of factories for clients (fixed clients phasing through planet when flying too fast)

0.6.2:

- Fixed error when loading saves that were created before 0.6.0. **WARNING: All previous client inventory and position data will be lost!**
- Improved compatibility with GigaStations mod (thanks to @kremnev8)
- Removed extraneous dlls that were mistakenly included in the previous release
- Now supports DSP version 0.8.22.8915+ (thanks to @starfi5h!)

0.6.1:

- Fixed statistics syncing (thanks to @starfi5h)
- Fixed audio playing for all players when pasting building settings and warping (thanks to @starfi5h)
- Added syncing for footstep and landing sounds (thanks to @starfi5h)

0.6.0:

- Fixed cases where a multiplayer session could hang on the player joining screen.
- Fixed issue where foundations built by clients would not sync to other clients.
- Fixed issue where the user would not be informed if they were kicked due to a mod mismatch.
- Enabled pausing in Multiplayer when no clients are connected. (thanks to @starfi5h)
- Now supports DSP version 0.8.21.8562+ (also thanks to @starfi5h!)
- Mecha color configuration has been removed from the options in favor of the new option in the Mecha panel

0.5.0:

- Added API that enables other mods to sync over multiplayer! (Big thanks to @kremnev8!)
- Fixed a bug that caused sorters to break when a client built a belt under preexisting sorters.
- Fixed a bug that resulted in the client getting an error after disconnecting from a game that the host left.
- Refactored session architecture (big changes to codebase but should be seamless to users)

0.4.0:

- Nebula now supports DSP version 0.8.20.7962+

0.3.1:

- Fixed issue where if client didn't have enough items to upgrade, the buildings would still be upgraded for the host.
- Clients will now retain their detail display settings between sessions (e.g. power grid visibility) (thanks to @Needix)
- Fixed issue where players would be able to construct buildings made with blueprints even if they did not have the required items.
- Fixed miscellaneous issues related to ILS ship movement
- Fixed error related to host building foundations while on a different planet from the client

0.3.0:

- Added support for blueprint update (0.8.x)
- Improved player name tag rendering
- Fixed newly introduced multithread issues

0.2.0:

- initial release on thunderstore
