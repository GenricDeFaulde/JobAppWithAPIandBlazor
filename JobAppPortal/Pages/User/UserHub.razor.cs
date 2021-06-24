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

namespace JobAppPortal.Pages.User
{
    public partial class UserHub
    {
        [Inject]
        ILocalStorageService LocalStorage { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        HttpClient Http { get; set; }
        // fields and variables

        private User user;
        private List<User> userList;
        EditUserModel _editUser;



        private string errorMessage = null;
        private string infoMessage = null;

        private string detailUser = "0";

        bool showModal = false;

        // initializing

        protected override async Task OnInitializedAsync()
        {

            try
            {
                var userId = 1;
                user = await Http.GetFromJsonAsync<User>("https://localhost:44372/Api/Users/Get/" + userId.ToString());
                userList = new List<User>();
                userList.Add(user);
        }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
            }
        }

        private async Task SaveUser()
        {
            // creating json objects
            var outputUser = new User
            {
                Id = _editUser.Id,
                ProfileId = _editUser.ProfileId,
                FirstName = _editUser.FirstName,
                LastName = _editUser.LastName,
                BirthDate = _editUser.BirthDate,
                Religion = _editUser.Religion,
                Sex = _editUser.Sex,
                Gender = _editUser.Gender,
                Nationality = _editUser.Nationality,
                Nationality2 = _editUser.Nationality2
            };
        //outputUser.ContactData = new UserContactData();
        //    outputUser.ContactData.EmailAddress = _editUser.Email;
        //    outputUser.ContactData.Current = _editUser.Current;
        //    outputUser.ContactData.AddressState = _editUser.AddressState;
        //    outputUser.ContactData.AddressCity = _editUser.AddressCity;
        //    outputUser.ContactData.AddressNation = _editUser.AddressNation;
        //    outputUser.ContactData.AddressStreet = _editUser.AddressStreet;
        //    outputUser.ContactData.PhoneNumber = _editUser.PhoneNumber;
        //    outputUser.ContactData.PhoneNumberAlt = _editUser.PhoneNumberAlt;
        //    outputUser.ContactData.UserId = _editUser.Id; 

        var outputAppUser = new AppUser
        {
            Id = _editUser.ProfileId,
            FirstName = _editUser.FirstName,
            LastName = _editUser.LastName,
            UserName = _editUser.UserName,
            Email = _editUser.Email
        };






            // calling  API
            // creating new user if needed

            await UpdateUser(outputUser);

            await OnInitializedAsync();
            Console.WriteLine("Done!");
        }




        private async Task UpdateUser(User editedUser)
        {
            showModal = true;
            Console.WriteLine(">--------<");

            // Edit user if exiting
            if (editedUser.Id != 0)
            {
                infoMessage = "Attempting to edit existing user...";
                var putString = "https://localhost:44372/Api/Users/Edit/" + editedUser.Id.ToString();

                using (HttpResponseMessage response = await Http.PutAsJsonAsync(putString, editedUser))
                {
                    infoMessage += "\r\n Accessing database...";

                    if (response.IsSuccessStatusCode)
                    {
                        // TODO: Log successfull call
                        infoMessage += "Success";
                    }
                    else
                    {
                        infoMessage += Environment.NewLine + "Something went wrong updating the user. " + Environment.NewLine + response.ReasonPhrase;
                    }
                }
            }
            // Else add new user
            else
            {
                editedUser.Id = 0;
                infoMessage += Environment.NewLine + "Attempting to create new user...";

                using (HttpResponseMessage response = await Http.PostAsJsonAsync("https://localhost:44372/Api/Users/Create/", editedUser))
                {
                    infoMessage += Environment.NewLine + "Accessing database...";

                    if (response.IsSuccessStatusCode)
                    {
                        infoMessage += Environment.NewLine + "Succesfully added new user. " + Environment.NewLine;
                    }
                    else
                    {
                        infoMessage += Environment.NewLine + "Something went wrong creating the user. " + Environment.NewLine + response.ReasonPhrase;
                    }
                }
            }

        }


    


    private static void GetPropertyValues(Object obj)
        {
            Type t = obj.GetType();
            Console.WriteLine("Type is: {0}", t.Name);
            var props = t.GetProperties();
            Console.WriteLine("Properties (N = {0}):",
                              props.Length);
            foreach (var prop in props)
                if (prop.GetIndexParameters().Length == 0)
                    Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                                      prop.PropertyType.Name,
                                      prop.GetValue(obj));
                else
                    Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                                      prop.PropertyType.Name);
        }


        // classes
        #region classes
        public class User
        {
            public int Id { get; set; }
            public string ProfileId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string BirthDate { get; set; }
            public string Religion { get; set; }
            public string Sex { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            public string Nationality2 { get; set; }
            public byte[] Picture { get; set; }
            public byte[] PictureAlt { get; set; }

        
    }

        public class UserRole
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string UserName { get; set; }
            public Dictionary<string, string> Roles { get; set; }
        }

        public class UserRolePairModel
        {
            public string UserId { get; set; }
            public string RoleName { get; set; }
        }

        public class AppUser
        {
            public string Id { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public bool IsAdmin { get; set; }
            public string AuthId { get; set; }
        }

        public class Role
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        #endregion


    }
}
