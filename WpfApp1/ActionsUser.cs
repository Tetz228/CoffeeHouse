using System.Data.Entity;
using System.Linq;
using WpfApp1;

public class ActionsUser
{
    private User user { get; set; }

    public (bool existUser, int idUser) SearchUser(string log, string pass)
    {
        using (CafeEntities db = new CafeEntities())
        {
            user = db.Users.Include(emp => emp.Employee).Include(empPost => empPost.Employee.Posts_employees).FirstOrDefault(fUser => fUser.Login == log && fUser.Password == pass);

            return user == null ? (false, 0) : (true, user.ID);
        }
    }

    public User SearchUser(int id)
    {
        using (CafeEntities db = new CafeEntities())
        {
            user = db.Users.Include(emp => emp.Employee).Include(empStatus => empStatus.Employee.Status_employees).Include(empPost => empPost.Employee.Posts_employees)
                           .Include(cont => cont.Employee.Contracts).FirstOrDefault(fUser => fUser.ID == id);

            return user;
        }
    }

    public string CountAndNamePost()
    {
        using (CafeEntities db = new CafeEntities())
        {
            int g;

            if (user.Employee.Posts_employees.Count > 1)
            {
                ChoiceRoleWindow choiceRole = new ChoiceRoleWindow(user);

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
            var gg = db.Posts_employees.Include(post=>post.Post).FirstOrDefault(e => e.Post.ID == fkPost);

            return gg.Post.Name;
        }
    }


}
