using FargowiltasSouls.Content.Items.Weapons.BossDrops;
using FargowiltasSouls.Content.Items.Weapons.SwarmDrops;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.FargowiltasSouls.Name)]
    [ExtendsFromMod(CrossModSupport.FargowiltasSouls.Name)]
    public class FargosSoulsYoyoFix : GlobalItem
    {
        //public override bool IsLoadingEnabled(Mod mod) => QoLCompendium.crossModConfig.SpiritClassicYoyoClassificationFix;

        public override bool InstancePerEntity => true;

        public List<int> Yoyos =
        [
            ModContent.ItemType<Dicer>(),
            ModContent.ItemType<Blender>()
        ];

        public override bool AppliesToEntity(Item item, bool lateInstantiation) => Yoyos.Contains(item.type);

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[ModContent.ItemType<Dicer>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Blender>()] = true;
        }
    }
}
