using System.Windows;
using WpfApp1.Add;
using WpfApp1.Admin.Add;
using WpfApp1.Admin.Edit;

namespace WpfApp1.Admin
{
    public partial class AdminWindow : Window
    {
        private readonly ListEmployeesUserControl listEmployeesUserControl;
        private readonly ListOrdersUserControl ordersUserControl;
        private readonly ListUsersUserControl listUserUserControl;
        private readonly ListTablesUserControl listTablesUserControl;
        private readonly ListContractsUserControl lsitContractsUserControl;
        private readonly ListShiftsDatesUserControl listShiftsDatesUserControl;
        private readonly ListShiftsUserControl listShiftsUserControl;

        private readonly ActionsUsers actionsUsers;

        private string PostName { get; } = "Администратор";

        public AdminWindow(int idUser)
        {
            InitializeComponent();

            listEmployeesUserControl = new ListEmployeesUserControl(idUser);
            ordersUserControl = new ListOrdersUserControl(idUser, PostName);            
            listUserUserControl = new ListUsersUserControl();
            listTablesUserControl = new ListTablesUserControl();
            lsitContractsUserControl = new ListContractsUserControl();
            listShiftsDatesUserControl = new ListShiftsDatesUserControl();
            listShiftsUserControl = new ListShiftsUserControl();

            actionsUsers = new ActionsUsers(idUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
            MenuItemUser.Header = actionsUsers.GettingLFMEmployee();
        }

        private void MenuItemListEmployees_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
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
            MainControl.Content = listUserUserControl;
        }

        private void MenuItemAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();

            listEmployeesUserControl.UploadEmployees();
        }

        private void MenuItemEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            listEmployeesUserControl.ChangeEmployee();
        }

        private void MenuItemAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow();
            addUser.ShowDialog();

            listUserUserControl.UploadUsers();
        }

        private void MenuItemListContracts_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = lsitContractsUserControl;
        }

        private void MenuItemAddContract_Click(object sender, RoutedEventArgs e)
        {
            AddContractsWindow addContracts = new AddContractsWindow();
            addContracts.ShowDialog();

            lsitContractsUserControl.UploadContract();
        }

        private void MenuItemListOrder_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersUserControl;
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.ChangeOrder();
        }

        private void MenuItemListTables_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listTablesUserControl;
        }

        private void MenuItemAddTable_Click(object sender, RoutedEventArgs e)
        {
            AddTableWindow addTableWindow = new AddTableWindow();
            addTableWindow.ShowDialog();

            listTablesUserControl.UploadTable();
        }

        private void MenuItemEditTable_Click(object sender, RoutedEventArgs e)
        {
            listTablesUserControl.ChangeTable();
        }

        private void MenuItemListShifts_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listShiftsUserControl;
        }

        private void MenuItemListShiftsDates_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listShiftsDatesUserControl;
        }

        private void MenuItemAddShiftDate_Click(object sender, RoutedEventArgs e)
        {
            AddShiftsDatesWindow addShiftsDates = new AddShiftsDatesWindow();
            addShiftsDates.ShowDialog();

            listShiftsDatesUserControl.UploadShiftsDates();
        }

        private void MenuItemAddShift_Click(object sender, RoutedEventArgs e)
        {
            AddShiftsWindow addShiftsWindow = new AddShiftsWindow();
            addShiftsWindow.ShowDialog();

            listShiftsUserControl.UploadShifts();
        }

        private void MenuItemEditShift_Click(object sender, RoutedEventArgs e)
        {
            listShiftsUserControl.ChangeShifts();
        }
    }
}
