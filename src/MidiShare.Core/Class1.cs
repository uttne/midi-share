using System;
using System.Collections.Generic;
using RtMidi.Core;
using RtMidi.Core.Devices;
using RtMidi.Core.Messages;

namespace MidiShare.Core
{
    public class Class1
    {
        public static void Sample()
        {
            // List all available MIDI API's
            foreach (var api in MidiDeviceManager.Default.GetAvailableMidiApis())
                Console.WriteLine($"Available API: {api}");

            // Listen to all available midi devices
            void ControlChangeHandler(IMidiInputDevice sender, in ControlChangeMessage msg)
            {
                Console.WriteLine($"[{sender.Name}] ControlChange: Channel:{msg.Channel} Control:{msg.Control} Value:{msg.Value}");
            }

            var devices = new List<IMidiDevice>();
            try
            {
                IMidiOutputDevice output = null;

                foreach (var inputDeviceInfo in MidiDeviceManager.Default.InputDevices)
                {
                    Console.WriteLine($"Opening {inputDeviceInfo.Name}");

                    var inputDevice = inputDeviceInfo.CreateDevice();
                    devices.Add(inputDevice);

                    inputDevice.ControlChange += ControlChangeHandler;
                    inputDevice.NoteOn += (IMidiInputDevice sender, in NoteOnMessage msg) =>
                    {
                        Console.WriteLine(msg);
                        output?.Send(msg);
                    };
                    inputDevice.NoteOff += (IMidiInputDevice sender, in NoteOffMessage msg) =>
                    {
                        Console.WriteLine(msg);
                        output?.Send(msg);
                    };
                    inputDevice.PolyphonicKeyPressure +=
                        (IMidiInputDevice sender, in PolyphonicKeyPressureMessage msg) =>
                            Console.WriteLine("PolyphonicKeyPressure");

                    inputDevice.Open();
                }

                foreach (var outputDeviceInfo in MidiDeviceManager.Default.OutputDevices)
                {
                    Console.WriteLine($"Opening output: {outputDeviceInfo.Name}");
                    var outputDevice = outputDeviceInfo.CreateDevice();
                    devices.Add(outputDevice);

                    outputDevice.Open();
                    output = outputDevice;
                    break;
                }

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();

            }
            finally
            {
                foreach (var device in devices)
                {
                    device.Dispose();
                }
            }
        }
    }
}
