using CalamityMod.Items.Accessories;
using CalamityMod.Items.Accessories.Wings;
using FargowiltasSouls.Content.Items.Accessories.Masomode;

namespace QoLCompendium.Core.UI.ItemSlots
{
    public class BootSlot : ModAccessorySlot
    {
        public override string FunctionalTexture => "QoLCompendium/Assets/Slots/Boots";

        public override string VanityTexture => "QoLCompendium/Assets/Slots/Boots";

        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (CrossModSupport.Calamity.Loaded && checkItem.IsCalamityBoot())
                return true;
            if (CrossModSupport.FargowiltasSouls.Loaded && checkItem.IsFargosBoot()) 
                return true;
            return checkItem.shoeSlot > 0;
        }
        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (CrossModSupport.Calamity.Loaded && item.IsCalamityBoot())
                return true;
            if (CrossModSupport.FargowiltasSouls.Loaded && item.IsFargosBoot())
                return true;
            return item.shoeSlot > 0;
        }

        public override bool IsEnabled()
        {
            return QoLCompendium.mainConfig.BootSlot;
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

    [JITWhenModsEnabled(CrossModSupport.Calamity.Name)]
    [ExtendsFromMod(CrossModSupport.Calamity.Name)]
    public static class CalamityBootSlot
    {
        public static bool IsCalamityBoot(this Item item)
        {
            if (item.type == ModContent.ItemType<SeraphTracers>())
                return item.wingSlot == -1;
            if (item.type == ModContent.ItemType<InterstellarStompers>())
                return true;
            return false;
        }
    }

    [JITWhenModsEnabled(CrossModSupport.FargowiltasSouls.Name)]
    [ExtendsFromMod(CrossModSupport.FargowiltasSouls.Name)]
    public static class FargoSoulsBootSlot
    {
        public static bool IsFargosBoot(this Item item)
        {
            return item.type == ModContent.ItemType<ZephyrBoots>();
        }
    }
}
