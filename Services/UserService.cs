using final_project_oop.Products;
using final_project_oop.Users;

namespace final_project_oop.Services;

public class UserService
{
    public DataBase DBContext_ { get; set; }
    
    public UserService(DataBase dbContext)
    {
        DBContext_ = dbContext;
    }

    public void Create(string username)
    {
        DBContext_.UserData.Add(new User(username));
    }

    public User FindById(int id)
    {
        return DBContext_.UserData.First(el => el.Id == id);
    }
    
    public User? FindByName(string name)
    {
        return DBContext_.UserData.FirstOrDefault(el => el.Username == name);
    }

    public List<User> FindAll()
    {
        return DBContext_.UserData;
    }

    public void DeleteById(int id)
    {
        DBContext_.UserData.RemoveAll(el => el.Id == id);
    }
}