using final_project_oop.Services;
using final_project_oop.Users;

namespace final_project_oop.Controller;

public class UserController
{
    
    public ProductService ProductService_ { get; set; }
    public UserService UserService_ { get; set; }

    public User CurrentUser { get; set; }
    

    public UserController(ProductService productService, UserService userService)
    {
        ProductService_ = productService;
        UserService_ = userService;
        CurrentUser = null;
    }

    public void CreateUser(string username)
    {
        UserService_.Create(username);
    }

    public void ShowProfile(string username)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        var user = UserService_.FindByName(username);
        Console.WriteLine("+-------------+");
        Console.WriteLine($"ID: {user.Id}");
        Console.WriteLine($"Username: {user.Username}");
        Console.WriteLine($"Balance: {user.Balance}$");
        Console.WriteLine("-------");
        Console.WriteLine("1. Check Cart");
        Console.WriteLine("2. Check purchase history");
        Console.WriteLine("3. Add balance");
        Console.WriteLine("0. Exit to Main Menu");
        Console.WriteLine("+-------------+");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Console.Clear();
                ShowCart();
                break;
            case 2:
                Console.Clear();
                ShowHistory();
                break;
            case 3:
                Console.Clear();
                Console.WriteLine("Please enter amount of money to deposit:");
                int amount = Convert.ToInt32(Console.ReadLine());
                AddBalance(CurrentUser.Username, amount);
                ShowProfile(user.Username);
                break;
            case 0:
                break;
        }
    }

    public void ShowCart()
    {
        var user = UserService_.FindByName(CurrentUser.Username);
        user.ShowCart();
        Console.WriteLine("1. Buy all");
        Console.WriteLine("0. Back");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Payment();
                break;
            case 0:
                ShowProfile(user.Username);
                break;
        }
    }
    
    public void ShowHistory()
    {
        var user = UserService_.FindByName(CurrentUser.Username);
        user.ShowPurchaseHistory();
        Console.WriteLine("Press enter to continue");
        Console.ReadKey();
    }

    public void Payment()
    {
        double initBalance = CurrentUser.Balance;
        CurrentUser.Balance -= CurrentUser.TotalCartPrice(CurrentUser.Cart);
        if (CurrentUser.Balance < 0)
        {
            Console.WriteLine();
            Console.WriteLine("You haven't enough money to do that!");
            CurrentUser.Balance = initBalance;
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
        }
        else if (CurrentUser.TotalCartPrice(CurrentUser.Cart) == 0)
        {
            Console.WriteLine("Your cart in empty now! Add some product to do that!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
        }
        else
        {
            CurrentUser.Cart.ForEach(el => CurrentUser.AddToHistory(el));
            CurrentUser.Cart.Clear();
            Console.WriteLine("Your payment was successful!");
            Console.WriteLine("Press enter to continue!");
            Console.ReadKey();
        }
    }

    public void AddBalance(string username, int amount)
    {
        var user = UserService_.FindByName(username);
        user.AddBalance(amount);
    }
    
    public void ShowAllUsers()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        var list = UserService_.FindAll();
        list.ForEach(el =>
        {
            Console.WriteLine($"ID: {el.Id}");
            Console.WriteLine($"Title: {el.Username}");
            Console.WriteLine("--------");
        });
        Console.WriteLine("Press enter to continue");
        Console.ReadKey();
    }
}