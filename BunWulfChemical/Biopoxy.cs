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
    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 5)]
    public partial class BiopoxyRecipe : RecipeFamily
    {
        public BiopoxyRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Biopoxy",
                    Localizer.DoStr("Biopoxy"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PlasticItem), 5, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                        new IngredientElement("Coal", 20, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                        new IngredientElement("Fat", 10, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    },
                    new CraftingElement[] {
                        new CraftingElement<EpoxyItem>(5),
                        new CraftingElement<OilItem>(typeof(CuttingEdgeCookingSkill), 10, typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(BiopoxyRecipe),
                1,
                typeof(CuttingEdgeCookingSkill),
                typeof(CuttingEdgeCookingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Biopoxy"), typeof(BiopoxyRecipe));
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}
