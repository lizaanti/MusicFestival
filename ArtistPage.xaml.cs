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
    /// Логика взаимодействия для ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : Page
    {
        public string role;

        public ArtistPage()
        {
            InitializeComponent();
            DGridArtist.ItemsSource = MusFestivalEntities.GetContext().Исполнители.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditArtistPage.xaml", UriKind.Relative));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }
            var ArtistRemov = DGridArtist.SelectedItems.Cast<Исполнители>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ArtistRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Исполнители.RemoveRange(ArtistRemov);
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
            StartPage newPage = new StartPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
