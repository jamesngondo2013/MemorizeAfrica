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

namespace Memorize_Africa
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Play : Page
    {
       
        public int scorePoints;

        public static bool _timerOn = true;
        public int userNumber = 1;
        public int bookCounter;
        int guessCount = 5, newCount = 2;
        public int scoreVal;

        DispatcherTimer waitTimer = new DispatcherTimer();
        DispatcherTimer guessTimer = new DispatcherTimer();
        DispatcherTimer overTimer = new DispatcherTimer();

        public Random rand = new Random();

        List<string> booksRandList = new List<string>();
        List<string> countyList = new List<string>{
                                "Algeria",
                                "Morocco",
                                "Tunisia",
                                "Western_Sahara",
                                "Mauritania",
                                "Mali",
                                "Senegal",
                                "Gambia",
                                "Guinea_Bissau",
                                "Guinea",
                                "Sierra_Leone",
                                "Liberia",
                                "Ivory_Coast",
                                "Bukina_Faso",
                                "Ghana",
                                "Togo",
                                "Benin",
                                "Niger",
                                "Nigeria",
								"Cameroon",
                                "Libya",
                                "Egypt",
                                "Sudan",
                                "Chad",
                                "Central_African_Republic",
                                "Gabon",
                                "Equatorial_Guinea",
                                "Congo_Brazzaville",
                                "DR_Congo",
                                "Eritrea",
                                "Djibouti",
                                "Somalia",
                                "Ethiopia",
                                "Uganda",
                                "Kenya",
                                "Rwanda",
                                "Burundi",
                                "Tanzania",
                                "Seychelles",
                                "Zambia",
                                "Malawi",
                                "Mozambique",
                                "Madagascar",
                                "Angola",
                                "Namibia",
                                "Botswana",
                                "Zimbabwe",
                                "South_Africa",
                                "Lesotho",
                                "Swaziland"
                                
                                };

        //string[] canvasArray = new string[50];

        List<string> countyRandList = new List<string>();

        Random random = new Random();

       
        public Play()
        {
            this.InitializeComponent();
            myRandomBooks();
            guessTimer.Interval = new TimeSpan(0, 0, 0, 1, 0); // 1 second
            guessTimer.Tick += Guess_Tick;
            guessTimer.Start();

            waitTimer.Interval = new TimeSpan(0, 0, 0, 1, 0); // 1 second
            waitTimer.Tick += Wait_Tick;
            waitTimer.Start();
        }
        private void Wait_Tick(object sender, object e)
        {
            //newCount--;
            if (newCount == 2)
            {
                //TimerBlock.Text = "";
                //QuestionBlock2.Text = "";
            }
            if (newCount == 0)
            {
                //bookCounter++;
                //myRandomBooks();
                //guessTimer.Start();
                // QuestionBlock2.Text = "";
                //waitTimer.Stop();
            }
        }
        private void Guess_Tick(object sender, object e)
        {
            guessCount--;
            TimerBlock.Text = guessCount.ToString();
            if (guessCount == 4)
            {

                QuestionBlock2.Text = "";
            }
            if (guessCount == 0)
            {
                bookCounter++;
               // QuestionBlock2.Text = "Slow Guess";
                ScoreBlock.Text = scoreVal.ToString();
                myRandomBooks();
                
            }

        }


        private void myRandomBooks()
        {
            if (countyList.Count == 0)
            {
                QuestionBlock2.Text = "Game Over";
                QuestionBlock.Text = "";
                TimerBlock.Text = "";
                guessTimer.Stop();
                Frame.Navigate(typeof(PlayQuit));
            }
            else
            {
                guessCount = 5;
                int books;
                books = rand.Next(0, countyList.Count());
                booksRandList.Add(countyList[books]);
                countyList.RemoveAt(books);

                QuestionBlock.Text = booksRandList[bookCounter];
            }
        }
        private void Path_Tapped(object sender, TappedRoutedEventArgs e)
        {

            //  Canvas tmp = BibleBooks;
            // int index = tmp.Children.Count;
            Canvas current = sender as Canvas;

            if (QuestionBlock.Text == current.Tag.ToString())
            {
                //have matched
                scoreVal++;
                bookCounter++;

                if (countyList.Count == 0)
                {
                    QuestionBlock2.Text = "Game Over";
                    QuestionBlock.Text = "";
                    TimerBlock.Text = "";
                    guessTimer.Stop();
                    Frame.Navigate(typeof(PlayQuit));
                }
                else
                {
                    QuestionBlock2.Text = "Correct";
                    ScoreBlock.Text = scoreVal.ToString();
                    current.Opacity = 1;
                    myRandomBooks();
                }


            }
            else
            {

                QuestionBlock2.Text = "Wrong Guess";

                 guessTimer.Start();
                guessCount = 5;
                 
                if(guessCount==4)
                {
                    QuestionBlock2.Text = "";
                    guessTimer.Stop();

                }

                ScoreBlock.Text = scoreVal.ToString();
                ((App)(App.Current)).TotalScore = scoreVal;

            }

        }

        private void gameOver()
        {
            if (bookCounter == countyList.Count)
            {
                TimerBlock.Opacity = 0;
                QuestionBlock2.Text = "Game over...Your Score is " + scoreVal;
                QuestionBlock.Text = "";
                TimerBlock.Text = "";
                guessTimer.Stop();
                Frame.Navigate(typeof(PlayQuit));


            }
        }


       

    }
}
