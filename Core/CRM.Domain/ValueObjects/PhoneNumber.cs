using System.Text.RegularExpressions;

namespace CRM.Domain.ValueObjects
{
    public sealed class PhoneNumber : IEquatable<PhoneNumber>
    {
        public string Value { get; private set; }

        private PhoneNumber()
        {
            Value = string.Empty;
        }

        public PhoneNumber(string value)
        {
            if(IsEmpty(value))
                throw new Exception("Phone number can not be empty.");
            value = value.Replace(" ", "");
            if (!Regex.IsMatch(value, @"^\d{10,15}$"))
                throw new ArgumentException("Invalid phone number.");
            Value = value;
        }

        private bool IsEmpty(string value)
        {
            if (value == "" || value == " ")
                return true;
            return false;
        }

        public override string ToString() => Value ?? string.Empty;

        public bool Equals(PhoneNumber? other)
            => other is not null && Value == other.Value;

        public override bool Equals(object? obj)
            => Equals(obj as PhoneNumber);

        public override int GetHashCode()
            => Value.GetHashCode();
    }
}
