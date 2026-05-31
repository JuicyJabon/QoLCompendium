namespace QoLCompendium.Core.Changes.ModChanges.ModTooltipChanges
{
    public class AddTooltipIcons : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => CrossModSupport.TooltipIcons.Loaded;

        public override void PostSetupContent()
        {
            TryRegisterCalamityIcons();
            TryRegisterCalamityEntropyIcons();
            TryRegisterClickerIcons();
            TryRegisterInfernalEclipseIcons();
            TryRegisterMartinsOrderIcons();
            TryRegisterThoriumIcons();
            TryRegisterSOTSIcons();
            TryRegisterSOTSBardHealerIcons();
            TryRegisterThrowerUnificationIcons();
            TryRegisterRagnarokIcons();
            TryRegisterVitalityIcons();
            TryRegisterVanillaIcons();
        }

        public static void TryRegisterCalamityIcons()
        {
            if (!CrossModSupport.Calamity.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Calamity.Mod, "RogueDamageClass"), "QoLCompendium/Assets/TooltipIcons/ThrowingDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Calamity.Mod, "StealthDamageClass"), "QoLCompendium/Assets/TooltipIcons/ThrowingDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Calamity.Mod, "AverageDamageClass"), "QoLCompendium/Assets/TooltipIcons/Classless");
        }

        public static void TryRegisterCalamityEntropyIcons()
        {
            if (!CrossModSupport.Calamity.Loaded && !CrossModSupport.CalamityEntropy.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.CalamityEntropy.Mod, "NoDRMelee"), "TooltipIcon/Textures/Weapons/MeleeDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.CalamityEntropy.Mod, "NoneTypeDamageClass"), "QoLCompendium/Assets/TooltipIcons/Classless");
        }

        public static void TryRegisterClickerIcons()
        {
            if (!CrossModSupport.ClickerClass.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.ClickerClass.Mod, "ClickerDamage"), "QoLCompendium/Assets/TooltipIcons/ClickDamage");
        }

        public static void TryRegisterInfernalEclipseIcons()
        {
            if (!CrossModSupport.InfernalEclipse.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "VoidRogue"), "QoLCompendium/Assets/TooltipIcons/VoidThrowingDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "MeleeWhip"), "TooltipIcon/Textures/Weapons/MeleeDamage");
            //Legendary Classes
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "LegendaryMelee"), "QoLCompendium/Assets/TooltipIcons/LegendaryMeleeDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "LegendaryRanged"), "QoLCompendium/Assets/TooltipIcons/LegendaryRangedDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "LegendaryMagic"), "QoLCompendium/Assets/TooltipIcons/LegendaryMagicDamage");
            //Mythic Classes
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "MythicMelee"), "QoLCompendium/Assets/TooltipIcons/MythicMeleeDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "MythicRanged"), "QoLCompendium/Assets/TooltipIcons/MythicRangedDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "MythicMagic"), "QoLCompendium/Assets/TooltipIcons/MythicMagicDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.InfernalEclipse.Mod, "MythicSummon"), "QoLCompendium/Assets/TooltipIcons/MythicSummonDamage");
        }

        public static void TryRegisterMartinsOrderIcons()
        {
            if (!CrossModSupport.MartinsOrder.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClass"), "QoLCompendium/Assets/TooltipIcons/ArtDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClassNoSpeed"), "QoLCompendium/Assets/TooltipIcons/ArtDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.MartinsOrder.Mod, "ArtistClassTempera"), "QoLCompendium/Assets/TooltipIcons/ArtDamage");
        }

        public static void TryRegisterThoriumIcons()
        {
            if (!CrossModSupport.Thorium.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Thorium.Mod, "BardDamage"), "QoLCompendium/Assets/TooltipIcons/BardDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Thorium.Mod, "HealerDamage"), "QoLCompendium/Assets/TooltipIcons/HealerDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Thorium.Mod, "HealerTool"), "QoLCompendium/Assets/TooltipIcons/HealerDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Thorium.Mod, "HealerToolDamageHybrid"), "QoLCompendium/Assets/TooltipIcons/HealerDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Thorium.Mod, "TrueDamage"), "QoLCompendium/Assets/TooltipIcons/Classless");
        }

        public static void TryRegisterSOTSIcons()
        {
            if (!CrossModSupport.SecretsOfTheShadows.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMelee"), "QoLCompendium/Assets/TooltipIcons/VoidMeleeDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidRanged"), "QoLCompendium/Assets/TooltipIcons/VoidRangedDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidMagic"), "QoLCompendium/Assets/TooltipIcons/VoidMagicDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidSummon"), "QoLCompendium/Assets/TooltipIcons/VoidSummonDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadows.Mod, "VoidGeneric"), "QoLCompendium/Assets/TooltipIcons/VoidClassless");
        }

        public static void TryRegisterSOTSBardHealerIcons()
        {
            if (!CrossModSupport.SecretsOfTheShadowsBardHealer.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidSymphonic"), "QoLCompendium/Assets/TooltipIcons/VoidBardDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidRadiant"), "QoLCompendium/Assets/TooltipIcons/VoidHealerDamage");
            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.SecretsOfTheShadowsBardHealer.Mod, "VoidThrowing"), "QoLCompendium/Assets/TooltipIcons/VoidThrowingDamage");
        }

        public static void TryRegisterThrowerUnificationIcons()
        {
            if (!CrossModSupport.ThrowerUnification.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.ThrowerUnification.Mod, "UnitedModdedThrower"), "QoLCompendium/Assets/TooltipIcons/ThrowingDamage");
        }

        public static void TryRegisterRagnarokIcons()
        {
            if (!CrossModSupport.Ragnarok.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Ragnarok.Mod, "ThoriumRogueClass"), "QoLCompendium/Assets/TooltipIcons/ThrowingDamage");
        }

        public static void TryRegisterVitalityIcons()
        {
            if (!CrossModSupport.Vitality.Loaded)
                return;

            TryAddDamageClassIcon(Common.GetModDamageClass(CrossModSupport.Vitality.Mod, "BloodHunterClass"), "QoLCompendium/Assets/TooltipIcons/BloodHunterDamage");
        }

        public static void TryRegisterVanillaIcons()
        {
            TryAddDamageClassIcon(DamageClass.Throwing, "QoLCompendium/Assets/TooltipIcons/ThrowingDamage");
            TryAddDamageClassIcon(DamageClass.Default, "QoLCompendium/Assets/TooltipIcons/Classless");
            TryAddDamageClassIcon(DamageClass.Generic, "QoLCompendium/Assets/TooltipIcons/Classless");
        }

        public static void TryAddDamageClassIcon(DamageClass damageClass, string texturePath)
        {
            if (!CrossModSupport.TooltipIcons.Loaded)
                return;

            Asset<Texture2D> texture = ModContent.Request<Texture2D>(texturePath, AssetRequestMode.ImmediateLoad);
            CrossModSupport.TooltipIcons.Mod.Call(["AddDamageClassIcon", damageClass, texture, null, null, null]);
        }
    }
}
