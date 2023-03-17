using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            try
            {
                CheckAllInputs();
                CheckURI(twitterUrltb);
                CheckURI(twitchUrltb);
                CheckURI(youtubeUrltb);
                CreateCreator();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckURI(TextBox input)
        {
            SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 171, 173, 179));
            input.BorderBrush = brush;
            if (!Uri.IsWellFormedUriString(input.Text, UriKind.Absolute) && !string.IsNullOrEmpty(input.Text))
            {
                input.BorderBrush = Brushes.Red;
                throw new Exception($"Invalid Url!");
            }
        }

        private void CheckAllInputs()
        {
            if (string.IsNullOrEmpty(nametb.Text))
            {
                throw new Exception($"Name cannot be empty!");
            }
            else if (string.IsNullOrEmpty(twitchUrltb.Text) && string.IsNullOrEmpty(twitterUrltb.Text) && string.IsNullOrEmpty(youtubeUrltb.Text))
            {
                throw new Exception($"No links entered!");
            }
        }

        private void CreateCreator()
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
        }
    }
}
