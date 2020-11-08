using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Data.Entity;
using WpfApp1;

public class ActionsUser
{
    private User user { get; set; }

    public ActionsUser() { }

    public ActionsUser(int id)
    {
        SearchUser(id);
    }

    public (bool existUser, int idUser) SearchUser(string log, string pass)
    {
        using (CafeEntities db = new CafeEntities())
        {
            user = db.Users.Include(emp => emp.Employee).Include(empPost => empPost.Employee.Posts_employees).FirstOrDefault(fUser => fUser.Login == log && fUser.Password == pass);

            return user == null ? (false, 0) : (true, user.ID);
        }
    }

    private User SearchUser(int id)
    {
        using (CafeEntities db = new CafeEntities())
        {
            user = db.Users.Include(emp => emp.Employee).Include(empStatus => empStatus.Employee.Status_employees).Include(empPost => empPost.Employee.Posts_employees)
                           .Include(cont => cont.Employee.Contracts).Include(shiftList => shiftList.Employee.Shift_list).Include(table => table.Employee.Tables).FirstOrDefault(fUser => fUser.ID == id);

            return user;
        }
    }

    public string CountPostAndTheirNames()
    {
        using (CafeEntities db = new CafeEntities())
        {
            int g;

            if (user.Employee.Posts_employees.Count > 1)
            {
                ChoicePostWindow choiceRole = new ChoicePostWindow(user.ID);

                choiceRole.ShowDialog();

                g = choiceRole.GetFkPost;
            }
            else
                g = user.Employee.Posts_employees.ToArray()[0].Fk_post;

            return g == 0 ? "Должность не выбрана" : PostName(g);
        }
    }

    private static string PostName(int fkPost)
    {
        using (CafeEntities db = new CafeEntities())
        {
            var gg = db.Posts_employees.Include(post => post.Post).FirstOrDefault(e => e.Post.ID == fkPost);
            return gg.Post.Name;
        }
    }

    public string GettingLFMEmployee() => user.Employee.MName == "Не указано"                                                            
                                                              ? user.Employee.LName + " " + user.Employee.FName.Substring(0, 1) + "."
                                                              : user.Employee.LName + " " + user.Employee.FName.Substring(0, 1) + ". " + user.Employee.FName.Substring(0, 1) + ".";

    public string GettingPhoneNumberEmployee() => user.Employee.Phone_number;

    public string GettingStatusName() => user.Employee.Status_employees.Name;

    public ImageSource GettingPhoto()
    {
        ImageSource image = new BitmapImage(new Uri(user.Employee.Photo));

        return image;
    }

    public void ChangePhoto(out ImageSource image)
    {
        using (CafeEntities db = new CafeEntities())
        {
            var changePhoto = db.Users.Include(emp => emp.Employee).Where(emp => emp.ID == user.ID).FirstOrDefault();

            OpenFileDialog file = new OpenFileDialog
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
}
