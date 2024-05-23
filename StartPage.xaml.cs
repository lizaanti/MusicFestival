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
        public string role;

        

        public StartPage()
        {
            InitializeComponent();
        }

        private void BtnFest_Click(object sender, RoutedEventArgs e)
        {

            NavigationService nav = NavigationService.GetNavigationService(this);
            FestivalPage newPage = new FestivalPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnArtist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            ArtistPage newPage = new ArtistPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void BtnSongs_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }


            NavigationService nav = NavigationService.GetNavigationService(this);
            SongsPage newPage = new SongsPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnSpeeches_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            SpeechesPage newPage = new SpeechesPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnGenre_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            GenrePage newPage = new GenrePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист")
            {
                return;
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            OrdersPage newPage = new OrdersPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            TicketPage newPage = new TicketPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            ClientPage newPage = new ClientPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист")
            {
                return;
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            StaffPage newPage = new StaffPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnJobTitle_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            JobTitlePage newPage = new JobTitlePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnPlace_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            PlacesPage newPage = new PlacesPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnNamePlace_Click(object sender, RoutedEventArgs e)
        {

            if (role == "Гость" || role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            NamePlacePage newPage = new NamePlacePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnScene_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            ScenePage newPage = new ScenePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnRole_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(role);
            if (role == "Гость" || role == "Артист" || role == "Сотрудник")
            {

                return;
                
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            RolePage newPage = new RolePage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnTicketType_Click(object sender, RoutedEventArgs e)
        {

            NavigationService nav = NavigationService.GetNavigationService(this);
            TypeTicketPage newPage = new TypeTicketPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист")
            {
                return;
            }

            NavigationService nav = NavigationService.GetNavigationService(this);
            ReportsPage newPage = new ReportsPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            AuthPage newPage = new AuthPage();
            newPage.role = role;
            nav.Navigate(newPage);
            
        }
    }
}
