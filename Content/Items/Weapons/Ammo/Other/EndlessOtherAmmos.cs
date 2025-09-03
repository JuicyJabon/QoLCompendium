using QoLCompendium.Core;
using QoLCompendium.Core.Changes.TooltipChanges;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Other
{
    public abstract class CoinBag : BaseAmmo
    {
        public override void SetDefaults()
        {
            Item.notAmmo = false;
            Item.useStyle = ItemUseStyleID.None;
            Item.useTime = 0;
            Item.useAnimation = 0;
            Item.createTile = -1;
            Item.shoot = ProjectileID.None;
        }

        class EndlessCopperCoinPouch : CoinBag
        {
            public override int AmmunitionItem => ItemID.CopperCoin;
        }

        class EndlessSilverCoinPouch : CoinBag
        {
            public override int AmmunitionItem => ItemID.SilverCoin;
        }

        class EndlessGoldCoinPouch : CoinBag
        {
            public override int AmmunitionItem => ItemID.GoldCoin;
        }

        class EndlessPlatinumCoinPouch : CoinBag
        {
            public override int AmmunitionItem => ItemID.PlatinumCoin;
        }

        public class EndlessCandyCornPie : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.CandyCorn;
        }

        public class EndlessExplosiveJackOLantern : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.ExplosiveJackOLantern;
        }

        public class EndlessGelTank : ModItem
        {
            public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EndlessAmmo;

            public override void SetStaticDefaults()
            {
                Item.ResearchUnlockCount = 1;
            }

            public override void SetDefaults()
            {
                Item.ammo = AmmoID.Gel;
                Item.knockBack = 0.5f;
                Item.DamageType = DamageClass.Ranged;
                Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 0, 0));
            }

            public override void ModifyTooltips(List<TooltipLine> tooltips)
            {
                Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EndlessAmmo);
            }

            public override void AddRecipes()
            {
                Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
                r.AddIngredient(ItemID.Gel, 3996);
                r.AddTile(TileID.Solidifier);
                r.Register();
            }
        }
        
        public class EndlessNailPouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.Nail;
        }

        public class EndlessSandPouch : ModItem
        {
            public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EndlessAmmo;

            public override void SetStaticDefaults()
            {
                Item.ResearchUnlockCount = 1;
            }

            public override void SetDefaults()
            {
                Item.CloneDefaults(ItemID.SandBlock);
                Item.consumable = false;
                Item.maxStack = 1;

                Item.useStyle = ItemUseStyleID.None;
                Item.useTime = 0;
                Item.useAnimation = 0;
                Item.createTile = -1;
                Item.shoot = ProjectileID.None;
                Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 0, 0));
            }

            public override void ModifyTooltips(List<TooltipLine> tooltips)
            {
                Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EndlessAmmo);
            }

            public override bool CanUseItem(Player player)
            {
                return false;
            }

            public override void AddRecipes()
            {
                Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
                r.AddIngredient(ItemID.SandBlock, 3996);
                r.AddTile(TileID.Solidifier);
                r.Register();
            }
        }

        public class EndlessSnowballPouch : ModItem
        {
            public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EndlessAmmo;

            public override void SetStaticDefaults()
            {
                Item.ResearchUnlockCount = 1;
            }

            public override void SetDefaults()
            {
                Item.CloneDefaults(ItemID.Snowball);
                Item.consumable = false;
                Item.maxStack = 1;

                Item.shoot = ProjectileID.None;
                Item.useAnimation = 0;
                Item.useTime = 0;
                Item.useStyle = ItemUseStyleID.None;
                Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 0, 0));
            }

            public override void ModifyTooltips(List<TooltipLine> tooltips)
            {
                Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EndlessAmmo);
            }

            public override bool CanUseItem(Player player)
            {
                return false;
            }

            public override void AddRecipes()
            {
                Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
                r.AddIngredient(ItemID.Snowball, 3996);
                r.AddTile(TileID.Solidifier);
                r.Register();
            }
        }

        public class EndlessStakeBundle : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.Stake;
        }

        public class EndlessStarPouch : ModItem
        {
            public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.EndlessAmmo;

            public override void SetStaticDefaults()
            {
                Item.ResearchUnlockCount = 1;
            }

            public override void SetDefaults()
            {
                Item.ammo = AmmoID.FallenStar;
                Item.DamageType = DamageClass.Ranged;
                Item.SetShopValues(ItemRarityColor.Green2, Item.sellPrice(0, 1, 0, 0));
            }

            public override void ModifyTooltips(List<TooltipLine> tooltips)
            {
                Common.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.EndlessAmmo);
            }

            public override bool CanUseItem(Player player)
            {
                return false;
            }

            public override void AddRecipes()
            {
                Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.EndlessAmmo, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
                r.AddIngredient(ItemID.FallenStar, 3996);
                r.AddTile(TileID.Solidifier);
                r.Register();
            }
        }
        public class EndlessStyngerBoltQuiver : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.StyngerBolt;
        }
    }
}
