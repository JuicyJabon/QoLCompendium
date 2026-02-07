namespace QoLCompendium.Core.Changes.TileChanges
{
    public class NoPylonRestrictions : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
        {
            if (QoLCompendium.mainConfig.NoPylonTeleportRestrictions)
                return true;
            return base.ValidTeleportCheck_PreAnyDanger(pylonInfo);
        }
        public override bool? ValidTeleportCheck_PreNPCCount(TeleportPylonInfo pylonInfo, ref int defaultNecessaryNPCCount)
        {
            if (QoLCompendium.mainConfig.NoPylonTeleportRestrictions)
                return true;
            return base.ValidTeleportCheck_PreNPCCount(pylonInfo, ref defaultNecessaryNPCCount);
        }

        public override bool? ValidTeleportCheck_PreBiomeRequirements(TeleportPylonInfo pylonInfo, SceneMetrics sceneData)
        {
            if (QoLCompendium.mainConfig.NoPylonTeleportRestrictions)
                return true;
            return base.ValidTeleportCheck_PreBiomeRequirements(pylonInfo, sceneData);
        }

        public override bool? PreCanPlacePylon(int x, int y, int tileType, TeleportPylonType pylonType)
        {
            if (QoLCompendium.mainConfig.NoPylonPlacementRestrictions)
                return true;
            return base.PreCanPlacePylon(x, y, tileType, pylonType);
        }
    }
}