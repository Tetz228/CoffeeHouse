using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1.Admin.Add
{
    public partial class AddContractsWindow : Window
    {
        private string WayToPhoto { get; set; }

        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();

        public AddContractsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxEmployees.ItemsSource = actionsEmployees.GettingAllEmployees();
            ComboBoxEmployees.SelectedIndex += 1;
        }

        private void ButtonAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            ImageSource image;

            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Картинки(*.JPG; *.PNG)| *.JPG; *.PNG",
                CheckFileExists = true,
                Title = "Выберете изображение"
            };

            if (file.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(WayToPhoto = file.FileName));
                ImageAvatar.Source = image;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new CafeEntities();

                Contract contract = new Contract()
                {
                    Number_contract = int.Parse(TextBoxNumberContract.Text),
                    Fk_employee = (int)ComboBoxEmployees.SelectedValue,
                    Scan_contract = WayToPhoto,
                };

                db.Contracts.Add(contract);
                db.SaveChanges();

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
