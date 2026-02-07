using InspirationPotions.Content.Items;
using InspirationPotions.Content.Players;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.InspirationPotions.Name)]
    [ExtendsFromMod(CrossModSupport.InspirationPotions.Name)]
    public class InspirationPotionsNotConsumable : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            if (QoLCompendium.crossModConfig.EndlessInspirationPotions)
            {
                HashSet<int> inspirationPotions = [Common.GetModItem(CrossModSupport.InspirationPotions.Mod, "LesserInspirationPotion"), Common.GetModItem(CrossModSupport.InspirationPotions.Mod, "InspirationPotion"), Common.GetModItem(CrossModSupport.InspirationPotions.Mod, "GreaterInspirationPotion"), Common.GetModItem(CrossModSupport.InspirationPotions.Mod, "SuperInspirationPotion")];
                if (inspirationPotions.Contains(item.type) && item.stack >= QoLCompendium.crossModConfig.EndlessInspirationPotionsAmount)
                    return false;
            }

            return base.ConsumeItem(item, player);
        }
    }

    [JITWhenModsEnabled(CrossModSupport.InspirationPotions.Name)]
    [ExtendsFromMod(CrossModSupport.InspirationPotions.Name)]
    public class QuickInspirationNotConsumable : GlobalItem
    {
        public delegate bool Orig_InspirationFlower(InspirationFlower self, Player player);

        private static readonly MethodInfo QuickInspirationMethod = typeof(InspirationFlower).GetMethod("QuickInspiration", Common.UniversalBindingFlags);

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.ModItem is InspirationFlower;
        }

        public override void Load()
        {
            Hook quickInspiration = new(QuickInspirationMethod, new Action<Player>(QuickInspiration_Detour));
            quickInspiration.Apply();
            Common.detours.Add(quickInspiration);
        }

        internal static void QuickInspiration_Detour(Player p)
        {
            if (p.GetModPlayer<InspirationModPlayer>().inspirationAutoCooldown != 0)
            {
                return;
            }
            bool useVoidBag = false;
            for (int i = 0; i < 58; i++)
            {
                Item item = p.inventory[i];
                if (!item.IsAir)
                {
                    if (item.ModItem is InspirationPotionBase potion)
                    {
                        if (QoLCompendium.crossModConfig.EndlessInspirationPotions && item.stack >= QoLCompendium.crossModConfig.EndlessInspirationPotionsAmount)
                            InspirationFlower.UsePotion(p, potion, decrement: false);
                        else
                            InspirationFlower.UsePotion(p, potion, decrement: true);
                        return;
                    }
                    if (!useVoidBag)
                    {
                        useVoidBag = item.type == ItemID.VoidLens;
                    }
                }
            }
            if (!useVoidBag)
            {
                return;
            }
            Item[] bag = p.bank4.item;
            foreach (Item item in bag)
            {
                if (!item.IsAir && item.ModItem is InspirationPotionBase potion)
                {
                    if (QoLCompendium.crossModConfig.EndlessInspirationPotions && item.stack >= QoLCompendium.crossModConfig.EndlessInspirationPotionsAmount)
                        InspirationFlower.UsePotion(p, potion, decrement: false);
                    else
                        InspirationFlower.UsePotion(p, potion, decrement: true);
                    break;
                }
            }
        }
    }
}
