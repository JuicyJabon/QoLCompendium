namespace QoLCompendium.Tiles
{
    public class BurgerTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileBlockLight[Type] = false;
            Main.tileLighted[Type] = false;
            DustType = DustID.Grass;
            AddMapEntry(new Color(188, 145, 73));
        }
    }
}
