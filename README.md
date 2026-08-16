# Peace

Mount any creature's trophy on an item stand to create a **peace zone** around
it that will make a specific creature type stop spawning within that zone and stops creatures outside the zone from noticing or
attacking you. Events that include creatures that have threir trophy mounted will not attack you in the **peace zone** while you're inside the zone — everything else in the world
behaves normally.

## How it works

- **Mount a trophy** on any item stand. If it's a recognized creature
  trophy based on the config list, a peace zone activates around that stand for that creature type
  only. You'll see **"Peace Has Come!"** message above the trophy when mounted.
- **Remove the trophy** and the zone deactivates: **"Peace Has Ended!"** messsage appears above the item mount.
- **One trophy per creature type, per area.** Mounting a *second* trophy of
  the same creature type within **peace zone** of the first cancels protection for
  that type in that zone area. If you overlap zones with the same creature trophy mounted then it will also cancel the **peace zone** (until you're remove duplicate trophys).
  Two trophies of the same type at **separate, non-overlapoping zones** don't affect
  each other — each protects its own area independently.
- Peace zones are **per creature type** — a Greydwarf trophy only pacifies
  Greydwarves. For example: Variants (Greydwarf Brute, Greydwarf Shaman, etc.) need their
  own trophy mounted to stop them from spawning.
- A handful of creatures that don't have a trophy of their own (e.g.
  Greyling, which can summon Greydwarves when startled) are suppressed
  automatically whenever you're within **any** active peace zone.
  This list is configurable — see `UniversalSuppressEnemies` below.
- A green line will appear and follow the terrain in a circle for each trophy mounted. 
- Raid and world events are affected by peace zones even though they spawn normally.
  ANy creature with their trophy mounted will appear in a Raid Event but will not attack but rather wander around even after the event.

## Visualizing a zone

To help a player visualize the ***peace zone edges, press **F8** (configurable) to toggle a green ring for each and every mounted trophy showing the boundary of
every currently active peace zone. The ring follows terrain height so it
won't clip into hillsides. There is a small buffer zone beyonf the gfreen ring however some creatures have large enoough alert zones to trigger if you go beyonf the green ring.

## Configuration

Config file: `BepInEx/config/com.RageZro.Peace.cfg`

| Section | Setting | Default | Notes |
|---|---|---|---|
| General | `ModEnabled` | `true` | Master on/off switch |
| PeaceZone | `PeaceZoneSize` | `Small` | `Small` (180m), `Medium` (270m), or `Large` (360m) |
| Visual | `ToggleZoneRadiusKey` | `F8` | Key to toggle the green zone ring |
| Advanced | `ZoneRescanIntervalSeconds` | `5` | Safety-net rescan interval for loaded item stands |
| Trophies | `TrophyToEnemyMap` | *(see below)* | `TrophyItemName:EnemyPrefabName` pairs, comma-separated |
| Trophies | `UniversalSuppressEnemies` | *(see below)* | Creature prefab names suppressed under any active zone, no trophy needed |

### Adding or fixing a trophy mapping

If you mount a trophy and it doesn't seem to do anything, check the log —
the mod logs a warning naming the exact item it didn't recognize:

```
[Peace] Mounted item 'X' has no trophy mapping in TrophyToEnemyMap.
```

Add `TrophyItemName:EnemyPrefabName` to `TrophyToEnemyMap` in the config
file to fix it (comma-separated from the existing entries).

### Meadows to Ashlands trophies

Support is included for Ashlands creature trophies, if one of these doesn't seem to work, check 
the log for the `[Peace] Mounted item '...'` warning above to find and correct it to the real
name.

## Known limitations

- Peace zones affect all ambient/wandering spawns and normal AI
  awareness — they don't stop raid/event spawns.
- Fleeing behavior and fire-fear/avoidance are left as vanilla — a
  "peaceful" creature will still flee if hurt and still avoid fire.
- Multiplayer: config values only take effect on whichever machine is
  actually running the world (the host, or the dedicated server).
- Dungeons, etc. are not affected if they are located in your ***peace zone*** and will generate hostile creatures.
- Creatures on the outside of a dungeon will still spawn but are passive.

## Credits

Built with [BepInEx](https://github.com/BepInEx/BepInEx) and
[HarmonyX](https://github.com/BepInEx/HarmonyX).
