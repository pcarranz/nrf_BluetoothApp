﻿#pragma checksum "C:\Users\pcarranza\Documents\Visual Studio 2015\Projects\nrf_Bluetooth\nrf_Bluetooth\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1CEEE201C1FA880293CE427A970D5E99"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nrf_Bluetooth
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.SplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.RunButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 22 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.RunButton).Click += this.RunButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.DevicesListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 23 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.DevicesListBox).SelectionChanged += this.DevicesListBox_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.bleInfoTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    this.receivePanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 6:
                {
                    this.receiveText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7:
                {
                    this.receiveTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8:
                {
                    this.sendText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.sendTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.writeMessageBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11:
                {
                    this.writeButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 40 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.writeButton).Click += this.Write_Button_Click;
                    #line default
                }
                break;
            case 12:
                {
                    this.messageWriteResponse = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.ledOnButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 42 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ledOnButton).Click += this.LED_On_Click;
                    #line default
                }
                break;
            case 14:
                {
                    this.ledOffButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.ledOffButton).Click += this.LED_Off_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

