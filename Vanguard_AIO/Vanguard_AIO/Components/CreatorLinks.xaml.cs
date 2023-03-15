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
            CreatorSetup(creatorName, twitchLink, youtubeLink, twitchLink);
        }

        private void CreatorSetup(string creatorName, string twitchLink, string youtubeLink, string twitterLink)
        {
            creatorNamelbl.Content = creatorName;
            twitchLogo.Tag = twitchLink;
            youTubeLogo.Tag = youtubeLink;
            twitchLogo.Tag = twitterLink;
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
