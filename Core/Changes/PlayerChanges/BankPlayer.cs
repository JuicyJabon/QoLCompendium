using QoLCompendium.Content.Projectiles.MobileStorages;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class BankPlayer : ModPlayer
    {
        internal bool chests;
        internal int pig = -1;
        internal int safe = -1;
        internal int defenders = -1;
        internal int vault = -1;

        public override void SetControls()
        {
            if (Player.whoAmI == Main.myPlayer && chests)
            {
                Main.SmartCursorShowing = false;
                Player.tileRangeX = 9999;
                Player.tileRangeY = 5000;
                if (Player.chest >= -1)
                {
                    pig = -1;
                    safe = -1;
                    defenders = -1;
                    vault = -1;
                    chests = false;
                }
                if (safe != -1 && Main.projectile[safe].type != ModContent.ProjectileType<FlyingSafeProjectile>())
                {
                    safe = -1;
                    chests = false;
                }
                if (defenders != -1 && Main.projectile[defenders].type != ModContent.ProjectileType<EtherianConstructProjectile>())
                {
                    defenders = -1;
                    chests = false;
                }
            }
        }

        public override void UpdateEquips()
        {
            if (QoLCompendium.mainConfig.UtilityAccessoriesWorkInBanks)
            {
                for (int i = 0; i < Player.bank.item.Length; i++)
                    CheckForBankItems(Player.bank.item[i]);
                for (int j = 0; j < Player.bank2.item.Length; j++)
                    CheckForBankItems(Player.bank2.item[j]);
                for (int k = 0; k < Player.bank3.item.Length; k++)
                    CheckForBankItems(Player.bank3.item[k]);
                for (int l = 0; l < Player.bank4.item.Length; l++)
                    CheckForBankItems(Player.bank4.item[l]);
            }
        }

        public void CheckForBankItems(Item item)
        {
            if (Common.BankItems.Contains(item.type))
            {
                if (item.type == Common.GetModItem(ModConditions.secretsOfTheShadowsMod, "ElectromagneticDeterrent"))
                    return;

                Player.GetModPlayer<QoLCPlayer>().activeItems.Add(item.type);
                Player.ApplyEquipFunctional(item, true);
                Player.RefreshInfoAccsFromItemType(item);
                Player.RefreshMechanicalAccsFromItemType(item.type);

                if (item.type == ItemID.RoyalGel) //Royal Gel Compatibility
                {
                    //Thorium Slimes
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "Clot")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "GelatinousCube")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "GelatinousSludge")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "GildedSlime")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "GildedSlimeling")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "GraniteFusedSlime")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "LivingHemorrhage")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "SpaceSlime")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "CrownofThorns")] = true;
                    Player.npcTypeNoAggro[Common.GetModNPC(ModConditions.thoriumMod, "BloodDrop")] = true;
                }
            }

            //CHECKS ALL ACCESSORY TYPES
            /*
            CheckMoneyAccessories(item);
            CheckWireAccessories(item);
            CheckInformationAccessories(item);
            CheckBuildingAccessories(item);
            CheckFishingAccessories(item);
            CheckMiscAccessories(item);
            */

            /* FIX CALAMITY STAT INCREASES FOR DEFENSE PREFIXES
            if (ModConditions.calamityLoaded)
                RemoveCalamityDefensePrefix(Player, item);
            */
        }
    }
}
