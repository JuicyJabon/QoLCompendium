using CalamityMod;
using CalamityMod.Cooldowns;
using CalamityMod.Items.Ammo;
using CalamityMod.Items.Armor.Wulfrum;
using CalamityMod.Items.Materials;
using CalamityMod.Items.Tools;
using CalamityMod.Items.Weapons.Ranged;
using System.Reflection;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other.Calamity
{
    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessBloodRune : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<BloodRune>();
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class EndlessWulfrumCogworkShard : BaseAmmo
    {
        public override int AmmunitionItem => ModContent.ItemType<WulfrumMetalScrap>();

        public override int IngredientStackCount => 396;
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class WulfrumBlunderbussEndless : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<WulfrumBlunderbuss>();
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (!player.HasItem(ModContent.ItemType<EndlessWulfrumCogworkShard>()))
                return;

            if (item.ModItem is WulfrumBlunderbuss wulfrumBlunderbuss)
                wulfrumBlunderbuss.storedScrap = 30;
        }
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class WulfrumScaffoldKitEndless : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<WulfrumScaffoldKit>();
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (!player.HasItem(ModContent.ItemType<EndlessWulfrumCogworkShard>()))
                return;

            if (item.ModItem is WulfrumScaffoldKit wulfrumScaffoldKit)
                wulfrumScaffoldKit.storedScrap = 40;
        }
    }

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public class WulfrumArmorEndless : ModPlayer
    {
        public override void ArmorSetBonusActivated()
        {
            if (WulfrumHat.HasArmorSet(Player))
            {
                if (Player.Calamity().cooldowns.TryGetValue(WulfrumBastion.ID, out var cd))
                {
                    if (cd.timeLeft > WulfrumHat.BastionCooldown && cd.timeLeft < WulfrumHat.BastionCooldown + WulfrumHat.BastionTime - 180)
                    {
                        cd.timeLeft = WulfrumHat.BastionCooldown + 1;
                        Player.Calamity().SyncCooldownDictionary(server: false);
                    }
                }
                else if (Player.HasItem(ModContent.ItemType<EndlessWulfrumCogworkShard>()))
                {
                    Player.AddCooldown(WulfrumBastion.ID, WulfrumHat.BastionCooldown + WulfrumHat.BastionTime);
                    FieldInfo cannon = typeof(WulfrumHat).GetField("DummyCannon", Constants.UniversalBindingFlags);
                    cannon?.SetValue(cannon, new Item(ModContent.ItemType<WulfrumFusionCannon>()));
                }
            }
        }
    }
}
