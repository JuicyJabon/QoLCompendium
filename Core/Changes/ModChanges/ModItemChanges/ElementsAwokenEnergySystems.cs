using ElementsAwoken.Content.Items.Tech.Generators;
using ElementsAwoken.EASystem;
using QoLCompendium.Content.Items.Weapons.Ammo.Other;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(CrossModSupport.ElementsAwoken.Name)]
    [ExtendsFromMod(CrossModSupport.ElementsAwoken.Name)]
    public class ElementsAwokenBatteriesInBanks : ModPlayer
    {
        public override void UpdateEquips()
        {
            if (QoLCompendium.crossModConfig.ElementsAwokenBatteriesInBanks)
                CheckForBankItems(ItemUtils.GetAllInventoryItemsList(Player, "inv").ToArray());
        }

        public void CheckForBankItems(Item[] items)
        {
            foreach (Item item in items)
            {
                if (Constants.ElementsAwokenBatteryItems.Contains(item.type) && !item.IsAir)
                {
                    Player.GetModPlayer<QoLCPlayer>().activeItems.Add(item.type);
                    ItemLoader.GetItem(item.type).UpdateInventory(Player);
                }
            }
        }
    }
    
    [JITWhenModsEnabled(CrossModSupport.ElementsAwoken.Name)]
    [ExtendsFromMod(CrossModSupport.ElementsAwoken.Name)]
    public class ElementsAwokenGeneratorChanges : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type == ModContent.ItemType<GelticBurner>();
        }

        public override void UpdateInventory(Item item, Player player)
        {
            PlayerEnergy modPlayer = player.GetModPlayer<PlayerEnergy>();
            if (item.ModItem is GelticBurner gelticBurner)
            {
                if (!gelticBurner.enabled || modPlayer.energy >= modPlayer.maxEnergy)
                    return;

                for (int i = 0; i < player.inventory.Length; i++)
                {
                    Item other = Main.LocalPlayer.inventory[i];
                    if (other.type == ModContent.ItemType<EndlessGelTank>() && gelticBurner.fuel <= 0)
                    {
                        gelticBurner.fuel = 900;
                    }
                }
                if (gelticBurner.fuel > 0)
                {
                    gelticBurner.fuel--;
                }
                gelticBurner.producePowerCooldown--;
                if (gelticBurner.fuel > 0 && gelticBurner.producePowerCooldown <= 0)
                {
                    gelticBurner.producePowerCooldown = 30;
                    modPlayer.energy++;
                }
            }
        }
    }
}
