using System.Linq;
using WpfApp1;

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

    #region Вывод информации о пользователе
    // Вывод ID пользователя
    public int GettingIDUser() => UserAuthorized.ID;
    #endregion
}
