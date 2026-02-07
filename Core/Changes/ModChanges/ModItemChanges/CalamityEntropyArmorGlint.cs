using CalamityEntropy;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.CalamityEntropy.Name)]
    [ExtendsFromMod(CrossModSupport.CalamityEntropy.Name)]
    public class CalamityEntropyArmorGlint : GlobalItem
    {
        public static bool ArmorHasEntropyPrefix(Item item)
        {
            if (item.Entropy().armorPrefix != null && item.Entropy().armorPrefixName != string.Empty)
                return true;
            return false;
        } 
    }
}
