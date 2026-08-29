# Peace

![Imgur](https://i.imgur.com/cr3WZ1xl.png)
![Imgur](https://i.imgur.com/j6VbISLl.png)
![Imgur](https://i.imgur.com/t2rSatcl.png)


## So what does this mod do?

Once this mod is installed then as you play nothing is different until you defeat your first boss. 

After defeating any biomes boss then you can make a **peace zone**, just place a wood wall 1x1 on any surface, then place an item stand on it, then lastly mount any creature's trophy from any defeated boss’s biome on the item stand to create a **peace zone** around it that stops that trophy’s creatures from spawning within your newly made **peace zone**. (see image above)

Not only will they stop spawning inside this zone, but should they already be in the zone when you make it, or wander in around the edge of it, they become totally passive while you're inside the zone. 

Everything else in the world behaves normally outside the zone. 

If you attack any creature inside the zone they will not fight back and if left alone then they will just wander around harmlessly. 

Less Annoying? Yes!, even the honking deer calm down if they are already in or wander inside the zone when their trophy is mounted.

What if the creature doesn’t have a trophy like a Greyling? No problem, as soon as you mount any creatures’ trophy from a defeated boss’s biome, then any non-trophy creature from that biome is also automatically prevented from spawning.

Oh and if you want to decorate with trophies then don’t worry as you can mount them just as you normally do *as long as you don’t place the item stand on a 1x1 wood wall piece*.

As you progress and defeat more bosses then you can start mounting that boss's creatures trophy's to add even more creatures that will respect your peace zone.

**Dungeon** If a Dungeon is inside your peace zone, then any creatures inside it are NOT affected by the peace zone regardless of any trophy mounted. The only exception is any creatures that hover around outside the entrance will be at peace with you.

**Raids/Events** These are not affected by your peace zone! Any creature in the raid will attack even if the event is over just like vanilla to help keep a better balance to game play.

## Is it complicated?

Nope! No need to remember anything, the mod keeps you informed so you know what mounting or dismounting a trophy is doing within your game.
- The mod tells you when you mount a trophy correctly to create a zone with an announcement of **Peace Has Come!**. 
- It will tell you when you mount one as you would normally without creating a zone with an announcement of  **Decorative Only**
- If you remove a trophy that was making a zone free of that creature then you will see **Peace Has Ended!** (but only for that creature, any others remain at peace)
- If you mount a creatures trophy on an item stand mounted to a wood wall 1x1 but that creature’s boss hasn’t been defeated yet you will see an announcement of **"Victory Will Still be Ours!"** to let you know you have work to do yet!
- To prevent killing your FPS by adding more than one of the same trophy inside a zone you already have created for that creature, the mod will cancel the peace effect and warn you with an announcement **Duplicate Trophy -Remove for Peace!**. Simply remove the duplicate trophy and it will announce **Peace Has Come!** again and automatically restore the zone. This also applies to overlapping same type creature peace zones from nearby building or bases. To avoid this just don’t overlap same for same zones.
- You can have as many peace zones as you want in your world so you can make them more specific for that biome if you have multiple bases.

## Visualizing a zone

But how do I know where the edge of my zone actually is so I don’t overlap or walk out into hostile territory?

Press **F8** (configurable) to toggle on and off a green ring showing the exact boundary of every currently active peace zone per creature. The ring follows terrain height so it won't clip into hillsides (it does disappear under water though). There will be one green ring for each creature peace zone. It doesn’t generate for a decorative, duplicated, or undefeated boss trophies.

The size of the zone is also configurable, I highly recommend using *Azus UnOfficial ConfigManager* for changing it.

## How it works summary

- Mount a trophy on an item stand that's placed directly on a `wood_wall_1x1` piece and if it's a recognized creature trophy, then a peace zone activates around that stand for that creature. **Only one trophy per creature type, per peace-zone.**
- Any item stand NOT placed on a `wood_wall_1x1`behaves like vanilla, but creates no protection at all. 
- If the trophy, item stand or 1x1 wall is later removed from an already-working stand, protection is cancelled automatically the next time the mod performs a periodic safety check run (configurable).
- Mounting a *second* trophy of the same creature type whose coverage circle actually overlaps the first one's cancels protection for both in both zones until you remove the duplicate trophy. 
- Two trophies of the same type at separate, non-overlapping bases don't affect each other — each protects its own area independently.
- Peace zones are **per creature type** — a Greydwarf trophy only pacifies Greydwarves. Variants (Greydwarf Brute, Greydwarf Shaman, etc.) need their own trophy mounted.
- A handful of creatures that don't have a trophy of their own (e.g. Greyling, which can summon Greydwarves when startled) are suppressed automatically whenever you're within an active peace zone. This list is configurable in the Config file generated after the mod is ran the first time.
- Deer (and any other non-combat creature) are fully covered too, they'll neither flee nor make their alert sound while inside an active zone for their type.
- Raid and world events are **NOT** affected by peace zones, they always spawn normally. Hey what can I say they like to gang up on you from time to time! 
- When you get near the edge of your peace zone any creature just outside the zone might charge you but once inside the zone will go passive and flee back outside the zone. GreyDwarves will still throw rocks at you from outside the zone as could other creatures that have a ranged attack so remember to not build too close to the edge as your neighbors aren’t friendly.

## Configuration

Config file: `BepInEx/config/com.RageZro.Peace.cfg`

| Section | Setting | Default | Notes |
|---|---|---|---|
| General | `ModEnabled` | `true` | Master on/off switch |
| PeaceZone | `PeaceZoneRadius` | `140` | Radius in meters, adjustable from 80 to 200 |
| Visual | `ToggleZoneRadiusKey` | `F8` | Key to toggle the green zone ring |
| Advanced | `ZoneRescanIntervalSeconds` | `5` | Safety-net rescan interval for loaded item stands |
| Trophies | `TrophyToEnemyMap` | *(see below)* | `TrophyItemName:EnemyPrefabName` pairs, comma-separated |
| Trophies | `UniversalSuppressEnemies` | *(see below)* | Creature prefab names suppressed under any active zone, no trophy needed |
| Trophies | `BossRequirementMap` | *(see below)* | `EnemyPrefabName:GlobalKey` pairs — which boss must be dead before that creature type's zone activates |


## Support through Ashlands

Support is included up through Ashlands creature trophies.
 
If one of these doesn't seem to work, check the log for the `[Peace] Mounted item '...'` warning to report an issue.

## Trouble Shooting

If you mount a trophy and it doesn't seem to do anything, check the log, the mod logs a warning naming the exact item it didn't recognize:

```
[Peace] Mounted item 'X' has no trophy mapping in TrophyToEnemyMap.
```
Most likely there is a conflict with another mod unfortunately, if there is a true issue then contact me at my Discord server below.

If a trophy shows "Victory Will Still Be Ours!" even though you're certain the correct boss is dead, first double check you're genuinely in the *same world* where that boss was killed (this mod checks defeated boss per world, not per player). If it appears your in the right world, with the correct boss defeated and only one trophy in an non-overlapped peacezone, then contact me at my Discord server below.

## Additional Info

- Fire-fear/avoidance is left as vanilla for every creature.
- Multiplayer: config values only take effect on whichever machine is actually running the world (the host, or the dedicated server).

## Conflicts

- None known, however any mod that affects creature behavior or spawning might cause a conflict.

## Contact Info

- Got an issue or question? Contact me at my Discord server below

- [RageZro](https://discord.gg/mAKHGep4f)

## Credits

Built with [BepInEx](https://github.com/BepInEx/BepInEx) and
[HarmonyX](https://github.com/BepInEx/HarmonyX).
