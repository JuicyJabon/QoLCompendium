namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class SliceOfCakeLastsUntilDeath : GlobalBuff
    {
        public bool defaultTimeLeft = BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush];
        public bool defaultTimeDisplay = Main.buffNoTimeDisplay[BuffID.SugarRush];
        public bool defaultNoSave = Main.buffNoSave[BuffID.SugarRush];

        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (QoLCompendium.mainConfig.InfiniteSliceOfCake)
            {
                BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = true;
                Main.buffNoTimeDisplay[BuffID.SugarRush] = true;
                Main.buffNoSave[BuffID.SugarRush] = true;
            }
            else
            {
                BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = defaultTimeLeft;
                Main.buffNoTimeDisplay[BuffID.SugarRush] = defaultTimeDisplay;
                Main.buffNoSave[BuffID.SugarRush] = defaultNoSave;
            }
        }
    }
}
