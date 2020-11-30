using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using WpfApp1.Classes;

namespace WpfApp1.Add
{
    public partial class AddEmployeeWindow : Window
    {
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        private string WayToPhoto { get; set; }

        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxStatus.ItemsSource = actionsEmployees.FillingComboBoxStatus_employees();
            ComboBoxStatus.SelectedIndex += 1;
        }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            ActionsPhoto actionsPhoto = new ActionsPhoto();
            actionsPhoto.AddPhoto(out ImageSource image, out string wayToPhoto);

            if (image != null)
            {
                ImageAvatar.Source = image;
                WayToPhoto = wayToPhoto;
            }
        }

        private void ButtonСonfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, string> dictionaryEmp = new Dictionary<string, string>()
                {
                    { "lName", TextBoxLName.Text },
                    { "fName", TextBoxFName.Text },
                    { "mName", TextBoxMName.Text == "" ? "Не указано" : TextBoxMName.Text },
                    { "fkStatus", ComboBoxStatus.SelectedValue.ToString() },
                    { "photo", WayToPhoto },
                    { "phoneNumber", TextBoxPhoneNumber.Text }
                };

                actionsEmployees.AddEmployee(dictionaryEmp);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении сотрудника.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxMName.IsEnabled = true;
            TextBoxMName.Text = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxMName.IsEnabled = false;
            TextBoxMName.Text = "";
        }
    }
}
