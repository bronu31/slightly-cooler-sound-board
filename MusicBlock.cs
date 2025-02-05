using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace slightly_cooler_sound_board
{
    internal class MusicBlock : Button
    {
        private string _fileName {  get; set; }
        private string _filePath {  get; set; }
        private Slider _slider { get; set; }

        public MusicBlock(string filePath, string fileName)
        {
            this._fileName = fileName;
            this._filePath = filePath;

            TextBlock textBlock = new()
            {
                Text = fileName
            };

            _slider = new Slider();
            _slider.Minimum = 0;
            _slider.Maximum = 100;
            _slider.Value = 100;

            StackPanel stackPanel = new();
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(_slider);

            
            Style buttonStyle = new Style(typeof(MusicBlock), Application.Current.FindResource(typeof(Button)) as Style);
            this.Style = buttonStyle;
            this.Width = 100;
            this.Height = 100;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.Content = stackPanel;
            this.Click += clickPlay;
        }




        public void Draw(StackPanel motherGroupBox) 
        {
            motherGroupBox.Children.Add(this);
        }

        private void clickPlay(object sender, RoutedEventArgs e) 
        {

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(this._filePath));
            mediaPlayer.Volume =_slider.Value/100f;
            mediaPlayer.Play();

        }

    }
}
