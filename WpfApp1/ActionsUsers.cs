using win32 =  Microsoft.Win32;
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

    public ActionsUsers() { }

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
            UserAuthorized = db.Users.Include(emp => emp.Employee).Include(status=>status.Employee.Status_employees).Include(empPost => empPost.Employee.Posts_employees)
                                     .FirstOrDefault(fUser => fUser.Login == log && fUser.Password == pass);

            return UserAuthorized == null ? (false, 0) : (true, UserAuthorized.ID);
        }
    }

    //Поиск пользователя по его id
    private User SearchUser(int idUser)
    {
        using (var db = new CafeEntities())
        {
            UserAuthorized = db.Users.Include(emp => emp.Employee).Include(empStatus => empStatus.Employee.Status_employees).Include(empPost => empPost.Employee.Posts_employees)
                                     .Include(cont => cont.Employee.Contracts).Include(shiftList => shiftList.Employee.Shift_list).Include(table => table.Employee.Tables)
                                     .FirstOrDefault(fUser => fUser.ID == idUser);

            return UserAuthorized;
        }
    }
    #endregion

    #region Кол-во должностей у сотрудника и получение названия выбранной должности

    //Проверка на количество должностей у сотрудника и получение название должности
    public string CountPostAndTheirNames()
    {
        using (var db = new CafeEntities())
        {
            int fkPost;

            if (UserAuthorized.Employee.Posts_employees.Count > 1)
            {
                ChoicePostWindow choicePost = new ChoicePostWindow(UserAuthorized.ID);

                choicePost.ShowDialog();

                fkPost = choicePost.GetFkPost;
            }
            else
                fkPost = UserAuthorized.Employee.Posts_employees.ToArray()[0].Fk_post;

            return fkPost == 0 ? "Должность не выбрана" : PostName(fkPost);
        }
    }

    //Получение название должности по fk
    private static string PostName(int fkPost)
    {
        using (var db = new CafeEntities())
        {
            var postName = db.Posts_employees.Include(post => post.Post).FirstOrDefault(e => e.Post.ID == fkPost);
            return postName.Post.Name;
        }
    }

    #endregion

    #region Вывод информации о пользо

    //Вывод ФИО сотрудника
    public string GettingLFMEmployee() => UserAuthorized.Employee.MName == "Не указано"
                                                                        ? UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName.Substring(0, 1) + "."
                                                                        : UserAuthorized.Employee.LName + " " + UserAuthorized.Employee.FName.Substring(0, 1) + ". "
                                                                        + UserAuthorized.Employee.FName.Substring(0, 1) + ".";

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
            MessageBox.Show("Ошибка! Фотография отсутствует!", "Фотография не обнаружена", MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            win32.OpenFileDialog file = new win32.OpenFileDialog
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
