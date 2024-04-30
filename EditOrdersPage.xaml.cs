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
    /// Логика взаимодействия для EditOrdersPage.xaml
    /// </summary>
    public partial class EditOrdersPage : Page
    {
        private Заказы _currentOrders = new Заказы();
        private Посетители _currentPerson = new Посетители();
        public EditOrdersPage()
        {
            InitializeComponent();
            DataContext = _currentOrders;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentPerson.ФИО == null))
                errors.AppendLine("Укажите имя заказчика!");
            if ((_currentOrders.дата_брони == null))
                errors.AppendLine("Укажите дату брони билета!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if ((_currentOrders.id_заказа == 0) && (_currentOrders.id_билета == 0) && (_currentOrders.id_посетителя == _currentPerson.id_посетителя) && (_currentOrders.id_посетителя == 0))
                MusFestivalEntities.GetContext().Заказы.Add(_currentOrders);

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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("OrdersPage.xaml", UriKind.Relative));
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TbxName.Text = "";
            TbxDateOrders.Text = "";
        }
    }
}
