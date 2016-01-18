using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace nrf_Bluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GattDeviceService nrfService;
        GattCharacteristic writeCharacteristic;
        GattCharacteristic readCharacteristic;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void RunButton_Click(object sender, RoutedEventArgs e)
        {
            RunButton.IsEnabled = false;

            // UART Service UUID: 6E400001-B5A3-F393-E0A9-E50E24DCCA9E
            // TX Characteristic UUID: 6E400002-B5A3-F393-E0A9-E50E24DCCA9E
            // RX Characteristic UUID: 6E400003-B5A3-F393-E0A9-E50E24DCCA9E
            var devices = await DeviceInformation.FindAllAsync(GattDeviceService.GetDeviceSelectorFromUuid(new Guid("6E400001-B5A3-F393-E0A9-E50E24DCCA9E")));

             DevicesListBox.Items.Clear();

             if (devices.Count > 0)
             {
                foreach (var device in devices)
                {
                   DevicesListBox.Items.Add(device);
                }
                DevicesListBox.Visibility = Visibility.Visible;
             }
             else
             {
                 bleInfoTextBlock.Text = "Could not find any devices";
             }
            RunButton.IsEnabled = true;
        }

        private async void DevicesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RunButton.IsEnabled = false;

            var device = DevicesListBox.SelectedItem as DeviceInformation;
            DevicesListBox.Visibility = Visibility.Collapsed;

            nrfService = await GattDeviceService.FromIdAsync(device.Id);
            writeCharacteristic = nrfService.GetCharacteristics(new Guid("6E400002-B5A3-F393-E0A9-E50E24DCCA9E"))[0];
            readCharacteristic = nrfService.GetCharacteristics(new Guid("6E400003-B5A3-F393-E0A9-E50E24DCCA9E"))[0];

            if (nrfService != null)
            {
                bleInfoTextBlock.Text = "Using service Id: " + nrfService.DeviceId;

                readCharacteristic.ValueChanged += incomingData_ValueChanged;
                await readCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.Notify);

            }
            else
            {
                bleInfoTextBlock.Text = "Error: gattService is null";
            }
        }

        // Read data change handler
        async void incomingData_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs eventArgs)
        {
            byte[] bArray = new byte[eventArgs.CharacteristicValue.Length];
            DataReader.FromBuffer(eventArgs.CharacteristicValue).ReadBytes(bArray);

            string message = System.Text.Encoding.UTF8.GetString(bArray);

            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                receiveTextBox.Text = message;
            });
        }

        private async void Write_Button_Click(object sender, RoutedEventArgs e)
        {
            var writer = new DataWriter();
            writer.WriteString(writeMessageBox.Text + "\r\n");

            try
            {
                var res = await writeCharacteristic.WriteValueAsync(writer.DetachBuffer(), GattWriteOption.WriteWithoutResponse);
                messageWriteResponse.Text = res.ToString();
            }
            catch (Exception ex)
            {
                messageWriteResponse.Text = "Message too long, keep under 20 chars";
            }   
        }

        private async void LED_On_Click(object sender, RoutedEventArgs e)
        {
            var writer = new DataWriter();
            writer.WriteString("1\r\n");

            try
            {
                var res = await writeCharacteristic.WriteValueAsync(writer.DetachBuffer(), GattWriteOption.WriteWithoutResponse);
                messageWriteResponse.Text = res.ToString();
            }
            catch (Exception ex)
            {
                messageWriteResponse.Text = "Turn on LED failed: " + ex;
            }
        }

        private async void LED_Off_Click(object sender, RoutedEventArgs e)
        {
            var writer = new DataWriter();
            writer.WriteString("0\r\n");

            try
            {
                var res = await writeCharacteristic.WriteValueAsync(writer.DetachBuffer(), GattWriteOption.WriteWithoutResponse);
                messageWriteResponse.Text = res.ToString();
            }
            catch (Exception ex)
            {
                messageWriteResponse.Text = "Turn off LED failed: " + ex;
            }
        }

        //private void menuopen_click(object sender, routedeventargs e)
        //{
        //    splitview.ispaneopen = !splitview.ispaneopen;
        //}
    }
}
