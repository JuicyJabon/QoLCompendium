using ThoriumMod.Utilities;

namespace QoLCompendium.Core.Changes.ModChanges.ModItemChanges
{
    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class ThoriumRemoveExhaustion : ModPlayer
    {
        public override void PreUpdate()
        {
            if (QoLCompendium.crossModConfig.RemoveThoriumExhaustion)
            {
                Player.GetThoriumPlayer().throwerExhaustion = 0f;
                Player.GetThoriumPlayer().throwerExhaustionMax = 0;
                Player.GetThoriumPlayer().throwerExhaustionPenalty = false;
            }
        }
    }

    [JITWhenModsEnabled(ModConditions.thoriumName)]
    [ExtendsFromMod(ModConditions.thoriumName)]
    public class ThoriumRemoveExhaustionUI : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            if (QoLCompendium.crossModConfig.RemoveThoriumExhaustion)
                layers[layers.FindIndex(0, x => x.Name == "ThoriumMod: Thrower Exhaustion Bar")].Active = false;
        }
    }
}
