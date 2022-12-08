using final_project_oop.Controller;
using final_project_oop.Users;

namespace final_project_oop;

public class Menu
{
    public UserController UserController_ { get; set; }
    public ProductController ProductController_ { get; set; }

    public User CurrentUser { get; set; }

    public Menu(UserController userController, ProductController productController)
    {
        UserController_ = userController;
        ProductController_ = productController;
        CurrentUser = null;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Registration");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                Login();
                break;
            case 2:
                Registration();
                Start();
                break;
            case 0:
                Environment.Exit(0);
                break;
        }
    }

    public void Login()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please enter your username to login:");
        string? username = Console.ReadLine();
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException();
        }
        var candidate = UserController_.UserService_.FindByName(username);
        if (candidate != null)
        {
            CurrentUser = candidate;
            UserController_.CurrentUser = candidate;
            ProductController_.CurrentUser = candidate;
            Console.Clear();
            MainMenu();
        }
        Console.WriteLine("User with that username not found!");
        Console.WriteLine("Press enter to continue!");
        Console.ReadKey();
        Console.Clear();
        Start();
    }

    public void Registration()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please enter your username to login:");
        string? username = Console.ReadLine();
        UserController_.CreateUser(username);
        var user = UserController_.UserService_.FindByName(username);
        CurrentUser = user;
        UserController_.CurrentUser = user;
        ProductController_.CurrentUser = user;
    }
    public void Logout()
    {
        CurrentUser = null;
        UserController_.CurrentUser = null;
        ProductController_.CurrentUser = null;
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("You logged out!");
        Login();
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. All products");
        Console.WriteLine("2. Filter product by type");
        Console.WriteLine("3. Search product by title");
        Console.WriteLine("4. My profile");
        Console.WriteLine("5. Add product");
        Console.WriteLine("6. Check all users");
        Console.WriteLine("0. Logout");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                ProductController_.ShowAll();
                Console.Clear();
                MainMenu();
                break;
            case 2:
                ProductController_.ShowByCategory();
                Console.Clear();
                MainMenu();
                break;
            case 3:
                ProductController_.ShowByTitle();
                Console.Clear();
                MainMenu();
                break;
            case 4:
                UserController_.ShowProfile(CurrentUser.Username);
                Console.Clear();
                MainMenu();
                break;
            case 5:
                ProductController_.CreateProduct();
                MainMenu();
                break;
            case 6:
                UserController_.ShowAllUsers();
                MainMenu();
                break;
            case 0:
                Logout();
                break;
        }
    }
}