using QoLCompendium.Core.PermanentBuffSystems.Effects.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Upgraded
{
    public class VisionEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new BiomeSightEffect().ApplyEffect(player);
            new DangersenseEffect().ApplyEffect(player);
            new HunterEffect().ApplyEffect(player);
            new InvisibilityEffect().ApplyEffect(player);
            new NightOwlEffect().ApplyEffect(player);
            new ShineEffect().ApplyEffect(player);
            new SpelunkerEffect().ApplyEffect(player);
        }
    }
}
