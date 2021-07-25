// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Togglr.Models;
// using Togglr.Utilities;

// namespace Togglr.Services
// {
//     public class UserService
//     {
//         public static List<User> Users { get; set; }
//         public UserService(string path)
//         {
//             Users = new JsonLoaderFromFile<User>().LoadJson(path);
//         }

//         public static List<User> GetAll() => Users;

//         public static User Get(int id) => Users.FirstOrDefault(user => user.Id == id);
//         public static User GetByAuthToken(string authToken) => Users.FirstOrDefault(user => user.AuthToken == authToken);
//         public static int GetCount() => Users.Count;

//         // public static void Post()
//         // {
//         // }

//         public static void Delete(int id)
//         {
//             var user = Get(id);
//             if(user is null)
//                 return;

//             Users.Remove(user);
//         }
//     }
// }