namespace final_project_oop.Products;

public class ShoesProduct : Product
{
    public ShoesProduct(string title, string description, double price)
    {
        Id = _idSeed;
        Title = title;
        Description = description;
        Price = price;
        Type = ProductType.Shoes.ToString();

        _idSeed++;
    }
}