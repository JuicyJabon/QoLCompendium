using QoLCompendium.Core.Configs;

namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class MiscEffectsPlayer : ModPlayer
    {
        public bool joinedTeam = false;

        public override void OnEnterWorld()
        {
            if (Player != Main.player[Main.myPlayer])
                return;

            if (QoLCompendium.mainConfig.AutoTeams > 0 && joinedTeam == false && Main.netMode == NetmodeID.MultiplayerClient)
            {
                Main.player[Main.myPlayer].team = QoLCompendium.mainConfig.AutoTeams;
                joinedTeam = true;
                NetMessage.SendData(MessageID.PlayerTeam, -1, -1, null, Main.myPlayer, QoLCompendium.mainConfig.AutoTeams, 0f, 0f, 0, 0, 0);
            }
        }

        public override void PostUpdateMiscEffects()
        {
            //PLACE SPEED INCREASE
            Player.tileSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;
            Player.wallSpeed -= QoLCompendium.mainConfig.IncreasePlaceSpeed;

            //PLACE RANGE INCREASE
            Player.tileRangeX += QoLCompendium.mainConfig.IncreasePlaceRange;
            Player.tileRangeY += QoLCompendium.mainConfig.IncreasePlaceRange;
        }

        public override void PostUpdateEquips()
        {
            //REMOVES ICE BIOME EXPERT CHANGE
            if (QoLCompendium.mainConfig.NoExpertIceWaterChilled && Player.wet && Player.ZoneSnow && Main.expertMode)
            {
                Player.buffImmune[BuffID.Chilled] = true;
                Player.chilled = false;
            }

            //REMOVES SHIMMER SINKING
            if (QoLCompendium.mainConfig.NoShimmerSink && Player.wet)
            {
                Player.buffImmune[BuffID.Shimmer] = true;
                Player.shimmerImmune = true;
            }
        }

        public override void PreUpdateBuffs()
        {
            //CHANGES SHOP PRICES WHEN HAPPINESS IS DISABLED
            if (QoLCompendium.mainConfig.DisableHappiness)
                Player.currentShoppingSettings.PriceAdjustment = QoLCompendium.mainConfig.HappinessPriceChange;
        }
    }
}