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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            DGridOrders.ItemsSource = MusFestivalEntities.GetContext().Заказы.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditOrdersPage.xaml", UriKind.Relative));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("StartPage.xaml", UriKind.Relative));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var OrderRemov = DGridOrders.SelectedItems.Cast<Заказы>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {OrderRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Заказы.RemoveRange(OrderRemov);
                    MusFestivalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToLower());
                }
            }
        }
    }
}
