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
    /// Логика взаимодействия для StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        public string role;

        public StaffPage()
        {
            InitializeComponent();
            DGridStaff.ItemsSource = MusFestivalEntities.GetContext().Сотрудники.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Сотрудник")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            EditStaffPage newPage = new EditStaffPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Сотрудник")
            {
                return;
            }
            var StaffRemov = DGridStaff.SelectedItems.Cast<Сотрудники>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {StaffRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Сотрудники.RemoveRange(StaffRemov);
                    MusFestivalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToLower());
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            StartPage newPage = new StartPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
