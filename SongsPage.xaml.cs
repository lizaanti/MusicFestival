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
    /// Логика взаимодействия для SongsPage.xaml
    /// </summary>
    public partial class SongsPage : Page
    {
        public string role;

        public SongsPage()
        {
            InitializeComponent();
            DGridSong.ItemsSource = MusFestivalEntities.GetContext().Песни.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            EditSongPage newPage = new EditSongPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }

            var SongRemov = DGridSong.SelectedItems.Cast<Песни>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {SongRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Песни.RemoveRange(SongRemov);
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
