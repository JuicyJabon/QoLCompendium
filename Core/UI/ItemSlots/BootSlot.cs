namespace QoLCompendium.Core.UI.ItemSlots
{
    public class BootSlot : ModAccessorySlot
    {
        public override string FunctionalTexture => "QoLCompendium/Assets/Slots/Boots";

        public override string VanityTexture => "QoLCompendium/Assets/Slots/Boots";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.shoeSlot > 0) return true;
            return false;
        }
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (item.shoeSlot > 0) return true;
            return false;
        }

        public override bool IsEnabled()
        {
            if (QoLCompendium.mainClientConfig.BootSlot) return true;
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
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.BootSlot.Boots");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.BootSlot.SocialBoots");
                    break;
                case AccessorySlotType.DyeSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.BootSlot.Dye");
                    break;
            }
        }
    }
}
