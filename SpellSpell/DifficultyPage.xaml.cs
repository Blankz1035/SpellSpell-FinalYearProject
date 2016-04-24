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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpellSpell
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DifficultyPage : Page
    {
        public static int difficultyLevel { get; private set; } //get/set for using in different pages

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public DifficultyPage()
        {
            //radio button logic.. 
            this.InitializeComponent();
            clearDifficultyBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            if (difficultyLevel !=0)
            {
                switch (difficultyLevel)
                {
                    case 3:
                        radioButton.IsChecked = true;
                        break;
                    case 4:
                        radioButton1.IsChecked = true;
                        break;
                    case 5:
                        radioButton2.IsChecked = true;
                        break;
                    case 6:
                        radioButton3.IsChecked = true;
                        break;
                    case 7:
                        radioButton4.IsChecked = true;
                        break;
                    case 8:
                        radioButton5.IsChecked = true;
                        break;
                }
            }
            if (MainPage.resetDif == 0)
            {
                difficultyLevel = 0;
            }
            
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton2_Click_1(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(DifficultyPage));
        }

        private void MenuButton1_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton3_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HighScores));
        }

        private void isChecked(object sender, RoutedEventArgs e)
        {
            // shows clear button
            clearDifficultyBtn.Visibility = Windows.UI.Xaml.Visibility.Visible;
            
            //assigns the difficulty level.
            
            if (Convert.ToBoolean(radioButton.IsChecked))
            {
                difficultyLevel = 3;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nThis one is easy..";
            }

            if (Convert.ToBoolean(radioButton1.IsChecked))
            {
                difficultyLevel = 4;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nWatch your spelling!";
            }
            if (Convert.ToBoolean(radioButton2.IsChecked))
            {
                difficultyLevel = 5;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nWatch your spelling!";
            }
            if (Convert.ToBoolean(radioButton3.IsChecked))
            {
                difficultyLevel = 6;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nWatch your spelling!";
            }
            if (Convert.ToBoolean(radioButton4.IsChecked))
            {
                difficultyLevel = 7;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nWatch your spelling!";
            }
            if (Convert.ToBoolean(radioButton5.IsChecked))
            {
                difficultyLevel = 8;
                testBlock.Text = "Difficulty Level set at: " + difficultyLevel + "\r\nGood Luck!\r\nWatch your spelling!";
            }
            
            
        }

        private void clearDifficultyBtn_Click(object sender, RoutedEventArgs e)
        { 
            
            DifficultyPage.difficultyLevel = 0;
            
            radioButton.IsChecked = false;
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
            radioButton4.IsChecked = false;
            radioButton5.IsChecked = false;

            testBlock.Text = "Reset Difficulty to: " + difficultyLevel;
            
            clearDifficultyBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(loginPage));
        }
    }
}
