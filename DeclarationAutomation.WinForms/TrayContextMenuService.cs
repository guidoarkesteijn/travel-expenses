using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    class TrayContextMenuService
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu = new ContextMenu();

        public TrayContextMenuService(ITrayMenuItem[] menuItemables)
        {
            AddItems(menuItemables);
            contextMenu.MenuItems.Add(new MenuItem("-"));
            contextMenu.MenuItems.Add(new MenuItem("Exit", ExitApplication));
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("appicon.ico");
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;
        }

        private void AddItems(ITrayMenuItem[] menuItemables)
        {
            foreach (var menuItemable in menuItemables)
            {
                contextMenu.MenuItems.AddRange(menuItemable.MenuItems);
            }
        }

        private void ExitApplication(object? sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
