using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListUsersUserControl : UserControl
    {
        private readonly ActionsUsers actionsUsers;

        public ListUsersUserControl()
        {
            InitializeComponent();

            actionsUsers = new ActionsUsers();

            UploadUsers();
        }

        public void UploadUsers()
        {
            DataGridUsers.ItemsSource = actionsUsers.GettingAllUsers();
        }

        private void DataGridEmployees_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridUsers.SelectedItem = null;
        }
    }
}
