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
            Login(TextBoxLogin.Text = "l", PasswordBoxPassword.Password = "p");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login(string login,string password)
        {
            using (CafeEntities db = new CafeEntities())
            {
                var findUser = db.Users.FirstOrDefault((fUser) =>
                                                        fUser.Login == login && fUser.Password == password);

                if (findUser == null)
                    MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    List<Posts_employees> postsEmployee = db.Posts_employees.Where((emp) =>
                                                                                    emp.Fk_employee == findUser.Employee.ID).ToList();

                    if (postsEmployee.Count > 1)
                    {
                        ChoiceRoleWindow choiceRole = new ChoiceRoleWindow() 
                        { 
                            PostsEmployee = postsEmployee
                        };

                        choiceRole.ShowDialog();

                        if (choiceRole.GetRole != null)
                        {
                            switch (choiceRole.GetRole)
                            {
                                case "Администратор":
                                    /*Окно администратора*/
                                    break;
                                case "Официант":
                                    WaiterWindow waiter = new WaiterWindow();
                                    waiter.Show();
                                    Close();
                                    break;
                                case "Повар":
                                    /*Окно повара*/
                                    break;
                            }
                        }
                    }
                    else
                    {
                        switch (postsEmployee[0].Post.Name)
                        {
                            case "Администратор":
                                /*Окно администратора*/
                                break;
                            case "Официант":
                                WaiterWindow waiter = new WaiterWindow();
                                waiter.Show();
                                Close();
                                break;
                            case "Повар":
                                /*Окно повара*/
                                break;
                        }
                    }
                }
            }
        }
    }
}
