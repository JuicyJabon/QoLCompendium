using QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Potions;

namespace QoLCompendium.Core.PermanentBuffSystems.Effects.Vanilla.Upgraded
{
    public class DefenseEffect : IPermanentBuff
    {
        internal override void ApplyEffect(PermanentBuffPlayer player)
        {
            new EnduranceEffect().ApplyEffect(player);
            new ExquisitelyStuffedEffect().ApplyEffect(player);
            new HeartreachEffect().ApplyEffect(player);
            new InfernoEffect().ApplyEffect(player);
            new IronskinEffect().ApplyEffect(player);
            new LifeforceEffect().ApplyEffect(player);
            new ObsidianSkinEffect().ApplyEffect(player);
            new RegenerationEffect().ApplyEffect(player);
            new ThornsEffect().ApplyEffect(player);
            new WarmthEffect().ApplyEffect(player);
        }
    }
}
