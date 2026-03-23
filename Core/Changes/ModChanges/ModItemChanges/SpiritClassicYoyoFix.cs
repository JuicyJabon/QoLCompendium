using SpiritMod.Items.BossLoot.InfernonDrops;
using SpiritMod.Items.BossLoot.OccultistDrops;
using SpiritMod.Items.Weapon.Yoyo;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class SpiritClassicYoyoFix : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => QoLCompendium.crossModConfig.SpiritClassicYoyoClassificationFix;

        public override bool InstancePerEntity => true;

        public List<int> Yoyos =
        [
            ModContent.ItemType<Handball>(), //Grasp
            ModContent.ItemType<Moonburst>(),
            ModContent.ItemType<TheFireball>(),
            ModContent.ItemType<SweetThrow>(),
            ModContent.ItemType<EyeOfTheInferno>(),
            ModContent.ItemType<Tao>(),
            ModContent.ItemType<Probe>(),
            ModContent.ItemType<Ancient>(),
            ModContent.ItemType<Typhoon>(),
            ModContent.ItemType<Martian>() //Terrestrial Ultimatum
        ];

        public override bool AppliesToEntity(Item item, bool lateInstantiation) => Yoyos.Contains(item.type);

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[ModContent.ItemType<Handball>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Moonburst>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<TheFireball>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<SweetThrow>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<EyeOfTheInferno>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Tao>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Probe>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Ancient>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Typhoon>()] = true;
            ItemID.Sets.Yoyo[ModContent.ItemType<Martian>()] = true;
        }
    }
}
