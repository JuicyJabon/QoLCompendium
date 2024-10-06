namespace QoLCompendium.Core.UI.ItemSlots
{
    public class ExpertSlot : ModAccessorySlot
    {
        public override string FunctionalTexture => "QoLCompendium/Assets/Slots/Expert";

        public override string VanityTexture => "QoLCompendium/Assets/Slots/Expert";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.expert && checkItem.accessory) return true;
            return false;
        }
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (item.expert && item.accessory) return true;
            return false;
        }

        public override bool IsEnabled()
        {
            if (QoLCompendium.mainClientConfig.ExpertSlot && Main.expertMode) return true;
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
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ExpertSlot.Expert");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ExpertSlot.SocialExpert");
                    break;
                case AccessorySlotType.DyeSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.QoLCompendium.ExpertSlot.Dye");
                    break;
            }
        }
    }
}
