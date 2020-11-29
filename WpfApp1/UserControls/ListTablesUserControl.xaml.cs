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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Admin.Add;
using WpfApp1.Admin.Edit;

namespace WpfApp1
{
    public partial class ListTablesUserControl : UserControl
    {
        private readonly ActionsTables actionsTables = new ActionsTables();

        public ListTablesUserControl()
        {
            InitializeComponent();

            UploadTable();
        }

        public void UploadTable()
        {
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
