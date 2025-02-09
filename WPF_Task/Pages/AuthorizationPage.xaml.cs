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
using WPF_Task.PagesController;

namespace WPF_Task.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        private AuthorizePageController _authorizePageController;

        public AuthorizationPage()
        {
            InitializeComponent();
            _authorizePageController = new AuthorizePageController();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             string login = TextBoxLogin.Text;
             string password = TextBoxPassword.Text;

            DataStorage.CurrentUser = _authorizePageController.FindUserByLoginAndPassword(login, password);

            switch(DataStorage.CurrentUser.RoleId)
                {
                    case 1:
                        NavigationService.Navigate(new AdminMainPage());
                        break;

                    case 2:
                        NavigationService.Navigate(new ManagerMainPage());
                        break;

                    case 3:
                        NavigationService.Navigate(new ClientMainPage());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }
    }
}
