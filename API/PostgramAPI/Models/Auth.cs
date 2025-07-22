using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace PostgramAPI.Models;

public class Auth  : IdentityUser
{
    public int UserId { get; set; }
    public User User { get; set; }
}