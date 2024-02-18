using System;
using System.Collections.Generic;
using System.IO;
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

namespace musiclibraryprog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private const string MusicDbList = "musics.csv";

        private void MusicPlus(object sender, RoutedEventArgs e)
        {
            MusicEditorWindow window = new MusicEditorWindow();
            if (window.ShowDialog() == true)
            {
                MusicList.Items.Add(window.Music);
            }
        }

        private void MusicDelete(object sender, RoutedEventArgs e)
        {
            MusicList.Items.Remove(MusicList.SelectedItem);
        }

        private void MusicEditor(object sender, RoutedEventArgs e)
        {
            MusicEditorWindow window = new MusicEditorWindow();
            window.Music = (Music)MusicList.SelectedItem;
            window.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String[] lines = File.ReadAllLines(MusicDbList);
            foreach (String line in lines)
            {
                Music music = Music.FromCsv(line);
            }
        }
    }
}
