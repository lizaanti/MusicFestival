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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void logBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(LoginTB.Text) || string.IsNullOrEmpty(PassTB.Password))
            {
                MessageBox.Show("Введите логин или пароль!");
                return;
            }

            using (var db = new MusFestivalEntities())
            {
                var role = db.Роли
                    .AsNoTracking()
                    .FirstOrDefault(r => r.логин == LoginTB.Text && r.пароль == PassTB.Password);
                if(role == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
            }
        }
    }
}
