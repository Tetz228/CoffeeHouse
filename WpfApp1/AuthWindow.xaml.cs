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

        private void Login(string login,string password)
        {
            using (CafeEntities db = new CafeEntities())
            {                
                var user = db.Users.FirstOrDefault( (u) => 
                                                     u.Login == login && u.Password == password
                                                  );

                if (user == null)
                    MessageBox.Show("Неверный логин или пароль");
                else
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    Close();
                }
            }
        }
    }
}
