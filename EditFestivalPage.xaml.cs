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
    /// Логика взаимодействия для EditFestivalPage.xaml
    /// </summary>
    public partial class EditFestivalPage : Page
    {
        private Фестиваль _currentFest = new Фестиваль();

        public EditFestivalPage()
        {
            InitializeComponent();
            DataContext = _currentFest;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentFest.название))
                errors.AppendLine("Введите название фестиваля!");
            if ((_currentFest.дата_начала == null))
                errors.AppendLine("Введите дату начала фестиваля!");
            if ((_currentFest.дата_окончания == null))
                errors.AppendLine("Введите дату окончания фестиваля!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentFest.id_фестиваля == 0)
                MusFestivalEntities.GetContext().Фестиваль.Add(_currentFest);

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
            TbxNameFest.Text = "";
            TbxDtStart.Text = "";
            TbxDtEnd.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("FestivalPage.xaml", UriKind.Relative));
        }
    }
}
