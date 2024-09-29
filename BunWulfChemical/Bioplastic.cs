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
    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 6)]
    public partial class BioplasticRecipe : RecipeFamily
    {
        public BioplasticRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Bioplastic",
                    Localizer.DoStr("Bioplastic"),
                    new IngredientElement[]
                    {
                        new IngredientElement("Fat", 5, true),
                        new IngredientElement("Vegetable", 5, true),
                    },
                    new CraftingElement[] {
                        new CraftingElement<PlasticItem>(2),
                        new CraftingElement<OilItem>(typeof(CuttingEdgeCookingSkill), 2, typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    }
                )
            };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(BioplasticRecipe),
                1,
                typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Bioplastic"), typeof(BioplasticRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}
