namespace QoLCompendium.Core
{
    public static class CoinStacker
    {
        public static int CoinType(int item)
        {
            if (item == 71)
            {
                return 1;
            }
            if (item == 72)
            {
                return 2;
            }
            if (item == 73)
            {
                return 3;
            }
            if (item == 74)
            {
                return 4;
            }
            return 0;
        }

        public static void Pig(Item[] pInv, Item[] cInv)
        {
            int[] array = new int[4];
            List<int> list = new();
            List<int> list2 = new();
            bool flag = false;
            int[] array2 = new int[40];
            for (int i = 0; i < cInv.Length; i++)
            {
                array2[i] = -1;
                if (cInv[i].stack < 1 || cInv[i].type <= ItemID.None)
                {
                    list2.Add(i);
                    cInv[i] = new Item();
                }
                if (cInv[i] != null && cInv[i].stack > 0)
                {
                    int num = CoinType(cInv[i].type);
                    array2[i] = num - 1;
                    if (num > 0)
                    {
                        array[num - 1] += cInv[i].stack;
                        list2.Add(i);
                        cInv[i] = new Item();
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                return;
            }
            for (int j = 0; j < pInv.Length; j++)
            {
                if (j != 58 && pInv[j] != null && pInv[j].stack > 0 && !pInv[j].favorited)
                {
                    int num2 = CoinType(pInv[j].type);
                    if (num2 > 0)
                    {
                        array[num2 - 1] += pInv[j].stack;
                        list.Add(j);
                        pInv[j] = new Item();
                    }
                }
            }
            for (int k = 0; k < 3; k++)
            {
                while (array[k] >= 100)
                {
                    array[k] -= 100;
                    array[k + 1]++;
                }
            }
            for (int l = 0; l < 40; l++)
            {
                if (array2[l] >= 0 && cInv[l].type == ItemID.None)
                {
                    int num3 = l;
                    int num4 = array2[l];
                    if (array[num4] > 0)
                    {
                        cInv[num3].SetDefaults(71 + num4);
                        cInv[num3].stack = array[num4];
                        if (cInv[num3].stack > cInv[num3].maxStack)
                        {
                            cInv[num3].stack = cInv[num3].maxStack;
                        }
                        array[num4] -= cInv[num3].stack;
                        array2[l] = -1;
                    }
                    list2.Remove(num3);
                }
            }
            for (int m = 0; m < 40; m++)
            {
                if (array2[m] >= 0 && cInv[m].type == ItemID.None)
                {
                    int num5 = m;
                    int n = 3;
                    while (n >= 0)
                    {
                        if (array[n] > 0)
                        {
                            cInv[num5].SetDefaults(71 + n);
                            cInv[num5].stack = array[n];
                            if (cInv[num5].stack > cInv[num5].maxStack)
                            {
                                cInv[num5].stack = cInv[num5].maxStack;
                            }
                            array[n] -= cInv[num5].stack;
                            array2[m] = -1;
                            break;
                        }
                        if (array[n] == 0)
                        {
                            n--;
                        }
                    }
                    if (Main.netMode == NetmodeID.MultiplayerClient && Main.player[Main.myPlayer].chest > -1)
                    {
                        NetMessage.SendData(MessageID.SyncChestItem, -1, -1, null, Main.player[Main.myPlayer].chest, num5, 0f, 0f, 0, 0, 0);
                    }
                    list2.Remove(num5);
                }
            }
            while (list2.Count > 0)
            {
                int num6 = list2[0];
                int num7 = 3;
                while (num7 >= 0)
                {
                    if (array[num7] > 0)
                    {
                        cInv[num6].SetDefaults(71 + num7);
                        cInv[num6].stack = array[num7];
                        if (cInv[num6].stack > cInv[num6].maxStack)
                        {
                            cInv[num6].stack = cInv[num6].maxStack;
                        }
                        array[num7] -= cInv[num6].stack;
                        break;
                    }
                    if (array[num7] == 0)
                    {
                        num7--;
                    }
                }
                if (Main.netMode == NetmodeID.MultiplayerClient && Main.player[Main.myPlayer].chest > -1)
                {
                    NetMessage.SendData(MessageID.SyncChestItem, -1, -1, null, Main.player[Main.myPlayer].chest, list2[0], 0f, 0f, 0, 0, 0);
                }
                list2.RemoveAt(0);
            }
            int num8 = 3;
            while (num8 >= 0 && list.Count > 0)
            {
                int num9 = list[0];
                if (array[num8] > 0)
                {
                    pInv[num9].SetDefaults(71 + num8);
                    pInv[num9].stack = array[num8];
                    if (pInv[num9].stack > pInv[num9].maxStack)
                    {
                        pInv[num9].stack = pInv[num9].maxStack;
                    }
                    array[num8] -= pInv[num9].stack;
                    list.RemoveAt(0);
                }
                if (array[num8] == 0)
                {
                    num8--;
                }
            }
        }

        static CoinStacker()
        {
            HashSet<int> hashSet = new()
            {
                71,
                72,
                73,
                74
            };
            CoinTypes = hashSet;
            List<int> list = new()
            {
                0,
                1,
                100,
                10000,
                1000000
            };
            CoinValues = list;
        }

        #pragma warning disable CA2211
        public static HashSet<int> CoinTypes;
        public static List<int> CoinValues;
        public const int Copper = 1;
        public const int Silver = 100;
        public const int Gold = 10000;
        public const int Platinum = 1000000;
        #pragma warning restore CA2211
    }

    public class CoinGItem : GlobalItem
    {
        public override void UpdateInventory(Item item, Player player)
        {
            if (CoinStacker.CoinTypes.Contains(item.type) && QoLCompendium.mainConfig.AutoMoneyStack)
            {
                CoinStacker.Pig(player.inventory, player.bank.item);
            }
        }
    }
}
