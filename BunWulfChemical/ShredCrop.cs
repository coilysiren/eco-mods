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

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class ShredCropRecipe : RecipeFamily
    {
        public ShredCropRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "ShredCrop",
                    Localizer.DoStr("Shred Crop"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Crop", 1, true),
                    },
                    new CraftingElement[] {
                        new CraftingElement<PlantFibersItem>(1),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(ShredCropRecipe),
                0.2f,
                typeof(FarmingSkill),
                typeof(FarmingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Shred Crop"), typeof(ShredCropRecipe));
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
