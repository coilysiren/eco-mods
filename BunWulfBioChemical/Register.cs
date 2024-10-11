using Eco.Core.Plugins.Interfaces;

public class BunWulfBioChemical : IModInit
{
    public static ModRegistration Register() => new()
    {
        ModName = "BunWulfBioChemical",
        ModDescription = "An Eco mod that gets Cutting Edge Cooking into a playable state. All of the Oil Drilling recipes have been replaced with Cutting Edge Cooking variants. These variants generally use fat, a laboratory, and are slow but low calorie cost.",
        ModDisplayName = "BunWulf BioChemical",
    };
}
