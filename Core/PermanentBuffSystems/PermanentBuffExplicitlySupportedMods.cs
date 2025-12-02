namespace QoLCompendium.Core.PermanentBuffSystems
{
    public static class PermanentBuffExplicitlySupportedMods
    {
        public static bool IsBuffItemFromSupportedMod(this Item item)
        {
            List<Mod> SupportedMods = [];

            //Calamity + Addons
            if (ModConditions.calamityLoaded)
                SupportedMods.Add(ModConditions.calamityMod);
            if (ModConditions.calamityEntropyLoaded)
                SupportedMods.Add(ModConditions.calamityEntropyMod);
            if (ModConditions.calamityRekindledLoaded)
                SupportedMods.Add(ModConditions.calamityRekindledMod);
            if (ModConditions.catalystLoaded)
                SupportedMods.Add(ModConditions.catalystMod);
            if (ModConditions.clamityAddonLoaded)
                SupportedMods.Add(ModConditions.clamityAddonMod);
            if (ModConditions.draedonExpansionLoaded)
                SupportedMods.Add(ModConditions.draedonExpansionMod);

            //Clicker
            if (ModConditions.clickerClassLoaded)
                SupportedMods.Add(ModConditions.clickerClassMod);

            //Consolaria
            if (ModConditions.consolariaLoaded)
                SupportedMods.Add(ModConditions.consolariaMod);

            //Homeward Journey
            if (ModConditions.homewardJourneyLoaded)
                SupportedMods.Add(ModConditions.homewardJourneyMod);

            //Martin's Order
            if (ModConditions.martainsOrderLoaded)
                SupportedMods.Add(ModConditions.martainsOrderMod);

            //Redemption
            if (ModConditions.redemptionLoaded)
                SupportedMods.Add(ModConditions.redemptionMod);

            //Shadows of Abaddon
            if (ModConditions.shadowsOfAbaddonLoaded)
                SupportedMods.Add(ModConditions.shadowsOfAbaddonMod);

            //Secrets of the Shadows
            if (ModConditions.secretsOfTheShadowsLoaded)
                SupportedMods.Add(ModConditions.secretsOfTheShadowsMod);

            //Spirit Classic
            if (ModConditions.spiritClassicLoaded)
                SupportedMods.Add(ModConditions.spiritClassicMod);

            //Thorium
            if (ModConditions.thoriumLoaded)
                SupportedMods.Add(ModConditions.thoriumMod);

            //Vitality
            if (ModConditions.vitalityLoaded)
                SupportedMods.Add(ModConditions.vitalityMod);

            if (SupportedMods.Contains(item.ModItem.Mod) && SupportedMods.Count > 0)
                return true;

            return false;
        }
    }
}
