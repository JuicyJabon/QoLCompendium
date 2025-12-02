namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class WallOfFleshSummon : BaseSummon
    {
        public override int SortingPriority => 6;
        public override int NPCType => NPCID.None;
        public override int Rarity => ItemRarityID.Orange;

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.WallofFlesh);
        }

        public override bool? UseItem(Player player)
        {
            NPC.SpawnWOF(player.Center);
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.BossSummons, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ItemID.SpicyPepper);
            r.AddIngredient(ItemID.Bone, 5);
            r.AddTile(TileID.DemonAltar);
            r.Register();
        }
    }
}
