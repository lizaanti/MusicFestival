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
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        public string role;

        public ReportsPage()
        {
            InitializeComponent();
        }

        private void BtnClientReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            ClientReportPage newPage = new ClientReportPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnArtistReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            ArtistReportPage newPage = new ArtistReportPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            StartPage newPage = new StartPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        //private void BtnStaffReport_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService nav = NavigationService.GetNavigationService(this);
        //    nav.Navigate(new Uri("StaffReportPage.xaml", UriKind.Relative));
        //}
    }
}
