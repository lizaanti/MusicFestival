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
    /// Логика взаимодействия для EditSongPage.xaml
    /// </summary>
    public partial class EditSongPage : Page
    {
        private Песни _currentSong = new Песни();

        public string role;

        public EditSongPage()
        {
            InitializeComponent();
            DataContext = _currentSong;
        }

        private void BtnCanel_Click(object sender, RoutedEventArgs e)
        {
            TxbNameSong.Text = "";
            TbxHwLong.Text = "";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSong.название_песни))
                errors.AppendLine("Введите название песни!");
            if (string.IsNullOrWhiteSpace(_currentSong.продолжительность_песни))
                errors.AppendLine("Введите продолжительность песни!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSong.id_песни == 0)
                MusFestivalEntities.GetContext().Песни.Add(_currentSong);

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
            SongsPage newPage = new SongsPage();
            newPage.role = role;
            nav.Navigate(newPage);
        }
    }
}
