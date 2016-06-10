using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Pollub_calculator.Assets;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Pollub_calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {
        List<Subject> subjects = new List<Subject>();

        public MainPage()
        {
            this.InitializeComponent();
            CreateControls();
            

        }

        private void CreateControls()
        {
            TextBlock txtName = new TextBlock();
            txtName.Text = "@isenthil";
            Button btnClick = new Button();
            btnClick.Content = "Click";
            btnClick.Click += new RoutedEventHandler(btnClick_Click);
           
            panel.Children.Add(txtName);
            panel.Children.Add(btnClick);
        }

        void btnClick_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ello");
        }
    }
}

