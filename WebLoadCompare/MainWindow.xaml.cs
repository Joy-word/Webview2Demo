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

namespace WebLoadCompare {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnWebview_Click(object sender, RoutedEventArgs e) {
            WebView webView = new WebView();
            webView.Show();
        }

        private void btnAwesomium_Click(object sender, RoutedEventArgs e) {
            AwesomiumWindow awesomiumWindow = new AwesomiumWindow();
            awesomiumWindow.Show();
        }

        private void btnCefSharp_Click(object sender, RoutedEventArgs e) {
            CefSharpWindow cefSharpWindow = new CefSharpWindow();
            cefSharpWindow.Show();
        }

        private void btnMiniblink_Click(object sender, RoutedEventArgs e) {
            MiniBlinkWindow miniBlinkWindow = new MiniBlinkWindow();
            miniBlinkWindow.Show();
        }
    }
}
