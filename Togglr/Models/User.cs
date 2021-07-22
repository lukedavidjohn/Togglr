using System;
using Togglr.Services;

namespace Togglr.Models
{
    public class User
    {
        // public User(string name, int id, bool isAdminUser)
        // {
        //     Name = name;
        //     Id = id;
        //     AuthToken = Guid.NewGuid().ToString();
        //     IsAdminUser = isAdminUser;
        // }
        public string Name { get; set; }
        public int Id { get; set; }
        public string AuthToken { get; set; }
        public bool IsAdminUser { get; set; }
    }
}