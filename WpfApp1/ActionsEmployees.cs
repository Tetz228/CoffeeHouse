using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class ActionsEmployees
    {
        private Employee Employee { get; set; }

        public ActionsEmployees() { }

        public ActionsEmployees(int idUser)
        {
            SearchEmployee(idUser);
        }

        //Поиск сотрудника по его id
        private void SearchEmployee(int idUser)
        {
            using var db = new CafeEntities();
            var employee = db.Users.Where(userId => userId.ID == idUser).FirstOrDefault();

            Employee = db.Employees.Include(empStatus => empStatus.Status_employees)
                                   .Include(empPost => empPost.Posts_employees)
                                   .Include(cont => cont.Contracts)
                                   .Include(shiftList => shiftList.Shift_list)
                                   .Include(table => table.Tables)
                                   .Include(user => user.Users)
                                   .FirstOrDefault(emp => emp.ID == employee.Fk_employee);
        }

        #region Кол-во должностей у сотрудника и получение названия выбранной должности
        //Проверка на количество должностей у сотрудника и получение название должности
        public string CountPostAndTheirNames()
        {
            string SelectedPost;           

            using (var db = new CafeEntities())
            {
                if (Employee.Posts_employees.Count > 1)
                {
                    ChoicePostWindow choicePost = new ChoicePostWindow(GettingIDEmployee());
                    choicePost.ShowDialog();

                    SelectedPost = choicePost.GetPost;
                }
                else
                    SelectedPost = Employee.Posts_employees.ToArray()[0].Post.Name;

                return SelectedPost;
            }
        }
        #endregion

        public Employee[] GettingEmployees()
        {
            using var db = new CafeEntities();
            var empoloyees = db.Employees.Include(status => status.Status_employees).ToArray();

            return empoloyees;
        }

        #region Вывод информации о сотруднике
        // Вывод ID сотрудника
        public int GettingIDEmployee() => Employee.ID;

        //Вывод сокращенного ФИО сотрудника
        public string GettingLFMEmployee() => Employee.MName == "Не указано"
                                                             ? Employee.LName + " " + Employee.FName.Substring(0, 1) + "."
                                                             : Employee.LName + " " + Employee.FName.Substring(0, 1) + ". "
                                                             + Employee.FName.Substring(0, 1) + ".";

        //Вывод ФИО сотрудника полностью
        public string GettingFullLFMEmployee() => Employee.MName == "Не указано"
                                                                 ? Employee.LName + " " + Employee.FName
                                                                 : Employee.LName + " " + Employee.FName
                                                                 + Employee.FName;

        //Вывод номера телефона сотрудника
        public string GettingPhoneNumberEmployee() => Employee.Phone_number;

        //Вывод статуса сотрудника
        public string GettingStatusName() => Employee.Status_employees.Name;

        //Вывод фотографии сотрудника
        public ImageSource GettingPhoto()
        {
            ImageSource image;

            try
            {
                image = new BitmapImage(new Uri(Employee.Photo));
                return image;
            }
            catch
            {
                MessageBox.Show("Ошибка! Фотография отсутствует!", "Фотография не обнаружена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

        #region Изменение информации о сотруднике
        //Изменение фотографии сотрудника
        public void ChangePhoto(out ImageSource image)
        {
            using var db = new CafeEntities();
            var changePhoto = db.Employees.Where(emp => emp.ID == Employee.ID).FirstOrDefault();

            Microsoft.Win32.OpenFileDialog file = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Картинки(*.JPG; *.PNG)| *.JPG; *.PNG",
                CheckFileExists = true,
                Title = "Выберете изображение"
            };

            image = null;

            if (file.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(file.FileName));
                changePhoto.Photo = file.FileName;

                db.SaveChanges();
            }
        }
        #endregion
    }
}
