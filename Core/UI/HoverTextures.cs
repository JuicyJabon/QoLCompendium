using System.Threading;

namespace QoLCompendium.Core.UI
{
    public class HoverTextures : ModSystem
    {
        private static Dictionary<Texture2D, Texture2D> outlineTextureCache = [];

        public override void Unload()
        {
            if (outlineTextureCache.Count <= 0)
                return;
            List<Texture2D> texturesToDispose = [.. outlineTextureCache.Values];
            RunOnMainThread(delegate
            {
                foreach (Texture2D current in texturesToDispose)
                {
                    current?.Dispose();
                }
            });
            outlineTextureCache.Clear();
        }

        public static Texture2D GenerateOutlineTexture(Texture2D original, int outlineWidth)
        {
            if (Main.netMode == NetmodeID.Server || original == null)
                return null;

            GraphicsDevice graphics = Main.graphics.GraphicsDevice;
            int newWidth = original.Width + outlineWidth * 2;
            int newHeight = original.Height + outlineWidth * 2;


            Color[] originalData = new Color[original.Width * original.Height];
            original.GetData(originalData);
            bool hasOpaquePixels = false;
            Color[] colorArray = originalData;
            for (int i = 0; i < colorArray.Length; i++)
            {
                Color pixel = colorArray[i];
                if (pixel.A > 0)
                {
                    hasOpaquePixels = true;
                    break;
                }
            }

            if (!hasOpaquePixels)
                return null;

            Color[] outlineData = new Color[newWidth * newHeight];
            int chunkSize = 2;

            for (int chunkY = 0; chunkY < newHeight; chunkY += chunkSize)
            {
                for (int chunkX = 0; chunkX < newWidth; chunkX += chunkSize)
                {
                    bool shouldBeOutline = false;
                    for (int py = chunkY; py < Math.Min(chunkY + chunkSize, newHeight); py++)
                    {
                        if (shouldBeOutline)
                        {
                            break;
                        }
                        for (int px = chunkX; px < Math.Min(chunkX + chunkSize, newWidth); px++)
                        {
                            if (shouldBeOutline)
                            {
                                break;
                            }
                            bool pixelShouldBeOutline = false;
                            for (int dy = -outlineWidth; dy <= outlineWidth; dy++)
                            {
                                if (pixelShouldBeOutline)
                                {
                                    break;
                                }
                                for (int dx = -outlineWidth; dx <= outlineWidth; dx++)
                                {
                                    if (pixelShouldBeOutline)
                                    {
                                        break;
                                    }
                                    if (dx * dx + dy * dy > outlineWidth * outlineWidth)
                                    {
                                        continue;
                                    }
                                    int origX = px - outlineWidth + dx;
                                    int origY = py - outlineWidth + dy;
                                    if (origX >= 0 && origX < original.Width && origY >= 0 && origY < original.Height)
                                    {
                                        int origIndex = origY * original.Width + origX;
                                        if (originalData[origIndex].A > 0)
                                        {
                                            pixelShouldBeOutline = true;
                                        }
                                    }
                                }
                            }
                            int centerX = px - outlineWidth;
                            int centerY = py - outlineWidth;
                            bool centerIsTransparent = true;
                            if (centerX >= 0 && centerX < original.Width && centerY >= 0 && centerY < original.Height)
                            {
                                int centerIndex = centerY * original.Width + centerX;
                                centerIsTransparent = originalData[centerIndex].A == 0;
                            }
                            if (pixelShouldBeOutline && centerIsTransparent)
                            {
                                shouldBeOutline = true;
                            }
                        }
                    }
                    Color chunkColor = (shouldBeOutline ? Color.White : Color.Transparent);
                    for (int py = chunkY; py < Math.Min(chunkY + chunkSize, newHeight); py++)
                    {
                        for (int px = chunkX; px < Math.Min(chunkX + chunkSize, newWidth); px++)
                        {
                            int outlineIndex = py * newWidth + px;
                            outlineData[outlineIndex] = chunkColor;
                        }
                    }
                }
            }
            Texture2D outlineTexture = new(graphics, newWidth, newHeight);
            outlineTexture.SetData(outlineData);
            return outlineTexture;
        }

        public static Texture2D GetOutlineTexture(Texture2D texture, int outlineWidth, Rectangle? sourceFrame = null)
        {
            if (Main.netMode == NetmodeID.Server)
                return null;
            try
            {
                int frame;
                if (!sourceFrame.HasValue)
                {
                    frame = 0;
                }
                else
                {
                    Rectangle valueOrDefault = sourceFrame.GetValueOrDefault();
                    frame = valueOrDefault.GetHashCode();
                }
                if (!outlineTextureCache.ContainsKey(texture))
                {
                    Texture2D newTexture = GenerateOutlineTexture(texture, outlineWidth);
                    if (newTexture != null)
                        outlineTextureCache.Add(texture, newTexture);
                    return newTexture;
                }
                else
                {
                    if (texture == null)
                        return null;

                    if (outlineTextureCache.TryGetValue(texture, out var cachedTexture))
                        return cachedTexture;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void RunOnMainThread(Action action)
        {
            if (AssetRepository.IsMainThread)
            {
                action();
                return;
            }
            ManualResetEventSlim evt = new(initialState: false);
            Main.QueueMainThreadAction(delegate
            {
                action();
                evt.Set();
            });
            evt.Wait();
        }
    }
}
