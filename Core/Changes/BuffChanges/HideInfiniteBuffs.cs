using Terraria.DataStructures;

namespace QoLCompendium.Core.Changes.BuffChanges
{
    public class HideInfiniteBuffs : GlobalBuff
    {
        public override bool PreDraw(SpriteBatch spriteBatch, int type, int buffIndex, ref BuffDrawParams drawParams)
        {
            if (!QoLCompendium.mainConfig.HideBuffs)
                return base.PreDraw(spriteBatch, type, buffIndex, ref drawParams);

            if (!HideBuffTypes(type))
                return base.PreDraw(spriteBatch, type, buffIndex, ref drawParams);

            drawParams.TextPosition = new Vector2(-100);
            drawParams.Position = new Vector2(-100);
            drawParams.MouseRectangle = Rectangle.Empty;
            return false;
        }

        public static bool HideBuffTypes(int type)
        {
            if (Main.LocalPlayer.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(type))
                return true;
            return false;
        }
    }

    public class HideBuffsPlayer : ModPlayer
    {
        public override void PostUpdateBuffs()
        {
            if (!QoLCompendium.mainConfig.HideBuffs)
                return;

            HashSet<int> reapplyBuffs = [];
            HashSet<int> otherBuffs = [];

            for (int i = 0; i < Player.CountBuffs(); i++)
            {
                if (!Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(Player.buffType[i]))
                    otherBuffs.Add(Player.buffType[i]);

                if (Player.GetModPlayer<QoLCPlayer>().activeBuffs.Contains(Player.buffType[i]))
                    reapplyBuffs.Add(Player.buffType[i]);
            }

            foreach (int buff in reapplyBuffs)
            {
                Player.ClearBuff(buff);
                Player.AddBuff(buff, 2);
            }
        }
    }
}
