using Terraria.Chat;

namespace QoLCompendium.Core.Changes.WorldChanges
{
    public class DisableMeteors : ModSystem
    {
        public override void Load() => On_WorldGen.dropMeteor += StopMeteor;

        public override void Unload() => On_WorldGen.dropMeteor -= StopMeteor;

        private void StopMeteor(On_WorldGen.orig_dropMeteor orig)
        {
            if (!QoLCompendium.mainConfig.NoMeteorSpawns)
            {
                orig();
                return;
            }

            ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Mods.QoLCompendium.Messages.MeteorStopped"), Color.White);

            int activePlayerCount = Main.player.Where(player => player.active).ToArray().Length;

            for (int i = 0; i < Main.player.Length; i++)
            {
                Player player = Main.player[i];
                if (!player.active) continue;

                int amount = Main.rand.Next(400, 500) / activePlayerCount;
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemID.Meteorite, amount);

                ChatHelper.SendChatMessageToClient(NetworkText.FromKey("Mods.QoLCompendium.Messages.MeteoriteGiven", amount), Color.White, i);
            }
        }
    }
}
