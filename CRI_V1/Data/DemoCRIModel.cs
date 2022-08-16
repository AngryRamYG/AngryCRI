using Microsoft.AspNetCore.Components;
using System.Runtime.Serialization;

namespace CRI_V1.Data
{
    [DataContract]
    public class DemoTabModel
    {
        [DataMember]
        public string FileTitle;
        [DataMember]
        public List<string> Paths;
        [DataMember]
        public List<DemoTabModel> SubFiles;
        [DataMember]
        public List<string> Contents = new();
    }

    [DataContract]
    public class DemoCRIList
    {
        [DataMember]
        public List<DemoTabModel> FileTabs { get; set; } = new();
    }
}
