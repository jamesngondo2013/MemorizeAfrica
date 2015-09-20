using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
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
    public sealed partial class About : Page
    {
        public About()
        {
            this.InitializeComponent();
            aboutUs();
        }
        public void aboutUs()
        {
            XDocument myData = XDocument.Load("About.xml");

            var SearchData = from query in myData.Descendants("about")
                             select new Student
                             {
                                 Message = (string)query.Element("message"),

                             };
            displayMsg.ItemsSource = SearchData;
            displayMsg.Visibility = Visibility.Visible;
        }

        public class Student
        {
            string message;

            public string Message
            {
                get { return message; }
                set { message = value; }
            }
        }

        private void back_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
