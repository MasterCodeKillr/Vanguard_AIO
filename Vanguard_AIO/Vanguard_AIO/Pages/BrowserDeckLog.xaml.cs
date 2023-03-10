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
    /// Interaction logic for BrowserDeckLog.xaml
    /// </summary>
    public partial class BrowserDeckLog : Page
    {
        public static WebView2 deckLog { get; set; }
        public BrowserDeckLog()
        {
            InitializeComponent();
            wbDeckLog.Source = new Uri("https://decklog-en.bushiroad.com/");
            deckLog = wbDeckLog;
        }

        public void NavigateTo(string url)
        {
            wbDeckLog.Source = new Uri(url);
        }
    }
}
