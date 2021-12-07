using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebView2Demo {
    //[{title:"天徽大厦",content:"000",point:"117.292738|31.869242",isOpen:1,icon:{w:21,h:21,l:0,t:46,x:1,lb:10}}]
    public class MapLocationInfo {
        public string title;
        public string content;
        public string point;
        public int isOpen;
        public IconInfo icon = new IconInfo();

    }

    public class IconInfo {
        public int w = 32;
        public int h = 47;
        public int l = 0;
        public int t = 0;
        public int x = 1;
        public int lb = 10;
    }
}
