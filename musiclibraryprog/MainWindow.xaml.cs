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
                Save();
            }
        }

        private void MusicDelete(object sender, RoutedEventArgs e)
        {
            MusicList.Items.Remove(MusicList.SelectedItem);
            Save();
        }

        private void MusicEditor(object sender, RoutedEventArgs e)
        {
            MusicEditorWindow window = new MusicEditorWindow();
            window.Music = (Music)MusicList.SelectedItem;
            window.ShowDialog();
            Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(MusicDbList))
            {
                String[] lines = File.ReadAllLines(MusicDbList);
                foreach (String line in lines)
                {
                    Music music = Music.FromCsv(line);
                    MusicList.Items.Add(music);
                }


            }
            else
            {
                File.Create(MusicDbList);
            }
                
        }

        private void Save()
        {
            List<string> op = new List<string>();
            foreach (Music item in MusicList.Items)
            {
                op.Add(item.ToCsv());
            }
            File.WriteAllLines(MusicDbList, op);
        }
    }
}
