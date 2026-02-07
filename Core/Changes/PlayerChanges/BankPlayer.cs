namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class BankPlayer : ModPlayer
    {
        public override void UpdateEquips()
        {
            if (QoLCompendium.mainConfig.UtilityAccessoriesWorkInBanks)
                CheckForBankItems(Common.GetAllInventoryItemsList(Player, "inv").ToArray());
        }

        public void CheckForBankItems(Item[] items)
        {
            foreach (Item item in items)
            {
                if (Common.BankItems.Contains(item.type) && !item.IsAir)
                {
                    Player.GetModPlayer<QoLCPlayer>().activeItems.Add(item.type);
                    Player.ApplyEquipFunctional(item, true);
                    Player.RefreshInfoAccsFromItemType(item);
                    Player.RefreshMechanicalAccsFromItemType(item.type);

                    if (item.type == ItemID.RoyalGel) //Royal Gel Compatibility
                    {
                        //Thorium Slimes
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "Clot")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "GelatinousCube")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "GelatinousSludge")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "GildedSlime")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "GildedSlimeling")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "GraniteFusedSlime")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "LivingHemorrhage")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "SpaceSlime")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "CrownofThorns")] = true;
                        Player.npcTypeNoAggro[Common.GetModNPC(CrossModSupport.Thorium.Mod, "BloodDrop")] = true;
                    }
                }
            }
        }
    }

    public class BankRange : ModSystem
    {
        public static int? LastOpenedBank;
        
        public const int PiggyBank = -2;
        public const int Safe = -3;
        public const int DefendersForge = -4;
        public const int VoidVault = -5;

        public override void Load()
        {
            On_Player.HandleBeingInChestRange += ChestRange;
        }

        public override void Unload()
        {
            On_Player.HandleBeingInChestRange -= ChestRange;
        }

        private static void ChestRange(On_Player.orig_HandleBeingInChestRange orig, Player player)
        {
            if (player.chest == LastOpenedBank) return;
            if (LastOpenedBank != null) LastOpenedBank = null;

            orig.Invoke(player);
        }
    }
}
