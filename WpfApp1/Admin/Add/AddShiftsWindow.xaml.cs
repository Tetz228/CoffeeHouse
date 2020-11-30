using System.Windows;

namespace WpfApp1.Admin.Add
{
    public partial class AddShiftsWindow : Window
    {
        public AddShiftsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();
            ActionsEmployees actionsEmployees = new ActionsEmployees();

            ComboBoxDate.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
            ComboBoxEmployee.ItemsSource = actionsEmployees.GettingAllEmployees();

            ComboBoxEmployee.SelectedIndex += 1;
            ComboBoxDate.SelectedIndex += 1;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ActionsShifts actionsShifts = new ActionsShifts();
            actionsShifts.AddShift((int)ComboBoxEmployee.SelectedValue, (int)ComboBoxDate.SelectedValue);

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
