using System.Text;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    class MyApplicationContext : ApplicationContext
    {
        private TrayContextMenuService trayContextMenuService;

        public MyApplicationContext(TrayContextMenuService trayContextMenuService)
        {
            this.trayContextMenuService = trayContextMenuService;
        }
    }
}
