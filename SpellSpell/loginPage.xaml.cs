using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class loginPage : Page
    {
        public static int userSetId { get; private set; }

        public static String gameName { get; private set; }
        public static String gamePassword { get; private set; }
        

        public loginPage()
        {
            this.InitializeComponent();
            userSetId = 3;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // method would have been used in the time of proper login and regist 
            //UserName Validation  
            if (TxtUserName.Text == " ")
            {
                valTextBlock.Text = "User Name Not Set!";
            }

            //Password length Validation  
            else if (TxtPwd.Password.Length < 6)
            {
                valTextBlock.Text = "Password should be more then 6 letters.";
            }

            //Address Text Empty Validation  
            else if (TxtAddr.Text == "")
            {
                valTextBlock.Text = "Address empty!";
            }

            //EmailID validation  
            else if (TxtEmail.Text== @"^([a-zA-Z_])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$")
            {
                valTextBlock.Text = "Invalid Email.";
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // button assigns the variable values !
            gameName = UserName.Text;
            gamePassword = PassWord.Password;

            userSetId = 1;
            Frame.Navigate(typeof(MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuButton1_Click(object sender, RoutedEventArgs e)
        {
            //User shouldnt be able to access any page without choosing user
            //Frame.Navigate(typeof(MainPage));
        }

        private void MenuButton2_Click(object sender, RoutedEventArgs e)
        {
            //User shouldnt be able to access any page without choosing user
            //Frame.Navigate(typeof(DifficultyPage));
        }

        private void MenuButton3_Click(object sender, RoutedEventArgs e)
        {
            //User shouldnt be able to access any page without choosing user
            //Frame.Navigate(typeof(HighScores));
        }

        private void MenuButton4_Click(object sender, RoutedEventArgs e)
        {
            //Dont want the user to reload the page
            //Frame.Navigate(typeof(loginPage));
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            userSetId = 0;
            Frame.Navigate(typeof(MainPage));
        }
    }
}
