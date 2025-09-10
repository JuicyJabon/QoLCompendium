using QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Flasks;
using QoLCompendium.Core;
using QoLCompendium.Core.PermanentBuffSystems;
using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded;

namespace QoLCompendium.Content.Items.Tools.PermanentBuffs.Vanilla.Upgraded
{
    public class PermanentFlasks : IPermanentBuffItem
    {
        public override string Texture => "QoLCompendium/Assets/Items/PermanentFlasks";

        public override void SetDefaults()
        {
            Common.SetDefaultsToPermanentBuff(Item);
        }

        public override void UpdateInventory(Player player)
        {
            if (player.TryGetModPlayer(out PermanentBuffPlayer pBuffPlayer))
                ApplyBuff(pBuffPlayer);

            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 0)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfCursedFlames"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 1)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfFire"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 2)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfGold"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 3)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfIchor"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 4)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfNanites"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 5)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfParty"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 6)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfPoison"));
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode == 7)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.PermanentFlasks.FlaskOfVenom"));
        }

        public override void OnConsumeItem(Player player) => Item.stack++;

        public override bool CanRightClick() => true;

        public override void RightClick(Player player)
        {
            player.GetModPlayer<QoLCPlayer>().flaskEffectMode++;
            if (player.GetModPlayer<QoLCPlayer>().flaskEffectMode > 7)
                player.GetModPlayer<QoLCPlayer>().flaskEffectMode = 0;
        }

        public override void AddRecipes()
        {
            Recipe r = Common.GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfCursedFlames>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfFire>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfGold>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfIchor>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfNanites>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfParty>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfPoison>());
            r.AddIngredient(ModContent.ItemType<PermanentFlaskOfVenom>());
            r.AddTile(TileID.CookingPots);
            r.Register();
        }

        internal override void ApplyBuff(PermanentBuffPlayer player)
        {
            player.buffActive = true;
            player.potionEffects.Add(new FlaskEffect());
        }
    }
}
