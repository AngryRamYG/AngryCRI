using System.Runtime.Serialization;
using static CRI_V1.Data.CRIModel;

namespace CRI_V1.Data
{
    public class CRIModel
    {
        [DataContract]
        public class CRITab
        {
            [DataMember]
            public string TabTitle;
            [DataMember]
            public List<string> Paths;
            [DataMember]
            public List<CRITab> SubTabs;
            [DataMember]
            public List<string> Contents = new();
        }

        [DataContract]
        public class CRITabList
        {
            [DataMember]
            public List<CRITab> Tabs { get; set; } = new();
        }
    }
}
