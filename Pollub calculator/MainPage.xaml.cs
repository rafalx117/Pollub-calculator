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
        List<TextBox> labelsList = new List<TextBox>();
        List<TextBox> gradesList = new List<TextBox>();
        List<TextBox> ectsList = new List<TextBox>();
        bool firstRun = true;
        bool firstCalculateButtonClick = true;


        //------------------------------------------------------
        //tych kontrolek bedziemy używac w metodzie createSet
        Subject temp;
        TextBox nameTextBox;
        TextBox gradeTextBox;
        TextBox ectsTextBox;
        // -----------------------------------------------------

        StackPanel mainPanel = new StackPanel();
      //  TextBox result; //tutaj bedziemy wyświetlać średnią

        public MainPage()
        {
            this.InitializeComponent();
          //  CreateFirstView();
             
            

        }

        private void createSet(object sender, RoutedEventArgs e)
        {
            temp = new Subject();

            if (!firstRun)
            {
                temp.Name = nameTextBox.Text;

                try
                {
                    temp.Grade = float.Parse(gradeTextBox.Text);
                }
                catch (FormatException)
                {

                   
                }
                try
                {
                    temp.Ects = int.Parse(ectsTextBox.Text);
                }
                catch (Exception)
                {

                    
                }
                
                subjects.Add(temp);
                setAverageLabel();
               
            }
            else
                firstRun = false;

            
            nameTextBox = new TextBox(); 
            gradeTextBox = new TextBox();
            ectsTextBox = new TextBox();
 
            nameTextBox.KeyUp += new KeyEventHandler(updateSubjectsList);
            

           TextBlock nameLabel = new TextBlock();
            nameLabel.Text = "Przedmiot " + (subjects.Count + 1);
            TextBlock gradeLabel = new TextBlock();
            gradeLabel.Text = "Ocena";
            TextBlock ectsLabel = new TextBlock();
            ectsLabel.Text = "ECTS";

             

            mainPanel.Children.Add(nameLabel);
            mainPanel.Children.Add(nameTextBox);
            mainPanel.Children.Add(gradeLabel);
            mainPanel.Children.Add(gradeTextBox);
            mainPanel.Children.Add(ectsLabel);      
            mainPanel.Children.Add(ectsTextBox);



            scrollViewer.Content = mainPanel;
            mainGrid.Children.Remove(scrollViewer);
            mainGrid.Children.Add(scrollViewer);


            firstCalculateButtonClick = true;

        }
 
    
            //btnClick.Click += new RoutedEventHandler(btnClick_Click);
       private void updateSubjectsList(object sender, RoutedEventArgs e)
        {
            string temp = e.OriginalSource.GetType().Name;

            Debug.WriteLine(temp);
        }

        private float calculateAverage(List<Subject> list)
        {
           /* if(firstCalculateButtonClick)
            {
                subjects.Add(temp); //jeśli po raz pierwszy klikamy przycisk, wówczas do listy przedmiotów dodajemy tymczasowy przedmiot z metody createSet (przedmiot którt jest ostatni i nie jest zapisywany po wciśnięciu przycisku Dodaj)
                firstCalculateButtonClick = false;
            }*/
           
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


        private void setAverageLabel( )
        {
            try
            {
                result.Text = calculateAverage(subjects).ToString();
            }
            catch (DivideByZeroException)
            {

                Debug.WriteLine("ZERO");
            }

        }

        private void setAverageLabel(object sender, RoutedEventArgs e)
        {
            try
            {
                result.Text = calculateAverage(subjects).ToString();
            }
            catch (DivideByZeroException)
            {

                Debug.WriteLine("ZERO");
            }
            
        }

        private void debugWrite_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(subjects.Count);
            foreach (Subject sub in subjects)
            {
               
                Debug.WriteLine(sub.Name);
            }
        }
    }
}

