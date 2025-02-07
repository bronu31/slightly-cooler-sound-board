
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Controls;

namespace slightly_cooler_sound_board
{
    internal class WorkingWithFiles
    {
        public static void CreateSaveFile(StackPanel stack)
        {

            ArrayList blocks = new ArrayList(stack.Children.OfType<MusicBlock>().ToList());
        string json= JsonConvert.SerializeObject(blocks,Formatting.Indented);
            File.WriteAllText("saved sounds.json", json);
        }

        public static void ReadSaveFile(StackPanel stack)
        {
            string json = File.ReadAllText("saved sounds.json");
            JArray blocks = JArray.Parse(json);
            foreach (var block in blocks)
            {
                MusicBlock musicBlock = new MusicBlock(block["path"].ToString(), block["name"].ToString(), (int)block["volume"]);
                stack.Children.Add(musicBlock);
            }

        }
    }
}
