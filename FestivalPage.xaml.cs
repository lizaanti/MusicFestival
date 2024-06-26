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
    /// Логика взаимодействия для FestivalPage.xaml
    /// </summary>
    public partial class FestivalPage : Page
    {
        public string role;

        public FestivalPage()
        {
            InitializeComponent();
            DGridMFestival.ItemsSource = MusFestivalEntities.GetContext().Фестиваль.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист" || role == "Сотрудник")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            EditFestivalPage newPage = new EditFestivalPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Гость" || role == "Артист" || role == "Сотрудник")
            {
                return;
            }
            var FestivalRemov = DGridMFestival.SelectedItems.Cast<Фестиваль>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {FestivalRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Фестиваль.RemoveRange(FestivalRemov);
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
