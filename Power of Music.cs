using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
namespace slightly_cooler_sound_board
{
    internal class Power_of_Music
    {
        public static string[] GetAllAudioInputs() 
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
            WaveInCapabilities deviceInfo = WaveIn.GetCapabilities(i);
            }
            return null;
        }

        public static string[] GetAllAudioOutputs()
        {
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities deviceInfo = WaveOut.GetCapabilities(i);
            }
            return null;
        }
    }
}
