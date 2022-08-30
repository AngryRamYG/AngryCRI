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
<<<<<<< HEAD

=======
>>>>>>> 6c5f7a03e8e6cd801afb09c83b84a1267d1cd87c
    }
}
