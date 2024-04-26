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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Место _currentPlace = new Место();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentPlace;
            App.Current.Resources["name"] = NamePlaces.Text;
            App.Current.Resources["loc"] = LocPlaces.Text;
            NavigationService.GetNavigationService(this).Navigate(new Uri("PlacesPage.xaml", UriKind.RelativeOrAbsolute));

            
        }

        

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPlace.название))
                errors.AppendLine("Укажите название места проведения");
            if (string.IsNullOrWhiteSpace(_currentPlace.название))
                errors.AppendLine("Укажите локацию места проведения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentPlace.id_места == 0)
            {
                MusFestivalEntities.GetContext().Место.Add(_currentPlace);
            }

            try
            {
                MusFestivalEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно сохранена!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
