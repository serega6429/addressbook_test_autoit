using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace addressbook_test_autoit
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGrops = app.Groups.GetGroupList();
            GroupData group = new GroupData()
            {
                Name = "test"
            };
            app.Groups.Add(group);
            List<GroupData> newGrops = app.Groups.GetGroupList();
            oldGrops.Add(group);
            oldGrops.Sort();
            newGrops.Sort();
            Assert.AreEqual(oldGrops, newGrops);
        }
    }
}
