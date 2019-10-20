using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    public class OutOfOfficeService : ITrayMenuItem
    {
        public MenuItem[] MenuItems { get; private set; }

        private OutOfOfficeCustomFormService outOfOfficeFormService;

        public OutOfOfficeService(OutOfOfficeCustomFormService outOfOfficeFormService)
        {
            this.outOfOfficeFormService = outOfOfficeFormService;
            MenuItems = GetMenuItems();
        }

        private MenuItem[] GetMenuItems()
        {
            var rootMenuItems = new MenuItem[1];
            var menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem("1 Day"));
            menuItems.Add(new MenuItem("1 Week"));
            menuItems.Add(new MenuItem("1 Month"));
            menuItems.Add(new MenuItem("-"));
            menuItems.Add(new MenuItem("Custom", OnOutOfOfficeCustomButtonClicked));

            var rootMenuItem = new MenuItem("Out of Office", menuItems.ToArray());
            rootMenuItems[0] = rootMenuItem;

            return rootMenuItems;
        }

        private void OnOutOfOfficeCustomButtonClicked(object? sender, EventArgs args)
        {
            outOfOfficeFormService.Show();
        }
    }
}
