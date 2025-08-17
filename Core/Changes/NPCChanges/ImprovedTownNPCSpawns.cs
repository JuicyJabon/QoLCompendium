using Terraria.GameContent.Bestiary;

namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class ImprovedTownNPCSpawns : ModSystem
    {
        private static bool _isExtraUpdate;
        private static HashSet<int> _activeTownNPCs = [];
        private static BestiaryUnlockProgressReport _cachedReport = new();

        public override void Load()
        {
            On_Main.UpdateTime_SpawnTownNPCs += orig =>
            {
                _isExtraUpdate = false;
                orig.Invoke();

                int times = QoLCompendium.mainConfig.FastTownNPCSpawns - 1;
                double worldUpdateRate = WorldGen.GetWorldUpdateRate();
                _cachedReport = Main.GetBestiaryProgressReport();
                _isExtraUpdate = true;
                for (int i = 0; i < times; i++)
                {
                    TrySetNPCSpawn(orig, worldUpdateRate);
                }
                _isExtraUpdate = false;
            };
            On_WorldGen.QuickFindHome += (orig, npc) =>
            {
                if (!_isExtraUpdate)
                    orig.Invoke(npc);
            };

            On_Main.GetBestiaryProgressReport += orig =>
            {
                if (!_isExtraUpdate)
                    return orig.Invoke();
                return _cachedReport;
            };
        }

        public override void PreUpdateWorld()
        {
            if (QoLCompendium.mainConfig.TownNPCSpawnImprovements)
            {
                NPC.savedAngler = true;
                NPC.savedGolfer = true;
                NPC.savedStylist = true;
                if (NPC.downedGoblins)
                    NPC.savedGoblin = true;
                if (NPC.downedBoss2)
                    NPC.savedBartender = true;
                if (NPC.downedBoss3)
                    NPC.savedMech = true;
                if (Main.hardMode)
                {
                    NPC.savedWizard = true;
                    NPC.savedTaxCollector = true;
                }
            }

            if (HasEnoughMoneyForMerchant() && QoLCompendium.mainConfig.AutoMoneyQuickStack)
                TrySetNPCSpawn(NPCID.Merchant);
        }

        private static void TrySetNPCSpawn(On_Main.orig_UpdateTime_SpawnTownNPCs orig, double worldUpdateRate)
        {
            orig.Invoke();

            if (Main.netMode is NetmodeID.MultiplayerClient || worldUpdateRate <= 0 || Main.checkForSpawns != 0)
                return;

            SetupActiveTownNPCList();

            if (HasEnoughMoneyForMerchant())
                TrySetNPCSpawn(NPCID.Merchant);
        }

        public static bool HasEnoughMoneyForMerchant()
        {
            int moneyCount = 0;
            for (int l = 0; l < Main.maxPlayers; l++)
            {
                var player = Main.player[l];
                if (!player.active)
                    continue;

                for (int m = 0; m < 40; m++)
                {
                    if (player.bank.item[m] is null || player.bank.item[m].stack <= 0)
                        continue;

                    var item = player.bank.item[m];
                    switch (item.type)
                    {
                        case ItemID.CopperCoin:
                            moneyCount += item.stack;
                            break;
                        case ItemID.SilverCoin:
                            moneyCount += item.stack * 100;
                            break;
                        case ItemID.GoldCoin:
                            return true;
                        case ItemID.PlatinumCoin:
                            return true;
                    }

                    if (moneyCount >= 5000) return true;
                }
            }
            return false;
        }

        public static void TrySetNPCSpawn(int npcId)
        {
            if (_activeTownNPCs.Contains(npcId))
                return;

            Main.townNPCCanSpawn[npcId] = true;
            if (WorldGen.prioritizedTownNPCType == 0)
                WorldGen.prioritizedTownNPCType = npcId;
        }

        private static void SetupActiveTownNPCList()
        {
            _activeTownNPCs = [];
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                var npc = Main.npc[i];
                if (npc.active && npc.townNPC && npc.friendly)
                {
                    _activeTownNPCs.Add(npc.type);
                }
            }
        }
    }

}
