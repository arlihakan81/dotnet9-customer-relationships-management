namespace CRM.Domain.ValueObjects
{
    public sealed class EmailAddress : IEquatable<EmailAddress>
    {
        public string Value { get; }
        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email address cannot be null or empty.", nameof(value));
            }
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email address format.", nameof(value));
            }
            Value = value;
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString() => Value;
        
        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);

        public bool Equals(EmailAddress? other)
        => other is not null && Value == other.Value;

        public override bool Equals(object? obj)
            => Equals(obj as EmailAddress);
    } 
}
