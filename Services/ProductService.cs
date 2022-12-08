using final_project_oop.Products;
using final_project_oop.Services.Interface;
using System.Collections.Generic;
using System.Linq;

namespace final_project_oop.Services;

public class ProductService : IProductService
{
    public DataBase DBContext_ { get; set; }
    
    public ProductService(DataBase dbContext)
    {
        DBContext_ = dbContext;
    }

    public void Create(Product product)
    {
        DBContext_.ProductData.Add(product);
    }

    public Product FindById(int id)
    {
        return DBContext_.ProductData.First(el => el.Id == id);
    }
    
    public Product FindByTitle(string title)
    {
        return DBContext_.ProductData.First(el => el.Title == title);
    }

    public List<Product> FindByCategory(string category)
    {
        return DBContext_.ProductData.Where(el => el.Type == category).ToList();
    }

    public List<Product> FindAll()
    {
        return DBContext_.ProductData;
    }

    public void DeleteById(int id)
    {
        DBContext_.ProductData.RemoveAll(el => el.Id == id);
    }
}