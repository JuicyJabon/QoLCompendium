using CustomSlot;
using CustomSlot.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;

namespace QoLCompendium.UI
{
    public class WingSlotPlayer : ModAccessorySlotPlayer
    {
        private PlayerData<float> panelX = new("panelX", 0f);
        private PlayerData<float> panelY = new("panelY", 0f);

        public override void OnEnterWorld()
        {
            WingSlotSystem.UI.Panel.Left.Set(panelX.Value, 0);
            WingSlotSystem.UI.Panel.Top.Set(panelY.Value, 0);
        }
    }

    public class WingSlotSystem : ModSystem
    {
        public static AccessorySlotsUI UI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                UI = new AccessorySlotsUI();
                UI.Activate();
            }
        }

        public override void Unload()
        {
            UI = null;
        }
    }

    internal class GlobalWingsItem : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.wingSlot > 0;

        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            return modded;
        }
    }
}
