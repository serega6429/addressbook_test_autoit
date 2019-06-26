using AutoItX3Lib;

namespace addressbook_test_autoit
{
    public class HelperBase
    {
        protected ApplicationManager applicationManager;
        protected string WINTITLE;
        protected  AutoItX3 aux;

        public HelperBase(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
            this.aux = applicationManager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}