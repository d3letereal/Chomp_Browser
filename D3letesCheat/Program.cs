using System;
using System.Windows.Forms;
using D3;
using EasyTabs;

namespace D3letesCheat
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create the main tab container
            var container = new AppContainer();

            // Create the first Form1 instance
            var homeForm = new Form1
            {
                Text = "Home"
            };

            // Create the first tab and assign ParentTab
            var firstTab = new TitleBarTab(container)
            {
                Content = homeForm
            };
            homeForm.ParentTab = firstTab; // <-- MUST DO THIS

            // Add the tab to the container
            container.Tabs.Add(firstTab);
            container.SelectedTabIndex = 0;

            // Run the container
            Application.Run(container);
        }
    }
}
