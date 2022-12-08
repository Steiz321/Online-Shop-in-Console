namespace final_project_oop.Products;

public class ClothesProduct : Product
{
    public ClothesProduct(string title, string description, double price)
    {
        Id = _idSeed;
        Title = title;
        Description = description;
        Price = price;
        Type = ProductType.Clothes.ToString();

        _idSeed++;
    }
}