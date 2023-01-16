
using System.Threading;
using BlinkBoardLed.WS2812;

namespace BlinkBoardLed
{
    public class Program
    {


        public static void Main()
        {
            // ESP32 WS2812 Driver
            // https://github.com/nanoframework/nf-Community-Contributions/tree/master/drivers/ESP32-WS2812

            // ΢ѩ�� ESP32-S2-Pico ֻ��һ������

            // ���ɶ�������ɫ
            uint ledCount = 25;

            PixelController controller = new PixelController(9, ledCount);

            
            // �򵥲�����ɫ
            controller.SetColor(0,255,0,0);//��
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 0, 255, 0);//��
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 0, 0, 255);//��
            controller.UpdatePixels();
            Thread.Sleep(1000);
            controller.SetColor(0, 255, 255, 255);//��
            controller.UpdatePixels();
            Thread.Sleep(1000);

            // ������Ч��
            var ts = 0;
            for (; ; )
            {
                var add = true;
                var v = 0f;
                for (; ; )
                {
                    controller.SetHSVColor(0, 240, 50, v);
                    controller.UpdatePixels();
                    if (add)
                    {
                        v += 0.05f;
                    }
                    else
                    {
                        v -= 0.05f;
                    }
                    
                    if (v >= 1) add = false;
                    if (v <= 0) break;
                    Thread.Sleep(50);
                }
                if (ts > 5) break;
                ts++;
            }




            // ��ӿ�ʼʱ���õ� ledCount ����ɫ
            int step = (int)(360 / ledCount);
            var hue = 0;
            for (uint i = 0; i < ledCount; i++)
            {
                // HSV
                // ɫ��H ȡֵ��ΧΪ0�㡫360��
                // ���Ͷ�S ȡֵ��ΧΪ0%��100%��ֵԽ����ɫԽ����
                // ����V ��ʾ��ɫ�����ĳ̶�,ͨ��ȡֵ��ΧΪ0%���ڣ���100%���ף�
                // V ���ȡֵͦ�õģ�����Ϊ1 �����Ϲ
                controller.SetHSVColor((short)i, (short)hue, 1, 0.05f);
                hue = hue + step;
                controller.UpdatePixels();
            }

            // ѭ���任��ɫ
            for (; ; )
            {
                controller.MovePixelsByStep(1);
                controller.UpdatePixels();
                Thread.Sleep(500);
            }
        }
    }
}
