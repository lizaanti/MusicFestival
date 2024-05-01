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
    /// Логика взаимодействия для EditRolePage.xaml
    /// </summary>
    public partial class EditRolePage : Page
    {
        private Роли _currentRole = new Роли();

        public EditRolePage()
        {
            InitializeComponent();
            DataContext = _currentRole;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentRole.логин))
                errors.AppendLine("Введите логин!");
            if (string.IsNullOrWhiteSpace(_currentRole.пароль))
                errors.AppendLine("Введите пароль!");
            if ((_currentRole.роль == null) || (CmbRole.Text == ""))
                errors.AppendLine("Выберите роль!");

            else
                _currentRole.роль = CmbRole.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentRole.id == 0)
                MusFestivalEntities.GetContext().Роли.Add(_currentRole);

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
            TbxLog.Text = "";
            TbxPass.Text = "";
            CmbRole.Text = "";
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("RolePage.xaml", UriKind.Relative));
        }
    }
}
