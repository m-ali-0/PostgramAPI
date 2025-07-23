using System.ComponentModel.DataAnnotations;

namespace PostgramAPI.DTOs;

public class UpdateUserRequest
{
    [MaxLength(20)] public string? DisplayName { get; set; }
    [MaxLength(50)] public string? Bio { get; set; }
    public string? ProfilePic { get; set; }
    [Range(13, 100)] public int? Age { get; set; }
}