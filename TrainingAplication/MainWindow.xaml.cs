using Microsoft.Win32;
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
using TagLib;
using WMPLib;

namespace TrainingAplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WMPLib.WindowsMediaPlayer player;
        Track Track = null;
        PlayList Playlist = null;
        public MainWindow()
        {
            InitializeComponent();
            Playlist = new PlayList();
            Playlist.LoadList();
            Track = Playlist.Playlist.First();
            ArtistBox.Text = Track.artist;
            GenreBox.Text = Track.genre;
            AlbumBox.Text = Track.album;
            TitleBox.Text = Track.title;
            YearBox.Text = Track.year.ToString();
            CommentBox.Text = Track.comment;
            textBox.Text = Track.path;
            player = new WMPLib.WindowsMediaPlayer();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open audio file";
            fDialog.InitialDirectory = @"D:\Muzyka";
            fDialog.Multiselect = true;
            fDialog.ShowDialog();
            Track = new Track(fDialog.FileName);
            ArtistBox.Text = Track.artist;
            GenreBox.Text = Track.genre;
            AlbumBox.Text = Track.album;
            TitleBox.Text = Track.title;
            YearBox.Text = Track.year.ToString();
            CommentBox.Text = Track.comment;
            textBox.Text = fDialog.FileName;

        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            player.URL = textBox.Text;
            player.controls.play();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            player.controls.stop();
        }
    }
}
