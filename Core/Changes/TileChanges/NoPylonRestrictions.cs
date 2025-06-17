namespace QoLCompendium.Core.Changes.TileChanges
{
    public class NoPylonRestrictions : GlobalPylon
    {
        public override bool? ValidTeleportCheck_PreAnyDanger(TeleportPylonInfo pylonInfo)
        {
            if (QoLCompendium.mainConfig.NoPylonTeleportRestrictions)
                return true;
            return null;
        }
        public override bool? ValidTeleportCheck_PreNPCCount(TeleportPylonInfo pylonInfo, ref int defaultNecessaryNPCCount)
        {
            if (QoLCompendium.mainConfig.NoPylonTeleportRestrictions)
                return true;
            return null;
        }
    }
}
