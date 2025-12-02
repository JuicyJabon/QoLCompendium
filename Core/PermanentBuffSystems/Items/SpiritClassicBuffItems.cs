using SpiritMod.Buffs;
using SpiritMod.Buffs.Candy;
using SpiritMod.Buffs.Potion;
using SpiritMod.Buffs.Tiles;
using SpiritMod.Items.Accessory;
using SpiritMod.Items.Consumable;
using SpiritMod.Items.Consumable.Potion;
using SpiritMod.Items.DonatorItems;
using SpiritMod.Items.Halloween;
using SpiritMod.Items.Placeable.Furniture;
using SpiritMod.Items.Sets.CoilSet;

namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    [JITWhenModsEnabled(ModConditions.spiritClassicName)]
    [ExtendsFromMod(ModConditions.spiritClassicName)]
    public static class SpiritClassicBuffItems
    {
        public static NewBuffEffect[] SpiritClassicEffects = [
            //potions
            new NewBuffEffect(ModContent.BuffType<PinkPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<MirrorCoatBuff>()),
            new NewBuffEffect(ModContent.BuffType<MoonBlessing>()),
            new NewBuffEffect(ModContent.BuffType<OliveBranchBuff>()),
            new NewBuffEffect(ModContent.BuffType<RunePotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<SoulPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<SpiritBuff>()),
            new NewBuffEffect(ModContent.BuffType<FlightPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<MushroomPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<StarPotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<TurtlePotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<BismitePotionBuff>()),
            new NewBuffEffect(ModContent.BuffType<DoubleJumpPotionBuff>()),
            //candies
            new NewBuffEffect(ModContent.BuffType<CandyBuff>(), (int) Common.EffectTypes.Candy),
            new NewBuffEffect(ModContent.BuffType<ChocolateBuff>(), (int) Common.EffectTypes.Candy),
            new NewBuffEffect(ModContent.BuffType<HealthBuffC>(), (int) Common.EffectTypes.Candy),
            new NewBuffEffect(ModContent.BuffType<LollipopBuff>(), (int) Common.EffectTypes.Candy),
            new NewBuffEffect(ModContent.BuffType<ManaBuffC>(), (int) Common.EffectTypes.Candy),
            new NewBuffEffect(ModContent.BuffType<TaffyBuff>(), (int) Common.EffectTypes.Candy),
            //arena
            new NewBuffEffect(ModContent.BuffType<OverDrive>(), (int) Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<KoiTotemBuff>(), (int) Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<SunPotBuff>(), (int) Common.EffectTypes.Arena),
            new NewBuffEffect(ModContent.BuffType<CouchPotato>(), (int) Common.EffectTypes.Arena),
        ];

        public static void LoadTasks()
        {
            BaseItems();
            CombinedItems();
        }

        public static void BaseItems()
        {
            foreach (var newEffect in SpiritClassicEffects)
            {
                BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                QoLCompendium.Instance.AddContent(effect);
                Common.AllEffects.Add(newEffect.buffID, effect);
            }

            NewBuffItem[] BuffItems = [
                //potions
                new NewBuffItem(ModContent.ItemType<PinkPotion>(), ModContent.BuffType<PinkPotionBuff>(), Common.AllEffects[ModContent.BuffType<PinkPotionBuff>()], 30, "PermanentJump", "Permanent Jump"),
                new NewBuffItem(ModContent.ItemType<MirrorCoat>(), ModContent.BuffType<MirrorCoatBuff>(), Common.AllEffects[ModContent.BuffType<MirrorCoatBuff>()], 30, "PermanentMirrorCoat", "Permanent Mirror Coat"),
                new NewBuffItem(ModContent.ItemType<MoonJelly>(), ModContent.BuffType<MoonBlessing>(), Common.AllEffects[ModContent.BuffType<MoonBlessing>()], 30, "PermanentMoonJelly", "Permanent Moon Jelly"),
                new NewBuffItem(ModContent.ItemType<OliveBranch>(), ModContent.BuffType<OliveBranchBuff>(), Common.AllEffects[ModContent.BuffType<OliveBranchBuff>()], 30, "PermanentOliveBranch", "Permanent Olive Branch"),
                new NewBuffItem(ModContent.ItemType<RunePotion>(), ModContent.BuffType<RunePotionBuff>(), Common.AllEffects[ModContent.BuffType<RunePotionBuff>()], 30, "PermanentRunescribe", "Permanent Runescribe"),
                new NewBuffItem(ModContent.ItemType<SoulPotion>(), ModContent.BuffType<SoulPotionBuff>(), Common.AllEffects[ModContent.BuffType<SoulPotionBuff>()], 30, "PermanentSoulguard", "Permanent Soulguard"),
                new NewBuffItem(ModContent.ItemType<SpiritPotion>(), ModContent.BuffType<SpiritBuff>(), Common.AllEffects[ModContent.BuffType<SpiritBuff>()], 30, "PermanentSpirit", "Permanent Spirit"),
                new NewBuffItem(ModContent.ItemType<FlightPotion>(), ModContent.BuffType<FlightPotionBuff>(), Common.AllEffects[ModContent.BuffType<FlightPotionBuff>()], 30, "PermanentSpiritSoaring", "Permanent Soaring"),
                new NewBuffItem(ModContent.ItemType<MushroomPotion>(), ModContent.BuffType<MushroomPotionBuff>(), Common.AllEffects[ModContent.BuffType<MushroomPotionBuff>()], 30, "PermanentSporecoid", "Permanent Sporecoid"),
                new NewBuffItem(ModContent.ItemType<StarPotion>(), ModContent.BuffType<StarPotionBuff>(), Common.AllEffects[ModContent.BuffType<StarPotionBuff>()], 30, "PermanentStarburn", "Permanent Starburn"),
                new NewBuffItem(ModContent.ItemType<TurtlePotion>(), ModContent.BuffType<TurtlePotionBuff>(), Common.AllEffects[ModContent.BuffType<TurtlePotionBuff>()], 30, "PermanentSteadfast", "Permanent Steadfast"),
                new NewBuffItem(ModContent.ItemType<BismitePotion>(), ModContent.BuffType<BismitePotionBuff>(), Common.AllEffects[ModContent.BuffType<BismitePotionBuff>()], 30, "PermanentToxin", "Permanent Toxin"),
                new NewBuffItem(ModContent.ItemType<DoubleJumpPotion>(), ModContent.BuffType<DoubleJumpPotionBuff>(), Common.AllEffects[ModContent.BuffType<DoubleJumpPotionBuff>()], 30, "PermanentZephyr", "Permanent Zephyr"),
                //candies
                new NewBuffItem(ModContent.ItemType<Candy>(), ModContent.BuffType<CandyBuff>(), Common.AllEffects[ModContent.BuffType<CandyBuff>()], 30, "PermanentCandy", "Permanent Candy"),
                new NewBuffItem(ModContent.ItemType<ChocolateBar>(), ModContent.BuffType<ChocolateBuff>(), Common.AllEffects[ModContent.BuffType<ChocolateBuff>()], 30, "PermanentChocolateBar", "Permanent Chocolate Bar"),
                new NewBuffItem(ModContent.ItemType<HealthCandy>(), ModContent.BuffType<HealthBuffC>(), Common.AllEffects[ModContent.BuffType<HealthBuffC>()], 30, "PermanentHealthCandy", "Permanent Health Candy"),
                new NewBuffItem(ModContent.ItemType<Lollipop>(), ModContent.BuffType<LollipopBuff>(), Common.AllEffects[ModContent.BuffType<LollipopBuff>()], 30, "PermanentLollipop", "Permanent Lollipop"),
                new NewBuffItem(ModContent.ItemType<ManaCandy>(), ModContent.BuffType<ManaBuffC>(), Common.AllEffects[ModContent.BuffType<ManaBuffC>()], 30, "PermanentManaCandy", "Permanent Mana Candy"),
                new NewBuffItem(ModContent.ItemType<Taffy>(), ModContent.BuffType<TaffyBuff>(), Common.AllEffects[ModContent.BuffType<TaffyBuff>()], 30, "PermanentTaffy", "Permanent Taffy"),
                //arena
                new NewBuffItem(ModContent.ItemType<CoilEnergizerItem>(), ModContent.BuffType<OverDrive>(), Common.AllEffects[ModContent.BuffType<OverDrive>()], 3, "PermanentCoiledEnergizer", "Permanent Coiled Energizer"),
                new NewBuffItem(ModContent.ItemType<KoiTotem>(), ModContent.BuffType<KoiTotemBuff>(), Common.AllEffects[ModContent.BuffType<KoiTotemBuff>()], 3, "PermanentKoiTotem", "Permanent Koi Totem"),
                new NewBuffItem(ModContent.ItemType<SunPot>(), ModContent.BuffType<SunPotBuff>(), Common.AllEffects[ModContent.BuffType<SunPotBuff>()], 3, "PermanentSunPot", "Permanent Sun Pot"),
                new NewBuffItem(ModContent.ItemType<TheCouch>(), ModContent.BuffType<CouchPotato>(), Common.AllEffects[ModContent.BuffType<CouchPotato>()], 3, "PermanentCouchPotato", "Permanent Couch Potato"),
            ];

            foreach (var newBuffItem in BuffItems)
            {
                BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }

        public static void CombinedItems()
        {
            Dictionary<BuffEffect, int> PermanentSpiritClassicDamage = new()
            {
                { Common.AllEffects[ModContent.BuffType<RunePotionBuff>()], ModContent.BuffType<RunePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<SoulPotionBuff>()], ModContent.BuffType<SoulPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<SpiritBuff>()], ModContent.BuffType<SpiritBuff>() },
                { Common.AllEffects[ModContent.BuffType<StarPotionBuff>()], ModContent.BuffType<StarPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<BismitePotionBuff>()], ModContent.BuffType<BismitePotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentSpiritClassicDefense = new()
            {
                { Common.AllEffects[ModContent.BuffType<MirrorCoatBuff>()], ModContent.BuffType<MirrorCoatBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonBlessing>()], ModContent.BuffType<MoonBlessing>() },
                { Common.AllEffects[ModContent.BuffType<OliveBranchBuff>()], ModContent.BuffType<OliveBranchBuff>() },
                { Common.AllEffects[ModContent.BuffType<MushroomPotionBuff>()], ModContent.BuffType<MushroomPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<TurtlePotionBuff>()], ModContent.BuffType<TurtlePotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentSpiritClassicMovement = new()
            {
                { Common.AllEffects[ModContent.BuffType<PinkPotionBuff>()], ModContent.BuffType<PinkPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlightPotionBuff>()], ModContent.BuffType<FlightPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<DoubleJumpPotionBuff>()], ModContent.BuffType<DoubleJumpPotionBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentSpiritClassicCandies = new()
            {
                { Common.AllEffects[ModContent.BuffType<CandyBuff>()], ModContent.BuffType<CandyBuff>() },
                { Common.AllEffects[ModContent.BuffType<ChocolateBuff>()], ModContent.BuffType<ChocolateBuff>() },
                { Common.AllEffects[ModContent.BuffType<HealthBuffC>()], ModContent.BuffType<HealthBuffC>() },
                { Common.AllEffects[ModContent.BuffType<LollipopBuff>()], ModContent.BuffType<LollipopBuff>() },
                { Common.AllEffects[ModContent.BuffType<ManaBuffC>()], ModContent.BuffType<ManaBuffC>() },
                { Common.AllEffects[ModContent.BuffType<TaffyBuff>()], ModContent.BuffType<TaffyBuff>() }
            };

            Dictionary<BuffEffect, int> PermanentSpiritClassicArena = new()
            {
                { Common.AllEffects[ModContent.BuffType<OverDrive>()], ModContent.BuffType<OverDrive>() },
                { Common.AllEffects[ModContent.BuffType<KoiTotemBuff>()], ModContent.BuffType<KoiTotemBuff>() },
                { Common.AllEffects[ModContent.BuffType<SunPotBuff>()], ModContent.BuffType<SunPotBuff>() },
                { Common.AllEffects[ModContent.BuffType<CouchPotato>()], ModContent.BuffType<CouchPotato>() }
            };

            Dictionary<BuffEffect, int> PermanentSpiritClassic = new()
            {
                { Common.AllEffects[ModContent.BuffType<RunePotionBuff>()], ModContent.BuffType<RunePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<SoulPotionBuff>()], ModContent.BuffType<SoulPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<SpiritBuff>()], ModContent.BuffType<SpiritBuff>() },
                { Common.AllEffects[ModContent.BuffType<StarPotionBuff>()], ModContent.BuffType<StarPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<BismitePotionBuff>()], ModContent.BuffType<BismitePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<MirrorCoatBuff>()], ModContent.BuffType<MirrorCoatBuff>() },
                { Common.AllEffects[ModContent.BuffType<MoonBlessing>()], ModContent.BuffType<MoonBlessing>() },
                { Common.AllEffects[ModContent.BuffType<OliveBranchBuff>()], ModContent.BuffType<OliveBranchBuff>() },
                { Common.AllEffects[ModContent.BuffType<MushroomPotionBuff>()], ModContent.BuffType<MushroomPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<TurtlePotionBuff>()], ModContent.BuffType<TurtlePotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<PinkPotionBuff>()], ModContent.BuffType<PinkPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<FlightPotionBuff>()], ModContent.BuffType<FlightPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<DoubleJumpPotionBuff>()], ModContent.BuffType<DoubleJumpPotionBuff>() },
                { Common.AllEffects[ModContent.BuffType<CandyBuff>()], ModContent.BuffType<CandyBuff>() },
                { Common.AllEffects[ModContent.BuffType<ChocolateBuff>()], ModContent.BuffType<ChocolateBuff>() },
                { Common.AllEffects[ModContent.BuffType<HealthBuffC>()], ModContent.BuffType<HealthBuffC>() },
                { Common.AllEffects[ModContent.BuffType<LollipopBuff>()], ModContent.BuffType<LollipopBuff>() },
                { Common.AllEffects[ModContent.BuffType<ManaBuffC>()], ModContent.BuffType<ManaBuffC>() },
                { Common.AllEffects[ModContent.BuffType<TaffyBuff>()], ModContent.BuffType<TaffyBuff>() },
                { Common.AllEffects[ModContent.BuffType<OverDrive>()], ModContent.BuffType<OverDrive>() },
                { Common.AllEffects[ModContent.BuffType<KoiTotemBuff>()], ModContent.BuffType<KoiTotemBuff>() },
                { Common.AllEffects[ModContent.BuffType<SunPotBuff>()], ModContent.BuffType<SunPotBuff>() },
                { Common.AllEffects[ModContent.BuffType<CouchPotato>()], ModContent.BuffType<CouchPotato>() }
            };

            NewCombinedBuffItem[] CombinedBuffItems = [
                new NewCombinedBuffItem(PermanentSpiritClassicDamage, "PermanentSpiritClassicDamage", "Permanent Spirit Classic Damage", "PermanentSpiritClassicDamage"),
                new NewCombinedBuffItem(PermanentSpiritClassicDefense, "PermanentSpiritClassicDefense", "Permanent Spirit Classic Defense", "PermanentSpiritClassicDefense"),
                new NewCombinedBuffItem(PermanentSpiritClassicMovement, "PermanentSpiritClassicMovement", "Permanent Spirit Classic Movement", "PermanentSpiritClassicMovement"),
                new NewCombinedBuffItem(PermanentSpiritClassicCandies, "PermanentSpiritClassicCandies", "Permanent Spirit Classic Candies", "PermanentSpiritClassicCandies"),
                new NewCombinedBuffItem(PermanentSpiritClassicArena, "PermanentSpiritClassicArena", "Permanent Spirit Classic Arena", "PermanentSpiritClassicArena"),
                new NewCombinedBuffItem(PermanentSpiritClassic, "PermanentSpiritClassic", "Permanent Spirit Classic", "PermanentSpiritClassic")
            ];

            foreach (var newCombinedBuffItem in CombinedBuffItems)
            {
                CombinedBuffItem item = new(newCombinedBuffItem.itemName, newCombinedBuffItem.effects, newCombinedBuffItem.displayName, newCombinedBuffItem.textureName);
                QoLCompendium.Instance.AddContent(item);
            }
        }
    }
}
