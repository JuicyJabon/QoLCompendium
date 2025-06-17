using System.Reflection;

namespace QoLCompendium.Core.Changes.ProjectileChanges
{
    public class NoAuraEffects : ModSystem
    {
        public const string TeslaTexturePath = @"Projectiles\Typeless\TeslaAura";

        private static TimeSpan NextTextureUpdate = TimeSpan.Zero;

        public static Asset<Texture2D> EmptyTexture => Common.GetAsset("Projectiles", "Invisible");
        public static Asset<Texture2D> OrigFlameRing;
        public static Asset<Texture2D> OrigTesla;

        public static List<int> OriginalTeslaProjectiles = new();

        public static bool WasTeslaEnabled = false;

        public override void Load()
        {
            Main.OnPreDraw += UpdateTextures;
        }
        public override void Unload()
        {
            if (OrigFlameRing != null && TextureAssets.FlameRing == EmptyTexture) TextureAssets.FlameRing = OrigFlameRing;

            if (OrigTesla != null)
                foreach (var Index in OriginalTeslaProjectiles)
                    TextureAssets.Projectile[Index] = OrigTesla;

            Main.OnPreDraw -= UpdateTextures;
        }

        private static void UpdateTextures(GameTime Time)
        {
            if (!Main.gameMenu && Time.TotalGameTime > NextTextureUpdate)
            {
                NextTextureUpdate = Time.TotalGameTime.Add(TimeSpan.FromSeconds(1));

                if (QoLCompendium.mainClientConfig.NoAuraVisuals && TextureAssets.FlameRing != EmptyTexture)
                {
                    OrigFlameRing ??= TextureAssets.FlameRing;

                    TextureAssets.FlameRing = EmptyTexture;
                }
                else if (!QoLCompendium.mainClientConfig.NoAuraVisuals && OrigFlameRing != null && TextureAssets.FlameRing != OrigFlameRing)
                    TextureAssets.FlameRing = OrigFlameRing;

                if (ModConditions.calamityLoaded)
                {
                    var AssetField = typeof(AssetRepository).GetField("_assets", BindingFlags.Instance | BindingFlags.NonPublic);

                    Dictionary<string, IAsset> Assets = (Dictionary<string, IAsset>)AssetField.GetValue(ModConditions.calamityMod.Assets);

                    if (AssetField != null && Assets != null && Assets.ContainsKey(TeslaTexturePath))
                    {
                        if (QoLCompendium.mainClientConfig.NoAuraVisuals && !WasTeslaEnabled)
                        {
                            OrigTesla ??= (Asset<Texture2D>)Assets[TeslaTexturePath];

                            for (int Index = TextureAssets.Projectile.Length - 1; Index >= 0; Index--)
                            {
                                var Texture = TextureAssets.Projectile[Index];

                                if (Texture == OrigTesla)
                                {
                                    WasTeslaEnabled = true; // Only set to true if the texture was found

                                    if (!OriginalTeslaProjectiles.Contains(Index))
                                        OriginalTeslaProjectiles.Add(Index);

                                    TextureAssets.Projectile[Index] = EmptyTexture;
                                }
                            }
                        }
                        else if (!QoLCompendium.mainClientConfig.NoAuraVisuals && OrigTesla != null && WasTeslaEnabled)
                        {
                            WasTeslaEnabled = false;

                            foreach (var Index in OriginalTeslaProjectiles)
                                TextureAssets.Projectile[Index] = OrigTesla;
                        }
                    }
                }
            }
        }
    }
}
