
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;

namespace slightly_cooler_sound_board
{
    internal class WorkingWithFiles
    {
        public static void CreateSaveFile(StackPanel stack)
        {
            Trace.WriteLine(stack.Children.OfType<Button>().ToString());

            ArrayList blocks = new ArrayList(stack.Children.OfType<MusicBlock>().ToList());
        string json= JsonConvert.SerializeObject(blocks,Formatting.Indented);
            Trace.WriteLine(blocks[0]);
            File.WriteAllText("saved sounds.json", json);
            Trace.WriteLine("blocks[0]");
        }

        public static void ReadSaveFile()
        {

        }
    }
}
