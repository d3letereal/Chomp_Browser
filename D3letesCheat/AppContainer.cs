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

            // Use default tab renderer (can use ChromeTabRenderer if you copied it)
            TabRenderer = new ChromeTabRenderer(this);
        }

        // Called to create a new tab with Form1
        public override TitleBarTab CreateTab()
        {
            var form = new Form1
            {
                Text = "New Tab" // The tab title comes from Form1.Text
            };

            var tab = new TitleBarTab(this)
            {
                Content = form
            };

            form.ParentTab = tab; // Important for drag safety

            return tab;
        }





    }
}
