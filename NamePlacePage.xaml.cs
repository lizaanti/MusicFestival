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
    /// Логика взаимодействия для NamePlacePage.xaml
    /// </summary>
    public partial class NamePlacePage : Page
    {
        public NamePlacePage()
        {
            InitializeComponent();
            DGridNamePlace.ItemsSource = MusFestivalEntities.GetContext().НазваниеМест.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditNamePlacePage.xaml", UriKind.Relative));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var NameplaceRemov = DGridNamePlace.SelectedItems.Cast<НазваниеМест>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {NameplaceRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().НазваниеМест.RemoveRange(NameplaceRemov);
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
