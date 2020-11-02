using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace WpfApp1
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login(TextBoxLogin.Text, PasswordBoxPassword.Password);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login(string login,string password)
        {
            using (CafeEntities db = new CafeEntities())
            {                
                var findUser = db.Users.FirstOrDefault( (user) => 
                                                     user.Login == login && user.Password == password);

                if (findUser == null)
                    MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    List<Posts_employees> postEmployee = db.Posts_employees.Where( (emp) => emp.Fk_employee == findUser.Employee.ID).ToList();



                    //switch(posts_Employees.Post.Name)
                    //{
                    //    case "Официант":
                    //        WaiterWindow waiter = new WaiterWindow();

                    //        Close();
                    //        break;
                    //}

                    
                }
            }
        }
    }
}
