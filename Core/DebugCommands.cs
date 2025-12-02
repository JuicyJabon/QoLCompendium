using QoLCompendium.Content.Items.Dedicated;

namespace QoLCompendium.Core
{
    public class DisplayLoadedSupportedMods : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "displayLoadedMods";

        public override string Description => "Displays loaded mods that Quality of Life Compendium supports";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            foreach (KeyValuePair<string, Mod> entry in LoadModSupport.LoadedMods)
                Main.NewText(entry.Value.DisplayName + " is loaded");
        }
    }

    public class DisplayDownedBosses : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "displayDownedBosses";

        public override string Description => "Displays all downed bosses from mods that Quality of Life Compendium supports";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            for (int i = 0; i < ModConditions.DownedBoss.Length; i++)
                Main.NewText("Boss: " + Enum.GetName(typeof(ModConditions.Downed), i) + " | Downed: " + ModConditions.DownedBoss[i] + " | Saved at: " + i.ToString());
        }
    }

    public class TheConsequences : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ICannotAcceptTheConsequencesOfMyActions";

        public override string Description => "Resets THE Button";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            THEButton.used = false;
        }
    }

    public class AllEffects : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ListBuffEffects";

        public override string Description => "Lists buffs and their sort type";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            for (int i = 0; i < Common.AllEffects.Count; i++)
                Main.NewText("Buff: " + Lang.GetBuffName(Common.AllEffects.ElementAt(i).Key) + ", Type: " + Common.AllEffects.ElementAt(i).Value.EffectType);
        }
    }
}
