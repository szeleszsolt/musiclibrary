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

        }
    }
}
