global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using ReLogic.Content;
global using System.Reflection;
global using Terraria;
global using Terraria.GameContent;
global using Terraria.ID;
global using Terraria.ModLoader;
using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using HookList = Terraria.ModLoader.Core.HookList<Terraria.ModLoader.GlobalNPC>;
using OnChest = On.Terraria.Chest;

namespace QoLCompendium.UI.ShopExpander
{
    internal static class AddShopPatch
    {
        public static void Load()
        {
            OnChest.AddItemToShop += Prefix;
        }

        private static int Prefix(OnChest.orig_AddItemToShop orig, Chest self, Item newItem)
        {
            if (self != Main.instance.shop[Main.npcShop] || QoLCompendium.ActiveShop == null)
            {
                return orig(self, newItem);
            }

            var stack = Main.shopSellbackHelper.Remove(newItem);

            if (stack >= newItem.stack)
            {
                return 0;
            }

            var insertItem = newItem.Clone();
            insertItem.favorited = false;
            insertItem.buyOnce = true;
            insertItem.stack -= stack;

            QoLCompendium.Buyback.AddItem(insertItem);
            QoLCompendium.ActiveShop.RefreshFrame();

            return 0;
        }
    }

    internal static class LeftRightClickPatch
    {
        public static void Load()
        {
            On.Terraria.UI.ItemSlot.HandleShopSlot += HandleShopSlot;
        }

        private static void HandleShopSlot(On.Terraria.UI.ItemSlot.orig_HandleShopSlot orig, Item[] inv, int slot, bool rightClickIsValid, bool leftClickIsValid)
        {
            if (leftClickIsValid && Main.mouseLeft && ClickedPageArrow(inv, slot, false))
            {
                return;
            }

            if (rightClickIsValid && Main.mouseRight && ClickedPageArrow(inv, slot, true))
            {
                return;
            }

            orig(inv, slot, rightClickIsValid, leftClickIsValid);
        }

        private static bool ClickedPageArrow(Item[] inv, int slot, bool skip)
        {
            if (QoLCompendium.ActiveShop == null)
            {
                return false;
            }

            if (inv[slot].type == QoLCompendium.ArrowLeft.Item.type)
            {
                if (skip)
                {
                    QoLCompendium.ActiveShop.MoveFirst();
                }
                else if (Main.mouseLeftRelease)
                {
                    QoLCompendium.ActiveShop.MoveLeft();
                }

                return true;
            }

            if (inv[slot].type == QoLCompendium.ArrowRight.Item.type)
            {
                if (skip)
                {
                    QoLCompendium.ActiveShop.MoveLast();
                }
                else if (Main.mouseLeftRelease)
                {
                    QoLCompendium.ActiveShop.MoveRight();
                }

                return true;
            }

            return false;
        }
    }

    internal static class SetupShopPatch
    {
        private const int maxProvisionTries = 3;

        private static readonly FieldInfo HookSetupShopFieldInfo = typeof(NPCLoader).GetField("HookSetupShop", BindingFlags.NonPublic | BindingFlags.Static)!;
        private static readonly FieldInfo GlobalNPCsFieldInfo = typeof(NPCLoader).GetField("globalNPCs", BindingFlags.NonPublic | BindingFlags.Static)!;
        private static readonly FieldInfo ShopToNPCFieldInfo = typeof(NPCLoader).GetField("shopToNPC", BindingFlags.NonPublic | BindingFlags.Static)!;
        private static readonly MethodInfo SetupShopMethodInfo = typeof(NPCLoader).GetMethod(nameof(NPCLoader.SetupShop), BindingFlags.Public | BindingFlags.Static)!;

        private static HookList HookSetupShop = null!;
        private static List<GlobalNPC> globalNPCsArray = null!;
        private static int[] shopToNpcs = null!;

        public static void Load()
        {
            HookSetupShop = (HookList)HookSetupShopFieldInfo.GetValue(null)!;
            globalNPCsArray = (List<GlobalNPC>)GlobalNPCsFieldInfo.GetValue(null)!;
            shopToNpcs = (int[])ShopToNPCFieldInfo.GetValue(null)!;

            HookEndpointManager.Add(SetupShopMethodInfo, (hook_SetupShop)Prefix);
        }

        public static void Unload()
        {
            HookSetupShop = null!;
            globalNPCsArray = null!;
            shopToNpcs = null!;

            HookEndpointManager.Remove(SetupShopMethodInfo, (hook_SetupShop)Prefix);
        }

