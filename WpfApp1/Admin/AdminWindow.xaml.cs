using System.Windows;
using WpfApp1.Add;

namespace WpfApp1.Admin
{
    public partial class AdminWindow : Window
    {
        private readonly ListEmployeesUserControl listEmployeesUserControl;
        private readonly ListOrdersUserControl ordersUserControl;
        private readonly ActionsUsers actionsUsers;

        private string PostName { get; } = "Администратор";

        public AdminWindow(int idUser)
        {
            InitializeComponent();
            listEmployeesUserControl = new ListEmployeesUserControl(idUser);
            ordersUserControl = new ListOrdersUserControl(idUser, PostName);
            actionsUsers = new ActionsUsers(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
            MenuItemUser.Header = actionsUsers.GettingLFMEmployee();
        }

        private void MenuItemListEmployees_Click(object sender, RoutedEventArgs e)
        {
            listEmployeesUserControl.UploadOrderingDishes();
        }

        private void MenuItemProfile_Click(object sender, RoutedEventArgs e)
        {
            MyProfileWindow myProfileWindow = new MyProfileWindow(actionsUsers.GettingIDUser(), PostName);
            myProfileWindow.ShowDialog();
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

        private void MenuItemListUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemShifts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemTables_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();

            listEmployeesUserControl.UploadOrderingDishes();
        }

        private void MenuItemEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            listEmployeesUserControl.ChangeEmployee();
        }

        private void MenuItemAddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemListContracts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemAddContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemEditContract_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemListOrder_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersUserControl;
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.ChangeOrder();
        }
    }
}
