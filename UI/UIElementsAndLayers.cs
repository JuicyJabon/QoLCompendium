using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;

namespace QoLCompendium.UI
{
    // Token: 0x02000007 RID: 7
    public class UIElementsAndLayers : ModSystem
    {
        // Token: 0x06000043 RID: 67 RVA: 0x000023B0 File Offset: 0x000005B0
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int num = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Mouse Text"));
            if (num != -1)
            {
                layers.Insert(num, new LegacyGameInterfaceLayer("QoLCompendium: Locator Arrow", delegate ()
                {
                    if (Main.LocalPlayer.accCritterGuide && ModContent.GetInstance<QoLCConfig>().LifeformPointer)
                    {
                        for (int i = 0; i < 200; i++)
                        {
                            NPC npc = Main.npc[i];
                            if (npc.active && npc.rarity >= 1)
                            {
                                Vector2 vector = Main.LocalPlayer.Center + new Vector2(0f, Main.LocalPlayer.gfxOffY);
                                Vector2 vector2 = npc.Center - vector;
                                float num2 = vector2.Length();
                                if (num2 > 40f && num2 <= 4000f)
                                {
                                    Vector2 vector3 = Vector2.Normalize(vector2) * Math.Min(70f, num2 - 20f);
                                    float num3 = Utils.ToRotation(vector2) + 1.5707964f;
                                    Vector2 vector4 = vector - Main.screenPosition + vector3;
                                    float num4 = Math.Min(1f, (num2 - 20f) / 70f);
                                    Main.spriteBatch.Draw(ModContent.Request<Texture2D>("QoLCompendium/Projectiles/LifeformLocator", (ReLogic.Content.AssetRequestMode)2).Value, vector4, default, Color.White * num4, num3, Utils.Size(TextureAssets.Cursors[1]) / 2f, Vector2.One, 0, 0f);
                                }
                            }
                        }
                    }
                    return true;
                }, 0));
            }
        }

        // Token: 0x06000044 RID: 68 RVA: 0x00002418 File Offset: 0x00000618
        internal static Dictionary<string, int> GetSentryNameToCount(out int totalCount, bool onlyCount = false)
        {
            totalCount = 0;
            Dictionary<string, int> dictionary = new();
            for (int i = 0; i < 1000; i++)
            {
                Projectile projectile = Main.projectile[i];
                if (projectile.active && projectile.sentry && projectile.owner == Main.myPlayer)
                {
                    totalCount++;
                    if (!onlyCount)
                    {
                        string text = Lang.GetProjectileName(projectile.type).Value;
                        if (string.IsNullOrEmpty(text))
                        {
                            text = "Uncountable";
                        }
                        if (dictionary.ContainsKey(text))
                        {
                            Dictionary<string, int> dictionary2 = dictionary;
                            string text2 = text;
                            int num = dictionary2[text2];
                            dictionary2[text2] = num + 1;
                        }
                        else
                        {
                            dictionary.Add(text, 1);
                        }
                    }
                }
            }
            return dictionary;
        }
    }
}
