using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.WorkGroups;
using System.Xml.XPath;

namespace ATframework3demo.TestEntities
{
    public class TestWorkgroup
    {
        public TestWorkgroup(string workGroupName)
        {
            WorkGroupName = workGroupName;
            XPath = ($"//a[contains(text(),'{workGroupName}')]" +
                $"//ancestor::tr [@class = \"main-grid-row main-grid-row-body\" " +
                $"or @class = \"main-grid-row main-grid-row-body sonet-ui-grid-row-pinned\"]");

        }

        public string WorkGroupName { get; set; }
        public string XPath { get; set; }
    }
}
