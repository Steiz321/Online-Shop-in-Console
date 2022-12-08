using final_project_oop.Products;
using final_project_oop.Services;
using final_project_oop.Users;

namespace final_project_oop.Controller;

public class ProductController
{
    public ProductService ProductService_ { get; set; }
    public UserService UserService_ { get; set; }
    
    public User CurrentUser { get; set; }
    
    public ProductController(ProductService productService, UserService userService)
    {
        ProductService_ = productService;
        UserService_ = userService;
        CurrentUser = null;
    }

    public void CreateProduct()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please input product title:");
        string? title = Console.ReadLine();
        Console.WriteLine("Please input product description:");
        string? description = Console.ReadLine();
        Console.WriteLine("Please input product price:");
        int price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Choose type of product:");
        Console.WriteLine("1. Clothes");
        Console.WriteLine("2. Shoes");
        Console.WriteLine("3. Accessories");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                ProductService_.Create(new ClothesProduct(title, description, price));
                break;
            case 2:
                ProductService_.Create(new ShoesProduct(title, description, price));
                break;
            case 3:
                ProductService_.Create(new AccessoriesProduct(title, description, price));
                break;
        }
    }
    
    public void ShowAll()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        var list = ProductService_.FindAll();
        list.ForEach(el =>
        {
            Console.WriteLine($"ID: {el.Id}");
            Console.WriteLine($"Title: {el.Title}");
            Console.WriteLine($"Type: {el.Type}");
            Console.WriteLine($"Price: {el.Price}$");
            Console.WriteLine("--------");
        });
        Console.WriteLine("1. Check product by title");
        Console.WriteLine("2. Add to Cart by title");
        Console.WriteLine("0. Exit to Main Menu");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                ShowByTitle();
                break;
            case 2:
                Console.WriteLine("Please input title of product to put it in the cart:");
                string? prodTitle = Console.ReadLine();
                if (prodTitle == null)
                {
                    throw new ArgumentException();
                }
                AddToCart(prodTitle);
                break;
            case 0:
                break;
        }
    }

    public void ShowByCategory()
    {
        Console.Clear();
        Console.WriteLine("Please choose category:");
        Console.WriteLine("1. Clothes");
        Console.WriteLine("2. Shoes");
        Console.WriteLine("3. Accessories");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                var clothesList = ProductService_.FindByCategory("Clothes");
                Display(clothesList);
                break;
            case 2:
                var shoesList = ProductService_.FindByCategory("Shoes");
                Display(shoesList);
                break;
            case 3:
                var accessoriesList = ProductService_.FindByCategory("Accessories");
                Display(accessoriesList);
                break;
        }
    }

    public void Display(List<Product> list)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        list.ForEach(el =>
        {
            Console.WriteLine($"ID: {el.Id}");
            Console.WriteLine($"Title: {el.Title}");
            Console.WriteLine($"Type: {el.Type}");
            Console.WriteLine($"Price: {el.Price}$");
            Console.WriteLine("--------");
        });
        Console.WriteLine("1. Check product by title");
        Console.WriteLine("2. Add to Cart by title");
        Console.WriteLine("0. Exit to Main Menu");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                ShowByTitle();
                break;
            case 2:
                Console.WriteLine("Please input title of product to put it in the cart:");
                string? prodTitle = Console.ReadLine();
                if (prodTitle == null)
                {
                    throw new ArgumentException();
                }
                AddToCart(prodTitle);
                break;
            case 0:
                break;
        }
    }

    public void ShowByTitle()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Please input product title:");
        string? title = Console.ReadLine();
        if (title == null)
        {
            throw new ArgumentException();
        }
        var prod = ProductService_.FindByTitle(title);
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"ID: {prod.Id}");
        Console.WriteLine($"Title: {prod.Title}");
        Console.WriteLine($"Type: {prod.Type}");
        Console.WriteLine($"Description: {prod.Description}");
        Console.WriteLine($"Price: {prod.Price}$");
        Console.WriteLine("--------");
        Console.WriteLine("1. Add to Cart");
        Console.WriteLine("0. Exit to Main Menu");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                AddToCart(prod.Title);
                break;
            case 0: break;
        }
    }

    public void AddToCart(string title)
    {
        var prod = ProductService_.FindByTitle(title);
        var user = UserService_.FindByName(CurrentUser.Username);
        user.AddToCart(prod);
    }
}