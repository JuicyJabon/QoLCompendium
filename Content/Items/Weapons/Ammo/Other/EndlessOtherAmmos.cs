namespace QoLCompendium.Content.Items.Weapons.Ammo.Other
{
    public abstract class CoinBag : BaseAmmo
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
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

        public class EndlessBonePouch : ModItem
        {
            public override void SetStaticDefaults()
            {
                Item.ResearchUnlockCount = 1;
            }

            public override void SetDefaults()
            {
                Item.CloneDefaults(ItemID.Bone);
                Item.consumable = false;
                Item.maxStack = 1;

                Item.shoot = ProjectileID.None;
                Item.useAnimation = 0;
                Item.useTime = 0;
                Item.useStyle = ItemUseStyleID.None;
            }

            public override void AddRecipes()
            {
                if (QoLCompendium.itemConfig.EndlessAmmo)
                {
                    CreateRecipe()
                    .AddIngredient(ItemID.Bone, 3996)
                    .AddTile(TileID.CrystalBall)
                    .Register();
                }
            }
        }

        public class EndlessCandyCornPouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.CandyCorn;
        }

        public class EndlessExplosiveJackOLanternPouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.ExplosiveJackOLantern;
        }

        public class EndlessGelBottle : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.Gel;
        }
        
        public class EndlessNailPouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.Nail;
        }

        public class EndlessSandPouch : ModItem
        {
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
            }

            public override void AddRecipes()
            {
                if (QoLCompendium.itemConfig.EndlessAmmo)
                {
                    CreateRecipe()
                    .AddIngredient(ItemID.SandBlock, 3996)
                    .AddTile(TileID.CrystalBall)
                    .Register();
                }
            }
        }

        public class EndlessSnowballPouch : ModItem
        {
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
            }

            public override void AddRecipes()
            {
                if (QoLCompendium.itemConfig.EndlessAmmo)
                {
                    CreateRecipe()
                    .AddIngredient(ItemID.Snowball, 3996)
                    .AddTile(TileID.CrystalBall)
                    .Register();
                }
            }
        }

        public class EndlessStakePouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.Stake;
        }
        public class EndlessStarPouch : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.FallenStar;
        }
        public class EndlessStyngerBoltQuiver : BaseAmmo
        {
            public override int AmmunitionItem => ItemID.StyngerBolt;
        }
    }
}
