﻿using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slightly_cooler_sound_board
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            if (File.Exists("saved sounds.json"))
            {
                WorkingWithFiles.ReadSaveFile(grid);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".wav"; // Default file extension
            dialog.Filter = "wavava files (.wav)|*.wav"; // Filter files by extension
            dialog.Multiselect = true;
            // Show open file dialog box
            bool? result = dialog.ShowDialog();
            // Process open file dialog box results

            if (result == true)
            {
                for (int i=0;i<dialog.FileNames.Length;i++) 
                {
                    MusicBlock musicBlock = new MusicBlock(dialog.FileNames[i], dialog.SafeFileNames[i], -1);
                    grid.Children.Add(musicBlock);
                }

            }
        }


        private void SaveBeforeClosing(object sender, CancelEventArgs e) 
        {
            WorkingWithFiles.CreateSaveFile(grid);
            Trace.WriteLine("closing");
        }
    }
}