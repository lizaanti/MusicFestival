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
    /// Логика взаимодействия для GenrePage.xaml
    /// </summary>
    public partial class GenrePage : Page
    {
        public string role;

        public GenrePage()
        {
            InitializeComponent();
            DGridGenre.ItemsSource = MusFestivalEntities.GetContext().Жанр.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            EditGenrePage newPage = new EditGenrePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }
            var GenreRemov = DGridGenre.SelectedItems.Cast<Жанр>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {GenreRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Жанр.RemoveRange(GenreRemov);
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
