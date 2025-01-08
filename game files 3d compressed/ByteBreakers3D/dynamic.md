# Game Design: Byte Breakers

## Part 1: Game Design

### 1. Numerical Attributes

#### Weapons Table
| **Weapon Name**  | **Type**        | **Damage** | **Range**  | **Cost (Credits)** | **Special Ability**         | **Pros**                       | **Cons**                  |
|-------------------|-----------------|------------|------------|---------------------|-----------------------------|--------------------------------|---------------------------|
| **Iron Sword**    | Melee Weapon    | 20         | Short      | 100                 | +10 Fire Damage             | High damage, low cost           | Short range               |
| **Battle Axe**    | Melee Weapon    | 30         | Short      | 150                 | +15 Ice Damage              | High damage, stuns enemies      | Heavy, slower attack speed|
| **Longbow**       | Ranged Weapon   | 20         | Long       | 200                 | +10 Fire/Ice Arrows         | Long range, versatile           | Moderate damage           |
| **Shotgun**       | Modern Weapon   | 50         | Short      | 250                 | +15 Fire Damage             | Devastating close-range power   | Ineffective at long range |
| **Assault Rifle** | Modern Weapon   | 20/shot    | Medium     | 300                 | +10 Ice Damage              | High rate of fire, versatile    | Consumes ammo quickly     |
| **Sniper Rifle**  | Modern Weapon   | 60         | Long       | 350                 | +30 Fire/Ice Precision      | High damage, long-range focus   | Slow fire rate            |

#### Throwables Table
| **Throwable Name** | **Effect**                      | **Damage** | **Range**  | **Cost (Credits)** | **Special Ability**         | **Pros**                       | **Cons**                  |
|---------------------|----------------------------------|------------|------------|---------------------|-----------------------------|--------------------------------|---------------------------|
| **Grenade**         | Explodes after a short delay    | 40         | Medium     | 75                  | None                        | High AoE damage               | Single-use                |
| **Molotov**         | Burns enemies over time         | 30         | Medium     | 100                 | +10 Fire AoE Damage         | Area denial                   | Limited range             |
| **Freeze Bomb**     | Slows enemies in an area        | None       | Medium     | 125                 | +15 Ice Effect              | Disables enemies temporarily  | No direct damage          |

---

### 2. Object Placement

#### Room Layout with Image Link
**Room Design**:
1. **Fire Faction**:
   - **Room 1**: Light Combat with 3 Fire Enemies
   - **Room 2**: Survival Combat (Waves of Fire Enemies)
   - **Room 3**: Fire Boss Room
2. **Ice Faction**:
   - Similar structure with Ice Enemies.
3. **Stone Faction**:
   - Introduces Stone Enemies weak to explosives.

**Image Placeholder**:
![Map Layout](link-to-map-image)

---

### 3. Behaviors of Objects and Characters
- **Enemies**:
  - Fire Enemies: Shoot fireballs, weak to ice.
  - Ice Enemies: Use freezing traps, weak to fire.
  - Stone Enemies: Slow but heavily armored, weak to explosives.
- **Weapons**:
  - Combine abilities and basic attributes for effectiveness.

---

### 4. Economic System
**Credits**:
- Earn credits through puzzle-solving efficiency.
- Example Costs:
  - Weapons: 100–350 credits.
  - Throwables: 75–125 credits.
  - Upgrades: 50–150 credits.

---

### 5. Player Information
- **HUD**:
  - Health bar, credits, abilities.
- **Perspective**:
  - Third-person for better spatial awareness.

---

### 6. Control Mechanism
- **Coding Rooms**:
  - Solve puzzles to unlock abilities.
- **Combat Rooms**:
  - Use pre-prepared weapons in real-time combat.

---

### 7. Player Strategy
- Players decide:
  - Which weapons and abilities to equip.
  - How to approach each faction based on weaknesses.

---
