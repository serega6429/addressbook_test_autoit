using System;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string WINGROUPEDITORTITLE = "Group editor";
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {
        }

        public void IfNeedCreatedGroup()
        {
            if (GetGroupList().Count == 0)
            {
                Add(new GroupData()
                {
                    Name = DateTime.Now.ToString()
                });
            }
        }

        public void RemovalGroup(GroupData removalGroup)
        {
            OpenGroupsDialog();
            aux.ControlTreeView(WINGROUPEDITORTITLE, "",
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#0", "");
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait("Delete group");
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGropsDialog();
            


        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();                                           
            string count = aux.ControlTreeView(WINGROUPEDITORTITLE, "", 
                "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "GetItemCount", "#0", "");
            
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(WINGROUPEDITORTITLE, "", 
                    "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGropsDialog();
            return list;
        }

        public void Add(GroupData group)
        {
            OpenGroupsDialog();
            aux.ControlClick(WINGROUPEDITORTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(group.Name);
            aux.Send("{ENTER}");
            CloseGropsDialog();
        }

        private void CloseGropsDialog()
        {
            aux.ControlClick(WINGROUPEDITORTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(WINGROUPEDITORTITLE);
        }
    }
}