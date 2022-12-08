namespace final_project_oop.Products;

public abstract class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public string Type { get; set; }
    
    protected enum ProductType {
        Clothes,
        Shoes,
        Accessories
    }
    
    protected static int _idSeed = 1;
}