using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
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
using Microsoft.Web.WebView2.Wpf;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using Vanguard_AIO.Classes;
using MessageBox = System.Windows.MessageBox;

namespace Vanguard_AIO.Pages
{
    /// <summary>
    /// Interaction logic for BrowserTCGMassEntry.xaml
    /// </summary>
    public partial class BrowserTCGMassEntry : Page
    {
        public static WebView2 tcg { get; set; }
        public BrowserTCGMassEntry()
        {
            InitializeComponent();
            wbTCG.Source = new Uri("https://www.tcgplayer.com/massentry?productline=Cardfight%20Vanguard&utm_campaign=affiliate&utm_medium=NaruSamurai&utm_source=NaruSamurai");
            tcg = wbTCG;
        }

        public void NavigateTo(string url)
        {
            tcg.Source = new Uri(url);
        }

        public static async Task getSource(string code)
        {
            try
            {
                ListFormatting.massList.Clear();
                await ApiRequest.request(code);
                await AddToList();
                await tcg.ExecuteScriptAsync("document.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").focus()");
                Thread.Sleep(250);
                await tcg.ExecuteScriptAsync("document.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").focus()");
                Thread.Sleep(250);
                await tcg.ExecuteScriptAsync("document.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").focus()");
                await tcg.ExecuteScriptAsync("document.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").focus()");


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static async Task AddToList()
        {
            string[] cards = ListFormatting.massList.ToArray();
            string print = string.Join("\\n", cards.Take(cards.Length-1));
            string command1 = $"document.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").innerText = '{print}'";
            string command = $"const string = document.createElement(\"div\")\nstring.className = 'row'\nstring.innerHTML = '{cards.Last()}'\ndocument.querySelector(\"#mass-entry > div.mass-entry__body > div.box.input-box > section\").prepend(string)";
            await tcg.ExecuteScriptAsync(command1);
            await tcg.ExecuteScriptAsync(command);
        }
    }
}
