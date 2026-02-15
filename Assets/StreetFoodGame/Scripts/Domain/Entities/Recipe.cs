using System.Collections.Generic;

public class Recipe
{
    public string Name { get; private set; }
    public List<IngredientByStep> IngredientsByStep { get; private set; }

    public Recipe(string name, List<IngredientByStep> ingredientsByStep)
    {
        Name = name;
        IngredientsByStep = ingredientsByStep;
    }
}