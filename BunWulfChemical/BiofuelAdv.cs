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
    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 7)]
    public partial class BiofuelAdvRecipe : RecipeFamily
    {
        public BiofuelAdvRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "BiofuelAdv",
                    Localizer.DoStr("Biofuel 30% Ethanol"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PlasticItem), 40, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                        new IngredientElement(typeof(EthanolItem), 10, true),
                        new IngredientElement("Fat", 30, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    },
                    new CraftingElement[] {
                        new CraftingElement<BiodieselItem>(5),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(400, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(BiofuelAdvRecipe),
                1,
                typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Biofuel 30% Ethanol"), typeof(BiofuelAdvRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}
