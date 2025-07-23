using System.ComponentModel.DataAnnotations;

namespace PostgramAPI.ValidationAttribute;

public class NotEqualToAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    private readonly string _value;
    private readonly string _fieldName;

    public NotEqualToAttribute(string fieldName, string value)
    {
        _value = value;
        _fieldName = fieldName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        if (value.ToString() == _value)
        {
            return new ValidationResult($"{_fieldName} cannot be equal to {_value}");
        }

        return ValidationResult.Success;
    }
}