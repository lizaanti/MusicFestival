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

namespace MusicFestival
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public string role;

        public AuthPage()
        {
            InitializeComponent();
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            Auth(LoginTB.Text, PassTB.Password);
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин или пароль!");
                return false;
            }

            using (var db = new MusFestivalEntities())
            {
                var role = db.Роли
                    .AsNoTracking()
                    .FirstOrDefault(r => r.логин == login && r.пароль == password);
                if (role == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    LoginTB.Clear();
                    PassTB.Clear();
                    return false;
                }
                else
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    StartPage newPage = new StartPage();
                    newPage.role = role.роль;
                    nav.Navigate(newPage);
                }

                LoginTB.Clear();
                PassTB.Clear();

                return true;
            }
        }
    }
}
