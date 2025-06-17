using MonoMod.Cil;
using Terraria.GameContent.Events;

namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class DisableCredits : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            ModLoader.TryGetMod("VanillaQoL", out Mod VanillaQoL);
            return VanillaQoL == null;
        }

        public override void Load()
        {
            IL_NPC.OnGameEventClearedForTheFirstTime += NoCredits;
        }

        public override void Unload()
        {
            IL_NPC.OnGameEventClearedForTheFirstTime -= NoCredits;
        }

        public static void NoCredits(ILContext il)
        {
            var c = new ILCursor(il);
            c.GotoNext(MoveType.Before, i => i.MatchCall<CreditsRollEvent>("TryStartingCreditsRoll"));
            c.Remove();
        }
    }
}
