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
using WPF_Task.Pages.RequestPages;
using WPF_Task.Repositories;

namespace WPF_Task.Pages
{
    /// <summary>
    /// Логика взаимодействия для ManagerMainPage.xaml
    /// </summary>
    public partial class ManagerMainPage : Page
    {
        private RequestsRepositories requestsRepositories;
        public ManagerMainPage()
        {
            InitializeComponent();
            requestsRepositories = new RequestsRepositories();
        }

        private void ButtonAddNewRequest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRequestPage());
        }

        private void GridCustomerRequests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonDeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            DataStorage.CurrentRequest = (Request)GridCustomerRequests.SelectedItem;
            
            requestsRepositories.DeleteRequestFromDb(DataStorage.CurrentRequest.Id);
            DataStorage.CurrentRequest = null;
        }
    }
}
