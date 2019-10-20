namespace DeclarationAutomation.WinForms
{
    public class OutOfOfficeCustomFormService
    {
        private OutOfOfficeCustomForm outOfOfficeCustomForm;

        public OutOfOfficeCustomFormService()
        {
            outOfOfficeCustomForm = new OutOfOfficeCustomForm();
        }

        internal void Show()
        {
            if(!outOfOfficeCustomForm.Visible)
            {
                outOfOfficeCustomForm.Show();
            }
        }
    }
}
