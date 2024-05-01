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
    /// Логика взаимодействия для EditJobTitlePage.xaml
    /// </summary>
    public partial class EditJobTitlePage : Page
    {
        private Должность _currentJT = new Должность();

        public EditJobTitlePage()
        {
            InitializeComponent();
            DataContext = _currentJT;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentJT.должность1 == null) || (CmbJT.Text == ""))
                errors.AppendLine("Укажите должность!");

            else
                _currentJT.должность1 = CmbJT.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentJT.id == 0)
                MusFestivalEntities.GetContext().Должность.Add(_currentJT);

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
            CmbJT.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("JobTitlePage.xaml", UriKind.Relative));
        }
    }
}
