using System.ComponentModel.DataAnnotations;

namespace PostgramAPI.ValidationAttribute;

public class NotContainingAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    private readonly string _fieldname;
    private readonly string[] _values;


    public NotContainingAttribute(string fieldname, string[] values)
    {
        _fieldname = fieldname;
        _values = values;
    }


    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        foreach (var word in _values)
        {
            if (value.ToString().Contains(word))
            {
                return new ValidationResult($"{_fieldname} cannot contain the word {word}");
            }
        }


        return ValidationResult.Success;
    }
}