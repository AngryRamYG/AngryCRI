using Microsoft.AspNetCore.Components;

namespace CRI_V1.Pages
{
    public partial class Index
    {
        public static string RepositoryName { get; set; } = "MeatRocket/CRI-testing";



        public async Task TestAsync()
        {
            var s = RepositoryName.Split("/");
            NavigationManager.NavigateTo("/" + s[0] + "/" + s[1]);

        }




    }
}
