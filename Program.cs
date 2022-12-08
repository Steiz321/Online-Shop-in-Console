using final_project_oop.Controller;
using final_project_oop.Products;
using final_project_oop.Services;

namespace final_project_oop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DataBase();

            var productService = new ProductService(db);
            var userService = new UserService(db);

            var productController = new ProductController(productService, userService);
            var userController = new UserController(productService, userService);

            var menu = new Menu(userController, productController);
            
            menu.Start();
        }
    }
}