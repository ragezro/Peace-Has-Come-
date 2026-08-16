# Peace

Mount a creature's trophy on an item stand to create a **peace zone** around
it: that specific creature type stops spawning nearby and stops noticing or
attacking you while you're inside the zone — everything else in the world
behaves normally.

## How it works

- **Mount a trophy** on any item stand. If it's a recognized creature
  trophy, a peace zone activates around that stand for that creature type
  only. You'll see **"Peace Has Come!"**.
- **Remove the trophy** and the zone deactivates: **"Peace Has Ended!"**.
- **One trophy per creature type, per area.** Mounting a *second* trophy of
  the same creature type within range of the first cancels protection for
  that type in that local area (until you're back down to exactly one).
  Two trophies of the same type at **separate, distant bases** don't affect
  each other — each protects its own area independently.
- Peace zones are **per creature type** — a Greydwarf trophy only pacifies
  Greydwarves. Variants (Greydwarf Brute, Greydwarf Shaman, etc.) need their
  own trophy.
- A handful of creatures that don't have a trophy of their own (e.g.
  Greyling, which can summon Greydwarves when startled) are suppressed
  automatically whenever you're within range of **any** active peace zone.
  This list is configurable — see `UniversalSuppressEnemies` below.
- Raid and world events are **not** affected by peace zones — they always
  spawn normally.

## Visualizing a zone

Press **F8** (configurable) to toggle a green ring showing the boundary of
every currently active peace zone. The ring follows terrain height so it
won't clip into hillsides.

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

### Ashlands/Mistlands trophies

Support is included for Ashlands and Mistlands creature trophies, but a few
of the enemy prefab name guesses are lower-confidence than the core game
entries. If one of these doesn't seem to work, check the log for the
`[Peace] Mounted item '...'` warning above to find and correct the real
name.

## Known limitations

- Peace zones only affect ambient/wandering spawns and normal AI
  awareness — they don't affect raid/event spawns.
- Fleeing behavior and fire-fear/avoidance are left as vanilla — a
  "peaceful" creature will still flee if hurt and still avoid fire.
- Multiplayer: config values only take effect on whichever machine is
  actually running the world (the host, or the dedicated server).

## Credits

Built with [BepInEx](https://github.com/BepInEx/BepInEx) and
[HarmonyX](https://github.com/BepInEx/HarmonyX).
