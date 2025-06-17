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

    public class DisplaySavedBuffData : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "displaySavedBuffData";

        public override string Description => "Displays all saved buff bools";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            for (int i = 0; i < PermanentBuffPlayer.PermanentBuffsBools.Length; i++)
                Main.NewText("Buff: " + Enum.GetName(typeof(PermanentBuffPlayer.PermanentBuffs), i) + " | Value: " + PermanentBuffPlayer.PermanentBuffsBools[i] + " | Saved at: " + i.ToString());
        }
    }
}
