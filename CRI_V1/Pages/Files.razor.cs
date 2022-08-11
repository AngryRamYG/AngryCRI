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

        protected override async Task OnInitializedAsync()
        {

            repositoryName = name;
            repositoryproject = project;

            await TestAsync();
        }
        public async Task TestAsync()
        {
            await GetFilesFromCRI(GenerateFileUrl("/.cri.json"));


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

        private static async Task<string> GetFileContent(string url)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApplication", "1"));
            return await httpClient.GetStringAsync(url);
        }

       
        public async Task<string> FillCRIContent(String path)
        {
            ActiveFile = ActiveCRI.Files.First(key => key.Path.Equals(path, StringComparison.OrdinalIgnoreCase));
            if (ActiveFile.Content == null)
                ActiveFile.Content = await GetFileContent(GenerateFileUrl(ActiveFile.Path));
            StringToHtml(path);
            this.StateHasChanged();
            return ActiveFile.Content;

        }
        public void StringToHtml(string path)
        {
            CRIFile cri;
            cri = ActiveCRI.Files.First(key => key.Path.Equals(path, StringComparison.OrdinalIgnoreCase));
            string s = Markdig.Markdown.ToHtml(cri.Content ?? "");
            HTMLcontents = (MarkupString)s;
        }
    }
}
