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
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void BtnFest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("FestivalPage.xaml", UriKind.Relative));
        }

        private void BtnArtist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ArtistPage.xaml", UriKind.Relative));
        }

        private void BtnSongs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("SongsPage.xaml", UriKind.Relative));
        }

        private void BtnSpeeches_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("SpeechesPage.xaml", UriKind.Relative));
        }

        private void BtnGenre_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("GenrePage.xaml", UriKind.Relative));
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("OrdersPage.xaml", UriKind.Relative));
        }

        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("TicketPage.xaml", UriKind.Relative));
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ClientPage.xaml", UriKind.Relative));
        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("StaffPage.xaml", UriKind.Relative));
        }

        private void BtnJobTitle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("JobTitlePage.xaml", UriKind.Relative));
        }

        private void BtnPlace_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("PlacesPage.xaml", UriKind.Relative));
        }

        private void BtnNamePlace_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("NamePlacePage.xaml", UriKind.Relative));
        }

        private void BtnScene_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ScenePage.xaml", UriKind.Relative));
        }

        private void BtnRole_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("RolePage.xaml", UriKind.Relative));
        }

        private void BtnTicketType_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("TypeTicketPage.xaml", UriKind.Relative));
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("ReportsPage.xaml", UriKind.Relative));
        }
    }
}
