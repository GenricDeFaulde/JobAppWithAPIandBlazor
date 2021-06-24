using Blazored.LocalStorage;
using JobAppPortal.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace JobAppPortal.Pages.Company
{
    public partial class CompanyHub
    {
        [Inject]
        ILocalStorageService LocalStorage { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        HttpClient Http { get; set; }

        public List<Company> companies;

        private string errorMessage = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                companies = await Http.GetFromJsonAsync<List<Company>>("https://localhost:44372/Api/Companies/GetAll");
                await Task.Delay(1000);
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
            }

        }


        public class Company
        {
            public int Id { get; set; }

            public string CompanyName { get; set; }

            public bool Current { get; set; }

            public string Description { get; set; }

            public List<Branch> Branches { get; set; }

            public List<History> Histories { get; set; }
        }


        public class Branch
        {
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string AddressNation { get; set; }
            public string AddressStreet { get; set; }
            public string AddressState { get; set; }
            public List<Contact> Contacts { get; set; }
            public List<Offer> Offers { get; set; }
        }

        public class History
        {
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public string Name { get; set; }
            public string Content { get; set; }
            public DateTime Date { get; set; }
        }

        public class Contact
        {
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public int CompanyBranchId { get; set; }
            public string PhoneNumber { get; set; }
            public string PhoneNumberAlt { get; set; }
            public string EmailAddress { get; set; }
            public string EmailAddressAlt { get; set; }
            public bool IsActive { get; set; }
        }

        public class Offer
        {
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public int CompanyBranchId { get; set; }
            public int JobId { get; set; }
            public int HeadHunterId { get; set; }
            public int ApplicationId { get; set; }
            public string SalaryOffered { get; set; }
            public bool IsActive { get; set; }
            public string ReleaseDate { get; set; }
            public string JobOfferUrl { get; set; }
        }
    }
}
