using Microsoft.AspNetCore.Components;

namespace CRI_V1.Data
{
    public class CRIDemoModel
    {
        public class UserCustomization
        {
            public bool HasSocialMedia { get; set; }
            public bool ManualLinks { get; set; }
            public bool DisplayProfilePic { get; set; }
            public string CardBackgroundColor { get; set; }
            public string CardTextColor { get; set; }

        }
        public class SocialMedia
        {
            public string Github { get; set; }
            public string FaceBook { get; set; }
            public string LinkedIn { get; set; }
            public string Instagram { get; set; }
            public string Twitter { get; set; }

        }
        public class AboutUser
        {
            public string ProfilePic { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string UserDescription { get; set; }
            public SocialMedia SocialMedia { get; set; }
        }
        public class MDFileCustomization
        {
            public string MDBackgroundColor { get; set; }
            public string MDTextColor { get; set; }
        }
        public class MDFile
        {
            public string FileName { get; set; }
            public string Path { get; set; }
            public MarkupString Content { get; set; }
            public DateTime LastCommited { get; set; }
        }

        public class MDTab
        {
            public string Title { get; set; }
            public string MDTabBackgroundColor { get; set; }
            public string MDTabTextColor { get; set; }

            List<MDFile> Contents;
            public List<MDTab> SubTab { get; set; }
        }

    }
}
