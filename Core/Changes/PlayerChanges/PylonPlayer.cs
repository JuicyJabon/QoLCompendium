namespace QoLCompendium.Core.Changes.PlayerChanges
{
    public class PylonPlayer : GlobalPylon
    {
        public override void PostValidTeleportCheck(TeleportPylonInfo destinationPylonInfo, TeleportPylonInfo nearbyPylonInfo, ref bool destinationPylonValid, ref bool validNearbyPylonFound, ref string errorKey)
        {
            //destinationPylonValid = true;
            //validNearbyPylonFound = true;
        }
    }
}
