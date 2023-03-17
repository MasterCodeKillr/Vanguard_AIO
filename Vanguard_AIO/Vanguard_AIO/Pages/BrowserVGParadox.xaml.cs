using Microsoft.Web.WebView2.Wpf;
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

namespace Vanguard_AIO.Pages
{
    /// <summary>
    /// Interaction logic for BrowserVGParadox.xaml
    /// </summary>
    public partial class BrowserVGParadox : Page
    {
        public static WebView2 paradox { get; set; }
        public BrowserVGParadox()
        {
            InitializeComponent();
            wbParadox.Source = new Uri("https://vg-paradox.com/");
            paradox = wbParadox;
        }

        public void goBack()
        {
            paradox.GoBack();
        }

        public void goForward()
        {
            paradox.GoForward();
        }

        public void refresh()
        {
            wbParadox.Source = new Uri("https://vg-paradox.com/");
        }

        public void NavigateTo(string url)
        {
            paradox.Source = new Uri(url);
        }
    }
}
