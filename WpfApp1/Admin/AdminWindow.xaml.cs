using System;
using System.Collections.Generic;
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

namespace WpfApp1.Admin
{
    public partial class AdminWindow : Window
    {
        private readonly ListEmployeesUserControl listEmployeesUserControl;
        private readonly ActionsEmployees actionsEmployees;

        public AdminWindow(int id)
        {
            InitializeComponent();
            listEmployeesUserControl = new ListEmployeesUserControl(id);
            actionsEmployees = new ActionsEmployees(id); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
            MenuItemUser.Header = actionsEmployees.GettingLFMEmployee();
        }

        private void MenuItemListEmployees_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemLogOutAccount_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();

            Close();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItemOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemListUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShifts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemTables_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
