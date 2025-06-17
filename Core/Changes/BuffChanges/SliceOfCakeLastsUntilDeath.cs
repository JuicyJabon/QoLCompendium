namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class SliceOfCakeLastsUntilDeath : GlobalBuff
    {
        private readonly bool _defaultTimeLeft = BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush];
        private readonly bool _defaultTimeDisplay = Main.buffNoTimeDisplay[BuffID.SugarRush];
        private readonly bool _defaultNoSave = Main.buffNoSave[BuffID.SugarRush];

        public override void SetStaticDefaults()
        {
            bool infinite = QoLCompendium.mainConfig.InfiniteSliceOfCake;
            BuffID.Sets.TimeLeftDoesNotDecrease[BuffID.SugarRush] = infinite || _defaultTimeLeft;
            Main.buffNoTimeDisplay[BuffID.SugarRush] = infinite || _defaultTimeDisplay;
            Main.buffNoSave[BuffID.SugarRush] = infinite || _defaultNoSave;
        }
    }
}
