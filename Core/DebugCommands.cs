using QoLCompendium.Content.Items.Dedicated;

namespace QoLCompendium.Core
{
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
            THEotherButton.used = false;
        }
    }
}
