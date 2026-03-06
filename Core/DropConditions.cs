using Terraria.GameContent.ItemDropRules;

namespace QoLCompendium.Core
{
    public class ExpertOnlyDropCondition : IItemDropRuleCondition, IProvideItemConditionDescription
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            HashSet<Mod> tempCalamityAndAddons =
            [
                CrossModSupport.Calamity.Mod,
                CrossModSupport.CalamityEntropy.Mod,
                CrossModSupport.CalamityOverhaul.Mod,
                CrossModSupport.CalamityRekindled.Mod,
                CrossModSupport.CalamityVanities.Mod,
                CrossModSupport.Catalyst.Mod,
                CrossModSupport.Clamity.Mod,
                CrossModSupport.HuntOfTheOldGod.Mod,
                CrossModSupport.Infernum.Mod,
                CrossModSupport.WrathOfTheGods.Mod
            ];
            HashSet<Mod> calamityAndAddons = [];

            for (int i = 0; i < tempCalamityAndAddons.Count; i++)
            {
                if (tempCalamityAndAddons.ElementAt(i) != null)
                    calamityAndAddons.Add(tempCalamityAndAddons.ElementAt(i));
            }

            if (QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode)
            {
                if (CalamityDifficultyEnabled())
                {
                    if (info.npc.type <= NPCID.Count)
                        return false;
                    if (info.npc.type > NPCID.Count && !calamityAndAddons.Contains(info.npc.ModNPC.Mod))
                        return true;
                }

                if (!CalamityDifficultyEnabled() && !FargoSoulsDifficultyEnabled())
                    return Main.expertMode;
                else
                    return false;
            }
            return false;
        }

        public bool CanShowItemDropInUI()
        {
            if (QoLCompendium.mainConfig.RelicsInExpert && !Main.masterMode)
            {
                if (!CalamityDifficultyEnabled() && !FargoSoulsDifficultyEnabled())
                    return Main.expertMode;
                else
                    return false;
            }
            return false;
        }

        public string GetConditionDescription()
        {
            return Language.GetTextValue("Mods.QoLCompendium.NPCDropConditions.ExpertNotMaster");
        }

        public static bool CalamityDifficultyEnabled()
        {
            if (Main.expertMode && (RevengeanceMode() || InfernumMode()))
                return true;
            return false;
        }

        public static bool RevengeanceMode()
        {
            if (CrossModSupport.Calamity.Loaded)
                return (bool)CrossModSupport.Calamity.Mod.Call("DifficultyActive", "revengeance");
            return false;
        }

        public static bool InfernumMode()
        {
            if (CrossModSupport.Infernum.Loaded)
                return (bool)CrossModSupport.Infernum.Mod.Call("GetInfernumActive");
            return false;
        }

        public static bool FargoSoulsDifficultyEnabled()
        {
            if (CrossModSupport.FargowiltasSouls.Loaded)
            {
                bool emode = (bool)CrossModSupport.FargowiltasSouls.Mod.Call("EternityMode");
                return emode;
            }
            return false;
        }
    }
}
