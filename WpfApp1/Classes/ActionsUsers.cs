using System.Linq;
using System.Data;
using System.Data.Entity;
using WpfApp1;
using System.Security.Cryptography;
using System;

public class ActionsUsers : ActionsEmployees
{
    private User UserAuthorized { get; set; }

    public ActionsUsers() { }

    public ActionsUsers(int idUser) : base(idUser)
    {
        SearchUser(idUser);
    }

    #region Поиск пользователя
    //Поиск пользователя по логину и паролю
    public (bool existUser, int idUser) SearchUser(string log, string pass)
    {
        using var db = new CafeEntities();
        UserAuthorized = db.Users.FirstOrDefault(fUser => fUser.Login == log && fUser.Password == pass);

        return UserAuthorized == null ? (false, 0) : (true, UserAuthorized.ID);
    }

    //Поиск пользователя по его id
    private void SearchUser(int idUser)
    {
        using var db = new CafeEntities();
        UserAuthorized = db.Users.FirstOrDefault(fUser => fUser.ID == idUser);
    }
    #endregion

    public User[] GettingAllUsers()
    {
        using var db = new CafeEntities();
        var users = db.Users.Include(emp => emp.Employee).ToArray();

        return users;
    }

    public void AddUser(string log, string pass, int emp)
    {
        using var db = new CafeEntities();

        User user = new User()
        {
            Login = log,
            Password = pass,
            Fk_employee = emp
        };

        db.Users.Add(user);
        db.SaveChanges();
    }

    #region Вывод информации о пользователе
    // Вывод ID пользователя
    public int GettingIDUser() => UserAuthorized.ID;
    #endregion
}
