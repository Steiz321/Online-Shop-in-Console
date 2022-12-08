using final_project_oop.Products;
using final_project_oop.Users;

namespace final_project_oop;

public class DataBase
{
    public List<Product> ProductData { get; set; }
    public List<User> UserData { get; set; }

    public DataBase()
    {
        ProductData = new List<Product>();
        UserData = new List<User>();
        InitProducts();
        InitUsers();
    }

    public void InitProducts()
    {
        ProductData.Add(new ClothesProduct("White hoodie", "Very warm, it's nice to wear in Winter", 43));
        ProductData.Add(new ClothesProduct("Black pants", "Default black pants", 40));
        ProductData.Add(new ClothesProduct("Mint t-shirt", "Mint color t-shirt, cool to wear in summer", 25));
        ProductData.Add(new AccessoriesProduct("Yellow hat", "Warm default hat", 20));
        ProductData.Add(new ShoesProduct("Running sneakers", "The best shoes for running", 70));
        ProductData.Add(new ShoesProduct("Black shoes", "Black shoes will cool fit to the suit", 90));
        ProductData.Add(new AccessoriesProduct("Rings kit", "Kit of silver ring, includes 3 rings", 12));
        ProductData.Add(new AccessoriesProduct("Brown belt", "Brown leather belt, that must be in your wardrobe", 50));
        ProductData.Add(new ClothesProduct("Black hoodie", "default black hoodie", 37));
    }

    public void InitUsers()
    {
        UserData.Add(new User("Timoha"));
        UserData.Add(new User("Roma"));
        UserData.Add(new User("Jora"));
        UserData.Add(new User("Vova"));
    }

}