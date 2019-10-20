using System;
using System.Windows.Forms;

namespace DeclarationAutomation.WinForms
{
    public class PreferenceService : ITrayMenuItem
    {
        public MenuItem[] MenuItems { get; private set; }

        private PreferencesForm preferencesForm;

        public PreferenceService()
        {
            MenuItems = GetMenuItems();
            preferencesForm = new PreferencesForm();
        }

        private MenuItem[] GetMenuItems()
        {
            return new MenuItem[] { new MenuItem("Preferences", OnPreferencesButtonClicked) };
        }

        private void OnPreferencesButtonClicked(object? sender, EventArgs args)
        {
            if (!preferencesForm.Visible)
            {
                preferencesForm.Show();
            }
        }
    }
}
