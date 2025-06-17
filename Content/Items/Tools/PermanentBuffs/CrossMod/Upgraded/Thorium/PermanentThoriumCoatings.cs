using QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Flasks.Thorium;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.CrossMod.Upgraded.Thorium;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.CrossMod.Upgraded.Thorium
{
    [JITWhenModsEnabled("ThoriumMod")]
    [ExtendsFromMod("ThoriumMod")]
    public class PermanentThoriumCoatings : IPermanentModdedBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentThoriumCoatings";

        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
        }

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);

            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 0)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentThoriumCoatings.DeepFreezeCoating"));
            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 1)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentThoriumCoatings.ExplosiveCoating"));
            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 2)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentThoriumCoatings.GorgonCoating"));
            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 3)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentThoriumCoatings.SporeCoating"));
            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode == 4)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentThoriumCoatings.ToxicCoating"));
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode++;
            if (player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode > 4)
                player.GetModPlayer<QoLCPlayer>().thoriumCoatingMode = 0;
        }

        public override void AddRecipes()
        {
            Recipe r = ModConditions.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentDeepFreezeCoating>());
            r.AddIngredient(ModContent.ItemType<PermanentExplosiveCoating>());
            r.AddIngredient(ModContent.ItemType<PermanentGorgonCoating>());
            r.AddIngredient(ModContent.ItemType<PermanentSporeCoating>());
            r.AddIngredient(ModContent.ItemType<PermanentToxicCoating>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.modPotionEffects.Add(new ThoriumCoatingEffect());
        }
    }
}
