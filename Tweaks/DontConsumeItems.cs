using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace QoLCompendium.Tweaks
{
    public class DontConsumeItems : GlobalItem
    {
        public override bool ConsumeItem(Item item, Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod thor);
            ModLoader.TryGetMod("SOTS", out Mod sots);
            ModLoader.TryGetMod("VitalityMod", out Mod vitality);
            ModLoader.TryGetMod("Consolaria", out Mod consolaria);
            ModLoader.TryGetMod("Spooky", out Mod spooky);
            ModLoader.TryGetMod("FargowiltasSouls", out Mod souls);
            ModLoader.TryGetMod("ContinentOfJourney", out Mod hj);
            return (thor == null || !Enumerable.Contains(new int[]
            {
                thor.Find<ModItem>("JellyfishResonator").Type,
                thor.Find<ModItem>("UnstableCore").Type,
                thor.Find<ModItem>("AncientBlade").Type,
                thor.Find<ModItem>("StarCaller").Type,
                thor.Find<ModItem>("StriderTear").Type,
                thor.Find<ModItem>("VoidLens").Type,
                thor.Find<ModItem>("DoomSayersCoin").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (sots == null || !Enumerable.Contains(new int[]
            {
                sots.Find<ModItem>("ElectromagneticLure").Type,
                sots.Find<ModItem>("JarOfPeanuts").Type,
                sots.Find<ModItem>("CatalystBomb").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (vitality == null || !Enumerable.Contains(new int[]
            {
                vitality.Find<ModItem>("CloudCore").Type,
                vitality.Find<ModItem>("AncientCrown").Type,
                vitality.Find<ModItem>("MultigemCluster").Type,
                vitality.Find<ModItem>("MoonlightLotusFlower").Type,
                vitality.Find<ModItem>("Dreadcandle").Type,
                vitality.Find<ModItem>("AnarchyCrystal").Type,
                vitality.Find<ModItem>("TotemofChaos").Type,
                vitality.Find<ModItem>("SpiritBox").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (consolaria == null || !Enumerable.Contains(new int[]
            {
                consolaria.Find<ModItem>("SuspiciousLookingEgg").Type,
                consolaria.Find<ModItem>("CursedStuffing").Type,
                consolaria.Find<ModItem>("SuspiciousLookingSkull").Type,
                consolaria.Find<ModItem>("Wishbone").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (spooky == null || !Enumerable.Contains(new int[]
            {
                spooky.Find<ModItem>("RottenSeed").Type,
                spooky.Find<ModItem>("Fertalizer").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (souls == null || !Enumerable.Contains(new int[]
            {
                souls.Find<ModItem>("AbomsCurse").Type,
                souls.Find<ModItem>("DevisCurse").Type,
                souls.Find<ModItem>("FragilePixieLamp").Type,
                souls.Find<ModItem>("MutantsCurse").Type,
                souls.Find<ModItem>("SquirrelCoatofArms").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (hj == null || !Enumerable.Contains(new int[]
            {
                hj.Find<ModItem>("CannedSoulofFlight").Type,
                hj.Find<ModItem>("SouthernPotting").Type,
                hj.Find<ModItem>("SunlightCrown").Type,
                hj.Find<ModItem>("MetalSpine").Type,
                hj.Find<ModItem>("UnstableGlobe").Type
            }, item.type) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && ((!Enumerable.Contains(BossSummons, item.type) && !Enumerable.Contains(EventSummons, item.type)) || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && (!item.consumable || item.stack < 999 || !ModContent.GetInstance<QoLCConfig>().EndlessConsumables) && base.ConsumeItem(item, player);
        }
        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            ModLoader.TryGetMod("ThoriumMod", out Mod mod);
            if ((mod != null && ammo.type == mod.Find<ModItem>("StormFlare").Type) || (ammo.ammo > 0 && ammo.stack >= 999) && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= 999 && ModContent.GetInstance<QoLCConfig>().EndlessConsumables)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }

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
