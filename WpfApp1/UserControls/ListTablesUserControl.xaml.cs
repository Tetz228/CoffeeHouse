using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Admin.Edit;

namespace WpfApp1
{
    public partial class ListTablesUserControl : UserControl
    {
        public ListTablesUserControl()
        {
            InitializeComponent();

            UploadTable();
        }

        public void UploadTable()
        {
            ActionsTables actionsTables = new ActionsTables();
            DataGridTables.ItemsSource = actionsTables.GettingAllTables();
        }

        private void DataGridTables_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeTable();
        }

        public void ChangeTable()
        {
            if (DataGridTables.SelectedItem != null)
            {
                Table table = DataGridTables.SelectedItem as Table;

                EditTableWindow editTableWindow = new EditTableWindow(table);
                editTableWindow.ShowDialog();

                UploadTable();
            }
        }

        private void DataGridTables_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridTables.SelectedItem = null;
        }
    }
}
