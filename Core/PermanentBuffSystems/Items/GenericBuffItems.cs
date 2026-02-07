namespace QoLCompendium.Core.PermanentBuffSystems.Items
{
    public static class GenericBuffItems
    {
        public static void LoadTasks()
        {
            for (int i = ItemID.Count; i < ItemLoader.ItemCount; i++)
            {
                //!ItemLoader.GetItem(i).Item.IsBuffItemFromSupportedMod() && 
                if (ItemLoader.GetItem(i).Item.buffType > BuffID.Count && ItemLoader.GetItem(i).Item.buffTime > 0 && ItemLoader.GetItem(i).Item.damage == -1)
                {
                    int buffType = ItemLoader.GetItem(i).Item.buffType;
                    if (BuffID.Sets.BasicMountData[buffType] == null && !Main.vanityPet[buffType] && !Main.lightPet[buffType] && !Main.debuff[buffType])
                    {
                        //EFFECT
                        NewBuffEffect newEffect = new(buffType);
                        BuffEffect effect = new(newEffect.buffID, newEffect.effectType);
                        QoLCompendium.Instance.AddContent(effect);
                        Common.AllEffects.Add(newEffect.buffID, effect);

                        //ITEM
                        NewBuffItem newBuffItem = new(ItemLoader.GetItem(i).Item.type, newEffect.buffID, effect, 30, "Permanent" + BuffLoader.GetBuff(newEffect.buffID).Name, Language.GetText("Mods.QoLCompendium.Items.PermanentBuffs.DefaultPermanent") + BuffLoader.GetBuff(newEffect.buffID).DisplayName.Value);
                        BuffItem item = new(newBuffItem.itemName, newBuffItem.buffID, newBuffItem.effect, newBuffItem.buffItem, newBuffItem.ingredientCount, newBuffItem.displayName, newBuffItem.textureName);
                        QoLCompendium.Instance.AddContent(item);
                    }
                }
            }
        }
    }
}
