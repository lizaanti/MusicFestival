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
    /// Логика взаимодействия для EditStaffPage.xaml
    /// </summary>
    public partial class EditStaffPage : Page
    {
        private Сотрудники _currentStaff = new Сотрудники();
        public EditStaffPage()
        {
            InitializeComponent();
            DataContext = _currentStaff;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentStaff.имя))
                errors.AppendLine("Введите ФИО сотрудника!");
            if ((_currentStaff.должность == null) || (CmbJobTitle.Text == ""))
                errors.AppendLine("Выберите должность сотрудника!");

            else
                _currentStaff.должность = CmbJobTitle.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentStaff.id == 0)
                MusFestivalEntities.GetContext().Сотрудники.Add(_currentStaff);

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
            nav.Navigate(new Uri("StaffPage.xaml", UriKind.Relative));
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TbxNameStaff.Text = "";
            CmbJobTitle.Text = "";
        }
    }
}
