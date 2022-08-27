using System.ComponentModel.DataAnnotations;

namespace JidelakCms.Validators;

public class TitleValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value != null && value.ToString().Contains("Kč"))
        {
            return false;
        }

        return true;
    }
}