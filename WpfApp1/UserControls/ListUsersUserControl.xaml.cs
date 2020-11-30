using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class ListUsersUserControl : UserControl
    {
        public ListUsersUserControl()
        {
            InitializeComponent();
            UploadUsers();
        }

        public void UploadUsers()
        {
            ActionsUsers actionsUsers = new ActionsUsers();
            DataGridUsers.ItemsSource = actionsUsers.GettingAllUsers();
        }

        private void DataGridEmployees_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridUsers.SelectedItem = null;
        }
    }
}
