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
    /// Логика взаимодействия для EditTicketPage.xaml
    /// </summary>
    public partial class EditTicketPage : Page
    {
        private Билеты _currentTicket = new Билеты();

        public EditTicketPage()
        {
            InitializeComponent();
            DataContext = _currentTicket;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            
            if ((_currentTicket.тип_билета == null) || (CmbTypeTicket.Text == ""))
                errors.AppendLine("Выберите тип билета!");
            if ((_currentTicket.цена == null) || (CmbPriceTicket.Text == ""))
                errors.AppendLine("Выберите цену билета!");
            else
            {
                _currentTicket.тип_билета = CmbTypeTicket.Text;
                _currentTicket.цена = Convert.ToInt32(CmbPriceTicket.Text);

            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentTicket.id_билета == 0)
                MusFestivalEntities.GetContext().Билеты.Add(_currentTicket);

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
            nav.Navigate(new Uri("TicketPage.xaml", UriKind.Relative));
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            CmbTypeTicket.Text = "";
            CmbPriceTicket.Text = "";
        }
    }
}
