using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Vanguard_AIO.Pages;

namespace Vanguard_AIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrowserTCGMassEntry tcgPage;
        BrowserHome homePage;
        BrowserNaruGaming naruPage;
        BrowserDeckLog deckLogPage;
        BrowserVGParadox paradoxPage;
        Creators creatorsPage;
        private bool tcgCheck = false;
        private bool homeCheck = false;
        private bool naruCheck = false;
        private bool deckLogCheck = false;
        private bool paradoxCheck = false;
        public MainWindow()
        {
            tcgPage = new BrowserTCGMassEntry();
            homePage = new BrowserHome();
            naruPage = new BrowserNaruGaming();
            deckLogPage = new BrowserDeckLog();
            paradoxPage = new BrowserVGParadox();
            creatorsPage = new Creators();
            InitializeComponent();
        }

        public bool validEntry()
        {
            try
            {
                if (tbDeckCode.Text.Length > 0 && !string.IsNullOrEmpty(tbDeckCode.Text))
                {
                    return true;
                }
                if (tbDeckCode.Text.Length > 0 || string.IsNullOrEmpty(tbDeckCode.Text))
                {
                    throw new ArgumentException("Deck code error. Please check deck code and try again.");
                }
                throw new ArgumentException("Invalid Entry.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private async void btExportTCG_Click(object sender, RoutedEventArgs e)
        {
            tbDeckCode.Text = tbDeckCode.Text.ToUpper();
            tcgPage.NavigateTo("https://www.tcgplayer.com/massentry?productline=Cardfight%20Vanguard&utm_campaign=affiliate&utm_medium=NaruSamurai&utm_source=NaruSamurai");
            if (validEntry())
            {
                MassEntryBtn.IsChecked = true;
                Thread.Sleep(1000);
                await BrowserTCGMassEntry.getSource(tbDeckCode.Text);
            }
        }

        private void MassEntryBtn_Checked(object sender, RoutedEventArgs e)
        {
            ShowBrowser(true);
            SetVisibility(true);
            if (!tcgCheck)
                tcgPage.NavigateTo("https://www.tcgplayer.com/massentry?productline=Cardfight%20Vanguard&utm_campaign=affiliate&utm_medium=NaruSamurai&utm_source=NaruSamurai");
            frMain.Content = tcgPage;
            tcgCheck = true;
        }

        public void SetVisibility(bool visible)
        {
            var isVisible = Visibility.Visible;
            if (!visible)
                isVisible = Visibility.Collapsed;
            lblDeckCode.Visibility = isVisible;
            tbDeckCode.Visibility = isVisible;
            btExportTCG.Visibility = isVisible;
        }

        public void ShowBrowser(bool visible)
        {
            var isVisible = Visibility.Visible;
            if (!visible)
                isVisible = Visibility.Collapsed;
            frMain.Visibility = isVisible;
        }

        private void HomeBtn_Checked(object sender, RoutedEventArgs e)
        {
            ShowBrowser(true);
            SetVisibility(false);
            if(!homeCheck)
                homePage.NavigateTo("https://narusamuraigaming.com/pages/vanguard-aio");
            frMain.Content = homePage;
            homeCheck = true;
        }

        private void DeckLogBtn_Checked(object sender, RoutedEventArgs e)
        {
            ShowBrowser(true);
            SetVisibility(true);
            if(!deckLogCheck)
                deckLogPage.NavigateTo("https://decklog-en.bushiroad.com/");
            frMain.Content = deckLogPage;
            deckLogCheck = true;
        }

        private void ParadoxBtn_Checked(object sender, RoutedEventArgs e)
        {
            ShowBrowser(true);
            SetVisibility(true);
            if(!paradoxCheck)
                paradoxPage.NavigateTo("https://vg-paradox.com/");
            frMain.Content = paradoxPage;
            paradoxCheck = true;
        }

        private void NaruBtn_Checked(object sender, RoutedEventArgs e)
        {
            ShowBrowser(true);
            SetVisibility(true);
            if(!naruCheck)
                naruPage.NavigateTo("https://narusamuraigaming.com/");
            frMain.Content = naruPage;
            naruCheck = true;
        }

        private void CreatorsBtn_Checked(object sender, RoutedEventArgs e)
        {
            SetVisibility(false);
            ShowBrowser(true);
            frMain.Content = creatorsPage;
        }

        private void SettingsBtn_Checked(object sender, RoutedEventArgs e)
        {
            SetVisibility(false);
            ShowBrowser(false);
        }

        private void MassEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!tcgCheck)
                tcgPage.NavigateTo("https://www.tcgplayer.com/massentry?productline=Cardfight%20Vanguard&utm_campaign=affiliate&utm_medium=NaruSamurai&utm_source=NaruSamurai");
            tcgCheck = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MassEntryBtn.IsChecked == true)
                tcgPage.goBack();

        }

        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MassEntryBtn.IsChecked == true)
                tcgPage.goBack();
            if (HomeBtn.IsChecked == true)
                homePage.goBack();
            if (ParadoxBtn.IsChecked == true)
                paradoxPage.goBack();
            if (NaruBtn.IsChecked == true)
                naruPage.goBack();
            if (DeckLogBtn.IsChecked == true)
                deckLogPage.goBack();
        }

        private void ForwardButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MassEntryBtn.IsChecked == true)
                tcgPage.goForward();
            if (HomeBtn.IsChecked == true)
                homePage.goForward();
            if (ParadoxBtn.IsChecked == true)
                paradoxPage.goForward();
            if (NaruBtn.IsChecked == true)
                naruPage.goForward();
            if (DeckLogBtn.IsChecked == true)
                deckLogPage.goForward();
        }

        private void RefreshArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MassEntryBtn.IsChecked == true)
                tcgPage.refresh();
            if (HomeBtn.IsChecked == true)
                homePage.refresh();
            if (ParadoxBtn.IsChecked == true)
                paradoxPage.refresh();
            if (NaruBtn.IsChecked == true)
                naruPage.refresh();
            if (DeckLogBtn.IsChecked == true)
                deckLogPage.refresh();
        }
    }
}
