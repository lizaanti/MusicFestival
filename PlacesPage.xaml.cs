using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для PlacesPage.xaml
    /// </summary>
    public partial class PlacesPage : Page
    {
        public static object name;
        public static object loc;
        public PlacesPage()
        {
            InitializeComponent();
            name = App.Current.Resources["name"];
            loc = App.Current.Resources["loc"];
            //DGridFestival.ItemsSource = MusFestivalEntities.GetContext().Место.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void bindDataGrid()
        {
            SqlConnection con = new SqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select *from[Место]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Место");
            da.Fill(dt);

            
            con.Close();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into[Место](название)values(@nm)";
            cmd.CommandText = "insert into[Место](локация)values(@lk)";
            cmd.Parameters.AddWithValue("@nm", name);
            cmd.Parameters.AddWithValue("@lk", loc);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a == 1)
            {
                MessageBox.Show("Информация успешно добавлена!");
                bindDataGrid();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGridFestival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibaleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            if(Visibility == Visibility.Visible)
            {
                MusFestivalEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridFestival.ItemsSource = MusFestivalEntities.GetContext().Место.ToList();
            }
        }

        
    }
}
