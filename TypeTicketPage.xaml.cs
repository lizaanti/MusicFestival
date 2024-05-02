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
    /// Логика взаимодействия для TypeTicketPage.xaml
    /// </summary>
    public partial class TypeTicketPage : Page
    {
        public TypeTicketPage()
        {
            InitializeComponent();
            DGridTypeTicket.ItemsSource = MusFestivalEntities.GetContext().ТипБилета.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditTypeTicketPage.xaml", UriKind.Relative));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var TTRemov = DGridTypeTicket.SelectedItems.Cast<ТипБилета>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {TTRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().ТипБилета.RemoveRange(TTRemov);
                    MusFestivalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToLower());
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("StartPage.xaml", UriKind.Relative));
        }
    }
}
