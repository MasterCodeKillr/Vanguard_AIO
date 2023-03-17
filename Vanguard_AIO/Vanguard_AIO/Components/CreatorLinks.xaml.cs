using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vanguard_AIO.Components
{
    /// <summary>
    /// Interaction logic for CreatorLinks.xaml
    /// </summary>
    public partial class CreatorLinks : UserControl
    {
        public CreatorLinks(string creatorName = "@Narusamurai", string twitchLink = "https://www.twitch.tv/narusamurai", string youtubeLink = "https://www.youtube.com/@NaruSamurai", string twitterLink = "https://twitter.com/NaruSamurai")
        {
            InitializeComponent();
            CreatorSetup(creatorName, twitchLink, youtubeLink, twitterLink);
        }

        private void CreatorSetup(string creatorName, string twitchLink, string youtubeLink, string twitterLink)
        {
            formatImages(creatorName, twitchLink, youtubeLink, twitterLink);
            creatorNamelbl.Content = creatorName;
            twitchLogo.Tag = twitchLink;
            youTubeLogo.Tag = youtubeLink;
            twitchLogo.Tag = twitterLink;
        }

        private void formatImages(string creatorName, string twitchLink, string youtubeLink, string twitterLink)
        {
            var count = 0;
            List<string> urls = new List<string>();
            List<string> urlList = new List<string>
            {
                twitchLink,
                twitterLink,
                youtubeLink
            };
            foreach (var link in urlList)
            {
                if (!string.IsNullOrEmpty(link))
                {
                    count++;
                    urls.Add(link);
                }
            }

            if (count == 1)
            {
                CreateSingleLink(urls);
            }
            if (count == 2)
            {
                CreateDoubleLink(urls);
            }
            urlList.Clear();
            urls.Clear();
        }

        private void CreateSingleLink(List<string> urls)
        {
            if (urls[0].ToLower().Contains("twitch"))
            {
                youTubeLogo.Visibility = Visibility.Hidden;
                twitterLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(twitchLogo, 1);
            }
            if (urls[0].ToLower().Contains("youtube"))
            {
                twitchLogo.Visibility = Visibility.Hidden;
                twitterLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(youTubeLogo, 1);
            }
            if (urls[0].ToLower().Contains("twitter"))
            {
                twitchLogo.Visibility = Visibility.Hidden;
                youTubeLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(twitterLogo, 1);
            }
        }

        private void CreateDoubleLink(List<string> urls)
        {
            if (urls[0].ToLower().Contains("twitch"))
            {
                if (urls[1].ToLower().Contains("youtube"))
                {
                    twitterLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(twitchLogo, 0);
                    Grid.SetColumnSpan(twitchLogo, 2);
                    Grid.SetColumn(youTubeLogo, 1);
                    Grid.SetColumnSpan(youTubeLogo, 2);
                }
                if (urls[1].ToLower().Contains("twitter"))
                {
                    youTubeLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(twitchLogo, 0);
                    Grid.SetColumnSpan(twitchLogo, 2);
                    Grid.SetColumn(twitterLogo, 1);
                    Grid.SetColumnSpan(twitterLogo, 2);
                }
            }
            else if (urls[0].ToLower().Contains("youtube"))
            {
                if (urls[1].ToLower().Contains("twitch"))
                {
                    twitterLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(twitchLogo, 0);
                    Grid.SetColumnSpan(twitchLogo, 2);
                    Grid.SetColumn(youTubeLogo, 1);
                    Grid.SetColumnSpan(youTubeLogo, 2);
                }
                if (urls[1].ToLower().Contains("twitter"))
                {
                    twitchLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(youTubeLogo, 0);
                    Grid.SetColumnSpan(youTubeLogo, 2);
                    Grid.SetColumn(twitterLogo, 1);
                    Grid.SetColumnSpan(twitterLogo, 2);
                }
            }
            else if (urls[0].ToLower().Contains("twitter"))
            {
                if (urls[1].ToLower().Contains("twitch"))
                {
                    twitterLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(twitchLogo, 0);
                    Grid.SetColumnSpan(twitchLogo, 2);
                    Grid.SetColumn(twitterLogo, 1);
                    Grid.SetColumnSpan(twitterLogo, 2);
                }
                if (urls[1].ToLower().Contains("youtube"))
                {
                    twitchLogo.Visibility = Visibility.Hidden;
                    Grid.SetColumn(youTubeLogo, 0);
                    Grid.SetColumnSpan(youTubeLogo, 2);
                    Grid.SetColumn(twitterLogo, 1);
                    Grid.SetColumnSpan(twitterLogo, 2);
                }
            }
        }

        private void twitchLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", twitchLogo.Tag.ToString());
        }

        private void youTubeLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", youTubeLogo.Tag.ToString());
        }

        private void twitterLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", twitterLogo.Tag.ToString());
        }
    }
}
