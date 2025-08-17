namespace QoLCompendium.Core.Changes.NPCChanges
{
    public class DisableNaturalBossSpawns : ModSystem
    {
        public override void PreUpdateTime()
        {
            if (QoLCompendium.mainConfig.NoNaturalBossSpawns)
            {
                WorldGen.spawnEye = false;
                WorldGen.spawnHardBoss = 0;
            }
        }
    }

}
