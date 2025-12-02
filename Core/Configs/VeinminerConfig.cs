using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace QoLCompendium.Core.Configs
{
    public class VeinminerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.QoLCompendium.ConfigHeaders.Veinminer")]

        [DefaultValue(true)]
        public bool VeinMiner { get; set; }

        [DefaultValue(3)]
        [Range(0, 15)]
        public int VeinMinerSpeed { get; set; }

        [DefaultValue(120)]
        [Range(1, 750)]
        public int VeinMinerTileLimit { get; set; }

        [DefaultListValue("Terraria:")]
        public HashSet<string> VeinMinerTileWhitelist =
        [
            "Terraria:" + TileID.Search.GetName(6),
                "Terraria:" + TileID.Search.GetName(7),
                "Terraria:" + TileID.Search.GetName(8),
                "Terraria:" + TileID.Search.GetName(9),
                "Terraria:" + TileID.Search.GetName(22),
                "Terraria:" + TileID.Search.GetName(37),
                "Terraria:" + TileID.Search.GetName(40),
                "Terraria:" + TileID.Search.GetName(56),
                "Terraria:" + TileID.Search.GetName(58),
                "Terraria:" + TileID.Search.GetName(63),
                "Terraria:" + TileID.Search.GetName(64),
                "Terraria:" + TileID.Search.GetName(65),
                "Terraria:" + TileID.Search.GetName(66),
                "Terraria:" + TileID.Search.GetName(67),
                "Terraria:" + TileID.Search.GetName(68),
                "Terraria:" + TileID.Search.GetName(107),
                "Terraria:" + TileID.Search.GetName(108),
                "Terraria:" + TileID.Search.GetName(111),
                "Terraria:" + TileID.Search.GetName(123),
                "Terraria:" + TileID.Search.GetName(162),
                "Terraria:" + TileID.Search.GetName(166),
                "Terraria:" + TileID.Search.GetName(167),
                "Terraria:" + TileID.Search.GetName(168),
                "Terraria:" + TileID.Search.GetName(169),
                "Terraria:" + TileID.Search.GetName(178),
                "Terraria:" + TileID.Search.GetName(204),
                "Terraria:" + TileID.Search.GetName(211),
                "Terraria:" + TileID.Search.GetName(221),
                "Terraria:" + TileID.Search.GetName(222),
                "Terraria:" + TileID.Search.GetName(223),
                "Terraria:" + TileID.Search.GetName(224),
                "Terraria:" + TileID.Search.GetName(404),
                "Terraria:" + TileID.Search.GetName(407),
                "Terraria:" + TileID.Search.GetName(408),
                "Terraria:" + TileID.Search.GetName(481),
                "Terraria:" + TileID.Search.GetName(482),
                "Terraria:" + TileID.Search.GetName(483),
                "Terraria:" + TileID.Search.GetName(48)
        ];

        public override void OnLoaded()
        {
            QoLCompendium.veinminerConfig = this;
        }
    }
}
