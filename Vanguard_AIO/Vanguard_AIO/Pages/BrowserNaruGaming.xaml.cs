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
    /// Interaction logic for BrowserNaruGaming.xaml
    /// </summary>
    public partial class BrowserNaruGaming : Page
    {
        public static WebView2 naru { get; set; }
        public BrowserNaruGaming()
        {
            InitializeComponent();
            wbNaru.Source = new Uri("https://narusamuraigaming.com/");
            naru = wbNaru;
        }

        public void NavigateTo(string url)
        {
            naru.Source = new Uri(url);
        }
    }
}
