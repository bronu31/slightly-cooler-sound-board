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

        public MusicBlock(string fileName)
        {
            this._fileName = fileName;
            this._button = new Button();
            this._button.Height=50;
            this._button.Height=50;
            this._button.Content=fileName;
            this._button.Click += clickPlay;
            Trace.WriteLine(this._fileName);
        }


        public void draw(StackPanel motherGroupBox) 
        {
            motherGroupBox.Children.Add(this._button);
        }

        private void clickPlay(object sender, RoutedEventArgs e) 
        {
            /*SoundPlayer soundPlayer = new SoundPlayer(_fileName);
            soundPlayer.Stream = System.IO.File.OpenRead(_fileName);
            if (soundPlayer.Stream.CanSeek)
            {
                soundPlayer.Stream.Seek(0, SeekOrigin.Begin);
                
                soundPlayer.Play();

            }*/
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(this._fileName));
            mediaPlayer.Volume = 0.1;
            mediaPlayer.Play();
        }

    }
}
