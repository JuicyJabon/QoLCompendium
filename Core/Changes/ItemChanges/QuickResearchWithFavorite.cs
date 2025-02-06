using Terraria.GameContent.Creative;

namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class QuickResearchWithFavorite : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (item.favorited && item.stack >= CreativeUI.GetSacrificeCount(item.type, out bool researched) && CreativeItemSacrificesCatalog.Instance.TryGetSacrificeCountCapToUnlockInfiniteItems(item.type, out int numResearch) && !researched && player.difficulty == PlayerDifficultyID.Creative && item.stack >= numResearch && QoLCompendium.mainClientConfig.FavoriteResearching)
            {
                if (item.type == ItemID.ShellphoneDummy || item.type == ItemID.ShellphoneHell || item.type == ItemID.ShellphoneOcean || item.type == ItemID.ShellphoneSpawn || item.type == ItemID.Shellphone)
                {
                    return;
                }
                CreativeUI.ResearchItem(item.type);
                SoundEngine.PlaySound(SoundID.ResearchComplete, default, null);
                item.stack -= numResearch;
                if (item.stack <= 0)
                {
                    item.TurnToAir();
                }
            }
        }
    }
}
