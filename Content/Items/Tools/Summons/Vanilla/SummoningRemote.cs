using Humanizer;
using QoLCompendium.Content.Projectiles.Other;
using QoLCompendium.Core.UI;
using QoLCompendium.Core.UI.Panels;
using Terraria.DataStructures;
using Terraria.Enums;

namespace QoLCompendium.Content.Items.Tools.Summons.Vanilla
{
    public class SummoningRemote : ModItem, ILocalizedModType
    {
        public override bool IsLoadingEnabled(Mod mod) => !QoLCompendium.itemConfig.DisableModdedItems || QoLCompendium.itemConfig.SummoningRemote;

        public new string LocalizationCategory => "Items.Tools.Summons";

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 0;
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 7;
            Item.height = 17;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.shoot = ModContent.ProjectileType<NPCSpawner>();
            Item.SetShopValues(ItemRarityColor.Blue1, Item.buyPrice(0, 1, 0, 0));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            ItemUtils.ItemDisabledTooltip(Item, tooltips, QoLCompendium.itemConfig.SummoningRemote);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
                return false;

            Vector2 spawnPosition = player.Center - Vector2.UnitY * 800f;
            QoLCPlayer qPlayer = QoLCPlayer.Get(player);

            if (qPlayer.bossToSpawn != -1 && qPlayer.bossSpawn)
            {
                if (qPlayer.bossToSpawn == NPCID.WallofFlesh)
                    return false;

                if (qPlayer.bossToSpawn == NPCID.Retinazer)
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.Spazmatism);

                Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, qPlayer.bossToSpawn);

                SoundEngine.PlaySound(SoundID.Roar, player.Center);
            }
            if (qPlayer.eventToSpawn == (int)UIEnums.EventTypes.Party && qPlayer.eventSpawn)
            {
                if (!NPC.AnyNPCs(NPCID.PartyGirl))
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse(Item), spawnPosition, Vector2.Zero, ModContent.ProjectileType<NPCSpawner>(), 0, 0f, player.whoAmI, NPCID.PartyGirl);
                }
            }
            return false;
        }

        public override bool? UseItem(Player player)
        {
            QoLCPlayer qPlayer = QoLCPlayer.Get(player);
            if (player.altFunctionUse == 2)
            {
                if (!SummoningRemoteUI.visible) 
                    SummoningRemoteUI.timeStart = Main.GameUpdateCount;
                SummoningRemoteUI.visible = true;
                SoundEngine.PlaySound(SoundID.MenuOpen, player.Center);
                return true;
            }
            else
            {
                if (qPlayer.bossToSpawn != -1 && qPlayer.bossSpawn && qPlayer.bossToSpawn == NPCID.WallofFlesh)
                {
                    NPC.SpawnWOF(player.Center);
                    SoundEngine.PlaySound(SoundID.Roar, player.Center);
                    return true;
                }
                if (qPlayer.eventToSpawn != -1 && qPlayer.eventSpawn)
                {
                    NPCsUtils.StartEvent(player, qPlayer.eventToSpawn);
                    SoundEngine.PlaySound(SoundID.Roar, player.Center);
                    return true;
                }
                return true;
            }
        }

        public override void RightClick(Player player)
        {
            if (!SummoningRemoteUI.visible)
                SummoningRemoteUI.timeStart = Main.GameUpdateCount;
            SummoningRemoteUI.visible = !SummoningRemoteUI.visible;
        }

        public override bool CanRightClick() => true;
        public override bool ConsumeItem(Player player) => false;

        public override void UpdateInventory(Player player)
        {
            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn > 0 && player.GetModPlayer<QoLCPlayer>().bossToSpawn != NPCID.Retinazer && player.GetModPlayer<QoLCPlayer>().bossToSpawn != NPCID.MoonLordCore && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.Boss").FormatWith(ContentSamples.NpcsByNetId[player.GetModPlayer<QoLCPlayer>().bossToSpawn].FullName));

            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.Retinazer && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.BossTwins"));

            if (player.GetModPlayer<QoLCPlayer>().bossToSpawn == NPCID.MoonLordCore && player.GetModPlayer<QoLCPlayer>().bossSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.BossMoonLord"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.LanternNight && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventLanternNight"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.Rain && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventRain"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.WindyDay && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventWind"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.Sandstorm && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSandstorm"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.Party && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventParty"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.SlimeRain && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSlimeRain"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.BloodMoon && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventBloodMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.GoblinArmy && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventGoblinArmy"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.FrostLegion && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventSnowLegion"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.PirateInvasion && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventPirateInvasion"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.SolarEclipse && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventEclipse"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.PumpkinMoon && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventPumpkinMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.FrostMoon && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventFrostMoon"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.MartianMadness && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventMartianMadness"));

            if (player.GetModPlayer<QoLCPlayer>().eventToSpawn == (int)UIEnums.EventTypes.LunarEvent && player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.EventLunar"));

            if (!player.GetModPlayer<QoLCPlayer>().bossSpawn && !player.GetModPlayer<QoLCPlayer>().eventSpawn)
                Item.SetNameOverride(Language.GetTextValue("Mods.QoLCompendium.ItemNames.SummoningRemote.NoModifier"));
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe r = RecipeUtils.GetItemRecipe(() => QoLCompendium.itemConfig.SummoningRemote, Type, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            r.AddRecipeGroup(RecipeGroupID.IronBar, 12);
            r.AddIngredient(ItemID.Ruby, 5);
            r.AddIngredient(ItemID.Lens, 2);
            r.AddTile(TileID.Anvils);
            r.Register();
        }
    }
}
