using PostgramAPI.ValidationAttribute;

namespace PostgramAPI.DTOs;

public class CreateAuthRequest
{
    [NotEqualTo("username","mali")] 
    [NoSpace("username")]
    public string UserName { get; set; }
    public string Password { get; set; }
}