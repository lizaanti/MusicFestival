using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для EditSpeechesPage.xaml
    /// </summary>
    public partial class EditSpeechesPage : Page
    {
        public string role;

        private Выступления _currentSpeeches = new Выступления();
        public EditSpeechesPage()
        {
            InitializeComponent();
            DataContext = _currentSpeeches;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentSpeeches.время_начала == null))
                errors.AppendLine("Укажите время начала выступления!");
            if ((_currentSpeeches.время_окончания == null))
                errors.AppendLine("Укажите время окончания выступления!");
            

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if ((_currentSpeeches.id_выступления == 0))
                MusFestivalEntities.GetContext().Выступления.Add(_currentSpeeches);

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
            SpeechesPage newPage = new SpeechesPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TbxStartTime.Text = "";
            TbxEndTime.Text = "";
        }
    }
}
