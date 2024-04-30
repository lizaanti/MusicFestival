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
using System.Xml.Linq;

namespace MusicFestival
{
    /// <summary>
    /// Логика взаимодействия для EditArtistPage.xaml
    /// </summary>
    public partial class EditArtistPage : Page
    {
        private Исполнители _currentArtist = new Исполнители();
        private Жанр _currentGenre = new Жанр();
        public EditArtistPage()
        {
            InitializeComponent();
            DataContext = _currentArtist;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentArtist.имя))
                errors.AppendLine("Укажите имя исполнителя!");
            if ((_currentArtist.имя == null) || (CmbGenre.Text == ""))
                errors.AppendLine("Выберите жанр исполнителя!");
            else
            {
                _currentArtist.имя = CmbGenre.Text;
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if ((_currentArtist.id_исполнителя == 0)){
                MusFestivalEntities.GetContext().Исполнители.Add(_currentArtist);
            }

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
            TbxNameArtist.Text = "";
            CmbGenre.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ArtistPage.xaml", UriKind.Relative));
        }
    }
}