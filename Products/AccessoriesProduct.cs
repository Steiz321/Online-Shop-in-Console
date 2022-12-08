namespace final_project_oop.Products;

public class AccessoriesProduct : Product
{
    public AccessoriesProduct(string title, string description, double price)
    {
        Id = _idSeed;
        Title = title;
        Description = description;
        Price = price;
        Type = ProductType.Accessories.ToString();

        _idSeed++;
    }
}