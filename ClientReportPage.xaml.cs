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
    /// Логика взаимодействия для ClientReportPage.xaml
    /// </summary>
    public partial class ClientReportPage : Page
    {
        public string role;

        public ClientReportPage()
        {
            InitializeComponent();
            DGridClientReport.ItemsSource = MusFestivalEntities.GetContext().УчетПосетителей.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            ReportsPage newPage = new ReportsPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
