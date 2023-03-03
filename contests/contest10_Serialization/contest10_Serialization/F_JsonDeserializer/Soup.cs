internal class Soup
{
    public Ingredient[] ingredients;
    public Soup(Ingredient[] ingredients)
    {
        this.ingredients = ingredients;
    }
    private bool Will()
    {
        foreach (var ingredient in ingredients)
        {
            var meat = ingredient as Meat;
            if (meat != null)
            {
                if (meat.IsTasty == false)
                    return false;
            }
            else
            {
                var vegetable = ingredient as Vegetable;
                if (vegetable.IsAllergicTo)
                    return false;
            }
        }
        return true;
    }
    public bool WillEat => Will();
}