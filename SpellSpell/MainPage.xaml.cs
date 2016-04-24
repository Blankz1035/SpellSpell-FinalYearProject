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
using Windows.Phone.UI.Input;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Microsoft.WindowsAzure.MobileServices;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpellSpell
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Boolean start = false;
        public static int resetDif { get; private set; }
        public int spellScore = 0;
        public int spellCounter = 0;
        public int rdmWord;
        public String userGuest = "Guest";
        public String guestPassword = "123";
        public String usernameDb;
        public String passwordDb;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public MainPage()
        {
          
            this.InitializeComponent();

            resetBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            if (DifficultyPage.difficultyLevel == 0)
            {
                diffTextBlock.Text = "Difficulty Not Set!";
            }
            else {
                diffTextBlock.Text = "Difficulty Level is " + DifficultyPage.difficultyLevel;
            }
            
            if (loginPage.userSetId == 0)
            {
                userNameTextBlock.Text = "User: " + userGuest;
            }
            else if (loginPage.userSetId == 3)
            {
                userNameTextBlock.Text = "User: not set";
            }
        }
        private async void userType()
        {
            var dialog = new MessageDialog("Would you like to login or play as Guest?");
            dialog.Title = "User Selection";
            dialog.Commands.Add(new UICommand { Label = "I will pick", Id = 0, });
            await dialog.ShowAsync();
            Frame.Navigate(typeof(loginPage));
        }

        //Menu - Navigation methods ------------------------------------------
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DifficultyPage));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(HighScores));
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(loginPage));
        }
        // right and wrong buttons mthods-----------------------------------

        private void wrongBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rdmWord == 2)
            {
                // this says if equals 2 then add to score.
                spellScore++;
            }
            else
            {
                // adds ... once reaches 10. calls stopgame
                spellCounter++;
            }
            if (start == true)
            {
                // Wont start the generation of words unless start is been made true 
                circleWords();
            }

            if (spellCounter == 10)
            {
                stopGame();
            }

        }

        private void correctBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rdmWord == 1)
            {
                spellScore++;
            }
            else
            {
                spellCounter++;
            }
            if (start == true)
            {
                circleWords();
                
            } 
            if (spellCounter == 10)
            {
                stopGame();
            }  
            
        }

        // Scoring and random words displayer --------------------------

        private void circleWords ()
        {
            scoreTxtBlock.Text = "Score: " + spellScore;
            Random rnd = new Random();
            rdmWord = rnd.Next(1, 3);

            // random generator to select number.. depending on number will throw out a right/wrong word!
            if (rdmWord ==1)
            {
                rightWords();
            }

            if (rdmWord ==2)
            {
                wrongWords();
              
            }
        }

        private void rightWords()
        {
            Random rnd = new Random();
            int rdmRightWord = rnd.Next(0, 8);

            // depending on the level set by user.. will determine which words come out. Everytime button clicked
            //runs the method again
            // this is the right word method
            if (DifficultyPage.difficultyLevel == 3)
            {
                String[] threeletterWords = { "and", "dog", "cat", "not", "big", "bad", "ben", "lit", "fag" };

                rdmWordsTxtBlock.Text = threeletterWords[rdmRightWord];

            }
            if (DifficultyPage.difficultyLevel == 4)
            {
                String[] fourletterWords = { "four", "work", "look", "book", "back", "fork", "rain", "duck", "laid" };

                rdmWordsTxtBlock.Text = fourletterWords[rdmRightWord];
            }
            if (DifficultyPage.difficultyLevel == 5)
            {
                String[] fiveletterWords = { "train", "claim", "boxer", "water", "amber", "clock", "alarm", "phone", "apple" };

                rdmWordsTxtBlock.Text = fiveletterWords[rdmRightWord];
            }
            if (DifficultyPage.difficultyLevel == 6)
            {
                String[] sixletterWords = { "iphone", "switch", "framed", "window", "socket", "tables", "bottle", "pillow", "stands" };

                rdmWordsTxtBlock.Text = sixletterWords[rdmRightWord];
            }
            if (DifficultyPage.difficultyLevel == 7)
            {
                String[] sevenletterWords = { "cushion", "laptops", "curtain", "couches", "charger", "posters", "ceiling", "kitchen", "travels" };

                rdmWordsTxtBlock.Text = sevenletterWords[rdmRightWord];
            }
            if (DifficultyPage.difficultyLevel == 8)
            {
                String[] eightletterWords = { "upstairs", "computer", "monopoly", "breaking", "disabled", "passcode", "username", "catholic", "canadian" };

                rdmWordsTxtBlock.Text = eightletterWords[rdmRightWord];
            }

        }

        private void wrongWords()
        {
            //wrong word method
            //The method is the same as right. Just wrong words!

            Random rnd = new Random();
            int rdmWrongWord = rnd.Next(0, 8);

            if (DifficultyPage.difficultyLevel == 3)
            {
                String[] threeletterWords = { "bnd", "dlg", "cit", "nott", "big", "bld", "bej", "lix", "fal" };

                rdmWordsTxtBlock.Text = threeletterWords[rdmWrongWord];
            }
            if (DifficultyPage.difficultyLevel == 4)
            {
                String[] fourletterWords = { "foor", "worc", "louk", "bouk", "bakk", "forc", "rane", "dukk", "lade" };

                rdmWordsTxtBlock.Text = fourletterWords[rdmWrongWord];
            }
            if (DifficultyPage.difficultyLevel == 5)
            {
                String[] fiveletterWords = { "trane", "clame", "boxsr", "watar", "ambar", "clokc", "alarm", "fonne", "appel" };

                rdmWordsTxtBlock.Text = fiveletterWords[rdmWrongWord];
            }
            if (DifficultyPage.difficultyLevel == 6)
            {
                String[] sixletterWords = { "iFonne", "swetch", "fraimd", "wendow", "sockit", "tabels", "bottel", "pellow", "standes" };

                rdmWordsTxtBlock.Text = sixletterWords[rdmWrongWord];
            }
            if (DifficultyPage.difficultyLevel == 7)
            {
                String[] sevenletterWords = { "kushion", "lapthops", "kurtain", "kouches", "kharger", "postors", "seiling", "kitchan", "travles" };

                rdmWordsTxtBlock.Text = sevenletterWords[rdmWrongWord];
            }
            if (DifficultyPage.difficultyLevel == 8)
            {
                String[] eightletterWords = { "upstaers", "computor", "monopole", "breeking", "disabeld", "pascode", "usrename", "caffolic", "canadien" };

                rdmWordsTxtBlock.Text = eightletterWords[rdmWrongWord];
            }

        }


        // Begining /reseting game/ Stoping game

        private async void startBtn_Click(object sender, RoutedEventArgs e)
        {
            // this gets value from login page, if it isnt set, then will ask user to set username.

            if (loginPage.userSetId == 3)
            {
                userType();
            }
            //if this, select a difficulty level to play the game


            if (DifficultyPage.difficultyLevel == 0)
            {
                var dialog = new MessageDialog("Please Select a Difficulty to Start Game.");
                dialog.Title = "Difficulty Not Set?";
                dialog.Commands.Add(new UICommand { Label = "Ok, I'll Set!", Id = 0, });
                await dialog.ShowAsync();
                Frame.Navigate(typeof(DifficultyPage));
            }
            else {
                start = true;  //start variable for before << set to true, now the method circle words Works
                rdmWordsTxtBlock.Text = "";
                introTxtBlock.Text = "";
                resetBtn.Visibility = Windows.UI.Xaml.Visibility.Visible;
                scoreTxtBlock.Text = "Score: 0";
                circleWords();
            }

            
            
        }

        private async void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            resetDif = 0; //resets difficulty
            spellCounter = 0;// resets counter to 0 so game wont end 
            start = false; // set to false to stop the buttons making words cycle
            introTxtBlock.Text = "Game Stopped and Reset.";
            rdmWordsTxtBlock.Text = "Well Done!  Scored: " + spellScore;


            // here is the database code..
            //if the user didnt selected a name or password on login page
            //this means they must be playing as guest!
            // else set the database variables to the text the user entered
            if (loginPage.gameName == "" || loginPage.gamePassword == "")
            {
                usernameDb = userGuest;
                passwordDb = guestPassword;
            }
            else
            {
                usernameDb = loginPage.gameName;
                passwordDb = loginPage.gamePassword;
            }
            // inserts into the azure database
            AddScore item = new AddScore { Username = usernameDb, Password = passwordDb, Highscore = spellScore };
            await App.MobileService.GetTable<AddScore>().InsertAsync(item);
            //then resets the score for next game
            spellScore = 0;
            scoreTxtBlock.Text = "Score: " + spellScore;
            resetBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private async void stopGame()
        {
            // stop game is a simpilar method, except it only runs once the spellCounter reaches 10
            // 10 represents the number of words the user spelt wrong!

            resetDif = 0;
            spellCounter = 0;
            start = false;
            introTxtBlock.Text = "  Game Stopped";
            rdmWordsTxtBlock.Text = "Well Done!  Scored: " + spellScore;

            if (loginPage.gameName == "" || loginPage.gamePassword == "")
            {
                usernameDb = userGuest;
                passwordDb = guestPassword;
            }
            else
            {
                usernameDb = loginPage.gameName;
                passwordDb = loginPage.gamePassword;
            }

            AddScore item = new AddScore { Username = usernameDb, Password = passwordDb, Highscore = spellScore };
            await App.MobileService.GetTable<AddScore>().InsertAsync(item);

            spellScore = 0;
            scoreTxtBlock.Text = "Score: " + spellScore;
            resetBtn.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        
    }

    
} //end
