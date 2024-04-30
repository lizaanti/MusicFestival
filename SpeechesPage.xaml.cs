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
    /// Логика взаимодействия для SpeechesPage.xaml
    /// </summary>
    public partial class SpeechesPage : Page
    {

        public SpeechesPage()
        {
            InitializeComponent();
            DGridSpeeches.ItemsSource = MusFestivalEntities.GetContext().Выступления.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("EditSpeechesPage.xaml", UriKind.Relative));
        }
    }
}
