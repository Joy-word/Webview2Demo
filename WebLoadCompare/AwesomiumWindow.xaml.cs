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
    /// AwesomiumWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AwesomiumWindow : Window {
        public AwesomiumWindow() {
            InitializeComponent();

            awesomiumView.BeginLoading += AwesomiumView_BeginLoading;
            awesomiumView.BeginNavigation += AwesomiumView_BeginNavigation;
            awesomiumView.LoadCompleted += AwesomiumView_LoadCompleted;

            awesomiumView.Source = new Uri("https://www.apowersoft.cn");
        }

        private DateTime dateTime;

        private void log(string log) {
            var logText = $"\n {DateTime.Now.ToString("#HH:mm:ss.fff")} : {log}";
            tbLog.Text += logText;
        }

        private void AwesomiumView_BeginLoading(object sender, Awesomium.Core.BeginLoadingEventArgs e) {
            log("BeginLoading.");
        }

        private void AwesomiumView_BeginNavigation(object sender, Awesomium.Core.BeginNavigationEventArgs e) {
            log("BeginNavigation.");
            dateTime = DateTime.Now;
        }

        private void AwesomiumView_LoadCompleted(object sender, EventArgs e) {
            log("LoadCompleted.");
            if (dateTime != null) {
                var duration = (DateTime.Now - dateTime).TotalMilliseconds;
                log("TotalMillisends: " + duration.ToString());
            }
        }

        private void btnGo_Click(object sender, RoutedEventArgs e) {
            awesomiumView.LoadURL(addressBar.Text);
        }
    }
}
