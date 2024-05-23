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

        public string role;

        public EditJobTitlePage()
        {
            InitializeComponent();
            DataContext = _currentJT;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentJT.сотрдолжность == null))
                errors.AppendLine("Укажите должность!");

            else
                _currentJT.сотрдолжность = TbxJT.Text;

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
            TbxJT.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            JobTitlePage newPage = new JobTitlePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
