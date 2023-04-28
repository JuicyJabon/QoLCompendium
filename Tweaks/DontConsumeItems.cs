using System.Linq;
using Terraria;
using Terraria.ModLoader;
using tModPorter;
using Terraria.ID;

namespace QoLCompendium.Tweaks
{
    // Token: 0x0200000D RID: 13
    public class DontConsumeItems : GlobalItem
    {
        // Token: 0x06000059 RID: 89 RVA: 0x000050EC File Offset: 0x000032EC
        public override bool ConsumeItem(Item item, Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod mod);
            ModLoader.TryGetMod("SOTS", out Mod mod2);
            ModLoader.TryGetMod("VitalityMod", out Mod mod3);
            ModLoader.TryGetMod("Consolaria", out Mod mod4);
            ModLoader.TryGetMod("Spooky", out Mod mod5);
            ModLoader.TryGetMod("FargowiltasSouls", out Mod mod6);
            ModLoader.TryGetMod("ContinentOfJourney", out Mod mod7);
            return (mod == null || !Enumerable.Contains<int>(new int[]
            {
                mod.Find<ModItem>("JellyfishResonator").Type,
                mod.Find<ModItem>("UnstableCore").Type,
                mod.Find<ModItem>("AncientBlade").Type,
                mod.Find<ModItem>("StarCaller").Type,
                mod.Find<ModItem>("StriderTear").Type,
                mod.Find<ModItem>("VoidLens").Type,
                mod.Find<ModItem>("DoomSayersCoin").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod2 == null || !Enumerable.Contains<int>(new int[]
            {
                mod2.Find<ModItem>("ElectromagneticLure").Type,
                mod2.Find<ModItem>("JarOfPeanuts").Type,
                mod2.Find<ModItem>("CatalystBomb").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod3 == null || !Enumerable.Contains<int>(new int[]
            {
                mod3.Find<ModItem>("CloudCore").Type,
                mod3.Find<ModItem>("AncientCrown").Type,
                mod3.Find<ModItem>("MultigemCluster").Type,
                mod3.Find<ModItem>("MoonlightLotusFlower").Type,
                mod3.Find<ModItem>("Dreadcandle").Type,
                mod3.Find<ModItem>("AnarchyCrystal").Type,
                mod3.Find<ModItem>("TotemofChaos").Type,
                mod3.Find<ModItem>("SpiritBox").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod4 == null || !Enumerable.Contains<int>(new int[]
            {
                mod4.Find<ModItem>("SuspiciousLookingEgg").Type,
                mod4.Find<ModItem>("CursedStuffing").Type,
                mod4.Find<ModItem>("SuspiciousLookingSkull").Type,
                mod4.Find<ModItem>("Wishbone").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod5 == null || !Enumerable.Contains<int>(new int[]
            {
                mod5.Find<ModItem>("RottenSeed").Type,
                mod5.Find<ModItem>("Fertalizer").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod6 == null || !Enumerable.Contains<int>(new int[]
            {
                mod6.Find<ModItem>("AbomsCurse").Type,
                mod6.Find<ModItem>("DevisCurse").Type,
                mod6.Find<ModItem>("FragilePixieLamp").Type,
                mod6.Find<ModItem>("MutantsCurse").Type,
                mod6.Find<ModItem>("SquirrelCoatofArms").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (mod7 == null || !Enumerable.Contains<int>(new int[]
            {
                mod7.Find<ModItem>("CannedSoulofFlight").Type,
                mod7.Find<ModItem>("SouthernPotting").Type,
                mod7.Find<ModItem>("SunlightCrown").Type,
                mod7.Find<ModItem>("MetalSpine").Type,
                mod7.Find<ModItem>("UnstableGlobe").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && ((!Enumerable.Contains<int>(BossSummons, item.type) && !Enumerable.Contains<int>(EventSummons, item.type)) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && ((item.healLife <= 0 && item.healMana <= 0) || item.stack < 30 || !ModContent.GetInstance<QoLCConfig>().EndlessBuffsAndHealing) && ((item.buffType <= 0 && item.type != ItemID.RecallPotion && item.type != ItemID.PotionOfReturn && item.type != ItemID.WormholePotion) || item.stack < 30 || !ModContent.GetInstance<QoLCConfig>().EndlessBuffsAndHealing) && (!item.consumable || item.stack < 999 || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && base.ConsumeItem(item, player);
        }
        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod mod);
            if ((mod != null && ammo.type == mod.Find<ModItem>("StormFlare").Type) || ammo.ammo > 0 && ammo.stack >= 999 && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }
            return true;
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= 999 && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }
            return true;
        }

        // Token: 0x040000A2 RID: 162
        public static readonly int[] BossSummons = new int[]
        {
            560,
            43,
            70,
            1331,
            1133,
            5120,
            4988,
            556,
            544,
            557,
            3601
        };

        // Token: 0x040000A3 RID: 163
        public static readonly int[] EventSummons = new int[]
        {
            4271,
            361,
            1315,
            2767,
            602,
            1844,
            1958
        };
    }
}
