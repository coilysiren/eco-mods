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
    [RequiresSkill(typeof(TailoringSkill), 4)]
    public partial class MeldedPlasticThreadRecipe : RecipeFamily
    {
        public MeldedPlasticThreadRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "MeldedPlasticThread",
                    Localizer.DoStr("Melded Plastic Thread"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PlasticItem), 5, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                        new IngredientElement(typeof(CottonThreadItem), 2, true),
                    },
                    new CraftingElement[] {
                        new CraftingElement<NylonThreadItem>(2),
                        new CraftingElement<PlantFibersItem>(typeof(TailoringSkill), 2, typeof(TailoringLavishResourcesTalent)),
                    }
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(
                typeof(MeldedPlasticThreadRecipe),
                4,
                typeof(TailoringSkill),
                typeof(TailoringFocusedSpeedTalent)
            );
            this.Initialize(Localizer.DoStr("Melded Plastic Thread"), typeof(MeldedPlasticThreadRecipe));
            CraftingComponent.AddRecipe(typeof(SpinMelterObject), this);
        }
    }
}
