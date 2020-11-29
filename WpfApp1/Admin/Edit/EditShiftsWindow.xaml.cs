using System.Linq;
using System.Windows;

namespace WpfApp1.Admin.Edit
{
    public partial class EditShiftsWindow : Window
    {
        private Shift_list shift_List { get; }

        private readonly ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        public EditShiftsWindow(Shift_list shift_List)
        {
            InitializeComponent();

            this.shift_List = shift_List;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxDate.ItemsSource = actionsShiftsDates.GettingAllShiftsDates();
            ComboBoxEmployee.ItemsSource = actionsEmployees.GettingAllEmployees();

            ComboBoxEmployee.SelectedValue = shift_List.Fk_employee;
            ComboBoxDate.SelectedValue = shift_List.Fk_shift_date;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            using var db = new CafeEntities();
            var shifts = db.Shift_list.Where(shiftList => shiftList.ID == shift_List.ID).FirstOrDefault();

            shifts.Fk_employee = (int)ComboBoxEmployee.SelectedValue;
            shifts.Fk_shift_date = (int)ComboBoxDate.SelectedValue;

            db.SaveChanges();

            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
