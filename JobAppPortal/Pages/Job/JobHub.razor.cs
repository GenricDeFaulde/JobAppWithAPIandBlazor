using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobAppPortal.Pages.Job
{
    public partial class JobHub
    {
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        HttpClient Http { get; set; }

        public List<Job> jobs;

        private string errorMessage = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                jobs = await Http.GetFromJsonAsync<List<Job>>("https://localhost:44372/Api/Jobs/GetAll");
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
            }

        }

        public class Job
        {
            public int Id { get; set; }

        }
    }
}
