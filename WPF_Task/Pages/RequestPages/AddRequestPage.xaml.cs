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

namespace WPF_Task.Pages.RequestPages
{
    /// <summary>
    /// Логика взаимодействия для AddRequestPage.xaml
    /// </summary>
    public partial class AddRequestPage : Page
    {
        RequestsRepositories requestsRepositories;
        public AddRequestPage()
        {
            InitializeComponent();
            requestsRepositories = new RequestsRepositories();

            ComboBoxSelectedClient.ItemsSource = requestsRepositories.GetAllUsers().Where(item => item.RoleId == 3);
            ComboBoxSelectedClient.DisplayMemberPath = "Name" + "Surname" + "PhoneNumber";

            ComboBoxSelectedGoods.ItemsSource = requestsRepositories.GetAllGoods();
            ComboBoxSelectedGoods.DisplayMemberPath = "Name";
        }

        private void AddNewRequest_Click(object sender, RoutedEventArgs e)
        {
            requestsRepositories.AddNewRequest((((User)ComboBoxSelectedClient.SelectedItem).Id), (((Good)ComboBoxSelectedGoods.SelectedItem).Id));
        }
    }
}
