using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
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

namespace WebView2Demo {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            InitializeAsync();
        }

        //(114.418843,30.5000154) 武汉铭丰大厦（网旭武汉）
        //(115.857372,28.692172) 南昌博能金融中心（网旭南昌）
        //(113.932235,22.517657) 深圳来福士广场（网旭深圳）
        //(108.955684,34.238651) 西安碑林区长安大街（网旭西安）

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            webView.Source = new Uri("file:///D:/documents/Domos/WebView2Demo/WebView2Demo/bin/Debug/html/webMap.html");
        }

        async void InitializeAsync() {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += WebMessageReceived;
        }

        void WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args) {
            MessageInfo message = JsonConvert.DeserializeObject<MessageInfo>(args.WebMessageAsJson);
            if(message != null) {
                ReceiveMessage(args.Source, message.type, message.data.ToString());
            }
        }

        public void SendMessage(MessageInfo message) {
            string json = JsonConvert.SerializeObject(message);
            webView.CoreWebView2.PostWebMessageAsJson(json);
        }

        public void ReceiveMessage(string source, string messageType, string messageJson) {
            switch (messageType) {
                case "Inited":
                    SetFirstPoint();
                    break;
                case "ShowMessage":
                    MessageBox.Show(messageJson);
                    break;
                case "InfoInMaps":
                    tbTitle.Text = messageJson;
                    break;
            }
        }

        public void SetFirstPoint() {
            MapLocationInfo mapLocationInfo = new MapLocationInfo {
                title = "网旭武汉",
                content = "研发中心，位于铭丰大厦写字楼。",
                point = "114.418843|30.5000154",
                isOpen = 1,
                icon = new IconInfo(),
            };

            List<MapLocationInfo> mapLocationInfos = new List<MapLocationInfo>();
            mapLocationInfos.Add(mapLocationInfo);

            MessageInfo message = new MessageInfo() {
                type = "AddLocation",
                data = mapLocationInfos
            };

            SendMessage(message);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            MapLocationInfo mapLocationInfo = new MapLocationInfo {
                title = tbTitle.Text,
                content = tbContent.Text,
                point = $"{tbX.Text}|{tbY.Text}",
                isOpen = 1,
                icon = new IconInfo(),
            };

            List<MapLocationInfo> mapLocationInfos = new List<MapLocationInfo>();
            mapLocationInfos.Add(mapLocationInfo);

            MessageInfo message = new MessageInfo() {
                type = "AddLocation",
                data = mapLocationInfos
            };

            SendMessage(message);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e) {

            MessageInfo message = new MessageInfo() {
                type = "SearchLocation",
                data = tbTitle.Text
            };

            SendMessage(message);
        }
    }
}
