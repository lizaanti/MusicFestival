using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicFestival
{
    /// <summary>
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        
        private Посетители _currentClient = new Посетители();

        public string role;

        public EditClientPage()
        {
            InitializeComponent();
            DataContext = _currentClient;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            ClientPage newPage = new ClientPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentClient.ФИО) == null)
                errors.AppendLine("Введите ФИО посетителя!");
            if (string.IsNullOrWhiteSpace(_currentClient.почта))
                errors.AppendLine("Введите почту!");
            if (string.IsNullOrWhiteSpace(_currentClient.номер_телефона))
                errors.AppendLine("Введите номер телефона!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentClient.id_посетителя == 0)
                MusFestivalEntities.GetContext().Посетители.Add(_currentClient);

            try
            {
                MusFestivalEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        
        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TbxFIO.Text = "";
            TbxMail.Text = "";
            TbxNumber.Text = "";
        }
    }
}
