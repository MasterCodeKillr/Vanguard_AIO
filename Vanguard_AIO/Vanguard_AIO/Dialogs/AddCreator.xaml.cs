using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Vanguard_AIO.Classes;

namespace Vanguard_AIO.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCreator.xaml
    /// </summary>
    public partial class AddCreator : Window
    {
        public AddCreator()
        {
            InitializeComponent();
        }

        private void btAddCreator_Click(object sender, RoutedEventArgs e)
        {

            SubArray newCreator = new SubArray
            {
                name = nametb.Text,
                twitch = twitchUrltb.Text,
                youtube = youtubeUrltb.Text,
                twitter = twitterUrltb.Text
            };
            var job = CreatorList.GetCreators();
            if (!job.Any(x => x.name == nametb.Text))
            {
                job.Add(newCreator);
                CreatorList.UpdatedList = job;
                CreatorList.UpdateList(job);
            }
            else
            {
                MessageBox.Show("Creator already on list so will not be added.");
            }
            this.Close();
        }
    }
}
