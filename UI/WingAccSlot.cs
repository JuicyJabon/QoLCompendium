using CustomSlot.UI;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace QoLCompendium.UI
{
    [Autoload(true)]
    public class WingAccessorySlots : DraggableAccessorySlots
    {
        public override AccessorySlotsUI UI => WingSlotSystem.UI;
        public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.CreativeWings;
        public override string VanityTexture => "Terraria/Images/Item_" + ItemID.AngelWings;

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<QoLCConfig>().WingSlot;
        }

        public override bool UseCustomLocation => false;

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.wingSlot > 0;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            return item.wingSlot > 0;
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
            }
        }
    }
}
