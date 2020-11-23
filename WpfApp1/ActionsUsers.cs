using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1;

public class ActionsUsers
{
    private User UserAuthorized { get; set; }

    public ActionsUsers() {}

    public ActionsUsers(int id)
    {
        SearchUser(id);
    }

    #region Поиск пользователя
    //Поиск пользователя по логину и паролю
    public (bool existUser, int idUser) SearchUser(string log, string pass)
    {
        using (var db = new CafeEntities())
        {
            UserAuthorized = db.Users.Include(emp => emp.Employee)
                                     .Include(status => status.Employee.Status_employees)
                                     .Include(empPost => empPost.Employee.Posts_employees)
                                     .FirstOrDefault(fUser => fUser.Login == log && fUser.Password == pass);

            UserAuthorized.Employee.Posts_employees = db.Posts_employees.Where(dbPost => dbPost.Fk_employee == UserAuthorized.Employee.ID).Include(post => post.Post).ToList();

            return UserAuthorized == null ? (false, 0) : (true, UserAuthorized.ID);
        }
    }

    //Поиск пользователя по его id
    private User SearchUser(int idUser)
    {
        using (var db = new CafeEntities())
        {
            UserAuthorized = db.Users.Include(emp => emp.Employee)
                                     .Include(empStatus => empStatus.Employee.Status_employees)
                                     .Include(empPost => empPost.Employee.Posts_employees)
                                     .Include(cont => cont.Employee.Contracts)
                                     .Include(shiftList => shiftList.Employee.Shift_list)
                                     .Include(table => table.Employee.Tables)
                                     .FirstOrDefault(fUser => fUser.ID == idUser);

            UserAuthorized.Employee.Posts_employees = db.Posts_employees.Where(dbPost => dbPost.Fk_employee == UserAuthorized.Employee.ID).Include(post => post.Post).ToList();

            return UserAuthorized;
        }
    }
    #endregion

    #region Кол-во должностей у сотрудника и получение названия выбранной должности
    //Проверка на количество должностей у сотрудника и получение название должности
    public string CountPostAndTheirNames()
    {
        string SelectedPost;

        using (var db = new CafeEntities())
        {
            if (UserAuthorized.Employee.Posts_employees.Count > 1)
            {
                ChoicePostWindow choicePost = new ChoicePostWindow(GettingIdEmployee());
                choicePost.ShowDialog();

                SelectedPost = choicePost.GetPost;
            }
            else
                SelectedPost = UserAuthorized.Employee.Posts_employees.ToArray()[0].Post.Name;

            return SelectedPost;
        }
    }
    #endregion

    #region Вывод информации о пользователе
    // Вывод ID пользователя
    public int GettingIdUser() => UserAuthorized.ID;

    // Вывод ID сотрудника
    public int GettingIdEmployee() => UserAuthorized.Employee.ID;

    //Вывод сокращенного ФИО сотрудника
    public string GettingLFMEmployee() => UserAuthorized.Employee.MName == "Не указано"
                                                                        ? UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName.Substring(0, 1) + "."
                                                                        : UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName.Substring(0, 1) + ". "
                                                                        + UserAuthorized.Employee.FName.Substring(0, 1) + ".";

    /*Вывод ФИО сотрудника полностью
    public string GettingFullLFMEmployee() => UserAuthorized.Employee.MName == "Не указано"
                                                                        ? UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName
                                                                        : UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName
                                                                        + UserAuthorized.Employee.FName;
    */

    //Вывод номера телефона сотрудника
    public string GettingPhoneNumberEmployee() => UserAuthorized.Employee.Phone_number;

    //Вывод статуса сотрудника
    public string GettingStatusName() => UserAuthorized.Employee.Status_employees.Name;

    //Вывод фотографии сотрудника
    public ImageSource GettingPhoto()
    {
        ImageSource image;

        try
        {
            image = new BitmapImage(new Uri(UserAuthorized.Employee.Photo));
            return image;
        }
        catch
        {
            MessageBox.Show("Ошибка! Фотография отсутствует!", "Фотография не обнаружена", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
    #endregion

    #region Изменение информации о сотруднике
    //Изменение фотографии сотрудника
    public void ChangePhoto(out ImageSource image)
    {
        using (var db = new CafeEntities())
        {
            var changePhoto = db.Users.Include(emp => emp.Employee).Where(emp => emp.ID == UserAuthorized.ID).FirstOrDefault();

            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Картинки(*.JPG; *.PNG)| *.JPG; *.PNG",
                CheckFileExists = true,
                Title = "Выберете изображение"
            };

            image = null;

            if (file.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(file.FileName));
                changePhoto.Employee.Photo = file.FileName;

                db.SaveChanges();
            }
        }
    }
    #endregion
}
