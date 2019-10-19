using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    class NotificationService
    {

    }

    class MyApplicationContext : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private PreferencesForm preferencesForm;

        public MyApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Preferences", new EventHandler(ShowPerferences));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(ExitApplication));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("appicon.ico");
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;

            preferencesForm = new PreferencesForm();
        }

        private void ShowPerferences(object sender, EventArgs e)
        {
            if(!preferencesForm.Visible)
            {
                preferencesForm.Show();
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
}
