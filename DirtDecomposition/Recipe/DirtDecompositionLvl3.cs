﻿namespace Eco.Mods.TechTree
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Gameplay.Items.Recipes;

    [RequiresSkill(typeof(MiningSkill), 7)]
    public partial class DirtProcessingLvl3Recipe : RecipeFamily
    {
        public DirtProcessingLvl3Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "DirtProcessingLvl3",
                displayName: Localizer.DoStr("Dirt Processing Lvl 3"),
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(DirtItem), 10, true),
                },
                items: new List<CraftingElement>
                {
                    new CraftingElement<ClayItem>(2),
                    new CraftingElement<SandItem>(7),
                    new CraftingElement<CompostItem>(1),
                }
            );
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(MiningSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                beneficiary: typeof(DirtProcessingLvl3Recipe),
                start: 1,
                skillType: typeof(MiningSkill)
            );
            this.Initialize(
                displayText: Localizer.DoStr("Dirt Processing Lvl 3"),
                recipeType: typeof(DirtProcessingLvl3Recipe)
            );
            CraftingComponent.AddRecipe(
                tableType: typeof(SensorBasedBeltSorterObject),
                recipe: this
            );
        }
    }
}
