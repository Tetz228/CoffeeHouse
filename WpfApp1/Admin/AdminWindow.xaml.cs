using System.Windows;
using WpfApp1.Add;
using WpfApp1.Admin.Add;

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
        private int IdUser { get; }

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

            IdUser = idUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainControl.Content = ordersUserControl;
            MenuItemUser.Header = actionsUsers.GettingLFMEmployee();
        }

        private void MenuItemListEmployees_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listEmployeesUserControl;
            Title = "Окно администратора -> Список сотрудников";
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
            Title = "Окно администратора -> Список пользователей";
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
            Title = "Окно администратора -> Список договоров";
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
            Title = "Окно администратора -> Список заказов";
        }

        private void MenuItemEditOrder_Click(object sender, RoutedEventArgs e)
        {
            ordersUserControl.ChangeOrder();
        }

        private void MenuItemListTables_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listTablesUserControl;
            Title = "Окно администратора -> Список столов";
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
            Title = "Окно администратора -> Список смен";
        }

        private void MenuItemListShiftsDates_Click(object sender, RoutedEventArgs e)
        {
            MainControl.Content = listShiftsDatesUserControl;
            Title = "Окно администратора -> Список дат смен";
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

        private void MenuItemReportShift_Click(object sender, RoutedEventArgs e)
        {
            ShiftReportWindow shiftReportWindow = new ShiftReportWindow(IdUser, PostName);
            shiftReportWindow.ShowDialog();
        }
    }
}
