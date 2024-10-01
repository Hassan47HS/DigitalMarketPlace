using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UoNMarketPlace.Model
{
    public class User:IdentityUser
    {
        public Role Role { get; set; }
        public Gender Gender { get; set; }

    }
    public enum Role
    {
        Student,
        Faculty,
        staff,
        alumini,
        Admin
    }
    public enum Gender
    {
        Male,
        Female,
        other,
    }

}
