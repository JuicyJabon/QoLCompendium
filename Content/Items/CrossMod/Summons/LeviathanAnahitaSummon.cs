using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core;
using QoLCompendium.Core.Changes;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.CrossMod.Summons
{
    public class LeviathanAnahitaSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 13;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 11;
            Item.height = 11;
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
            return ModConditions.calamityLoaded && NPC.downedPlantBoss && player.ZoneBeach && !NPC.AnyNPCs(Common.GetModNPC(ModConditions.calamityMod, "Anahita"));
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, Common.GetModNPC(ModConditions.calamityMod, "Anahita"));
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
            r.AddIngredient(ItemID.WhitePearl, 3);
            r.AddIngredient(ItemID.Ectoplasm, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
    }
}
