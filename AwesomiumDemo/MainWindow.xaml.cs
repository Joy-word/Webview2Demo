using Awesomium.Core;
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

namespace AwesomiumDemo {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            mapWeb.LoadCompleted += MapWeb_LoadCompleted;
            WebCore.BaseDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "//html";
            mapWeb.LoadFile("webMap.html");
            //mapWeb.LoadURL("http://www.baidu.com");

        }

        private void MapWeb_LoadCompleted(object sender, EventArgs e) {
            var mcInfo = new MapLocationInfo();
            mcInfo.title = "网旭武汉";
            mcInfo.content = "研发中心，位于铭丰大厦写字楼。";
            mcInfo.point = "114.418843|30.5000154";
            mcInfo.isOpen = 1;
            mcInfo.icon = new IconInfo();

            ShowMcInMap(new List<MapLocationInfo>() { mcInfo });


            mapWeb.CreateObject("jsobject");
            mapWeb.SetObjectCallback("jsobject", "callNETNoReturn", JSHandler);
        }

        private void JSHandler(object sender, JSCallbackEventArgs args) {
            var resultMessage = mapWeb.ExecuteJavascriptWithResult("myMethodExpectingReturn()");
            MessageBox.Show(resultMessage.ToString());
            //getMcEvent(resultMessage.ToString());
        }

        private void ShowMcInMap(List<MapLocationInfo> mcList) {
            string json = JsonConvert.SerializeObject(mcList);
            JSValue param1 = new JSValue(json);

            mapWeb.CallJavascriptFunction(null, "getMarkerArr", new JSValue[] { param1 });


        }
    }
}
