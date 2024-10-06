namespace QoLCompendium.Core.UI.ItemSlots
{
    public class ShieldSlot : ModAccessorySlot
    {
        public override string FunctionalTexture => "QoLCompendium/Assets/Slots/Shield";

        public override string VanityTexture => "QoLCompendium/Assets/Slots/Shield";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.shieldSlot > 0) return true;
            return false;
        }
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (item.shieldSlot > 0) return true;
            return false;
        }

        public override bool IsEnabled()
        {
            if (QoLCompendium.mainClientConfig.ShieldSlot) return true;
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
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ShieldSlot.Shield");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ShieldSlot.SocialShield");
                    break;
                case AccessorySlotType.DyeSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ShieldSlot.Dye");
                    break;
            }
        }
    }
}
