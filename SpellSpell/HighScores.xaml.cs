
using System;
using System.Data;
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
using System.Collections;
using Microsoft.WindowsAzure.MobileServices;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpellSpell
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HighScores : Page
    {
       //private string connectionString = "server=http://g00313312.cloudapp.net; Uid=Andyb1080;password =Azure.123 ; Database=spellspell_database;";


        
        

        public HighScores()
        {
            this.InitializeComponent();
        
        }   

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DifficultyPage));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(HighScores));
        }


        // Button to fetch data from a local store
        private void localHS_Click(object sender, RoutedEventArgs e)
        {
            
            localTextBlock.Text = "This button would retrieve data from local database";
            }
        
        // Button to fetch Data from an online database
        private void onlineHS_Click(object sender, RoutedEventArgs e)
        {
            //AddScore item = new AddScore {Username = "ChrisW", Password = "g00313312", Highscore = 10};
            //await App.MobileService.GetTable<AddScore>().InsertAsync(item);
            localTextBlock.Text = "This button would retrieve data from online Azure database";
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(loginPage));
        }
    }
}
