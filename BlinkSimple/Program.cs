using Iot.Device.Ws28xx.Esp32;
using System.Drawing;
using System.Threading;

namespace BlinkSimple
{
    public class Program
    {
        // 1 �����飬1����
        const int Count = 1;
        // ΢ѩ�� ESP32-S2-Pico �� LED Pin
        const int Pin = 9;
        public static void Main()
        {
            // ע�⣺ʹ�� Ws2812c
            Ws28xx neo = new Ws2812c(Pin, Count);
            BitmapImage img = neo.Image;

            for (; ; )
            {
                img.SetPixel(0, 0, Color.Red);
                neo.Update();
                Thread.Sleep(500);
                img.SetPixel(0, 0, 0, 255, 0);
                neo.Update();
                Thread.Sleep(500);
                img.SetPixel(0, 0, 0, 0, 255);
                neo.Update();
                Thread.Sleep(500);
            }
            
        }
    }
}
