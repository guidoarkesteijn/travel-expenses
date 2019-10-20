using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    public interface IMenuItemable
    {
        MenuItem[] MenuItems { get; }
    }

    class TrayContextMenuService
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu = new ContextMenu();

        public TrayContextMenuService(IMenuItemable[] menuItemables)
        {
            AddItems(menuItemables);
            contextMenu.MenuItems.Add(new MenuItem("Exit", ExitApplication));
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("appicon.ico");
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;
        }

        private void AddItems(IMenuItemable[] menuItemables)
        {
            foreach (var menuItemable in menuItemables)
            {
                contextMenu.MenuItems.AddRange(menuItemable.MenuItems);                
            }
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }

    public class OutOfOfficeService : IMenuItemable
    {
        public MenuItem[] MenuItems { get; private set; }

        public OutOfOfficeService()
        {
            MenuItems = GetMenuItems();
        }

        private MenuItem[] GetMenuItems()
        {
            var menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem("1 Hour"));
            menuItems.Add(new MenuItem("1 Week"));
            menuItems.Add(new MenuItem("1 Day"));
            menuItems.Add(new MenuItem("Custom"));

            return menuItems.ToArray();
        }
    }

    public class LocalMenuItem
    {

    }

    public class LocalContextMenu
    {

    }
    
    class NotificationService
    {

    }

    class MyApplicationContext : ApplicationContext
    {
        private PreferencesForm preferencesForm;

        public MyApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Preferences", new EventHandler(ShowPerferences));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(ExitApplication));

            MenuItem subMenuItem = new MenuItem("Sub");
            MenuItem outOfOfficeMenuItem = new MenuItem("Out of Office", new MenuItem[] { subMenuItem });

            preferencesForm = new PreferencesForm();
        }

        private void ShowPerferences(object sender, EventArgs e)
        {
            if(!preferencesForm.Visible)
            {
                preferencesForm.Show();
            }
        }
    }
}
