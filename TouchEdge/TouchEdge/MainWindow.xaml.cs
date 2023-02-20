// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Win32;
using Windows.Win32.Foundation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TouchEdge
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            

        }

        private void SetWindowSize(Window window, int width, int height)
        {
            var hwnd = new HWND( WinRT.Interop.WindowNative.GetWindowHandle(window));
            var dpi = PInvoke.GetDpiForWindow(hwnd);
            float scalingFactor = (float)dpi / 96;
            width = (int)(width * scalingFactor);
            height = (int)(height * scalingFactor);

            PInvoke.SetWindowPos(hwnd, HWND.Null,
                                        0, 0, width, height,
                                        Windows.Win32.UI.WindowsAndMessaging.SET_WINDOW_POS_FLAGS.SWP_NOMOVE);
            // PInvoke.SetWindowLong(hwnd, Windows.Win32.UI.WindowsAndMessaging.WINDOW_LONG_PTR_INDEX.GWL_STYLE, 0);
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            SetWindowSize(this, 100, 100);
        }
    }
}
