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
using Vanguard_AIO.Components;

namespace Vanguard_AIO.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Creators : Page
    {
        public Creators()
        {
            InitializeComponent();
        }

        private void btAddCreator_Click(object sender, RoutedEventArgs e)
        {
            creatorGrid.Children.Add(new CreatorLinks());
        }
    }
}
