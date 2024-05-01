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
    /// Логика взаимодействия для EditTypeTicketPage.xaml
    /// </summary>
    public partial class EditTypeTicketPage : Page
    {
        private ТипБилета _currentType = new ТипБилета();

        public EditTypeTicketPage()
        {
            InitializeComponent();
            DataContext = _currentType;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if ((_currentType.тип == null) || (CmbTicketType.Text == ""))
                errors.AppendLine("Укажите тип билета!");

            else
                _currentType.тип = CmbTicketType.Text;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentType.id == 0)
                MusFestivalEntities.GetContext().ТипБилета.Add(_currentType);

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
            CmbTicketType.Text = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("TypeTicketPage.xaml", UriKind.Relative));
        }
    }
}