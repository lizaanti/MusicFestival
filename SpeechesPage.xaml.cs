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
    /// Логика взаимодействия для SpeechesPage.xaml
    /// </summary>
    public partial class SpeechesPage : Page
    {
        public string role;

        public SpeechesPage()
        {
            InitializeComponent();
            DGridSpeeches.ItemsSource = MusFestivalEntities.GetContext().Выступления.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }
            NavigationService nav = NavigationService.GetNavigationService(this);
            EditSpeechesPage newPage = new EditSpeechesPage();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Артист")
            {
                return;
            }
            var SpeechRemov = DGridSpeeches.SelectedItems.Cast<Выступления>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {SpeechRemov.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MusFestivalEntities.GetContext().Выступления.RemoveRange(SpeechRemov);
                    MusFestivalEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToLower());
                }
            }
        }
    }
}
