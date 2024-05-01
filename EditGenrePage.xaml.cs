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
    /// Логика взаимодействия для EditGenrePage.xaml
    /// </summary>
    public partial class EditGenrePage : Page
    {
        private Жанр _currentGenre = new Жанр();

        public EditGenrePage()
        {
            InitializeComponent();
            DataContext = _currentGenre;
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            CmbGenre.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentGenre.жанр == null) || (CmbGenre.Text == ""))
                errors.AppendLine("Укажите жанр!");

            else
                _currentGenre.жанр = CmbGenre.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentGenre.id == 0)
                MusFestivalEntities.GetContext().Жанр.Add(_currentGenre);

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
            nav.Navigate(new Uri("GenrePage.xaml", UriKind.Relative));
        }
    }
}
