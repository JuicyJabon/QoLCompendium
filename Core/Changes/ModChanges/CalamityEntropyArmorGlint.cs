using CalamityEntropy;

namespace QoLCompendium.Core.Changes.ModChanges
{
    [JITWhenModsEnabled(ModConditions.calamityEntropyName)]
    [ExtendsFromMod(ModConditions.calamityEntropyName)]
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
