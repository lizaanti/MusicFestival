﻿using System;
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
    /// Логика взаимодействия для StaffReportPage.xaml
    /// </summary>
    public partial class StaffReportPage : Page
    {
        public StaffReportPage()
        {
            InitializeComponent();
            //DGridStaffReport.ItemsSource = MusFestivalEntities.GetContext().УчетСотрудников.ToList();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
