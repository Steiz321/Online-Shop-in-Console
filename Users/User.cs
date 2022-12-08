using final_project_oop.Products;

namespace final_project_oop.Users;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public double Balance { get; set; }
    public List<Product> Cart { get; set;  }
    public List<Product> PurchaseHistory { get; set; }
    
    private static int _idSeed = 1;
    private const int BalanceInit = 0;

    public User(string username)
    {
        Id = _idSeed;
        Username = username;
        Balance = BalanceInit;
        Cart = new List<Product>();
        PurchaseHistory = new List<Product>();

        _idSeed++;
    }

    public void AddBalance(int amount)
    {
        Balance += amount;
    }

    public void AddToCart(Product prod)
    {
        Cart.Add(prod);
    }

    public double TotalCartPrice(List<Product> cart)
    {
        double total = 0;
        cart.ForEach(el => total += el.Price);
        return total;
    }
    
    public double TotalSpend(List<Product> history)
    {
        double total = 0;
        history.ForEach(el => total += el.Price);
        return total;
    }

    public void AddToHistory(Product prod)
    {
        PurchaseHistory.Add(prod);
    }

    public void ShowPurchaseHistory()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("---------");
        Console.WriteLine("Purchase history:");
        PurchaseHistory.ForEach(el =>
        {
            Console.WriteLine("---------");
            Console.WriteLine($"ID: {el.Id}");
            Console.WriteLine($"Title: {el.Title}");
            Console.WriteLine($"Description: {el.Description}");
            Console.WriteLine($"Price: {el.Price}$");
        });
        Console.WriteLine("---------");
        Console.WriteLine($"Total spend: {TotalSpend(PurchaseHistory)}$");
        Console.WriteLine("---------");
    }

    public void ShowCart()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("---------");
        Console.WriteLine("Cart:");
        Cart.ForEach(el =>
        {
            Console.WriteLine("---------");
            Console.WriteLine($"ID: {el.Id}");
            Console.WriteLine($"Title: {el.Title}");
            Console.WriteLine($"Description: {el.Description}");
            Console.WriteLine($"Price: {el.Price}$");
        });
        Console.WriteLine("---------");
        Console.WriteLine($"Total: {TotalCartPrice(Cart)}$");
        Console.WriteLine("---------");
    }

}