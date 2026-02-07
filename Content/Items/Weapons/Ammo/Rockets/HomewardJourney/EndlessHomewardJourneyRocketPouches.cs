using ContinentOfJourney.Items.Rockets;

namespace QoLCompendium.Content.Items.Weapons.Ammo.Rockets.HomewardJourney
{
    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessMiniNukeIIIPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MiniNukeIII>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIIIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIIISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIIIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIIIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessMiniNukeIVPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MiniNukeIV>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIVRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIVSnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIVGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MiniNukeIVMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessShellIPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<ShellI>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessShellIIPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<ShellII>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessShellIIIPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<ShellIII>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIIIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessShellIVPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<ShellIV>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIVRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIVSnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIVGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellIVMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessShellVPouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<ShellV>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellVRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellVSnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellVGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "ShellVMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessT1MissilePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MissleI>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessT2MissilePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MissleII>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessT3MissilePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MissleIII>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIIRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIISnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIIGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIIIMine");
    }

    [JITWhenModsEnabled(CrossModSupport.HomewardJourney.Name)]
    [ExtendsFromMod(CrossModSupport.HomewardJourney.Name)]
    public class EndlessT4MissilePouch : RocketPouch
    {
        public override int AmmunitionItem => ModContent.ItemType<MissleIV>();
        public override int RocketProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIVRocket");
        public override int SnowmanProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIVSnowman");
        public override int GrenadeProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIVGrenade");
        public override int MineProjectile => Common.GetModProjectile(CrossModSupport.HomewardJourney.Mod, "MissleIVMine");
    }
}
