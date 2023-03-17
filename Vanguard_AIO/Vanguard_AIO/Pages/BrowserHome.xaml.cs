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
    /// Interaction logic for BrowserHome.xaml
    /// </summary>
    public partial class BrowserHome : Page
    {
        public static WebView2 home { get; set; }
        public BrowserHome()
        {
            InitializeComponent();
            wbHome.Source = new Uri("https://narusamuraigaming.com/pages/vanguard-aio");
            home = wbHome;
        }

        public void goBack()
        {
            home.GoBack();
        }

        public void goForward()
        {
            home.GoForward();
        }

        public void refresh()
        {
            wbHome.Source = new Uri("https://narusamuraigaming.com/pages/vanguard-aio");
        }

        public void NavigateTo(string url)
        {
            home.Source = new Uri(url);
        }
    }
}
