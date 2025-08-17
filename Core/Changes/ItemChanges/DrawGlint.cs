namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class DrawGlint : GlobalItem
    {
        public override bool PreDrawInInventory(Item item, SpriteBatch sb, Vector2 position, Rectangle frame,
        Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (Common.CheckToActivateGlintEffect(item) == false)
                return true;

            var texture = Common.GetAsset("Effects", "Glint_", (int)QoLCompendium.mainClientConfig.GlintColor);
            var shader = ModContent.Request<Effect>("QoLCompendium/Assets/Effects/Transform", AssetRequestMode.ImmediateLoad).Value;

            shader.Parameters["uTime"].SetValue(Main.GlobalTimeWrappedHourly * 0.2f);
            shader.CurrentTechnique.Passes["EnchantedPass"].Apply();
            Main.instance.GraphicsDevice.Textures[1] = texture.Value;

            sb.End();
            sb.Begin(SpriteSortMode.Deferred, sb.GraphicsDevice.BlendState, sb.GraphicsDevice.SamplerStates[0], sb.GraphicsDevice.DepthStencilState, sb.GraphicsDevice.RasterizerState, shader, Main.UIScaleMatrix);
            return true;
        }

        public override void PostDrawInInventory(Item item, SpriteBatch sb, Vector2 position, Rectangle frame,
            Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (Common.CheckToActivateGlintEffect(item) == false)
                return;

            sb.End();
            sb.Begin(SpriteSortMode.Deferred, sb.GraphicsDevice.BlendState, sb.GraphicsDevice.SamplerStates[0], sb.GraphicsDevice.DepthStencilState, sb.GraphicsDevice.RasterizerState, null, Main.UIScaleMatrix);
        }

        public override bool PreDrawInWorld(Item item, SpriteBatch sb, Color lightColor, Color alphaColor,
            ref float rotation, ref float scale, int whoAmI)
        {
            if (Common.CheckToActivateGlintEffect(item) == false)
                return true;

            var texture = Common.GetAsset("Effects", "Glint_", (int)QoLCompendium.mainClientConfig.GlintColor);
            var shader = ModContent.Request<Effect>("QoLCompendium/Assets/Effects/Transform", AssetRequestMode.ImmediateLoad).Value;

            shader.Parameters["uTime"].SetValue(Main.GlobalTimeWrappedHourly * 0.2f);
            shader.CurrentTechnique.Passes["EnchantedPass"].Apply();
            Main.instance.GraphicsDevice.Textures[1] = texture.Value;

            sb.End();
            sb.Begin(SpriteSortMode.Deferred, Main.spriteBatch.GraphicsDevice.BlendState, sb.GraphicsDevice.SamplerStates[0], Main.spriteBatch.GraphicsDevice.DepthStencilState, sb.GraphicsDevice.RasterizerState, shader, Main.GameViewMatrix.TransformationMatrix);
            return true;
        }

        public override void PostDrawInWorld(Item item, SpriteBatch sb, Color lightColor, Color alphaColor, float rotation,
            float scale, int whoAmI)
        {
            if (Common.CheckToActivateGlintEffect(item) == false)
                return;

            sb.End();
            sb.Begin(SpriteSortMode.Deferred, sb.GraphicsDevice.BlendState, sb.GraphicsDevice.SamplerStates[0], sb.GraphicsDevice.DepthStencilState, sb.GraphicsDevice.RasterizerState, null, Main.GameViewMatrix.TransformationMatrix);
        }
    }
}
