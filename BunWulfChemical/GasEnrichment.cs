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
    [RequiresSkill(typeof(OilDrillingSkill), 4)]
    public partial class GasEnrichmentRecipe : RecipeFamily
    {
        public GasEnrichmentRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "GasEnrichment",
                    Localizer.DoStr("Gasoline Enrichment"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(GasolineItem), 1, true),
                        new IngredientElement("Coal", 10, typeof(OilDrillingSkill), typeof(OilDrillingLavishResourcesTalent)),
                    },
                    new CraftingElement[] { new CraftingElement<PetroleumItem>(1) }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(100, typeof(OilDrillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(GasEnrichmentRecipe),
                1,
                typeof(OilDrillingSkill),
                typeof(OilDrillingFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Gasoline Enrichment"), typeof(GasEnrichmentRecipe));
            CraftingComponent.AddRecipe(typeof(OilRefineryObject), this);
        }
    }
}
