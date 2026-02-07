using SpiritMod.Items.Consumable;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.SpiritClassic.Name)]
    [ExtendsFromMod(CrossModSupport.SpiritClassic.Name)]
    public class SpiritClassicBossSummonFix : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => QoLCompendium.crossModConfig.SpiritClassicBossSummonClassificationFix;

        public override bool InstancePerEntity => true;

        public List<int> BossSummons =
        [
            ModContent.ItemType<GladeWreath>(), //Glade Wraith
            ModContent.ItemType<ScarabIdol>(), //Scarabeus
            ModContent.ItemType<DistressJellyItem>(), //Jelly Deluge
            ModContent.ItemType<DreamlightJellyItem>(), //Moon Jelly Wizard
            ModContent.ItemType<ReachBossSummon>(), //Vinewrath Bane
            ModContent.ItemType<JewelCrown>(), //Ancient Avian
            ModContent.ItemType<StarWormSummon>(), //Starplate Voyager
            ModContent.ItemType<BlackPearl>(), //Tide
            ModContent.ItemType<BlueMoonSpawn>(), //Mystic Moon
            ModContent.ItemType<CursedCloth>(), //Infernon
            ModContent.ItemType<DuskCrown>(), //Dusking
            ModContent.ItemType<StoneSkin>(), //Atlas
            ModContent.ItemType<MartianTransmitter>() //Martian Invasion
        ];

        public override bool AppliesToEntity(Item item, bool lateInstantiation) => BossSummons.Contains(item.type);

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<GladeWreath>()] = 0;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<ScarabIdol>()] = 1;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<DistressJellyItem>()] = 2;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<DreamlightJellyItem>()] = 2;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<ReachBossSummon>()] = 3;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<JewelCrown>()] = 4;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<StarWormSummon>()] = 5;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<BlackPearl>()] = 5;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<BlueMoonSpawn>()] = 5;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<CursedCloth>()] = 8;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<DuskCrown>()] = 9;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<StoneSkin>()] = 17;
            ItemID.Sets.SortingPriorityBossSpawns[ModContent.ItemType<MartianTransmitter>()] = 16;
        }
    }
}
