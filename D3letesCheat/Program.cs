using D3;
using EasyTabs;
using System;
using System.Windows.Forms;

namespace D3letesCheat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            AppContainer container = new AppContainer();


            container.Tabs.Add(new TitleBarTab(container)
            {
                Content = new Main
                {
                    Text = "New Tab"
                }
            });

            container.SelectedTabIndex = 0;


            TitleBarTabsApplicationContext appContext = new TitleBarTabsApplicationContext();


            appContext.Start(container);



            Application.Run(appContext);
        }
    }
}
