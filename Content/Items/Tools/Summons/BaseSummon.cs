using QoLCompendium.Content.Projectiles.Other;
using Terraria.DataStructures;

namespace QoLCompendium.Content.Items.Tools.Summons
{
    public abstract class BaseSummon : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.BossSummons;

        public new string LocalizationCategory => "Items.Tools.Summons";

        public abstract int SortingPriority { get; }
        public abstract int NPCType { get; }
        public abstract int Rarity { get; }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = SortingPriority;
            Item.ResearchUnlockCount = QoLCompendium.mainConfig.EndlessBossSummons ? 1 : 3;
        }

        public override void SetDefaults()
        {
            Item.width = Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
            Item.shoot = ModContent.ProjectileType<NPCSpawner>();
            Item.rare = Rarity;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
            Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCType);
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) => Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.BossSummons);
    }
}
