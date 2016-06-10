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
        List<TextBox> labels = new List<TextBox>();
        List<TextBox> grades = new List<TextBox>();
        List<TextBox> ects = new List<TextBox>();

        StackPanel mainPanel = new StackPanel();
        TextBox result; //tutaj bedziemy wyświetlać średnią

        public MainPage()
        {
            this.InitializeComponent();
            CreateFirstView();
             
            

        }

        private void createSet(object sender, RoutedEventArgs e)
        {
            Subject temp = new Subject();
            

            StackPanel tempPanel = new StackPanel();
            TextBox tempNameLabel = new TextBox(); 
            TextBox tempGradeLabel = new TextBox();
            TextBox tempEctsLanel = new TextBox();

            TextBlock name = new TextBlock();
            name.Text = "Przedmiot";
            TextBlock grade = new TextBlock();
            grade.Text = "Ocena";
            TextBlock ects = new TextBlock();
            ects.Text = "ECTS";

            

            mainPanel.Children.Add(name);
            mainPanel.Children.Add(tempNameLabel);
            mainPanel.Children.Add(grade);
            mainPanel.Children.Add(tempGradeLabel);
            mainPanel.Children.Add(ects);      
            mainPanel.Children.Add(tempEctsLanel);



            scrollViewer.Content = mainPanel;
            mainGrid.Children.Remove(scrollViewer);
            mainGrid.Children.Add(scrollViewer);

            


        }

        private void CreateFirstView()
        {
            Button addSubjectButton = new Button();
            addSubjectButton.Content = "Dodaj przedmiot";
            addSubjectButton.Click += new RoutedEventHandler(createSet);
            placeForFirstView.Children.Add(addSubjectButton);

            TextBlock averageLabel = new TextBlock();
            averageLabel.Text = "Średnia";
            result = new TextBox();
            placeForFirstView.Children.Add(averageLabel);
            placeForFirstView.Children.Add(result);
            
        }

        private void CreateControls()
        {
            

            TextBlock txtName = new TextBlock();
            txtName.Text = "@isenthil";
            Button btnClick = new Button();
            btnClick.Content = "Click";
            btnClick.Click += new RoutedEventHandler(btnClick_Click);
           
          //  panel.Children.Add(txtName);
            //panel.Children.Add(btnClick);

        }

        void btnClick_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ello");
        }

        private float average(List<Subject> list)
        {
            float combinedSum = 0; //suma wszystkich przedmiotów: ects * ocena
            int ectsSum = 0;

            try
            {
                foreach (Subject sub in list)
                {
                    combinedSum += (sub.Grade * sub.Ects);
                    ectsSum += sub.Ects;
                }
                return combinedSum / (float)ectsSum;
            }
            catch (FormatException)
            {

                Debug.WriteLine("Literki!");
                return -1;
            }
            

        }
    }
}

