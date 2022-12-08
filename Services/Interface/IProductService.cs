using final_project_oop.Products;
using System.Collections.Generic;

namespace final_project_oop.Services.Interface;

public interface IProductService
{

    public void Create(Product product);
    public Product FindById(int id);
    public List<Product> FindAll();
    public void DeleteById(int id);
}