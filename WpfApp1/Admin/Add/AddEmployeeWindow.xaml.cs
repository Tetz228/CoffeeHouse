﻿using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp1.Classes;

namespace WpfApp1.Add
{
    public partial class AddEmployeeWindow : Window
    {
        private readonly ActionsEmployees actionsEmployees = new ActionsEmployees();
        private readonly ActionsPhoto actionsPhoto = new ActionsPhoto();

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
                using var db = new CafeEntities();

                Employee employee = new Employee()
                {
                    LName = TextBoxLName.Text,
                    FName = TextBoxFName.Text,
                    MName = TextBoxMName.Text == "" ? TextBoxMName.Text = "Не указано" : TextBoxMName.Text,
                    Fk_status_employee = (int)ComboBoxStatus.SelectedValue,
                    Photo = WayToPhoto,
                    Phone_number = TextBoxPhoneNumber.Text
                };

                db.Employees.Add(employee);
                db.SaveChanges();

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