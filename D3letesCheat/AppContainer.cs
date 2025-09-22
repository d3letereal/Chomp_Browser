using D3letesCheat;
using EasyTabs;
using System.Windows.Forms;

namespace D3
{
    public class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new Main
                {
                    Text = "New Tab"
                }
            };
        }
    }
}