        private static void Prefix(orig_SetupShop orig, int type, Chest shop, ref int nextSlot)
        {
            var vanillaShop = shop.item;
            QoLCompendium.ResetAndBindShop();
            var dyn = new DynamicPageProvider(vanillaShop, null, ProviderPriority.Vanilla);
            var modifiers = new List<GlobalNPC>();

            if (type < shopToNpcs.Length)
            {
                type = shopToNpcs[type];
            }
            else
            {
                var npc = NPCLoader.GetNPC(type);
                if (npc != null)
                {
                    DoSetupFor(shop, dyn, "ModNPC", npc.Mod, npc, delegate (Chest c)
                    {
                        var zero = 0;
                        npc.SetupShop(c, ref zero);
                    });
                }
            }

            foreach (var globalNPC in HookSetupShop.Enumerate(globalNPCsArray))
            {
                if (QoLCompendium.ModifierOverrides.GetValue(globalNPC))
                {
                    modifiers.Add(globalNPC);
                }
                else
                {
                    DoSetupFor(shop, dyn, "GloabalNPC", globalNPC.Mod, globalNPC, delegate (Chest c)
                    {
                        var zero = 0;
                        globalNPC.SetupShop(type, c, ref zero);
                    });
                }
            }

            dyn.Compose();

            foreach (var item in modifiers)
            {
                try
                {
                    var max = dyn.ExtendedItems.Length;
                    item.SetupShop(type, MakeFakeChest(dyn.ExtendedItems), ref max);
                }
                catch (Exception e)
                {
                    LogAndPrint("modifier GlobalNPC", item.Mod, item, e);
                }
            }

            QoLCompendium.ActiveShop.AddPage(dyn);
            QoLCompendium.ActiveShop.RefreshFrame();
        }

        private static void DoSetupFor(Chest shop, DynamicPageProvider mainDyn, string typeText, Mod mod, object obj, Action<Chest> setup)
        {
            try
            {
                var methods = QoLCompendium.LegacyMultipageSetupMethods.GetValue(obj);
                if (methods != null)
                {
                    foreach (var item in methods)
                    {
                        var dynPage = new DynamicPageProvider(shop.item, item.name, item.priority);
                        QoLCompendium.ActiveShop.AddPage(dynPage);
                        item.setup?.Invoke();
                        DoSetupSingle(dynPage, obj, setup);
                        dynPage.Compose();
                    }
                }
                else
                {
                    DoSetupSingle(mainDyn, obj, setup);
                }
            }
            catch (Exception e)
            {
                LogAndPrint(typeText, mod, obj, e);
            }
        }

        private static void DoSetupSingle(DynamicPageProvider dyn, object obj, Action<Chest> setup)
        {
            var sizeToTry = QoLCompendium.ProvisionOverrides.GetValue(obj);
            var numMoreTries = maxProvisionTries;
            var exceptions = new List<Exception>(maxProvisionTries);

            var retry = true;
            while (retry)
            {
                retry = false;
                Chest provision = null;
                try
                {
                    provision = ProvisionChest(dyn, obj, sizeToTry);
                    setup(provision);
                }
                catch (IndexOutOfRangeException e)
                {
                    exceptions.Add(e);
                    if (--numMoreTries > 0)
                    {
                        retry = true;
                        if (provision != null)
                        {
                            dyn.UnProvision(provision.item);
                        }

                        sizeToTry *= 2;
                    }
                    else
                    {
                        throw new AggregateException("Failed setup after trying with " + sizeToTry + " slots", exceptions);
                    }
                }
            }
        }

        private static Chest MakeFakeChest(Item[] items)
        {
            var fake = new Chest
            {
                item = items
            };
            return fake;
        }

        private static Chest ProvisionChest(DynamicPageProvider dyn, object target, int size)
        {
            return MakeFakeChest(dyn.Provision(size, QoLCompendium.NoDistinctOverrides.GetValue(target), QoLCompendium.VanillaCopyOverrrides.GetValue(target)));
        }   

        private static void LogAndPrint(string type, Mod mod, object obj, Exception e)
        {
            if (QoLCompendium.IgnoreErrors.GetValue(obj))
            {
                return;
            }

            QoLCompendium.IgnoreErrors.SetValue(obj, true);

            var modName = "N/A";
            if (mod != null && mod.DisplayName != null)
            {
                modName = mod.DisplayName;
            }

            var message = string.Format("Shop Expander failed to load {0} from mod {1}.", type, modName);
            Main.NewText(message, Color.Red);
            Main.NewText("See log for more info. If this error persists, please consider reporting it to the author of the mod mentioned above.", Color.Red);
            var logger = QoLCompendium.Instance.Logger;
            logger.Error("--- SHOP EXPANDER ERROR ---");
            logger.Error(message);
            logger.Error(e.ToString());
            logger.Error("--- END SHOP EXPANDER ERROR ---");
        }

        private delegate void orig_SetupShop(int type, Chest shop, ref int nextSlot);

        private delegate void hook_SetupShop(orig_SetupShop orig, int type, Chest shop, ref int nextSlot);
    }
}
