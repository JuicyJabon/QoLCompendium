namespace QoLCompendium.Core.Changes.TileChanges
{
    public class UnbreakableQueenBeeLarva : ModSystem
    {
        private static bool oldBreak;

        public override void Load()
        {
            oldBreak = Main.tileCut[TileID.Larva];
            if (QoLCompendium.mainConfig.NoLarvaBreak)
                Main.tileCut[TileID.Larva] = false;
        }

        public override void Unload()
        {
            Main.tileCut[TileID.Larva] = oldBreak;
        }
    }
}
