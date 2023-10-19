using QoLCompendium.Tweaks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace QoLCompendium.Items.BossAndEventSummons
{
    public class ClamSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 2;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Green;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        public override bool CanUseItem(Player player)
        {
            if (ModConditions.calamityLoaded)
            {
                ModConditions.calamityMod.TryFind("GiantClam", out ModNPC GiantClam);

                if (GiantClam != null)
                {
                    return player.ZoneDesert && !NPC.AnyNPCs(GiantClam.Type);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override bool? UseItem(Player player)
        {
            if (ModConditions.calamityLoaded)
            {
                ModConditions.calamityMod.TryFind("GiantClam", out ModNPC GiantClam);

                if (GiantClam != null)
                {
                    NetcodeBossSpawn.SpawnBossNetcoded(player, GiantClam.Type);
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            if (ModConditions.calamityLoaded && QoLCompendium.itemConfig.BossSummoners)
            {
                ModConditions.calamityMod.TryFind("SeaPrism", out ModItem SeaPrism);
                ModConditions.calamityMod.TryFind("Navystone", out ModItem Navystone);

                if (SeaPrism != null && Navystone != null)
                {
                    CreateRecipe()
                        .AddIngredient(SeaPrism.Type)
                        .AddIngredient(Navystone.Type, 3)
                        .AddTile(TileID.Anvils)
                        .Register();
                }
            }
        }
    }
}
