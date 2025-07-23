using System.ComponentModel.DataAnnotations;

namespace PostgramAPI.ValidationAttribute;

public class NoSpaceAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
   private readonly string _fieldName;

   public NoSpaceAttribute(string fieldName)
   {
      _fieldName = fieldName;
   }
   
   protected override ValidationResult IsValid(object value, ValidationContext validationContext)
   {
      if (value == null) return ValidationResult.Success;

      if (value.ToString().Contains(" "))
      {
         return new ValidationResult($"{_fieldName} cannot contain any spaces");
      }
      return ValidationResult.Success;
   }
}