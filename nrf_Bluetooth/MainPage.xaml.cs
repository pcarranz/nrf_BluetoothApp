using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace nrf_Bluetooth
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
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

            GattDeviceService nrfService = await GattDeviceService.FromIdAsync(device.Id);
            GattCharacteristic writeCharacteristic = nrfService.GetCharacteristics(new Guid("6E400002-B5A3-F393-E0A9-E50E24DCCA9E"))[0];
            GattCharacteristic readCharacteristic = nrfService.GetCharacteristics(new Guid("6E400003-B5A3-F393-E0A9-E50E24DCCA9E"))[0];

            if (nrfService != null)
            {
                bleInfoTextBlock.Text = "Using service Id: " + nrfService.DeviceId;
                var writer = new Windows.Storage.Streams.DataWriter();
                writer.WriteString("#FF00FF");
                var res = await writeCharacteristic.WriteValueAsync(writer.DetachBuffer(), GattWriteOption.WriteWithoutResponse);
            }
            else
            {
                bleInfoTextBlock.Text = "gattService is null";
            }
        }

        private void Write_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
