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

namespace WpfApp1.Admin.Add
{
    public partial class AddShiftsWindow : Window
    {
        private readonly ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        public AddShiftsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxDate.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
            ComboBoxEmployee.ItemsSource = actionsEmployees.GettingAllEmployees();

            ComboBoxEmployee.SelectedIndex += 1;
            ComboBoxDate.SelectedIndex += 1;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            using var db = new CafeEntities();

            Shift_list shift_List = new Shift_list()
            {
                Fk_employee = (int)ComboBoxEmployee.SelectedValue,
                Fk_shift_date = (int)ComboBoxDate.SelectedValue
            };

            db.Shift_list.Add(shift_List);
            db.SaveChanges();

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
