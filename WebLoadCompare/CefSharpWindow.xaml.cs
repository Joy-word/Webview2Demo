using CefSharp;
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
    /// CefSharpWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CefSharpWindow : Window {
        public CefSharpWindow() {
            InitializeComponent();

            cefSharpView.AddressChanged += CefSharpView_AddressChanged;
            cefSharpView.FrameLoadStart += CefSharpView_FrameLoadStart;
            cefSharpView.FrameLoadEnd += CefSharpView_FrameLoadEnd;

            cefSharpView.Address = "https://www.apowersoft.cn";
        }

      
        private DateTime dateTime;

        private void log(string log) {
            var logText = $"\n {DateTime.Now.ToString("#HH:mm:ss.fff")} : {log}";
            tbLog.Text += logText;
        }

        private void CefSharpView_FrameLoadEnd(object sender, FrameLoadEndEventArgs e) {
            Application.Current.Dispatcher.Invoke(() => {
                log("FrameLoadEnd.");
                if (dateTime != null) {
                    var duration = (DateTime.Now - dateTime).TotalMilliseconds;
                    log("TotalMillisends: " + duration.ToString());
                }
            });
          
        }

        private void CefSharpView_FrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e) {
            Application.Current.Dispatcher.Invoke(() => {
                log("FrameLoadStart.");
                dateTime = DateTime.Now;
            });
        }


        private void CefSharpView_AddressChanged(object sender, DependencyPropertyChangedEventArgs e) {
            Application.Current.Dispatcher.Invoke(() => {
                log("AddressChanged.");
            });
        }

        private void btnGo_Click(object sender, RoutedEventArgs e) {
            cefSharpView.LoadUrl(addressBar.Text);
        }
    }
}
