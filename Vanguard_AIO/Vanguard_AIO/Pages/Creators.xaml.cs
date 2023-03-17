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
using Vanguard_AIO.Classes;
using Vanguard_AIO.Components;
using Vanguard_AIO.Dialogs;

namespace Vanguard_AIO.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Creators : Page
    {
        private AddCreator addCreator;
        public Creators()
        {
            InitializeComponent();
            ShowCreators();
        }

        public void CreateWindow()
        {
            addCreator = new AddCreator();
            addCreator.Closing += AddCreator_Closing;
        }

        public void ShowCreators()
        {
            CreatorList.CurrentList = CreatorList.GetCreators();
            foreach (var creator in CreatorList.CurrentList)
            {
                creatorGrid.Children.Add(new CreatorLinks(creator.name, creator.twitch, creator.youtube,
                    creator.twitter));
            }
        }

        private void btAddCreator_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow();
            addCreator.ShowDialog();
        }

        private void AddCreator_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CreatorList.CurrentList != CreatorList.UpdatedList && CreatorList.UpdatedList != null)
            {
                var newCreators =
                    CreatorList.UpdatedList.Where(x => !CreatorList.CurrentList.Any(z => z.name == x.name)).ToList();
                foreach (var creator in newCreators)
                {
                    creatorGrid.Children.Add(new CreatorLinks(creator.name, creator.twitch, creator.youtube,
                        creator.twitter));
                    CreatorList.CurrentList.Add(creator);
                }
            }
        }
    }
}
