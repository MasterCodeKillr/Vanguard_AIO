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
        private readonly string twitchUrl;
        private readonly string youtubeUrl;
        private readonly string twitterUrl;
        public CreatorLinks(string creatorName = "", string twitchLink = "", string youtubeLink = "", string twitterLink = "")
        {
            this.twitchUrl = twitchLink;
            this.youtubeUrl = youtubeLink;
            this.twitterUrl = twitterLink;
            InitializeComponent();
            CreatorSetup(creatorName, twitchLink, youtubeLink, twitterLink);
        }

        private void CreatorSetup(string creatorName, string twitchLink, string youtubeLink, string twitterLink)
        {
            FormatImages(creatorName, twitchLink, youtubeLink, twitterLink);
            creatorNamelbl.Content = creatorName;
        }

        private void FormatImages(string creatorName, string twitchLink, string youtubeLink, string twitterLink)
        {
            var count = 0;
            var urls = new List<string>();
            var urlList = new List<string>
            {
                twitchLink,
                youtubeLink,
                twitterLink,
                
            };
            foreach (var link in urlList.Where(link => !string.IsNullOrEmpty(link)))
            {
                count++;
                urls.Add(link);
            }

            switch (count)
            {
                case 1:
                    CreateSingleLink(urls);
                    break;
                case 2:
                    CreateDoubleLink(urls);
                    break;
            }

            urlList.Clear();
            urls.Clear();
        }

        private void CreateSingleLink(IReadOnlyList<string> urls)
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

        private void CreateDoubleLink(IReadOnlyList<string> urls)
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

                if (!urls[1].ToLower().Contains("twitter")) return;
                youTubeLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(twitchLogo, 0);
                Grid.SetColumnSpan(twitchLogo, 2);
                Grid.SetColumn(twitterLogo, 1);
                Grid.SetColumnSpan(twitterLogo, 2);
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

                if (!urls[1].ToLower().Contains("twitter")) return;
                twitchLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(youTubeLogo, 0);
                Grid.SetColumnSpan(youTubeLogo, 2);
                Grid.SetColumn(twitterLogo, 1);
                Grid.SetColumnSpan(twitterLogo, 2);
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

                if (!urls[1].ToLower().Contains("youtube")) return;
                twitchLogo.Visibility = Visibility.Hidden;
                Grid.SetColumn(youTubeLogo, 0);
                Grid.SetColumnSpan(youTubeLogo, 2);
                Grid.SetColumn(twitterLogo, 1);
                Grid.SetColumnSpan(twitterLogo, 2);
            }
        }

        private void twitchLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", twitchUrl);
        }

        private void youTubeLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", youtubeUrl);
        }

        private void twitterLogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", twitterUrl);
        }
    }
}
