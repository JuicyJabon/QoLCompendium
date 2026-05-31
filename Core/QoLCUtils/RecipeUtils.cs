namespace QoLCompendium.Core.QoLCUtils
{
    public static class RecipeUtils
    {
        public static Condition ItemToggled(string displayText, Func<bool> toggle)
        {
            return new Condition(Language.GetTextValue(displayText), toggle);
        }

        public static Recipe GetItemRecipe(Func<bool> toggle, int itemType, int amount = 1, string displayText = "")
        {
            Recipe obj = Recipe.Create(itemType, amount);
            obj.AddCondition(ItemToggled(displayText, toggle));
            return obj;
        }

        public static void CreateBagRecipe(int[] items, int bagID)
        {
            for (int i = 0; i < items.Length; i++)
            {
                CreateSimpleRecipe(bagID, items[i], TileID.WorkBenches, 1, 1, true, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.BossBags", () => QoLCompendium.mainConfig.EasierRecipes));
            }
        }

        public static void CreateCrateRecipe(int result, int crateID, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateHardmodeRecipe(int result, int crateHardmodeID, int crateCount, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, result, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void CreateCrateWithKeyRecipe(int item, int crateID, int crateHardmodeID, int crateCount, int keyID, params Condition[] conditions)
        {
            Recipe recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateID, crateCount);
            recipe.AddIngredient(keyID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();

            recipe = GetItemRecipe(() => QoLCompendium.mainConfig.EasierRecipes, item, 1, "Mods.QoLCompendium.ItemToggledConditions.Crates");
            recipe.AddIngredient(crateHardmodeID, crateCount);
            recipe.AddIngredient(keyID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            recipe.AddTile(TileID.WorkBenches);
            recipe.DisableDecraft();
            recipe.Register();
        }

        public static void ConversionRecipe(int item1, int item2, int station)
        {
            //Item 1 -> Item 2
            CreateSimpleRecipe(item1, item2, station, 1, 1, false, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));

            //Item 2 -> Item 1
            CreateSimpleRecipe(item2, item1, station, 1, 1, false, false, ItemToggled("Mods.QoLCompendium.ItemToggledConditions.ItemConversions", () => QoLCompendium.mainConfig.ItemConversions));
        }

        public static void AddBannerGroupToItemRecipe(int recipeGroupID, int resultID, int resultAmount = 1, int groupAmount = 1, params Condition[] conditions)
        {
            CreateSimpleRecipe(recipeGroupID, resultID, TileID.WorkBenches, groupAmount, resultAmount, disableDecraft: true, usesRecipeGroup: true, conditions);
        }

        public static void AddBannerToItemRecipe(int bannerItemID, int resultID, int bannerAmount = 1, int resultAmount = 1, params Condition[] conditions)
        {
            CreateSimpleRecipe(bannerItemID, resultID, TileID.WorkBenches, bannerAmount, resultAmount, disableDecraft: true, usesRecipeGroup: false, conditions);
        }

        public static void CreateLoopingRecipe(int[] items, int tileType)
        {
            List<int> newItems = [];
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] != 0)
                    newItems.Add(items[j]);
            }

            int firstID = Common.GetFirstNonZeroValue(newItems.ToArray());
            int lastID = Common.GetLastNonZeroValue(newItems.ToArray());

            for (int i = 0; i < newItems.Count; i++)
            {
                if (i >= newItems.Count - 1)
                    CreateSimpleRecipe(lastID, firstID, tileType);
                else
                    CreateSimpleRecipe(newItems[i], newItems[i + 1], tileType);
            }
        }

        public static void CreateSimpleRecipe(int ingredientID, int resultID, int tileID, int ingredientAmount = 1, int resultAmount = 1, bool disableDecraft = false, bool usesRecipeGroup = false, params Condition[] conditions)
        {
            Recipe recipe = Recipe.Create(resultID, resultAmount);
            if (usesRecipeGroup)
                recipe.AddRecipeGroup(ingredientID, ingredientAmount);
            else
                recipe.AddIngredient(ingredientID, ingredientAmount);
            recipe.AddTile(tileID);
            foreach (Condition condition in conditions)
                recipe.AddCondition(condition);
            if (disableDecraft)
                recipe.DisableDecraft();
            recipe.Register();
        }

        public static void TransmuteItems(int[] items)
        {
            List<int> newItems = [];
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] != 0)
                    newItems.Add(items[j]);
            }

            int firstID = Common.GetFirstNonZeroValue(newItems.ToArray());
            int lastID = Common.GetLastNonZeroValue(newItems.ToArray());

            for (int i = 0; i < newItems.Count; i++)
            {
                if (i >= newItems.Count - 1)
                    ItemID.Sets.ShimmerTransformToItem[lastID] = firstID;
                else
                {
                    if (newItems[i] != ItemID.None && newItems[i + 1] != ItemID.None)
                    {
                        ItemID.Sets.ShimmerTransformToItem[newItems[i]] = newItems[i + 1];
                    }
                }
            }
        }

        public static void CombinedPermanentBuffRecipe(int[] ingredients, int result)
        {
            Recipe r = GetItemRecipe(() => QoLCompendium.itemConfig.PermanentBuffs, result, 1, "Mods.QoLCompendium.ItemToggledConditions.ItemEnabled");
            foreach (int ingredient in ingredients)
                r.AddIngredient(ingredient);
            r.AddTile(TileID.CookingPots);
            r.Register();
        }
    }
}
