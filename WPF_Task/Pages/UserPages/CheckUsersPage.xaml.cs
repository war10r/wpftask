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
using WPF_Task.Pages.UserPages;
using WPF_Task.Repositories;

namespace WPF_Task.Pages
{
    /// <summary>
    /// Логика взаимодействия для CheckUsersPage.xaml
    /// </summary>
    public partial class CheckUsersPage : Page
    {
        private UsersRepository usersRepository;
        public CheckUsersPage()
        {
            InitializeComponent();
            FillGridUsersInformation();
            EventPagesAggregator.GridDataUpdated += FillGridUsersInformation;
        }

        private void FillGridUsersInformation()
        {
            this.GridUsersInformation.ItemsSource = Connect.DbConnection.Users.ToList();
        }
        private void ButtonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(GridUsersInformation.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пользователя для удаления");
                return;
            }
            
            DataStorage.CurrentUser = (User)GridUsersInformation.SelectedItem;
            usersRepository.DeleteUserFromDb(DataStorage.CurrentUser.Id);
            DataStorage.CurrentUser = null;
        }

        private void ButtonAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }
        private void ButtonUpdateUser_Click(Object sender, RoutedEventArgs e)
        {
            if(GridUsersInformation.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пользователя для обновления");
                return;
            }

            DataStorage.CurrentUser = (User)this.GridUsersInformation.SelectedItem;
            NavigationService.Navigate(new UpdateUserPage());
        }

        private void TextBoxFindByName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchName = TextBoxFindByName.Text;

            if(searchName.Length == 0)
            {
                return;
            }

            this.GridUsersInformation.ItemsSource = null;
            this.GridUsersInformation.ItemsSource = Connect.DbConnection.Users.Where(item => item.Name.Contains(searchName)).ToList();
        }
    }
}
