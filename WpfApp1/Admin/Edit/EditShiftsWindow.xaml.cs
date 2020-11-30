using System.Windows;

namespace WpfApp1.Admin.Edit
{
    public partial class EditShiftsWindow : Window
    {
        private Shift_list SelectedShift { get; }

        public EditShiftsWindow(Shift_list shift_List)
        {
            InitializeComponent();

            SelectedShift = shift_List;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsEmployees actionsEmployees = new ActionsEmployees();
            ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();

            ComboBoxDate.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
            ComboBoxEmployee.ItemsSource = actionsEmployees.GettingAllEmployees();

            ComboBoxEmployee.SelectedValue = SelectedShift.Fk_employee;
            ComboBoxDate.SelectedValue = SelectedShift.Fk_shift_date;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            ActionsShifts actionsShifts = new ActionsShifts();
            actionsShifts.EditShift(SelectedShift.ID, (int)ComboBoxEmployee.SelectedValue, (int)ComboBoxDate.SelectedValue);

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
