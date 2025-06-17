using System.Reflection;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.Utilities;

namespace QoLCompendium.Core.Changes.TileChanges
{
    public class MoreTreeDrops : ModSystem
    {
        public override void Load()
        {
            On_WorldGen.SetGemTreeDrops += GemAlways;
            ShakeTreeTweak.Load();
        }

        public override void Unload()
        {
            On_WorldGen.SetGemTreeDrops -= GemAlways;
        }

        private void GemAlways(On_WorldGen.orig_SetGemTreeDrops orig, int gemType, int seedType, Tile tileCache, ref int dropItem, ref int secondaryItem)
        {
            if (QoLCompendium.mainConfig.TreesDropMoreWhenShook)
            {
                dropItem = gemType;
                secondaryItem = seedType;
            }
            else
            {
                orig.Invoke(gemType, seedType, tileCache, ref dropItem, ref secondaryItem);
            }
        }

        private class ShakeTreeTweak
        {
            private class ShakeTreeItem : GlobalItem
            {
                public override void OnSpawn(Item item, IEntitySource source)
                {
                    if (_isShakingTree && source is EntitySource_ShakeTree)
                        _hasItemDropped = true;
                }
            }

            private static bool _isShakingTree;
            private static bool _hasItemDropped;

            public static void Load()
            {
                FieldInfo numShakes = typeof(WorldGen).GetField("numTreeShakes", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo maxShakes = typeof(WorldGen).GetField("maxTreeShakes", BindingFlags.NonPublic | BindingFlags.Static);

                FieldInfo shakeX = typeof(WorldGen).GetField("treeShakeX", BindingFlags.NonPublic | BindingFlags.Static);
                FieldInfo shakeY = typeof(WorldGen).GetField("treeShakeY", BindingFlags.NonPublic | BindingFlags.Static);

                On_WorldGen.ShakeTree += (orig, i, j) =>
                {
                    if (!QoLCompendium.mainConfig.TreesDropMoreWhenShook)
                    {
                        orig(i, j);
                        return;
                    }

                    _isShakingTree = true;
                    _hasItemDropped = false;

                    bool treeShaken = false;

                    WorldGen.GetTreeBottom(i, j, out var x, out var y);
                    for (int k = 0; k < (int)numShakes.GetValue(null); k++)
                    {
                        if (shakeX.GetValue(null).Equals(k) && shakeY.GetValue(null).Equals(k))
                        {
                            treeShaken = true;
                            break;
                        }
                    }

                    orig(i, j);

                    _isShakingTree = false;

                    if ((int)numShakes.GetValue(null) == (int)maxShakes.GetValue(null) || _hasItemDropped || treeShaken)
                        return;

                    TreeTypes treeType = WorldGen.GetTreeType(Main.tile[x, y].TileType);
                    if (treeType == TreeTypes.None)
                        return;

                    y--;
                    while (y > 10 && Main.tile[x, y].HasTile && TileID.Sets.IsShakeable[Main.tile[x, y].TileType])
                    {
                        y--;
                    }

                    y++;
                    if (!WorldGen.IsTileALeafyTreeTop(x, y) || Collision.SolidTiles(x - 2, x + 2, y - 2, y + 2))
                        return;

                    int fruit = GetShakeTreeFruit(treeType);
                    if (fruit > -1)
                        Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, 16, 16, fruit);
                };
            }
        }

        public static int GetShakeTreeFruit(TreeTypes treeType)
        {
            switch (treeType)
            {
                case TreeTypes.Forest:
                    WeightedRandom<short> weightedRandom = new();
                    weightedRandom.Add(ItemID.Apple);
                    weightedRandom.Add(ItemID.Apricot);
                    weightedRandom.Add(ItemID.Peach);
                    weightedRandom.Add(ItemID.Grapefruit);
                    weightedRandom.Add(ItemID.Lemon);
                    return weightedRandom.Get();
                case TreeTypes.Snow:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.Plum : ItemID.Cherry;
                case TreeTypes.Jungle:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.Mango : ItemID.Pineapple;
                case TreeTypes.Palm or TreeTypes.PalmCorrupt or TreeTypes.PalmCrimson or TreeTypes.PalmHallowed:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.Coconut : ItemID.Banana;
                case TreeTypes.Corrupt or TreeTypes.PalmCorrupt:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.Elderberry : ItemID.BlackCurrant;
                case TreeTypes.Crimson or TreeTypes.PalmCrimson:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.BloodOrange : ItemID.Rambutan;
                case TreeTypes.Hallowed or TreeTypes.PalmHallowed:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.Dragonfruit : ItemID.Starfruit;
                case TreeTypes.Ash:
                    return !WorldGen.genRand.NextBool(2) ? ItemID.SpicyPepper : ItemID.Pomegranate;
                default:
                    return -1;
            }
        }
    }
}
