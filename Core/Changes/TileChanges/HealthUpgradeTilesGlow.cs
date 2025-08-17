namespace QoLCompendium.Core.Changes.TileChanges
{
    public class HealthUpgradeTilesGlow : GlobalTile
    {
        public bool heartCrystalGlowOrig;
        public bool lifeFruitGlowOrig;

        public override void SetStaticDefaults()
        {
            heartCrystalGlowOrig = Main.tileLighted[TileID.Heart];
            lifeFruitGlowOrig = Main.tileLighted[TileID.LifeFruit];
            Main.tileLighted[TileID.Heart] = QoLCompendium.mainConfig.HeartCrystalGlow;
            Main.tileLighted[TileID.LifeFruit] = QoLCompendium.mainConfig.LifeFruitGlow;
        }

        public override void Unload()
        {
            Main.tileLighted[TileID.Heart] = heartCrystalGlowOrig;
            Main.tileLighted[TileID.LifeFruit] = lifeFruitGlowOrig;
        }

        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            float strongGlow = 1f + (270 - Main.mouseTextColor) / 400f;
            float weakGlow = 0.8f - (270 - Main.mouseTextColor) / 400f;
            const float mult = 0.3f;
            if (type == TileID.Heart && QoLCompendium.mainConfig.HeartCrystalGlow)
            {
                r = 0.9f * strongGlow * mult;
                g = 0.15f * weakGlow * mult;
                b = 0.3f * weakGlow * mult;
            }

            if (type == TileID.LifeFruit && QoLCompendium.mainConfig.LifeFruitGlow)
            {
                r = 0.1f * weakGlow;
                g = 0.9f * strongGlow;
                b = 0.3f * weakGlow;
            }
        }
    }
}
