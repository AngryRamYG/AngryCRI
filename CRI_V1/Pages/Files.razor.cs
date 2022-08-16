using CRI_V1.Data;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CRI_V1.Data;

namespace CRI_V1.Pages
{
    public partial class Files
    {
        [Parameter]
        public string name { get; set; }
        [Parameter]
        public string project { get; set; }

        private MarkupString HTMLcontents;
        private static readonly HttpClient httpClient = new();
        public CRIFile ActiveFile { get; set; }
        public static CRI ActiveCRI { get; set; } = new();

        public static String repositoryName;
        public static String repositoryproject;

        //Model for new Demo starts here
        public static DemoCRIList CRIListDemo { get; set; } = new();
        public DemoTabModel ActiveDemoTab { get; set; } = new();
        public static List<DemoTabModel> DemoModelList { get; set; } = new();
        private List<MarkupString> HTMLDemoContents = new();


        protected override async Task OnInitializedAsync()
        {
            repositoryName = name;
            repositoryproject = project;
            await TestAsync();
        }
        public async Task TestAsync()
        {
            //await GetFilesFromCRI(GenerateFileUrl("/.criconfig.json"));
            await GetDemoFilesFromCRI(GenerateFileUrl("/.cridemoconfig.json"));
        }

        private static string GenerateFileUrl(string filePath)
        {
            return $"https://raw.githubusercontent.com/{repositoryName}/{repositoryproject}/main{filePath}";
        }

        public async Task GetFilesFromCRI(string url)
        {
            ActiveCRI.Files.Clear();
            ActiveCRI = JsonConvert.DeserializeObject<CRI>(await GetFileContent(url));
        }
        public async Task GetDemoFilesFromCRI(string url)
        {
            CRIListDemo.FileTabs.Clear();
           var tempResult = await GetFileContent(url);
            CRIListDemo = JsonConvert.DeserializeObject<DemoCRIList>(tempResult);
            Console.WriteLine(CRIListDemo);
            //DemoModelList.Clear();
            //DemoModelList = JsonConvert.DeserializeObject<List<DemoTabModel>>(await GetFileContent(url));
        }

        private static async Task<string> GetFileContent(string url)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApplication", "1"));
            return await httpClient.GetStringAsync(url);
        }


        public async Task FillCRIContent(String path)
        {
            ActiveFile = ActiveCRI.Files.First(key => key.Path.Equals(path, StringComparison.OrdinalIgnoreCase));
            if (ActiveFile.Content == null)
                ActiveFile.Content = await GetFileContent(GenerateFileUrl(ActiveFile.Path));
            StringToHtml(path);
            this.StateHasChanged();

        }

        public async Task FillCRIDemoContent(List<string> Paths)
        {
            ActiveDemoTab = CRIListDemo.FileTabs.First(key => key.Paths == Paths);
            //filling contents if they arent filled
            if (ActiveDemoTab.Contents.Count == 0)
                foreach (string path in Paths)
                {
                    var temp = await GetFileContent(GenerateFileUrl(path));
                    ActiveDemoTab.Contents.Add(temp); 
                }

            DemoContentToHtml(ActiveDemoTab.Contents);
            this.StateHasChanged();

        }

        public void StringToHtml(string path)
        {
            CRIFile cri;
            cri = ActiveCRI.Files.First(key => key.Path.Equals(path, StringComparison.OrdinalIgnoreCase));
            //string s = Markdig.Markdown.ToHtml(cri.Content ?? "");
            HTMLcontents = (MarkupString)Markdig.Markdown.ToHtml(cri.Content ?? "");
        }

        public void DemoContentToHtml(List<string> contents)
        {
            HTMLDemoContents.Clear();

            foreach (string content in contents)
            {
                HTMLDemoContents.Add((MarkupString)Markdig.Markdown.ToHtml(content ?? ""));
            }
        }
    }
}
