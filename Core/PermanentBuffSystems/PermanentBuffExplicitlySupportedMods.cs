namespace QoLCompendium.Core.PermanentBuffSystems
{
    public static class PermanentBuffExplicitlySupportedMods
    {
        public static bool IsBuffItemFromSupportedMod(this Item item)
        {
            List<Mod> SupportedMods = [];

            //Calamity + Addons
            if (CrossModSupport.Calamity.Loaded)
                SupportedMods.Add(CrossModSupport.Calamity.Mod);
            if (CrossModSupport.CalamityEntropy.Loaded)
                SupportedMods.Add(CrossModSupport.CalamityEntropy.Mod);
            if (CrossModSupport.CalamityRekindled.Loaded)
                SupportedMods.Add(CrossModSupport.CalamityRekindled.Mod);
            if (CrossModSupport.Catalyst.Loaded)
                SupportedMods.Add(CrossModSupport.Catalyst.Mod);
            if (CrossModSupport.Clamity.Loaded)
                SupportedMods.Add(CrossModSupport.Clamity.Mod);
            if (CrossModSupport.DraedonExpansion.Loaded)
                SupportedMods.Add(CrossModSupport.DraedonExpansion.Mod);

            //Clicker
            if (CrossModSupport.ClickerClass.Loaded)
                SupportedMods.Add(CrossModSupport.ClickerClass.Mod);

            //Consolaria
            if (CrossModSupport.Consolaria.Loaded)
                SupportedMods.Add(CrossModSupport.Consolaria.Mod);

            //Homeward Journey
            if (CrossModSupport.HomewardJourney.Loaded)
                SupportedMods.Add(CrossModSupport.HomewardJourney.Mod);

            //Martin's Order
            if (CrossModSupport.MartinsOrder.Loaded)
                SupportedMods.Add(CrossModSupport.MartinsOrder.Mod);

            //Redemption
            if (CrossModSupport.Redemption.Loaded)
                SupportedMods.Add(CrossModSupport.Redemption.Mod);

            //Shadows of Abaddon
            if (CrossModSupport.ShadowsOfAbaddon.Loaded)
                SupportedMods.Add(CrossModSupport.ShadowsOfAbaddon.Mod);

            //Secrets of the Shadows
            if (CrossModSupport.SecretsOfTheShadows.Loaded)
                SupportedMods.Add(CrossModSupport.SecretsOfTheShadows.Mod);

            //Spirit Classic
            if (CrossModSupport.SpiritClassic.Loaded)
                SupportedMods.Add(CrossModSupport.SpiritClassic.Mod);

            //Thorium
            if (CrossModSupport.Thorium.Loaded)
                SupportedMods.Add(CrossModSupport.Thorium.Mod);

            //Vitality
            if (CrossModSupport.Vitality.Loaded)
                SupportedMods.Add(CrossModSupport.Vitality.Mod);

            if (SupportedMods.Contains(item.ModItem.Mod) && SupportedMods.Count > 0)
                return true;

            return false;
        }
    }
}
