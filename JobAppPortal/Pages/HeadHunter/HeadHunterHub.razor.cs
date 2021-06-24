using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobAppPortal.Pages.HeadHunter
{
    public partial class HeadHunterHub
    {
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        HttpClient Http { get; set; }

        public List<HeadHunter> headHunters;

        private string errorMessage = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                headHunters = await Http.GetFromJsonAsync<List<HeadHunter>>("https://localhost:44372/Api/HeadHunters/GetAll");
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
            }

        }

        public class HeadHunter
        {
            public int Id { get; set; }

        }
    }
}
