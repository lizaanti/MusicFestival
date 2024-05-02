using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для PlacesPage.xaml
    /// </summary>
    public partial class PlacesPage : Page
    {
        public PlacesPage()
        {
            InitializeComponent();
            DGridFestival.ItemsSource = MusFestivalEntities.GetContext().Место.ToList();
        }
 
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("AddEditPage.xaml", UriKind.Relative));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var PlaceRemov = DGridFestival.SelectedItems.Cast<Место>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {PlaceRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Место.RemoveRange(PlaceRemov);
                    MusFestivalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToLower());
                }
            }
        }

        private void DGridFestival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibaleChanged(object sender, DependencyPropertyChangedEventArgs e) 
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("StartPage.xaml", UriKind.Relative));
        }
    }
}
