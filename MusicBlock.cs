
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Newtonsoft.Json;

namespace slightly_cooler_sound_board
{
[JsonObject(MemberSerialization.OptIn)]

    internal class MusicBlock : Button
    {
        [JsonProperty(PropertyName = "name")]
        private string _fileName {  get; set; }
        [JsonProperty(PropertyName = "path")]
        private string _filePath {  get; set; }
        [Newtonsoft.Json.JsonIgnore]
        private Slider _slider { get; set; }
        //[JsonPropertyName("volume")]
        [JsonProperty(PropertyName = "volume")]
        public int SliderValue => (int)(_slider?.Value ?? 0);


        public MusicBlock(string filePath, string fileName, int volume)
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
            _slider.Value = volume==-1 ? 100 : volume;

            StackPanel stackPanel = new();
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(_slider);


            this.Content = stackPanel;
            this.Click += clickPlay;
            this.Margin= new Thickness(5);
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
