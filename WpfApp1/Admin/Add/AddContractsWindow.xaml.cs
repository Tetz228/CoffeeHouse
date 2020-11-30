using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using WpfApp1.Classes;

namespace WpfApp1.Admin.Add
{
    public partial class AddContractsWindow : Window
    {
        private string WayToPhoto { get; set; }

        public AddContractsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActionsEmployees actionsEmployees = new ActionsEmployees();

            ComboBoxEmployees.ItemsSource = actionsEmployees.GettingAllEmployees();
            ComboBoxEmployees.SelectedIndex += 1;
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

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActionsContracts actionsContracts = new ActionsContracts();
                actionsContracts.AddContract(int.Parse(TextBoxNumberContract.Text), (int)ComboBoxEmployees.SelectedValue, WayToPhoto);

                Close();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Ошибка при добавлении договора.", "Ошибка! Некорректный ввод!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
