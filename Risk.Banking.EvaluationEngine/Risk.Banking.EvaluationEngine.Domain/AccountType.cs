namespace Risk.Banking.EvaluationEngine.Domain
{
    public class AccountType : IEquatable<AccountType>
    {
        public static readonly AccountType Standard = new AccountType(1, "Standard");

        public static readonly AccountType Student = new AccountType(2, "Student");

        public static readonly AccountType Graduate = new AccountType(3, "Graduate");

        private AccountType(int value, string description)
        {
            Value = value;
            Description = description;
        }

        public int Value { get; }

        public string Description { get; }

        public static AccountType FromSnapshot(Definitions.AccountType accountType)
        {
            if (accountType == Definitions.AccountType.Standard)
                return Standard;

            if (accountType == Definitions.AccountType.Student)
                return Student;

            if (accountType == Definitions.AccountType.Graduate)
                return Graduate;

            throw new ArgumentException("Not Valid");
        }

        public Definitions.AccountType ToSnapshot()
        {
            if (this == Standard)
                return Definitions.AccountType.Standard;

            if (this == Student)
                return Definitions.AccountType.Student;

            if (this == Graduate)
                return Definitions.AccountType.Graduate;

            throw new ArgumentException("Not Valid");
        }

        public bool CanUpgradeToStandard()
        {
            return this == Graduate || this == Student;
        }

        public bool UpgradeToGraduate()
        {
            return this == Student;
        }

        public bool Equals(AccountType? other)
        {
            return other.Value == Value;
        }
    }
}
