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

namespace StoreStroy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginElement.Text;
            string password = passwordElement.Password;

            User user = Helpers.Auth(login, password);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }


            if (user.UserPassword != password)
            {
                MessageBox.Show("Неверный пароль!");
                return;
            }

            Store.user = user;
            if (user.UserRole == 1)
            {
                new Admin().Show();
                Close();
            }
            else if (user.UserRole != 1)
            {
                new ClientManager().Show();
                Close();
            }

            MessageBox.Show($"Добро пожаловать, {user.UserName} {user.UserPatronymic} {user.UserSurname}");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Guest guest = new Guest();
            guest.Show();
            Close();
        }

        


    }
}
