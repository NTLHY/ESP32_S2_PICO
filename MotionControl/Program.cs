using Iot.Device.ServoMotor;
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.Gpio;
using System.Device.Pwm;
using System.Diagnostics;
using System.Threading;

namespace MotionControl
{
    public class Program
    {
        private static GpioPin _a1;
        private static GpioPin _a2;

        public static void Main()
        {
            var gpioController = new GpioController();
            // GP2 ������� A1
            _a1 = gpioController.OpenPin(2, PinMode.Output);
            // GP3 ������� A2
            _a2 = gpioController.OpenPin(3, PinMode.Output);

            /*
            // �������
            // ��ת
            _a1.Write(PinValue.High);
            _a2.Write(PinValue.Low);
            Thread.Sleep(2000);
            // ��ת
            _a1.Write(PinValue.Low);
            _a2.Write(PinValue.High);
            Thread.Sleep(2000);
            // ֹͣ
            _a1.Write(PinValue.Low);
            _a2.Write(PinValue.Low);
            */
            // �������

            // ��������ź� GP8 ����Ϊ PWM
            Configuration.SetPinFunction(2, DeviceFunction.PWM1);

            // �� GP8 ���� PWM ͨ��
            PwmChannel pwmChannel = PwmChannel.CreateFromPin(2, 5000);
            // ʹ�� PwmChannel ���� ServoMotor
            ServoMotor servoMotor = new ServoMotor(pwmChannel);
            // ���� ����
            servoMotor.Start();


            servoMotor.WritePulseWidth(0);
            Thread.Sleep(2000);
            servoMotor.WritePulseWidth(90);
            Thread.Sleep(2000);
            servoMotor.WritePulseWidth(180);
            Thread.Sleep(Timeout.Infinite);

        }
    }
}
