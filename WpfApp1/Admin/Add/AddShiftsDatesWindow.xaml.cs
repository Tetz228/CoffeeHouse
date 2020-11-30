using System;
using System.Windows;
using System.Windows.Forms;

namespace WpfApp1.Admin.Add
{
    public partial class AddShiftsDatesWindow : Window
    {
        public AddShiftsDatesWindow()
        {
            InitializeComponent();

            DatePickerDate.SelectedDate = DateTime.Now;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActionsShiftsDates actionsShiftsDates = new ActionsShiftsDates();
                actionsShiftsDates.AddShiftDate((DateTime)DatePickerDate.SelectedDate);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении даты.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
