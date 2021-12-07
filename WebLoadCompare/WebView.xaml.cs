using Microsoft.Web.WebView2.Core;
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
using System.Windows.Shapes;

namespace WebLoadCompare {
    /// <summary>
    /// WebView.xaml 的交互逻辑
    /// </summary>
    public partial class WebView : Window {
        public WebView() {
            InitializeComponent();

            webView.NavigationStarting += WebView_NavigationStarting;
            webView.SourceChanged += WebView_SourceChanged;
            webView.NavigationCompleted += WebView_NavigationCompleted;

            webView.Source = new Uri("https://www.apowersoft.cn");

            log("Create page.");
        }

        private DateTime dateTime;

        private void log(string log) {
            var logText = $"\n {DateTime.Now.ToString("#HH:mm:ss.fff")} : {log}";
            tbLog.Text += logText;
        }

        
        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
            log("NavigationCompleted.");
            if(dateTime != null) {
                var duration = (DateTime.Now - dateTime).TotalMilliseconds;
                log("TotalMillisends: " + duration.ToString());
            }
        }

        private void WebView_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e) {
            log("SourceChanged.");
        }

        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e) {
            log("NavigationStarting.");
            dateTime = DateTime.Now;
        }


        private void btnGo_Click(object sender, RoutedEventArgs e) {
            if (webView != null && webView.CoreWebView2 != null) {
                webView.CoreWebView2.Navigate(addressBar.Text);
            }
        }
    }
}
