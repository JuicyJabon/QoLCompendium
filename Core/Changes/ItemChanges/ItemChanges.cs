namespace QoLCompendium.Core.Changes.ItemChanges
{
    public class ItemChanges : GlobalItem
    {
        public override void Load()
        {
            On_Player.ItemCheck_UseMiningTools_TryHittingWall += (orig, player, item, x, y) =>
            {
                orig.Invoke(player, item, x, y);
                if (player.itemTime == item.useTime / 2)
                    player.itemTime = (int)Math.Max(1, (1f - QoLCompendium.mainConfig.IncreaseToolSpeed) * (item.useTime / 2f));
            };
        }

        public override void SetDefaults(Item item)
        {
            if (QoLCompendium.mainConfig.NoDeveloperSetsFromBossBags && ItemID.Sets.BossBag[item.type])
            {
                ItemID.Sets.PreHardmodeLikeBossBag[item.type] = true;
            }

            if (QoLCompendium.mainConfig.IncreaseMaxStack > 0 && item.maxStack > 10 && item.maxStack != 100 && !(item.type >= ItemID.CopperCoin && item.type <= ItemID.PlatinumCoin))
            {
                item.maxStack = QoLCompendium.mainConfig.IncreaseMaxStack;
            }

            if (QoLCompendium.mainConfig.StackableQuestItems && item.questItem == true && QoLCompendium.mainConfig.IncreaseMaxStack > 0)
            {
                item.maxStack = QoLCompendium.mainConfig.IncreaseMaxStack;
            }

            if (QoLCompendium.mainConfig.AutoReuseHealthUpgrades && (item.type == ItemID.LifeCrystal || item.type == ItemID.LifeFruit || item.type == ItemID.ManaCrystal))
                item.autoReuse = true;

            if (QoLCompendium.mainConfig.ItemConversions)
            {
                if (item.type == ItemID.EnchantedSword)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Terragrim;

                if (item.type == ItemID.Terragrim)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.EnchantedSword;

                if (item.type == ItemID.BrickLayer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.ExtendoGrip;

                if (item.type == ItemID.ExtendoGrip)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PaintSprayer;

                if (item.type == ItemID.PaintSprayer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.PortableCementMixer;

                if (item.type == ItemID.PortableCementMixer)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BrickLayer;

                if (item.type == ItemID.Toolbelt)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Toolbox;

                if (item.type == ItemID.Toolbox)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.Toolbelt;

                if (item.type == ItemID.BottomlessBucket)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BottomlessLavaBucket;

                if (item.type == ItemID.BottomlessLavaBucket)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BottomlessHoneyBucket;

                if (item.type == ItemID.BottomlessHoneyBucket)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.BottomlessBucket;

                if (item.type == ItemID.SuperAbsorbantSponge)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.LavaAbsorbantSponge;

                if (item.type == ItemID.LavaAbsorbantSponge)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.HoneyAbsorbantSponge;

                if (item.type == ItemID.HoneyAbsorbantSponge)
                    ItemID.Sets.ShimmerTransformToItem[item.type] = ItemID.SuperAbsorbantSponge;

                if (item.type == Common.GetModItem(ModConditions.redemptionMod, "Keycard2"))
                    ItemID.Sets.ShimmerTransformToItem[item.type] = Common.GetModItem(ModConditions.redemptionMod, "Keycard");
            }
        }

        public override void ExtractinatorUse(int extractType, int extractinatorBlockType, ref int resultType, ref int resultStack)
        {
            if (QoLCompendium.mainConfig.FasterExtractinator)
            {
                Main.LocalPlayer.itemAnimation = 1;
                Main.LocalPlayer.itemTime = 1;
                Main.LocalPlayer.itemTimeMax = 1;
            }
        }

        public override float UseTimeMultiplier(Item item, Player player)
        {
            if (item.pick > 0 || item.hammer > 0 || item.axe > 0 || item.type == ItemID.WireCutter)
                return 1f - QoLCompendium.mainConfig.IncreaseToolSpeed;
            return 1f;
        }

        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            reforgePrice = (int)(reforgePrice * (1f - QoLCompendium.mainConfig.ReforgePriceChange * 0.01f));
            return true;
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            if (item.consumable == true && item.damage == -1 && item.stack >= QoLCompendium.mainConfig.EndlessItemAmount && QoLCompendium.mainConfig.EndlessConsumables)
            {
                return false;
            }

            if (item.consumable == true && item.damage > 0 && item.stack >= QoLCompendium.mainConfig.EndlessWeaponAmount && QoLCompendium.mainConfig.EndlessWeapons)
            {
                return false;
            }

            return base.ConsumeItem(item, player);
        }

        public override bool CanBeConsumedAsAmmo(Item ammo, Item weapon, Player player)
        {
            if (ammo.ammo > 0 && ammo.stack >= QoLCompendium.mainConfig.EndlessAmmoAmount && QoLCompendium.mainConfig.EndlessAmmo)
            {
                return false;
            }
            return base.CanBeConsumedAsAmmo(ammo, weapon, player);
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            if (bait.bait > 0 && bait.stack >= QoLCompendium.mainConfig.EndlessBaitAmount && QoLCompendium.mainConfig.EndlessBait)
            {
                return false;
            }
            return base.CanConsumeBait(player, bait);
        }
    }

    public class DrawGlintEffect : GlobalItem
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