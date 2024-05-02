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
    /// Логика взаимодействия для EditScenePage.xaml
    /// </summary>
    public partial class EditScenePage : Page
    {
        private Сцены _currentScene = new Сцены();

        public EditScenePage()
        {
            InitializeComponent();
            DataContext = _currentScene;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentScene.id_выступления == 0)
                errors.AppendLine("Введите номер выступления!");
            if ((_currentScene.вместимость_сцены == null))
                errors.AppendLine("Введите вместимость сцены!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentScene.id_сцены == 0)
                MusFestivalEntities.GetContext().Сцены.Add(_currentScene);

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
            TbxNumSh.Text = "";
            TbxCpc.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ScenePage.xaml", UriKind.Relative));
        }
    }
}
