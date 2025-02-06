using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.CrossMod.Summons
{
    public class GiantClamSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 2;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<NPCSpawner>();
            Item.SetShopValues(ItemRarityColor.Pink5, Item.sellPrice(0, 0, 0, 0));
        }

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded && ModConditions.calamityMod.TryFind("SunkenSeaBiome", out ModBiome SunkenSeaBiome) && SunkenSeaBiome != null && Main.LocalPlayer.InModBiome(SunkenSeaBiome))
                return ModConditions.downedDesertScourge && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.calamityMod, "GiantClam"));
            return false;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, Common.GetModNPC(ModConditions.calamityMod, "GiantClam"));
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipChanges.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CrossModItems);
        }

        public override void AddRecipes()
        {
            if (!ModConditions.calamityLoaded)
                return;

            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.CrossModItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "SeaPrism"), 3);
            r.AddIngredient(Common.GetModItem(ModConditions.calamityMod, "Navystone"), 5);
            r.Register();
        }
    }
}
