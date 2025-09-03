using QoLCompendium.Content.Items.Dedicated;
using QoLCompendium.Core.PermanentBuffSystems;

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

    public class PermanentBuffCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "PermanentBuffCommand";

        public override string Description => "displays buff data";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Main.NewText(Enum.GetValues<PermanentBuffPlayer.PermanentSpiritClassicBuffs>().Length);
            for (int i = 0; i < Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools.Length; i++)
                Main.NewText(Main.LocalPlayer.GetModPlayer<PermanentBuffPlayer>().PermanentSpiritClassicBuffsBools.ToString() + " " + i);
        }
    }
}
