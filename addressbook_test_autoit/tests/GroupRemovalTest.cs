using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupRemovalTest : TestBase
    {
        [Test]
        public void TetsRemovalGroup()
        {
            app.Groups.IfNeedCreatedGroup();
            List<GroupData> oldGroup = app.Groups.GetGroupList();
            GroupData removalGroup = oldGroup[0];
            app.Groups.RemovalGroup(removalGroup);
            List<GroupData> newGroup = app.Groups.GetGroupList();
            oldGroup.Remove(removalGroup);
            oldGroup.Sort();
            newGroup.Sort();
            Assert.AreEqual(oldGroup, newGroup);

        }
    }
}
