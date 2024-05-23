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

        public string role;
        
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentPlace;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPlace.локация))
                errors.AppendLine("Укажите локацию места проведения!");
            if ((_currentPlace.название == null) ||(CmbNamePlace.Text == ""))
                errors.AppendLine("Выберите название места проведения!");
            
            else
                _currentPlace.название = CmbNamePlace.Text;

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPlace.id_места == 0)
                MusFestivalEntities.GetContext().Место.Add(_currentPlace);

            try
            {
                MusFestivalEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Page_IsVisibileChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                MusFestivalEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                //.ItemSources = MusFestivalEntities.GetContext().Место.ToList();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            PlacesPage newPage = new PlacesPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            CmbNamePlace.Text = "";
            LocPlaceTbx.Text = "";
        }
    }
}
