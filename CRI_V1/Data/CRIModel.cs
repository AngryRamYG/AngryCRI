
using static CRI_V1.Data.CRIModel;

namespace CRI_V1.Data
{
    public class CRIInfo
    {

        public UserCustomization UserCustomization {get;set;}
        public SocialMedia SocialMedia { get;set;}
        public AboutUser AboutUser { get;set;}
        public MDFileCustomization MDFileCustomization { get;set;}
        public List<MDTab> MDTabs { get;set;}

    }
}
