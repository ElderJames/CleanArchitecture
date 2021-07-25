using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Template.Pages.User
{
    public partial class Register
    {
        [Inject] private HttpClient HttpClient { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        User _user = new User();

        public async Task SubmitRegister()
        {
            var response = await HttpClient.PostAsJsonAsync("api/account/register", _user);
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("user/login");
            }
        }
    }

    public class User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}