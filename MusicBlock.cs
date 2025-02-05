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
    internal class MusicBlock 
    {
        private string _fileName {  get; set; }
        private string _filePath {  get; set; }
        private Button _button { get; set; }
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

            this._button = new Button
            {
                Content = stackPanel
            };
            this._button.Click += clickPlay;
        }


        public void Draw(StackPanel motherGroupBox) 
        {
            motherGroupBox.Children.Add(this._button);
        }

        private void clickPlay(object sender, RoutedEventArgs e) 
        {

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(this._filePath));
            mediaPlayer.Volume =_slider.Value/100f;
            mediaPlayer.Play();


        }

        public override string ToString() {
        return this._fileName + this._filePath + this._slider.GetValue;
        }

    }
}
