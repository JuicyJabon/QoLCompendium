namespace QoLCompendium.Core.UI.ItemSlots
{
    public class WingSlot : ModAccessorySlot
    {
        public override string FunctionalTexture => "QoLCompendium/Assets/Slots/Wings";

        public override string VanityTexture => "QoLCompendium/Assets/Slots/Wings";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.wingSlot > 0) return true;
            return false;
        }
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (item.wingSlot > 0) return true;
            return false;
        }

        public override bool IsEnabled()
        {
            if (QoLCompendium.mainConfig.WingSlot) return true;
            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.WingSlot.Wings");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.WingSlot.SocialWings");
                    break;
                case AccessorySlotType.DyeSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.WingSlot.Dye");
                    break;
            }
        }
    }
}
