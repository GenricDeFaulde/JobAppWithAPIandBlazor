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

namespace JobAppPortal.Pages.Admin
{
    public partial class AdminHub
    {

        [Inject]
        AuthenticationStateProvider AuthStateProvider { get; set; }
        [Inject]
        ILocalStorageService LocalStorage { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        [Inject]
        HttpClient Http { get; set; }



        // fields and variables

        private User[] users;
        private List<User> usersList;
        EditUserModel _editUser;
        private UserRole[] userRoles;
        private AppUser[] appUsers;
        private Dictionary<string, string> roles { get; set; } = new Dictionary<string, string>();

        private string errorMessage = null;
        private string infoMessage = null;

        private string detailUser = "0";

        bool showModal = false;

        // initializing

        protected override async Task OnInitializedAsync()
        {
#if DEBUG
//await Task.Delay(10000); 
#endif
try
            {
                users = await Http.GetFromJsonAsync<User[]>("https://localhost:44372/Api/Users/GetAll");
                userRoles = await Http.GetFromJsonAsync<UserRole[]>("https://localhost:44372/Api/_Admin/Users/GetAllUsers");
                roles = await Http.GetFromJsonAsync<Dictionary<string, string>>("https://localhost:44372/api/_Admin/Users/GetAllRoles");
                appUsers = await Http.GetFromJsonAsync<AppUser[]>("https://localhost:44372/api/_Admin/Users/GetAllAuthUsers");
                usersList = users.ToList();
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                NavManager.NavigateTo("/logout");
            }
        }


        // Methods

        private void OnUserSelected(string selection)
        {
            detailUser = selection;
            PropagateEditUserFormFromAuthProfile(selection);
        }

        private void PropagateEditUserFormFromAuthProfile(string selection)
        {
            _editUser = new EditUserModel();

            AppUser appUser = appUsers.FirstOrDefault(x => x.Id == selection);
            User user = users.FirstOrDefault(x => x.ProfileId == selection);
            Dictionary<string, string> appUserRoles = userRoles.FirstOrDefault(r => r.Id == selection).Roles;

            _editUser.UserName = appUser.UserName;
            _editUser.FirstName = appUser.FirstName;
            _editUser.LastName = appUser.LastName;
            _editUser.ProfileId = appUser.Id;
            _editUser.Email = appUser.Email;
            _editUser.IsAdmin = appUserRoles.ContainsValue("Admin");
            _editUser.IsSuperAdmin = appUserRoles.ContainsValue("SuperAdmin");
            _editUser.IsModerator = appUserRoles.ContainsValue("Moderator");
            _editUser.Roles = appUserRoles;
            _editUser.Id = 0;

            if (user != null)
            {
                _editUser.BirthDate = user.BirthDate;
                _editUser.Gender = user.Gender;
                _editUser.Nationality = user.Nationality;
                _editUser.Nationality2 = user.Nationality2;
                _editUser.Religion = user.Religion;
                _editUser.Sex = user.Sex;
                _editUser.Id = user.Id;
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
            //outputUser.ContactData.EmailAddress = _editUser.Email;
            //outputUser.ContactData.Current = _editUser.Current;
            //outputUser.ContactData.AddressState = _editUser.AddressState;
            //outputUser.ContactData.AddressCity = _editUser.AddressCity;
            //outputUser.ContactData.AddressNation = _editUser.AddressNation;
            //outputUser.ContactData.AddressStreet = _editUser.AddressStreet;
            //outputUser.ContactData.PhoneNumber = _editUser.PhoneNumber;
            //outputUser.ContactData.PhoneNumberAlt = _editUser.PhoneNumberAlt;
            //outputUser.ContactData.UserId = _editUser.Id; 

var outputAppUser = new AppUser
{
    Id = _editUser.ProfileId,
    FirstName = _editUser.FirstName,
    LastName = _editUser.LastName,
    UserName = _editUser.UserName,
    Email = _editUser.Email
};

            var outputAddRoles = new UserRole
            {
                Id = _editUser.ProfileId,
                UserName = _editUser.UserName,
                Email = _editUser.Email,
                Roles = new Dictionary<string, string>()
                {

                }
            };


            var outputRemoveRoles = new UserRole
            {
                Id = _editUser.ProfileId,
                UserName = _editUser.UserName,
                Email = _editUser.Email,
                Roles = new Dictionary<string, string>()
                {
                }
            };


            if(_editUser is not null)
        {
                Console.WriteLine(">--------<");
                Console.WriteLine("processing roles...");
                Console.WriteLine($"EditUser roles contains Basic: {_editUser.Roles.ContainsKey("e8df7710-8d8d-41aa-94db-8b04248407e7")}");
                Console.WriteLine($"EditUser roles contains Admin: {_editUser.Roles.ContainsKey("3ccb1c2f-4571-4be4-8f54-753b886b94ac")}");
                Console.WriteLine($"EditUser roles contains SuperAdmin: {_editUser.Roles.ContainsKey("4a87fa22-f9b1-411a-9e2b-2896f44d5ade")}");
                Console.WriteLine($"EditUser roles contains Moderator: {_editUser.Roles.ContainsKey("b47c1af6-667d-44e7-8d80-dec1f322f600")}");

                if (!_editUser.Roles.ContainsKey("e8df7710-8d8d-41aa-94db-8b04248407e7"))
                    outputAddRoles.Roles.Add("e8df7710-8d8d-41aa-94db-8b04248407e7", "Basic");
                Console.WriteLine("Set Basic role to be added");

                if(_editUser.IsAdmin)
            {
                    outputRemoveRoles.Roles.Remove("3ccb1c2f-4571-4be4-8f54-753b886b94ac");
                    if (!_editUser.Roles.ContainsKey("3ccb1c2f-4571-4be4-8f54-753b886b94ac"))
                    {
                        outputAddRoles.Roles.Add("3ccb1c2f-4571-4be4-8f54-753b886b94ac", "Admin");
                        Console.WriteLine("Set Admin role to be added");
                    }
                    else
                    {
                        Console.WriteLine("Admin role already set in database");
                    }

                }
    else
                {
                    outputAddRoles.Roles.Remove("3ccb1c2f-4571-4be4-8f54-753b886b94ac");
                    if (_editUser.Roles.ContainsKey("3ccb1c2f-4571-4be4-8f54-753b886b94ac"))
                    {
                        outputRemoveRoles.Roles.Add("3ccb1c2f-4571-4be4-8f54-753b886b94ac", "Admin");
                        Console.WriteLine("Set Admin role to be removed");
                    }
                    else
                    {
                        Console.WriteLine("User not set to Admin in database");
                    }

                }

                if(_editUser.IsSuperAdmin)
            {
                    outputRemoveRoles.Roles.Remove("4a87fa22-f9b1-411a-9e2b-2896f44d5ade");
                    if (!_editUser.Roles.ContainsKey("4a87fa22-f9b1-411a-9e2b-2896f44d5ade"))
                    {
                        outputAddRoles.Roles.Add("4a87fa22-f9b1-411a-9e2b-2896f44d5ade", "SuperAdmin");
                        Console.WriteLine("Set SuperAdmin role to be added");
                    }
                    else
                    {
                        Console.WriteLine("SuperAdmin role already set in database");
                    }

                }
    else
                {
                    outputAddRoles.Roles.Remove("4a87fa22-f9b1-411a-9e2b-2896f44d5ade");
                    if (_editUser.Roles.ContainsKey("4a87fa22-f9b1-411a-9e2b-2896f44d5ade"))
                    {
                        outputRemoveRoles.Roles.Add("4a87fa22-f9b1-411a-9e2b-2896f44d5ade", "SuperAdmin");
                        Console.WriteLine("Set SuperAdmin role to be removed");
                    }
                    else
                    {
                        Console.WriteLine("User not set to SuperAdmin in database");
                    }

                }

                if(_editUser.IsModerator)
            {
                    outputRemoveRoles.Roles.Remove("b47c1af6-667d-44e7-8d80-dec1f322f600");
                    if (!_editUser.Roles.ContainsKey("b47c1af6-667d-44e7-8d80-dec1f322f600"))
                    {
                        outputAddRoles.Roles.Add("b47c1af6-667d-44e7-8d80-dec1f322f600", "Moderator");
                        Console.WriteLine("Set Moderator role to be removed");
                    }
                    else
                    {
                        Console.WriteLine("Moderator role already set in database");
                    }

                }
    else
                {
                    outputAddRoles.Roles.Remove("b47c1af6-667d-44e7-8d80-dec1f322f600");
                    if (_editUser.Roles.ContainsKey("b47c1af6-667d-44e7-8d80-dec1f322f600"))
                    {
                        outputRemoveRoles.Roles.Add("b47c1af6-667d-44e7-8d80-dec1f322f600", "Moderator");
                        Console.WriteLine("Set Moderator role to be removed");
                    }
                    else
                    {
                        Console.WriteLine("user not set to mod in db");
                    }

                }
                Console.WriteLine($"Roles to be added: {outputAddRoles.Roles.Count()}");
                Console.WriteLine($"Roles to be removed: {outputRemoveRoles.Roles.Count()}");
            }

            // calling  API
            // creating new user if needed

            await UpdateUser(outputUser);
            await UpdateUserRoles(outputAddRoles, outputRemoveRoles);

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


        private async Task UpdateUserRoles(UserRole userAddRole, UserRole userRemoveRole)
        {


            Console.WriteLine(">--------<");
            Console.WriteLine("Attempting to update roles.");
            infoMessage += Environment.NewLine + "Attempting to create new userroles..." + Environment.NewLine;
            await Task.Delay(3000);

            if (userAddRole.Roles is not null)
            {
                foreach (var role in userAddRole.Roles)
                {
                    Console.WriteLine($"Creating rolepair with User {userAddRole.Id} and role {role.Value} to be added.");

                    UserRolePairModel rolePair = new UserRolePairModel
                    {
                        UserId = userAddRole.Id,
                        RoleName = role.Value
                    };

                    using (HttpResponseMessage response = await Http.PostAsJsonAsync("https://localhost:44372/Api/_Admin/Users/AddRole", rolePair))
                    {
                        Console.WriteLine("Accessing databse to update role.");

                        if (response.IsSuccessStatusCode)
                        {
                            infoMessage += Environment.NewLine + "Succesfully added new role: " + role.Value.ToString() + Environment.NewLine;
                            Console.WriteLine("Successfully added role.");
                        }
                        else
                        {
                            infoMessage += Environment.NewLine + "something went wrong updating the userRoles. Error:" + response.ReasonPhrase;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No roles to add to the user");
            }

            if (userRemoveRole.Roles is not null)
            {
                foreach (var role in userRemoveRole.Roles)
                {
                    Console.WriteLine($"Creating rolepair with User {userRemoveRole.Id} and role {role.Value} to be removed.");
                    UserRolePairModel rolePair = new UserRolePairModel
                    {
                        UserId = userRemoveRole.Id,
                        RoleName = role.Value
                    };

                    using (HttpResponseMessage response = await Http.PostAsJsonAsync("https://localhost:44372/Api/_Admin/Users/RemoveRole", rolePair))
                    {
                        Console.WriteLine("Accessing databse to remove role.");

                        if (response.IsSuccessStatusCode)
                        {
                            infoMessage += Environment.NewLine + "Succesfully removed role. ";
                            Console.WriteLine("Successfully removed role.");
                        }
                        else
                        {
                            infoMessage += Environment.NewLine + "something went wrong updating the userRoles. Error:" + response.ReasonPhrase;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No roles to reomve from the user");
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

        //public virtual UserContactData ContactData { get; set; }
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
