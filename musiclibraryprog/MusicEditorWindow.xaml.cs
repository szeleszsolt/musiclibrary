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
using System.Windows.Shapes;

namespace musiclibraryprog
{
    /// <summary>
    /// Interaction logic for MusicEditorWindow.xaml
    /// </summary>
    public partial class MusicEditorWindow : Window
    {
        public MusicEditorWindow()
        {
            InitializeComponent();
        }

        public Music? Music { get; set; }
        private void MentesClick(object sender, RoutedEventArgs e)
        {
            Music = new Music();
            Music.Title = SongTitle.Text;
            Music.Artist = SongArtist.Text;
            Music.Release = (DateTime)ReleaseDate.SelectedDate; /*Csak így hajlandó elfogatni.*/
            Music.Style = SongStyle.Text;
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) /*Valamiért nem működik*/
        {
            if (Music != null)
            {
                SongTitle.Text = Music.Title;
                SongArtist.Text = Music.Artist;
                ReleaseDate.SelectedDate = Music.Release;
                SongStyle.Text = Music.Style;
            }
        }

        private void Valtozas(object sender, TextChangedEventArgs e)
        {
            BTNSave.IsEnabled = !string.IsNullOrWhiteSpace(SongTitle.Text) && !string.IsNullOrWhiteSpace(SongArtist.Text) && !string.IsNullOrWhiteSpace(SongStyle.Text) && ReleaseDate.SelectedDate != null;
        }
    }
}
