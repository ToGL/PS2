using System.Text.RegularExpressions;

namespace PS2.Validators
{
    public interface IStringValidator
    {
        bool Validate(string str);
    }
    public class StringValidator: IStringValidator
    {
        public bool Validate(string str)
        {
            return Regex.IsMatch(str, "^[a-zA-Z0-9!@#$&*{}\\/()_-]*$");
        }
    }
}
