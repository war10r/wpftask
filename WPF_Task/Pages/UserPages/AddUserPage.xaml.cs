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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Task.Models;
using WPF_Task.Repositories;

namespace WPF_Task.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        UsersRepository usersRepository;
        public AddUserPage()
        {
            InitializeComponent();
            usersRepository = new UsersRepository();

            ComboBoxRole.ItemsSource = Connect.DbConnection.Roles.ToList();
            ComboBoxRole.DisplayMemberPath = "Name";
        }

        private void ButtonAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            if(TextBoxName.Text.Length == 0)
            {
                MessageBox.Show("Длина имени не может быть 0");
                return;
            }

            if (TextBoxSurname.Text.Length == 0)
            {
                MessageBox.Show("Длина имени не может быть 0");
                return;
            }

            if (TextBoxPhoneNumber.Text.Length == 0)
            {
                MessageBox.Show("Длина имени не может быть 0");
                return;
            }

            if (TextBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("Длина имени не может быть 0");
                return;
            }

            if (TextBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("Длина имени не может быть 0");
                return;
            }

            if (ComboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль пользователя");
                return;
            }
            try
            {
                usersRepository.AddNewUser
                    (
                    TextBoxName.Text,
                    TextBoxSurname.Text,
                    TextBoxPhoneNumber.Text,
                    TextBoxEmail.Text,
                    TextBoxPassword.Text,
                    ((Role)ComboBoxRole.SelectedItem).Id
                    );

                TextBoxName.Clear();
                TextBoxSurname.Clear();
                TextBoxPhoneNumber.Clear();
                TextBoxEmail.Clear();
                TextBoxPassword.Clear();
                ComboBoxRole.SelectedItem = null;
                
                MessageBox.Show("Пользователь успешно добавлен");
                EventPagesAggregator.NotifyDataUpdated();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! Не удалось добавить пользователя");
            }
            
        }
    }
}
