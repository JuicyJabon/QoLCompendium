using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.IO;

namespace QoLCompendium.Core.Changes.ModChanges.ModNPCChanges
{
    public class MagicStorageShadowDiamondDrops : GlobalNPC
    {
        public override bool IsLoadingEnabled(Mod mod) => CrossModSupport.MagicStorage.Loaded && QoLCompendium.crossModConfig.MagicStorageShadowDiamondDrops;
        
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.boss && npc.type > NPCID.Count)
                npcLoot.Add(DropDiamond(1));
        }

        public static IItemDropRule Drop(int count) => ItemDropRule.Common(Common.GetModItem(CrossModSupport.MagicStorage.Mod, "ShadowDiamond"), minimumDropped: count, maximumDropped: count);

        public static IItemDropRule DropDiamond(int stack, int expertStack = -1)
        {
            IItemDropRule rule = new LeadingConditionRule(new ShadowDiamondCondition());
            rule.OnSuccess(expertStack < 0 ? Drop(stack) : new DropBasedOnExpertMode(Drop(stack), Drop(expertStack)));
            return rule;
        }
    }

    public class ShadowDiamondCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (info.npc.boss && info.npc.type > NPCID.Count && info.npc.ModNPC != null && !info.IsInSimulation)
            {
                if (MagicStorageShadowDiamondSystem.droppedShadowDiamonds.ContainsKey(info.npc.ModNPC.Name) &&
                    MagicStorageShadowDiamondSystem.droppedShadowDiamonds.TryGetValue(info.npc.ModNPC.Name, out bool result) && !result)
                {
                    MagicStorageShadowDiamondSystem.droppedShadowDiamonds[info.npc.ModNPC.Name] = true;
                    return true;
                }
            }
            return false;
        }

        public bool CanShowItemDropInUI() => true;

        public string GetConditionDescription() => Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ShadowDiamond");
    }

    public class MagicStorageShadowDiamondSystem : ModSystem
    {
        public static Dictionary<string, bool> droppedShadowDiamonds = [];

        public override bool IsLoadingEnabled(Mod mod) => CrossModSupport.MagicStorage.Loaded && QoLCompendium.crossModConfig.MagicStorageShadowDiamondDrops;

        public override void PostSetupContent()
        {
            for (int i = NPCID.Count; i < NPCLoader.NPCCount; i++)
            {
                if (NPCLoader.GetNPC(i).NPC.boss)
                    droppedShadowDiamonds.TryAdd(NPCLoader.GetNPC(i).Name, false);
            }
        }

        public override void OnWorldUnload()
        {
            droppedShadowDiamonds.Clear();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["QoLCMagicStorageShadowDiamondDropTrackerBosses"] = droppedShadowDiamonds.Keys.ToList();
            tag["QoLCMagicStorageShadowDiamondDropTrackerHasDropped"] = droppedShadowDiamonds.Values.ToList();
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if (tag.ContainsKey("QoLCMagicStorageShadowDiamondDropTrackerBosses") && tag.ContainsKey("QoLCMagicStorageShadowDiamondDropTrackerHasDropped"))
            {
                var bosses = tag.Get<List<string>>("QoLCMagicStorageShadowDiamondDropTrackerBosses");
                var values = tag.Get<List<bool>>("QoLCMagicStorageShadowDiamondDropTrackerHasDropped");
                droppedShadowDiamonds = bosses.Zip(values, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }
}