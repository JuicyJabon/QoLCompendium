using System;
using Terraria;
using Terraria.ModLoader;
using tModPorter;

namespace QoLCompendium.Tweaks
{
    // Token: 0x02000008 RID: 8
    public class AccessoriesInSocial : GlobalItem
    {
        // Token: 0x06000046 RID: 70 RVA: 0x000024BB File Offset: 0x000006BB
        public override void SetDefaults(Item item)
        {
            if (item.accessory && ModContent.GetInstance<QoLCConfig>().VanityAccessories)
            {
                item.canBePlacedInVanityRegardlessOfConditions = true;
            }
        }
    }
}
