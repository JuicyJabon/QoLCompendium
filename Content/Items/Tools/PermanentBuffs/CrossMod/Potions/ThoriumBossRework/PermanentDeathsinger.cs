using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Potions.ThoriumBossRework;
using ThoriumRework;
using ThoriumRework.Buffs;
using ThoriumRework.Items;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Potions.ThoriumBossRework
{
    [JITWhenModsEnabled("ThoriumRework")]
    [ExtendsFromMod("ThoriumRework")]
    public class PermanentDeathsinger : IPermanentModdedBuffItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ModContent.GetInstance<CompatConfig>().extraPotions;

        public override string Texture => Common.ModBuffAsset(ModConditions.thoriumBossReworkMod, ModContent.BuffType<Deathsinger>());

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<DeathsingerPotion>(), 30);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new DeathsingerEffect());
        }
    }
}
