using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Summons.CrossMod
{
    public class ScarabBeliefSummon : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.BossSummons;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 21;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 14;
            Item.maxStack = Item.CommonMaxStack;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<NPCSpawner>();
            Item.SetShopValues(ItemRarityColor.StrongRed10, Item.sellPrice(0, 0, 0, 0));
        }

        public override bool CanUseItem(Player player)
        {
            return ModConditions.homewardJourneyLoaded && ModConditions.DownedLifebringer.IsMet() && ModConditions.DownedMaterealizer.IsMet() && ModConditions.DownedOverwatcher.IsMet() && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"));
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, Common.GetModNPC(ModConditions.homewardJourneyMod, "ScarabBelief"));
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.CrossModItems);
        }

        public override void AddRecipes()
        {
            if (!ModConditions.homewardJourneyLoaded)
                return;

            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.CrossModItems, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(Common.GetModItem(ModConditions.homewardJourneyMod, "FinalBar"), 3);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}
