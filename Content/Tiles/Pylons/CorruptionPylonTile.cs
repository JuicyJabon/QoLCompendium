﻿using QoLCompendium.Content.Items.Placeables.Pylons;
using QoLCompendium.Core;
using Terraria.DataStructures;
using Terraria.Map;
using Terraria.ModLoader.Default;
using Terraria.ObjectData;
using static Terraria.ModLoader.NPCShop;

namespace QoLCompendium.Content.Tiles.Pylons
{
    public class CorruptionPylonTile : ModPylon
    {
        public int CrystalVerticalFrameCount = 8;

        public Asset<Texture2D> crystalTexture;

        public Asset<Texture2D> crystalHighlightTexture;

        public Asset<Texture2D> mapIcon;

        public override void Load()
        {
            crystalTexture = ModContent.Request<Texture2D>("QoLCompendium/Assets/PylonCrystals/CorruptionPylonTile_Crystal", (AssetRequestMode)2);
            crystalHighlightTexture = ModContent.Request<Texture2D>("QoLCompendium/Assets/Highlights/PylonCrystal_Highlight", (AssetRequestMode)2);
            mapIcon = ModContent.Request<Texture2D>("QoLCompendium/Assets/MapIcons/CorruptionPylonTile_MapIcon", (AssetRequestMode)2);
        }

        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.StyleHorizontal = true;
            TEModdedPylon instance = (TEModdedPylon)(object)ModContent.GetInstance<CorruptionPylonTileEntity>();
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(instance.PlacementPreviewHook_CheckIfCanPlace, 1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(instance.Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.PreventsSandfall[Type] = true;
            TileID.Sets.AvoidedByMeteorLanding[Type] = true;
            AddToArray(ref TileID.Sets.CountsAsPylon);
            LocalizedText val = CreateMapEntryName();
            AddMapEntry(Color.BlueViolet, val);
            DustType = -1;
        }

        public override Entry GetNPCShopEntry()
        {
            if (QoLCompendium.itemConfig.Pylons)
            {
                return new Entry(ModContent.ItemType<CorruptionPylon>(), Condition.InCorrupt);
            }
            return null;
        }

        public override void MouseOver(int i, int j)
        {
            Main.LocalPlayer.cursorItemIconEnabled = true;
            Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<CorruptionPylon>();
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            ModContent.GetInstance<CorruptionPylonTileEntity>().Kill(i, j);
        }

        public override bool ValidTeleportCheck_NPCCount(TeleportPylonInfo pylonInfo, int defaultNecessaryNPCCount)
        {
            return true;
        }

        public override bool ValidTeleportCheck_BiomeRequirements(TeleportPylonInfo pylonInfo, SceneMetrics sceneData)
        {
            return sceneData.EnoughTilesForCorruption;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = g = b = 0.75f;
        }

        public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
        {
            DefaultDrawPylonCrystal(spriteBatch, i, j, crystalTexture, crystalHighlightTexture, new Vector2(-1f, -12f), Color.White * 0.1f, Common.ColorSwap(Color.BlueViolet, Color.SlateBlue, 1.5f), 4, CrystalVerticalFrameCount);
        }

        public override void DrawMapIcon(ref MapOverlayDrawContext context, ref string mouseOverText, TeleportPylonInfo pylonInfo, bool isNearPylon, Color drawColor, float deselectedScale, float selectedScale)
        {
            bool flag = DefaultDrawMapIcon(ref context, mapIcon, pylonInfo.PositionInTiles.ToVector2() + new Vector2(1.5f, 2f), drawColor, deselectedScale, selectedScale);
            DefaultMapClickHandle(flag, pylonInfo, ModContent.GetInstance<CorruptionPylon>().DisplayName.Key, ref mouseOverText);
        }
    }

    public class CorruptionPylonTileEntity : TEModdedPylon
    {

    }
}
