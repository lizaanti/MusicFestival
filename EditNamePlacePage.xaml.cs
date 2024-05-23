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
    /// Логика взаимодействия для EditNamePlacePage.xaml
    /// </summary>
    public partial class EditNamePlacePage : Page
    {
        private НазваниеМест _currentNPlace = new НазваниеМест();

        public string role;

        public EditNamePlacePage()
        {
            InitializeComponent();
            DataContext = _currentNPlace;
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TbxNmPlc.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentNPlace.название_места == null))
                errors.AppendLine("Укажите название!");

            else
                _currentNPlace.название_места = TbxNmPlc.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentNPlace.id == 0)
                MusFestivalEntities.GetContext().НазваниеМест.Add(_currentNPlace);

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
            NamePlacePage newPage = new NamePlacePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
