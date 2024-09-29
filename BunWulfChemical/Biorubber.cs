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
    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 3)]
    public partial class BiorubberRecipe : RecipeFamily
    {
        public BiorubberRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Biorubber",
                    Localizer.DoStr("Biorubber"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CeibaLogItem), 1, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                        new IngredientElement("Fat", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    },
                    new CraftingElement[] {
                        new CraftingElement<SyntheticRubberItem>(10),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(BiorubberRecipe),
                0.3f,
                typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Biorubber"), typeof(BiorubberRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}
