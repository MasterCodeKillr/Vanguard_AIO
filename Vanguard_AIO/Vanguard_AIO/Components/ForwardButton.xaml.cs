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
    /// Interaction logic for ForwardButton.xaml
    /// </summary>
    public partial class ForwardButton : UserControl
    {
        public ForwardButton()
        {
            InitializeComponent();
        }

        private void forwardButtonBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            forwardButtonBorder.Background = Brushes.CadetBlue;
        }

        private void forwardButtonBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            forwardButtonBorder.Background = Brushes.Gray;
        }
    }
}
